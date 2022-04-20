using System;
using System.IO;
using Xunit;

namespace AlinSpace.ProjectManipulator.Tests.Test05
{
    /// <summary>
    /// Update dependency.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Perform()
        {
            var project = Project.Open("Test05/Input.txt");
            project.AddOrUpdateDependency("AutoMapper", new Version(7, 8, 9));
            project.Save();

            Assert.Equal(
                expected: File.ReadAllText("Test05/Expected.txt"),
                actual: File.ReadAllText("Test05/Input.txt"));
        }
    }
}