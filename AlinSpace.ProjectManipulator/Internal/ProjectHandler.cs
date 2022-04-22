using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace AlinSpace.ProjectManipulator
{
    internal class ProjectHandler : IProject
    {
        private XmlDocument document;

        private XmlNode projectNode;
        private XmlNode propertyGroupNode;

        private XmlNode versionNode;
        private XmlNode generatePackageOnBuildNode;

        public ProjectHandler(string pathToProjectFile)
        {
            PathToProjectFile = AbsolutePath.Get(pathToProjectFile);
            Name = Path.GetFileNameWithoutExtension(pathToProjectFile);
            document = new XmlDocument();
        }

        public static IProject Open(string pathToProjectFile)
        {
            var project = new ProjectHandler(pathToProjectFile);
            project.Init();

            return project;
        }

        private void Init()
        {
            document.Load(PathToProjectFile);

            projectNode = document.SelectSingleNode("/Project");
            propertyGroupNode = projectNode.SelectSingleNode("PropertyGroup");

            #region Version

            versionNode = propertyGroupNode.SelectSingleNode("Version");
            if (versionNode != null)
            {
                Version = Version.Parse(versionNode.InnerText);
            }

            #endregion

            #region GeneratePackageOnBuild

            generatePackageOnBuildNode = propertyGroupNode.SelectSingleNode("GeneratePackageOnBuild");
            if (generatePackageOnBuildNode != null)
            {
                GeneratePackageOnBuild = Convert.ToBoolean(generatePackageOnBuildNode.InnerText);
            }

            #endregion
        }

        public string PathToProjectFile { get; private set; }

        public string Name { get; private set; }

        public ProjectType Type { get; private set; }

        public bool? GeneratePackageOnBuild
        {
            get => generatePackageOnBuild;
            set
            {
                if (value == null)
                {
                    var node = propertyGroupNode
                        .GetNodes()
                        .FirstOrDefault(x => x.Name == "GeneratePackageOnBuild");

                    if (node != null)
                    {
                        propertyGroupNode.RemoveChild(node);
                    }

                    return;
                }
                else
                {
                    if (generatePackageOnBuildNode == null)
                    {
                        generatePackageOnBuildNode = document.CreateElement("GeneratePackageOnBuild");
                        propertyGroupNode.AppendChild(generatePackageOnBuildNode);
                    }

                    generatePackageOnBuildNode.InnerText = value.Value ? "true" : "false";
                    generatePackageOnBuild = value.Value;
                }
            }
        }
        bool generatePackageOnBuild;

        #region Version

        public Version Version
        {
            get => version;
            set
            {
                if (value == null)
                {
                    var node = propertyGroupNode
                        .GetNodes()
                        .FirstOrDefault(x => x.Name == "Version");

                    if (node != null)
                    {
                        propertyGroupNode.RemoveChild(node);
                    }

                    return;
                }
                else
                {
                    if (versionNode == null)
                    {
                        versionNode = document.CreateElement("Version");
                        propertyGroupNode.AppendChild(versionNode);
                    }

                    versionNode.InnerText = value?.ToString();
                    version = value;
                }
            }
        }
        private Version version;

        void CheckSetVersion()
        {
            if (Version == null)
            {
                Version = new Version(0, 0, 0);
            }
        }

        public IProject VersionIncrementMajor()
        {
            CheckSetVersion();

            Version = new Version(
                Version.Major + 1,
                Version.Minor,
                Version.Build);

            WriteVersion();

            return this;
        }

        public IProject VersionIncrementMinor()
        {
            CheckSetVersion();

            Version = new Version(
                Version.Major,
                Version.Minor + 1,
                Version.Build);

            WriteVersion();

            return this;
        }

        public IProject VersionIncrementBuild()
        {
            CheckSetVersion();

            Version = new Version(
                Version.Major,
                Version.Minor,
                Version.Build + 1);

            WriteVersion();
            
            return this;
        }

        void WriteVersion()
        {
            if (versionNode == null)
            {
                versionNode = document.CreateElement("Version");
                propertyGroupNode.AppendChild(versionNode);
            }

            versionNode.InnerText = Version.ToString();
        }

        #endregion

        #region Dependencies

        public IProject AddOrUpdateDependency(string name, Version version)
        {
            var dependency = this
                .GetDependencies()
                .FirstOrDefault(x => x.Name == name);

            if (dependency != null)
            {
                dependency.Version = version;
            }
            else
            {
                var itemGroup = projectNode
                    .GetNodes()
                    .FirstOrDefault(x => x.Name == "ItemGroup");

                if (itemGroup == null)
                {
                    itemGroup = document.CreateElement("ItemGroup");
                    projectNode.AppendChild(itemGroup);
                }

                var packageReferenceNode = document.CreateElement("PackageReference");
                itemGroup.AppendChild(packageReferenceNode);

                #region Include

                var includeAttribute = document.CreateAttribute("Include");
                includeAttribute.Value = name;

                packageReferenceNode.Attributes.Append(includeAttribute);

                #endregion

                #region Version

                var versionAttribute = document.CreateAttribute("Version");
                versionAttribute.Value = version.ToString();

                packageReferenceNode.Attributes.Append(versionAttribute);

                #endregion
            }

            return this;
        }

        public IEnumerable<IDependency> GetDependencies()
        {
            foreach (var itemGroupNode in projectNode.GetNodes("ItemGroup"))
            {
                foreach(var packageReferenceNode in itemGroupNode.GetNodes("PackageReference"))
                {
                    yield return new DependencyHandler(itemGroupNode, packageReferenceNode);
                }
            }
        }

        public IProject SetDependency(string name, Version version)
        {
            var dependency = this
                .GetDependencies()
                .FirstOrDefault(x => x.Name == name);

            if (dependency != null)
            {
                dependency.Version = version;
            }
            else
            {
                // todo
            }

            return this;
        }

        #endregion

        public void Save()
        {
            document.Save(PathToProjectFile);
        }
    }
}
