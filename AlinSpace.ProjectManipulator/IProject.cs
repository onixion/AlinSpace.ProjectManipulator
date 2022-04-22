using System;
using System.Collections.Generic;

namespace AlinSpace.ProjectManipulator
{
    public interface IProject
    {
        string PathToProjectFile { get; }

        string Name { get; }

        ProjectType Type { get; }

        bool? GeneratePackageOnBuild { get; set; }

        #region Version

        Version Version { get; set; }

        IProject VersionIncrementMajor();
        
        IProject VersionIncrementMinor();

        IProject VersionIncrementBuild();

        #endregion

        #region Dependencies

        IProject AddOrUpdateDependency(string name, Version version);

        IEnumerable<IDependency> GetDependencies();
        
        #endregion

        void Save();
    }
}