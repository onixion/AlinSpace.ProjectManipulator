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

        IProject SetDependencyVersion(string dependency, Version version);

        Version GetDependencyVersion(string dependency);

        void Save();
    }
}