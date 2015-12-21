using System;

namespace XFG
{
    /// <summary>
    /// Keys enum, tries to encompass most frequent keys and provide common subset,
    /// that can be expanded later, every platform needs to convert to this keycode set from its native one,
    /// This set is derived from android since it is suited for mobile and desktop.
    /// </summary>
    public enum Keys
    {
        ANY_KEY = -1,
        UNKNOWN = 0,

        SOFT_LEFT = 1,
        SOFT_RIGHT = 2,
        HOME = 3,
        BACK = 4,

        CALL = 5,
        ENDCALL = 6,

        NUM_0 = 7,
        NUM_1 = 8,
        NUM_2 = 9,
        NUM_3 = 10,
        NUM_4 = 11,
        NUM_5 = 12,
        NUM_6 = 13,
        NUM_7 = 14,
        NUM_8 = 15,
        NUM_9 = 16,

        STAR = 17,
        POUND = 18,

        UP = 19,
        DOWN = 20,
        LEFT = 21,
        RIGHT = 22,
        CENTER = 23,

        VOLUME_UP = 24,
        VOLUME_DOWN = 25,

        POWER = 26,
        CAMERA = 27,
        CLEAR = 28,

        A = 29,
        B = 30,
        C = 31,
        D = 32,
        E = 33,
        F = 34,
        G = 35,
        H = 36,
        I = 37,
        J = 38,
        K = 39,
        L = 40,
        M = 41,
        N = 42,
        O = 43,
        P = 44,
        Q = 45,
        R = 46,
        S = 47,
        T = 48,
        U = 49,
        V = 50,
        W = 51,
        X = 52,
        Y = 53,
        Z = 54,

        COMMA = 55,
        PERIOD = 56,

        ALT_LEFT = 57,
        ALT_RIGHT = 58,

        SHIFT_LEFT = 59,
        SHIFT_RIGHT = 60,

        TAB = 61,
        SPACE = 62,
        SYM = 63,

        EXPLORER = 64,
        ENVELOPE = 65,
        ENTER = 66,

        BACKSPACE = 67,

        GRAVE = 68,
        BACKTICK = GRAVE,
        TILDE = GRAVE,

        MINUS = 69,
        DASH = MINUS,
        EQUALS = 70,

        LEFT_BRACKET = 71,
        RIGHT_BRACKET = 72,


        BACKSLASH = 73,
        SEMICOLON = 74,
        APOSTROPHE = 75,
        SLASH = 76,
        AT = 77,
        NUM__UNUSED = 78,
        HEADSETHOOK = 79,
        FOCUS = 80,

        PLUS = 81, 
        MENU = 82,
        NOTIFICATION = 83,
        SEARCH = 84,

        MEDIA_PLAY_PAUSE = 85,
        MEDIA_STOP = 86,
        MEDIA_NEXT = 87,
        MEDIA_PREVIOUS = 88,
        MEDIA_REWIND = 89,
        MEDIA_FAST_FORWARD = 90,

        MUTE_mic= 91,

        PAGE_UP = 92,
        PAGE_DOWN = 93,

        BUTTON_A = 96,
        BUTTON_B = 97,
        BUTTON_C = 98,
        BUTTON_X = 99,
        BUTTON_Y = 100,
        BUTTON_Z = 101,
        BUTTON_L1 = 102,
        BUTTON_R1 = 103,
        BUTTON_L2 = 104,
        BUTTON_R2 = 105,
        BUTTON_THUMBL = 106,
        BUTTON_THUMBR = 107,
        BUTTON_START = 108,
        BUTTON_SELECT = 109,
        BUTTON_MODE = 110,

        ESCAPE = 111,
        DELETE = 112,
        CTRL_LEFT = 113,
        CTRL_RIGHT=114,
        CAPS_LOCK=115,
        SCROLL_LOCK=116,

        META_LEFT=117,
        META_RIGHT=118,
        WIN_LEFT=META_LEFT,
        WIN_RIGHT=META_RIGHT,
        CMD_LEFT = META_LEFT,
        CMD_RIGHT = META_RIGHT,

        BREAK = 121,
        PAUSE = BREAK,

        HOME_TEXT = 122,
        END_TEXT = 123,
        INSERT_TEXT = 124,

        FORWARD=125,

        F1 = 131,
        F2 = 132,
        F3 = 133,
        F4 = 134,
        F5 = 135,
        F6 = 136,
        F7 = 137,
        F8 = 138,
        F9 = 139,
        F10 = 140,
        F11 = 141,
        F12 = 142,

        NUM_LOCK = 143,

        NUMPAD_0 = 144,
        NUMPAD_1 = 145,
        NUMPAD_2 = 146,
        NUMPAD_3 = 147,
        NUMPAD_4 = 148,
        NUMPAD_5 = 149,
        NUMPAD_6 = 150,
        NUMPAD_7 = 151,
        NUMPAD_8 = 152,
        NUMPAD_9 = 153,
        
        NUMPAD_DIV=154,
        NUMPAD_MUL=155,
        NUMPAD_SUB=156,
        NUMPAD_ADD=157,
        NUMPAD_DOT=158,
        MUPAD_COMMA=159,
        NUMPAD_ENTER=160,

        LEFT_PAREN = 162,
        RIGHT_PAREN = 163
    }

    [Flags]
    public enum Modifiers
    {
        None=0,
        Alt = 0x1,
        Control=0x2,
        Shift=0x4,
        Meta=0x8,
        Super=0x10,
        CapsLock=0x20,
        ScrollLock=0x40,
        NumLock=0x80,
    }
    public enum MouseButton
    {
        Move =0,
        Left = 1,
        Finger = Left,
        Right = 2,
        Center = 3,
        /*
        ScrollUp=4,
        ScrollDown = 5,
        */
        WheelLeft=6,
        WheelRight=7,
        Button8 = 8,
        Button9 = 9,
        Button10 = 10,
        Button11 = 11,
        Button12 = 12,
    }
}