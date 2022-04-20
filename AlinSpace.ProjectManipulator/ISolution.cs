namespace AlinSpace.ProjectManipulator
{
    public interface ISolution
    {
        string Name { get; }

        IEnumerable<IProjectLink> GetProjects();
    }
}
