namespace AlinSpace.ProjectManipulator
{
    public static class Project
    {
        public static IProject Open(string pathToProjectFile)
        {
            return ProjectHandler.Open(pathToProjectFile);
        }
    }
}
