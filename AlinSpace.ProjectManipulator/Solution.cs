namespace AlinSpace.ProjectManipulator
{
    public static class Solution
    {
        public static ISolution Read(string pathToFile)
        {
            return SolutionHandler.Read(pathToFile);
        }
    }
}
