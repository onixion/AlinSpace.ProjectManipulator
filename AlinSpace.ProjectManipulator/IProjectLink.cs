namespace AlinSpace.ProjectManipulator
{
    public interface IProjectLink
    {
        string Name { get; }

        string PathToProjectFile { get; }
    }
}