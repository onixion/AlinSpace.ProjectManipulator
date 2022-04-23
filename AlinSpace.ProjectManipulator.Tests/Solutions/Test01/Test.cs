using System.IO;
using System.Linq;
using Xunit;

namespace AlinSpace.ProjectManipulator.Solutions.Tests.Test01
{
    /// <summary>
    /// Sets version.
    /// </summary>
    public class Test
    {
        [Fact]
        public void Perform()
        {
            var solution = Solution.Read("Solutions/Test01/Input.txt");

            Assert.Equal(
                expected: 3,
                actual: solution.Projects.Count());

            var project = solution.Projects.First();

            Assert.Equal(
                expected: "AlinSpace.ProjectManipulator",
                actual: project.Name);
        }
    }
}