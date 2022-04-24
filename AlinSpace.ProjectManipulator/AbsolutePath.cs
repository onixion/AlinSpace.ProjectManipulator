using System;
using System.IO;

namespace AlinSpace.ProjectManipulator
{
    /// <summary>
    /// Represents the absolute path helper.
    /// </summary>
    public static class AbsolutePath
    {
        /// <summary>
        /// Gets the absolute path.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <returns>Absolute path.</returns>
        public static string Get(string path)
        {
            if (path == null)
                return null;

            if (Path.IsPathRooted(path))
                return path;

            return Path.Combine(Environment.CurrentDirectory, path);
        }
    }
}
