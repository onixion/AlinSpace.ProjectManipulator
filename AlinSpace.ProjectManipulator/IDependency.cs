using System;

namespace AlinSpace.ProjectManipulator
{
    public interface IDependency
    {
        public string Name { get; set; }

        public Version Version { get; set; }

        void Remove();
    }
}
