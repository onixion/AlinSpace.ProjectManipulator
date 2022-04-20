using System.Xml;

namespace AlinSpace.ProjectManipulator
{
    internal class SolutionHandler : ISolution
    {
        private readonly XmlDocument document;

        public string Name { get; }

        private SolutionHandler(string pathToFile)
        {
            document = new XmlDocument();
            document.LoadXml(pathToFile);
        }

        private void Init()
        {

        }

        public static ISolution Open(string pathToFile)
        {
            var solution = new SolutionHandler(pathToFile);
            solution.Init();

            return solution;
        }

        public IEnumerable<IProjectLink> GetProjects()
        {
            throw new NotImplementedException();
        }
    }
}
