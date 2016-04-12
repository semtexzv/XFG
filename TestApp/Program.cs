using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            XFG.AppConfig conf = new XFG.AppConfig();
            conf.DisplayFormat = DisplayFormat.RGBA8888;
            conf.Title = "TITLE";
            
            conf.Width = 500;
            conf.Height = 500;
            XFG.Logger.OnMessage += (a, b) => { Console.WriteLine(a); };
            XFG.Desktop.Init(conf);
            XFG.Desktop.Run(new TestAppListener());
        }
    }
}
