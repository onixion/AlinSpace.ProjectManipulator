namespace AlinSpace.ProjectManipulator
{
    public class ProjectLink : IProjectLink
    {
        public string Name { get; }

        public string PathToProjectFile { get; }

        public ProjectLink(
            string name,
            string pathToProjectFile)
        {
            Name = name;
            PathToProjectFile = pathToProjectFile;
        }
    }
}
