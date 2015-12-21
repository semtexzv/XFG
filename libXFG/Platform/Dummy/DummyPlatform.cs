using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFG.Platform.Dummy
{
    class DummyPlatform : IPlatform
    {
        public void Init(AppConfig config, AppListener app)
        {
            throw new NotImplementedException();
        }

        public IAudio Audio
        {
            get { throw new NotImplementedException(); }
        }

        public IDisplay Display
        {
            get { throw new NotImplementedException(); }
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
