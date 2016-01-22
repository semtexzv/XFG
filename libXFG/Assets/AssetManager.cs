using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFG.Assets
{
    public static class AssetManager
    {
        private static Dictionary<Type, AssetLoader> loaders;
        static AssetManager()
        {
            loaders = new Dictionary<Type, AssetLoader>();
        }
        
    }
}
