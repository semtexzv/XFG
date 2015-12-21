using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFG.Backend
{
    interface IWindow
    {
        
        string Title { get; set; }
        bool Visible { get; set; }
        bool Fullscreen { get; set; }
    }
}
