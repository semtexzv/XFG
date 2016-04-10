using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Gfx.Loaders
{
    public interface TextureLoader
    {

        /// <summary>
        /// Create new instance of this loader, use provided filename in next call to Load()
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        TextureLoader Create(string filename);
        /// <summary>
        /// Can this loader load filename ? 
        /// This method behaves as static ( Its result does not depend on instance from which it is called)
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        bool CanLoad(string filename);
        /// <summary>
        /// Do actual loading, prior to this call, Opengl is set up, texture handle created and bound
        /// This method should be self contained, so before returning to caller you should clean up all the resources
        /// Preffered method to do so is using()
        /// </summary>
        void Load();
        /// <summary>
        /// Width of the texture, only obtained once
        /// </summary>
        int Width
        {
            get;
        }
        /// <summary>
        /// Height of the texture, only obtained once
        /// </summary>
        int Height
        {
            get;
        }
    }
}
