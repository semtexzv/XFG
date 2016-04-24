using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFG.Platform
{
    public interface IFiles
    {
        bool Exists(string filename, FileType type);
        IFileHandle Open(string filename, FileType type);
    }
}
