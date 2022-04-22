using System.IO;
using System.Linq;
using Xunit;

namespace AlinSpace.ProjectManipulator.Projects.Tests.Test03
{
    /// <summary>
    /// Remove dependency.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Perform()
        {
            var project = Project.Open("Projects/Test03/Input.txt");
            var dependencies = project.GetDependencies();
            dependencies.First().Remove();
            project.Save();

            Assert.Equal(
                expected: File.ReadAllText("Projects/Test03/Expected.txt"),
                actual: File.ReadAllText("Projects/Test03/Input.txt"));
        }
    }
}