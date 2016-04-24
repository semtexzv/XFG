using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFG.MathUtils;
using XFG.Platform;

namespace XFG
{
    public class AndroidInput : IInput
    {
        #region IInput implementation

        public event OnKeyDelegate OnKeyDown;

        public event OnKeyDelegate OnKeyUp;

        public event OnCharDelegate OnCharacter;

        public event OnMouseMoveDelegate OnMouseMove;

        public event OnMouseDelegate OnMouseDown;

        public event OnMouseDelegate OnMouseUp;

        public event OnScrollDelegate OnScroll;

        public Vector2 GetMousePos()
        {
        
            return new Vector2();
        }

        public bool IsKeyDown(Keys key)
        {
            return false;
        }

        public bool IsMouseDown(MouseButton button)
        {
            return false;
        }

        public Modifiers GetModifiers()
        {
            var res = Modifiers.None;
            res |= (IsKeyDown(Keys.ALT_LEFT) | IsKeyDown(Keys.ALT_RIGHT)) ? Modifiers.Alt : Modifiers.None;
            res |= (IsKeyDown(Keys.CTRL_LEFT) | IsKeyDown(Keys.CTRL_RIGHT)) ? Modifiers.Control : Modifiers.None;
            res |= (IsKeyDown(Keys.SHIFT_LEFT) | IsKeyDown(Keys.SHIFT_RIGHT)) ? Modifiers.Shift : Modifiers.None;

            res |= (IsKeyDown(Keys.META_LEFT) | IsKeyDown(Keys.META_RIGHT)) ? Modifiers.Super : Modifiers.None;
            return res;
        }

        #endregion
    }
}