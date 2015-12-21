using XFG.MathUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG.OpenGL;

namespace XFG.Platform
{

    public interface IDisplay
    {
        void SetSync(SyncType type);
        void SetFullscreen(bool fullscreen);
        int Width { get; }
        int Height { get; }
        event OnResizeDelegate OnResized;
        void Hide();
        void Show();
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
