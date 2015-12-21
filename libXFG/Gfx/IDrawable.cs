using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Gfx
{
    /// <summary>
    /// This interface will be used in 2D and UI to provide easy way to create 
    /// generic algorithms.
    /// </summary>
    interface IDrawable
    {
        /// <summary>
        /// Draw using provided SpriteBatch
        /// </summary>
        /// <param name="batch"></param>
        void Draw(SpriteBatch batch);
    
    }
}
