using System.Xml;

namespace AlinSpace.DotNetProject
{
    internal class ProjectHandler : IProject
    {
        private string file;
        private XmlDocument document;

        private XmlNode projectNode;
        private XmlNode propertyGroupNode;

        private XmlNode versionNode;
        private XmlNode generatePackageOnBuildNode;

        public static IProject Open(string file)
        {
            var project = new ProjectHandler();

            var document = new XmlDocument();
            
            project.file = file;
            project.document = document;

            project.Init();

            return project;
        }

        private void Init()
        {
            Name = Path.GetFileNameWithoutExtension(file);

            document.Load(file);

            projectNode = document.SelectSingleNode("/Project");
            propertyGroupNode = projectNode.SelectSingleNode("PropertyGroup");

            #region Version

            versionNode = propertyGroupNode.SelectSingleNode("Version");
            if (versionNode == null)
            {
                versionNode = document.CreateElement("Version");
                versionNode.InnerText = new Version(0, 0, 0).ToString();
            
                propertyGroupNode.AppendChild(versionNode);
            }

            Version = Version.Parse(versionNode.InnerText);

            #endregion

            #region GeneratePackageOnBuild

            generatePackageOnBuildNode = propertyGroupNode.SelectSingleNode("GeneratePackageOnBuild");
            if (generatePackageOnBuildNode == null)
            {
                generatePackageOnBuildNode = document.CreateElement("GeneratePackageOnBuild");
                generatePackageOnBuildNode.InnerText = "false";

                propertyGroupNode.AppendChild(generatePackageOnBuildNode);
            }

            GeneratePackageOnBuild = Convert.ToBoolean(generatePackageOnBuildNode.InnerText);

            #endregion
        }

        public string Name { get; private set; }

        public ProjectType Type { get; private set; }

        public bool GeneratePackageOnBuild { get; set; }

        #region Version

        public Version Version { get; set; }

        public IProject VersionIncrementMajor()
        {
            Version = new Version(
                Version.Major + 1,
                Version.Minor,
                Version.Build);

            WriteVersion();

            return this;
        }

        public IProject VersionIncrementMinor()
        {
            Version = new Version(
                Version.Major,
                Version.Minor + 1,
                Version.Build);

            WriteVersion();

            return this;
        }

        public IProject VersionIncrementBuild()
        {
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

        public IProject SetDependencyVersion(string dependency, Version version)
        {
            foreach(var node in projectNode.GetNodes("ItemGroup/PackageReference"))
            {
                var includeAttribute = node
                    .GetAttributes()
                    .FirstOrDefault(x => x.Name == "Include" && x.Value == dependency);

                if (includeAttribute == null)
                    continue;

                var versionAttribute = node
                     .GetAttributes()
                     .FirstOrDefault(x => x.Name == "Version");

                if (versionAttribute == null)
                    continue;

                //var parsedVersion = Version.Parse(versionAttribute.Value);

                versionAttribute.Value = version.ToString();
                break;
            }

            return this;
        }

        public Version GetDependencyVersion(string dependency)
        {
            foreach (var node in projectNode.GetNodes("ItemGroup/PackageReference"))
            {
                var includeAttribute = node
                    .GetAttributes()
                    .FirstOrDefault(x => x.Name == "Include" && x.Value == dependency);

                if (includeAttribute == null)
                    continue;

                var versionAttribute = node
                     .GetAttributes()
                     .FirstOrDefault(x => x.Name == "Version");

                if (versionAttribute == null)
                    continue;

                return Version.Parse(versionAttribute.Value);
            }

            return null;
        }

        #endregion

        public void Save()
        {
            versionNode.InnerText = Version.ToString();
            generatePackageOnBuildNode.InnerText = GeneratePackageOnBuild ? "true" : "false";

            document.Save(file);
        }
    }
}
