using System;
using System.IO;
using Xunit;

namespace AlinSpace.ProjectManipulator.Projects.Tests.Test04
{
    /// <summary>
    /// Add dependency to project.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Perform()
        {
            var project = Project.Open("Projects/Test04/Input.txt");
            project.AddOrUpdateDependency("AutoMapper", new Version(3, 4, 5));
            project.Save();

            Assert.Equal(
                expected: File.ReadAllText("Projects/Test04/Expected.txt"),
                actual: File.ReadAllText("Projects/Test04/Input.txt"));
        }
    }
}