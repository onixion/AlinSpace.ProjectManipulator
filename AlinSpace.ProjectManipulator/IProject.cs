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

        #region Authors

        string Authors { get; set; }

        #endregion

        #region Copyright

        string Copyright { get; set; }

        #endregion

        #region PackageProjectUrl

        Uri PackageProjectUrl { get; set; }

        #endregion

        #region RepositoryUrl

        Uri RepositoryUrl { get; set; }

        #endregion

        #region PackageTags

        string PackageTags { get; set; }

        #endregion

        void Save();
    }
}