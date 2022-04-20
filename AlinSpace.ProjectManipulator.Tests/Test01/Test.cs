using System;
using System.IO;
using Xunit;

namespace AlinSpace.ProjectManipulator.Tests.Test01
{
    /// <summary>
    /// Sets version.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Perform()
        {
            var project = Project.Open("Test01/Input.txt");
            project.Version = new Version(1, 2, 3);
            project.Save();

            Assert.Equal(
                expected: File.ReadAllText("Test01/Expected.txt"),
                actual: File.ReadAllText("Test01/Input.txt"));
        }
    }
}