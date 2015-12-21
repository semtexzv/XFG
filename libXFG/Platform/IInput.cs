using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFG.MathUtils;

namespace XFG.Platform
{
    interface IInput
    {
        event OnKeyDelegate OnKeyDown;
        event OnKeyDelegate OnKeyUp;
        event OnCharDelegate OnCharacter;
        event OnMouseMoveDelegate OnMouseMove;
        event OnMouseDelegate OnMouseDown;
        event OnMouseDelegate OnMouseUp;
        event OnScrollDelegate OnScroll;
        Vector2 GetMousePos();
        bool IsKeyDown(Keys key);
        bool IsMouseDown(MouseButton button);
        Modifiers GetModifiers();        
    }
}
