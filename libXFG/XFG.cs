using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFG
{
    public static class XFG
    {
        public static void Init(AppConfig conf, AppListener listener)
        {
            Config.Init();
            //Should initialize library, platform stuff, create window with config and activate listener inside
        }
    }
}
