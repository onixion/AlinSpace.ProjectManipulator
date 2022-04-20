namespace AlinSpace.ProjectManipulator
{
    public interface IProject
    {
        public string Name { get; }

        public ProjectType Type { get; }

        bool GeneratePackageOnBuild { get; set; }

        public Version Version { get; set; }

        IProject VersionIncrementMajor();
        
        IProject VersionIncrementMinor();

        IProject VersionIncrementBuild();

        IEnumerable<IDependency> GetDependencies();

        IProject SetDependency(string name, Version version);

        void Save();
    }
}