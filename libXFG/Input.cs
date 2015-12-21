using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG.Platform;
using XFG.MathUtils;

namespace XFG
{
    public delegate void OnKeyDelegate(Keys key, Modifiers mods);
    public delegate void OnCharDelegate(char character);

    public delegate void OnMouseMoveDelegate(int x, int y);
    public delegate void OnMouseDelegate(MouseButton button);
    public delegate void OnScrollDelegate(int amount);

    public static class Input
    {
        private static IInput Platform;
        internal static void SetPlatform(IInput input)
        {
            Platform = input;
        }

        public static event OnKeyDelegate OnKeyDown
        {
            add { Platform.OnKeyDown += value; }
            remove { Platform.OnKeyDown -= value; }
        }
        public static event OnKeyDelegate OnKeyUp
        {
            add { Platform.OnKeyUp += value; }
            remove { Platform.OnKeyUp -= value; }
        }
        public static event OnCharDelegate OnCHaracter
        {
            add { Platform.OnCharacter += value; }
            remove { Platform.OnCharacter -= value; }
        }
        public static event OnMouseDelegate OnMouseDown
        {
            add { Platform.OnMouseDown += value; }
            remove { Platform.OnMouseDown -= value; }
        }
        public static event OnMouseDelegate OnMouseUp
        {
            add { Platform.OnMouseUp += value; }
            remove { Platform.OnMouseUp -= value; }
        }
        public static event OnMouseMoveDelegate OnMouseMove
        {
            add { Platform.OnMouseMove += value; }
            remove { Platform.OnMouseMove -= value; }
        }
        public static event OnScrollDelegate OnScroll
        {
            add { Platform.OnScroll += value; }
            remove { Platform.OnScroll -= value; }
        }

        public static  bool IsKeyDown(Keys key)
        {
            return Platform.IsKeyDown(key);
        }
        public static Vector2 GetMousePos()
        {
            return Platform.GetMousePos();
        }
        public static bool IsMouseButtonDown(MouseButton button)
        {
            return Platform.IsMouseDown(button);
        }
    }
}
