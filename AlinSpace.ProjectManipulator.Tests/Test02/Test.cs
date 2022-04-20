using System;
using System.IO;
using System.Linq;
using Xunit;

namespace AlinSpace.ProjectManipulator.Tests.Test02
{
    /// <summary>
    /// Sets version of dependency.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Perform()
        {
            var project = Project.Open("Test02/Input.txt");
            var dependencies = project.GetDependencies();
            dependencies.First().Version = new Version(5, 6, 7);
            project.Save();

            Assert.Equal(
                expected: File.ReadAllText("Test02/Expected.txt"),
                actual: File.ReadAllText("Test02/Input.txt"));
        }
    }
}