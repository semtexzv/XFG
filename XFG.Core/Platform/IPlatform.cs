using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFG.Platform;

namespace XFG.Platform
{
  
   public interface IPlatform
    {
        IAudio Audio { get; }
        IDisplay Display { get; }
        IInput Input { get; }
    }
}
