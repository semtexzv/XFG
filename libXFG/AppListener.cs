using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG
{
    /// <summary>
    /// Your Game/App should implement this interface
    /// If you need to know when screen is resized and/or similar events
    /// You have to subscribe to appropriate events
    /// </summary>
    public interface AppListener 
    {
        /// <summary>
        /// Occurs after all platform resources are initialized, initialize your resources here
        /// </summary>
        void Create();
        /// <summary>
        /// Occurs once per frame,Game Logic + Rendering belong here
        /// </summary>
        /// <param name="delta"></param>
        void Render(float delta);
        /// <summary>
        /// User Left the application, or minimized it
        /// </summary>
        void Pause();
        /// <summary>
        /// User returned to application
        /// </summary>
        void Resume();
        /// <summary>
        /// Release all resources, Save games state if needed
        /// </summary>
        void Destroy();
    }
}
