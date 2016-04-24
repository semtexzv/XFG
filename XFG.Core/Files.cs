using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFG.Platform;

namespace XFG
{
    public enum FileType
    {
        Internal,
        External
    }
    public static class Files
    {
        private static IFiles Platform;
        public static void SetPlatform(IFiles files)
        {
            Platform = files;
        }

        public static bool Exists(string filename, FileType type = FileType.Internal)
        {
            return Platform.Exists(filename, type);
        }
        public static IFileHandle Open(string filename, FileType type)
        {
            return Platform.Open(filename, type);
        }
        public static IFileHandle Internal(string filename)
        {
            return Open(filename, FileType.Internal);
        }
        public static IFileHandle External(string filename)
        {
            return Open(filename, FileType.External);
        }
    }
}
