using System;
using Xunit;

namespace AlinSpace.ProjectManipulator.Tests.Test01
{
    public class Test
    {
        [Fact]
        public void Perform()
        {
            var project = Project.Open("Test01/Input.txt");

            project.SetDependencyVersion("Polly", new Version(5, 6, 7));

            project.Save();

            project = Project.Open("Test01/Input.txt");
            var version = project.GetDependencyVersion("Polly");

            Assert.Equal(5, version.Major);
            Assert.Equal(6, version.Minor);
            Assert.Equal(7, version.Build);
        }
    }
}