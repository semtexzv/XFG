using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFG.Platform;
using Android.Content.Res;

namespace XFG
{
    public class AndroidFileHandle : IFileHandle
    {
        private AssetManager assets;
        private string filename;
        public AndroidFileHandle(string name, AssetManager assets)
        {
            this.filename = name;
            this.assets = assets;
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
               return  assets.Open(filename);
               
            }
        }

        public Stream Writer
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
    class AndroidFiles : IFiles
    {
        private AssetManager assets;
        public AndroidFiles(Activity act)
        {
            this.assets = act.Assets;
        }
        bool IFiles.Exists(string filename, FileType type)
        {
            throw new NotImplementedException();
        }

        IFileHandle IFiles.Open(string filename, FileType type)
        {
            return new AndroidFileHandle(filename, assets);
            
        }
    }
}