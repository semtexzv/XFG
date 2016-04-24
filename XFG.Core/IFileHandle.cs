using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XFG
{
    public interface IFileHandle
    {
        string Filename { get; }
        Stream Reader { get; }
        Stream Writer { get; }
    }
}
