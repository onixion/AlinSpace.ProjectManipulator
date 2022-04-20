using System.Xml;

namespace AlinSpace.ProjectManipulator
{
    internal class DependencyHandler : IDependency
    {
        private readonly XmlNode parentNode;
        private readonly XmlNode dependencyNode;
        private readonly XmlAttribute includeAttribute;
        private readonly XmlAttribute versionAttribute;

        private bool removed;

        public DependencyHandler(
            XmlNode parentNode,
            XmlNode dependencyNode)
        {
            this.parentNode = parentNode;
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

        void ThrowIfRemoved()
        {
            if (removed)
                throw new InvalidOperationException("Dependency has been removed.");
        }

        public string Name
        {
            get
            {
                ThrowIfRemoved();
                return name;
            }
            set
            {
                ThrowIfRemoved();
                includeAttribute.Value = value;
                name = value;
            }
        }
        private string name;

        public Version Version
        {
            get
            {
                ThrowIfRemoved();
                return version;
            }
            set
            {
                ThrowIfRemoved();
                versionAttribute.Value = value?.ToString();
                version = value;
            }
        }
        private Version version;

        public void Remove()
        {
            ThrowIfRemoved();

            parentNode.RemoveChild(dependencyNode);
        
            if (parentNode.ChildNodes.Count == 0)
            {
                parentNode.ParentNode.RemoveChild(parentNode);
            }

            removed = true;
        }
    }
}
