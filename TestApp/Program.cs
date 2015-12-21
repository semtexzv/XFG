using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            XFG.AppConfig conf = new XFG.AppConfig();
            conf.Title = "TITLE";
            
            conf.Width = 500;
            conf.Height = 500;
            XFG.XFG.Init(conf, new TestAppListener());
        }
    }
}
