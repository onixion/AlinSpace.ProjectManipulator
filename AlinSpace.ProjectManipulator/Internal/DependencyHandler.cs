using System.Xml;

namespace AlinSpace.ProjectManipulator
{
    internal class DependencyHandler : IDependency
    {
        private readonly XmlNode dependencyNode;
        private readonly XmlAttribute includeAttribute;
        private readonly XmlAttribute versionAttribute;

        public DependencyHandler(XmlNode dependencyNode)
        {
            this.dependencyNode = dependencyNode;

            includeAttribute = dependencyNode
                .GetAttributes()
                .FirstOrDefault(x => x.Name == "Include");

            name = includeAttribute.Value;

            versionAttribute = dependencyNode
                .GetAttributes()
                .FirstOrDefault(x => x.Name == "Version");

            version = Version.Parse(versionAttribute.InnerText);
        }

        public string Name
        {
            get => name;
            set
            {
                includeAttribute.Value = value;
                name = value;
            }
        }
        private string name;

        public Version Version
        {
            get => version;
            set
            {
                versionAttribute.Value = value?.ToString();
                version = value;
            }
        }
        private Version version;
    }
}
