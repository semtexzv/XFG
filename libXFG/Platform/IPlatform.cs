using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFG.Platform;

namespace XFG.Platform
{
  
    interface IPlatform
    {
        void Init(AppConfig config, AppListener app);
      
        IAudio Audio { get; }
        IDisplay Display { get; }
        /// <summary>
        /// 
        /// </summary>
        void Run();
    }
}
