using XFG.MathUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Backend
{

    public interface IInputPlatform
    {
        /// <summary>
        /// Occurs when key is pressed
        /// </summary>
        event OnKeyDelegate OnKeyDown;
        /// <summary>
        /// Occurs when key is released, If key is pressed and user changes focused window,
        /// This event won't be recieved
        /// </summary>
        event OnKeyDelegate OnKeyUp;
        /// <summary>
        /// Called on keyUp but sends char code instead of key enum
        /// </summary>
        event OnCharDelegate OnCharacter;
        /// <summary>
        /// On every mouse movement event
        /// </summary>
        event OnMouseMoveDelegate OnMouseMove;
        /// <summary>
        /// Mouse buttons being pressed
        /// </summary>
        event OnMouseDelegate OnMouseDown;
        /// <summary>
        /// Mouse buttons being released
        /// </summary>
        event OnMouseDelegate OnMouseUp;
        /// <summary>
        /// Mouse scrollwheel events
        /// </summary>
        event OnScrollDelegate OnScroll;
        
        Vector2 GetMousePos();
        bool IsKeyDown(Keys key);
        bool IsMouseDown(MouseButton button);
        Modifiers GetModifiers();
        
        
    }
}
