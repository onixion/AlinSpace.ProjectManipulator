using System;
using System.IO;
using Xunit;

namespace AlinSpace.ProjectManipulator.Projects.Tests.Test05
{
    /// <summary>
    /// Update dependency version of project.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Perform()
        {
            var project = Project.Open("Projects/Test05/Input.txt");
            project.AddOrUpdateDependency("AutoMapper", new Version(7, 8, 9));
            project.Save();

            Assert.Equal(
                expected: File.ReadAllText("Projects/Test05/Expected.txt"),
                actual: File.ReadAllText("Projects/Test05/Input.txt"));
        }
    }
}