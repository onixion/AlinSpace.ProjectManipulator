using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace AlinSpace.ProjectManipulator
{
    internal class SolutionHandler : ISolution
    {
        public string PathToSolutionFile { get; }

        public string Name { get; }

        public IEnumerable<IProjectLink> Projects => projects;
        private ReadOnlyCollection<IProjectLink> projects;

        private SolutionHandler(string pathToSolutionFile)
        {
            PathToSolutionFile = pathToSolutionFile;
            Name = Path.GetFileNameWithoutExtension(pathToSolutionFile);
        }

        private void Init()
        {
            var lines = File.ReadAllLines(PathToSolutionFile);

            // example:
            //Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "TestProject", "TestProject/TestProject.csproj", "{281B1AA4-3402-464A-BDC2-6D28729212FF}"
            var regex = new Regex("^Project\\(\".*\"\\) = \"(.*)\", \"(.*)\", \".*\"$");

            var tempProjects = new List<IProjectLink>();

            foreach (var line in lines)
            {
                var match = regex.Match(line);

                if(match.Success)
                {
                    var groups = match.Groups;

                    var projectName = match.Groups[1].Value;
                    var pathToProjectFile = match.Groups[2].Value;

                    tempProjects.Add(new ProjectLink(projectName, pathToProjectFile));
                }
            }

            projects = new ReadOnlyCollection<IProjectLink>(tempProjects);
        }

        public static ISolution Read(string pathToFile)
        {
            var solution = new SolutionHandler(pathToFile);
            solution.Init();

            return solution;
        }
    }
}
