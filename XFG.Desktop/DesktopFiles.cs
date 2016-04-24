using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG.Platform;

namespace XFG
{
    public class DesktopFileHandle : IFileHandle
    {
        private string filename;
        public DesktopFileHandle(string name)
        {
            this.filename = name;
        }
        public string Filename
        {
            get
            {
                return filename;
            }
        }

        public Stream Reader
        {
            get
            {
                return File.OpenRead(filename);
            }
        }

        public Stream Writer
        {
            get
            {
                return File.OpenWrite(filename);
            }
        }
    }
    public class DesktopFiles : IFiles
    {
        bool IFiles.Exists(string filename, FileType type)
        {
            return File.Exists("./Assets/"+filename);
        }

        IFileHandle IFiles.Open(string filename, FileType type)
        {
            if(type == FileType.Internal)
            {
                return new DesktopFileHandle("./Assets/" + filename);
            }
            throw new InvalidOperationException("unsupported");
        }
    }
}
