using System.Linq;
using Xunit;

namespace AlinSpace.ProjectManipulator.Solutions.Tests.Test01
{
    /// <summary>
    /// Enumerates through projects of solution. 
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

            Assert.Equal(
                expected: "AlinSpace.ProjectManipulator",
                actual: solution.Projects.First().Name);

            Assert.Equal(
                expected: "TestProject",
                actual: solution.Projects.Skip(1).First().Name);

            Assert.Equal(
                expected: "AlinSpace.ProjectManipulator.Tests",
                actual: solution.Projects.Skip(2).First().Name);
        }
    }
}