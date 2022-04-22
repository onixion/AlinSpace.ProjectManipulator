using System.Collections.Generic;

namespace AlinSpace.ProjectManipulator
{
    public interface ISolution
    {
        string Name { get; }

        IEnumerable<IProjectLink> Projects { get; }
    }
}
