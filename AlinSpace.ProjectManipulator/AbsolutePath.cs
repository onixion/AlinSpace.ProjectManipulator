using System;
using System.IO;

namespace AlinSpace.ProjectManipulator
{
    public static class AbsolutePath
    {
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
