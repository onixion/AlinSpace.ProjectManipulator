using System;
using System.IO;
using Xunit;

namespace AlinSpace.ProjectManipulator.Tests.Test04
{
    /// <summary>
    /// Add dependency.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Perform()
        {
            var project = Project.Open("Test04/Input.txt");
            project.AddOrUpdateDependency("AutoMapper", new Version(3, 4, 5));
            project.Save();

            Assert.Equal(
                expected: File.ReadAllText("Test04/Expected.txt"),
                actual: File.ReadAllText("Test04/Input.txt"));
        }
    }
}