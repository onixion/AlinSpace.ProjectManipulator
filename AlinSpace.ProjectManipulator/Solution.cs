namespace AlinSpace.ProjectManipulator
{
    public static class Solution
    {
        public static ISolution Open(string pathToFile)
        {
            return SolutionHandler.Open(pathToFile);
        }
    }
}
