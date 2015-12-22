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
            XFG.Logger.OnMessage += (a, b) => { Console.WriteLine(a); };
            XFG.XFG.Init(conf, new TestAppListener());
        }
    }
}
