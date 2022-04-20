using System.IO;
using System.Linq;
using Xunit;

namespace AlinSpace.ProjectManipulator.Tests.Test03
{
    /// <summary>
    /// Remove dependency.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Perform()
        {
            var project = Project.Open("Test03/Input.txt");
            var dependencies = project.GetDependencies();
            dependencies.First().Remove();
            project.Save();

            Assert.Equal(
                expected: File.ReadAllText("Test03/Expected.txt"),
                actual: File.ReadAllText("Test03/Input.txt"));
        }
    }
}