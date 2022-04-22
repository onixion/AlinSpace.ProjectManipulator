using System;
using System.IO;
using Xunit;

namespace AlinSpace.ProjectManipulator.Projects.Tests.Test01
{
    /// <summary>
    /// Sets version.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Perform()
        {
            var project = Project.Open("Projects/Test01/Input.txt");
            project.Version = new Version(1, 2, 3);
            project.Save();

            Assert.Equal(
                expected: File.ReadAllText("Projects/Test01/Expected.txt"),
                actual: File.ReadAllText("Projects/Test01/Input.txt"));
        }
    }
}