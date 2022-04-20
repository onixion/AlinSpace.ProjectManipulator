namespace AlinSpace.DotNetProject
{
    public static class Project
    {
        public static IProject Open(string path)
        {
            return ProjectHandler.Open(path);
        }
    }
}
