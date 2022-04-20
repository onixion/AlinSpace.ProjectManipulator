namespace AlinSpace.ProjectManipulator
{
    public static class Project
    {
        public static IProject Open(string path)
        {
            return ProjectHandler.Open(path);
        }
    }
}
