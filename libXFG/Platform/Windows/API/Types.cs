using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XFG.Platform.Windows
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        internal Int32 x;
        internal Int32 Y;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct MSG
    {
        internal IntPtr hwnd;
        internal WM message;
        internal UIntPtr wParam;
        internal UIntPtr lParam;
        internal UInt32 time;
        internal POINT pt;
    }
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    struct DEVMODE
    {
        internal const int CCHDEVICENAME = 32;
        internal const int CCHFORMNAME = 32;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
        [System.Runtime.InteropServices.FieldOffset(0)]
        internal string dmDeviceName;
        [System.Runtime.InteropServices.FieldOffset(32)]
        internal Int16 dmSpecVersion;
        [System.Runtime.InteropServices.FieldOffset(34)]
        internal Int16 dmDriverVersion;
        [System.Runtime.InteropServices.FieldOffset(36)]
        internal Int16 dmSize;
        [System.Runtime.InteropServices.FieldOffset(38)]
        internal Int16 dmDriverExtra;
        [System.Runtime.InteropServices.FieldOffset(40)]
        internal DM dmFields;

        [System.Runtime.InteropServices.FieldOffset(44)]
        Int16 dmOrientation;
        [System.Runtime.InteropServices.FieldOffset(46)]
        Int16 dmPaperSize;
        [System.Runtime.InteropServices.FieldOffset(48)]
        Int16 dmPaperLength;
        [System.Runtime.InteropServices.FieldOffset(50)]
        Int16 dmPaperWidth;
        [System.Runtime.InteropServices.FieldOffset(52)]
        Int16 dmScale;
        [System.Runtime.InteropServices.FieldOffset(54)]
        Int16 dmCopies;
        [System.Runtime.InteropServices.FieldOffset(56)]
        Int16 dmDefaultSource;
        [System.Runtime.InteropServices.FieldOffset(58)]
        Int16 dmPrintQuality;

        [System.Runtime.InteropServices.FieldOffset(44)]
        internal POINT dmPosition;
        [System.Runtime.InteropServices.FieldOffset(52)]
        internal Int32 dmDisplayOrientation;
        [System.Runtime.InteropServices.FieldOffset(56)]
        internal Int32 dmDisplayFixedOutput;

        [System.Runtime.InteropServices.FieldOffset(60)]
        internal short dmColor; // See note below!
        [System.Runtime.InteropServices.FieldOffset(62)]
        internal short dmDuplex; // See note below!
        [System.Runtime.InteropServices.FieldOffset(64)]
        internal short dmYResolution;
        [System.Runtime.InteropServices.FieldOffset(66)]
        internal short dmTTOption;
        [System.Runtime.InteropServices.FieldOffset(68)]
        internal short dmCollate; // See note below!
        [System.Runtime.InteropServices.FieldOffset(72)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
        internal string dmFormName;
        [System.Runtime.InteropServices.FieldOffset(102)]
        internal Int16 dmLogPixels;
        [System.Runtime.InteropServices.FieldOffset(104)]
        internal Int32 dmBitsPerPel;
        [System.Runtime.InteropServices.FieldOffset(108)]
        internal Int32 dmPelsWidth;
        [System.Runtime.InteropServices.FieldOffset(112)]
        internal Int32 dmPelsHeight;
        [System.Runtime.InteropServices.FieldOffset(116)]
        internal Int32 dmDisplayFlags;
        [System.Runtime.InteropServices.FieldOffset(116)]
        internal Int32 dmNup;
        [System.Runtime.InteropServices.FieldOffset(120)]
        internal Int32 dmDisplayFrequency;
    }

    delegate IntPtr WndProc(IntPtr hWnd, WM msg, IntPtr wParam, IntPtr lParam);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct WNDCLASSEX
    {
        [MarshalAs(UnmanagedType.U4)]
        internal int cbSize;
        [MarshalAs(UnmanagedType.U4)]
        internal ClassStyles style;
        internal WndProc lpfnWndProc; // not WndProc
        internal int cbClsExtra;
        internal int cbWndExtra;
        internal IntPtr hInstance;
        internal IntPtr hIcon;
        internal IntPtr hCursor;
        internal IntPtr hbrBackground;
        internal string lpszMenuName;
        internal string lpszClassName;
        internal IntPtr hIconSm;
    }
    /// <summary>
    /// The PIXELFORMATDESCRIPTOR structure describes the pixel format of a drawing surface
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct PixelFormatDescriptor
    {
        /// <summary>
        /// Specifies the size of this data structure. This value should be set to sizeof(PIXELFORMATDESCRIPTOR).
        /// </summary>
         ushort nSize;

        /// <summary>
        /// Specifies the version of this data structure. This value should be set to 1.
        /// </summary>
         ushort nVersion;

        /// <summary>
        /// A set of bit flags that specify properties of the pixel buffer
        /// </summary>
         PFDBitFlag dwFlags;

        /// <summary>
        /// Specifies the type of pixel data
        /// </summary>
         PixelType iPixelType;

        /// <summary>
        /// Specifies the number of color bitplanes in each color buffer. For RGBA pixel types, it is the size of
        /// the color buffer, excluding the alpha bitplanes. For color-index pixels, it is the size of the color-index buffer
        /// </summary>
         byte cColorBits;

        /// <summary>
        /// Specifies the number of red bitplanes in each RGBA color buffer
        /// </summary>
         byte cRedBits;

        /// <summary>
        /// Specifies the shift count for red bitplanes in each RGBA color buffer
        /// </summary>
         byte cRedShift;

        /// <summary>
        /// Specifies the number of green bitplanes in each RGBA color buffer
        /// </summary>
         byte cGreenBits;

        /// <summary>
        /// Specifies the shift count for green bitplanes in each RGBA color buffer
        /// </summary>
         byte cGreenShift;

        /// <summary>
        /// Specifies the shift count for green bitplanes in each RGBA color buffer
        /// </summary>
         byte cBlueBits;

        /// <summary>
        /// Specifies the shift count for blue bitplanes in each RGBA color buffer
        /// </summary>
         byte cBlueShift;

        /// <summary>
        /// Specifies the number of alpha bitplanes in each RGBA color buffer. 
        /// Alpha bitplanes are not supported
        /// </summary>
         byte cAlphaBits;

        /// <summary>
        /// Specifies the shift count for alpha bitplanes in each RGBA color buffer. 
        /// Alpha bitplanes are not supported
        /// </summary>
         byte cAlphaShift;

        /// <summary>
        /// Specifies the total number of bitplanes in the accumulation buffer
        /// </summary>
         byte cAccumBits;

        /// <summary>
        /// Specifies the number of red bitplanes in the accumulation buffer
        /// </summary>
         byte cAccumRedBits;

        /// <summary>
        /// Specifies the number of green bitplanes in the accumulation buffer
        /// </summary>
         byte cAccumGreenBits;

        /// <summary>
        /// Specifies the number of blue bitplanes in the accumulation buffer
        /// </summary>
        byte cAccumBlueBits;

        /// <summary>
        /// Specifies the number of alpha bitplanes in the accumulation buffer
        /// </summary>
         byte cAccumAlphaBits;

        /// <summary>
        /// Specifies the depth of the depth (z-axis) buffer
        /// </summary>
         byte cDepthBits;

        /// <summary>
        /// Specifies the depth of the stencil buffer
        /// </summary>
         byte cStencilBits;

        /// <summary>
        /// Specifies the number of auxiliary buffers. Auxiliary buffers are not supported
        /// </summary>
        byte cAuxBuffers;

        /// <summary>
        /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used
        /// </summary>
         byte iLayerType;

        /// <summary>
        /// Specifies the number of overlay and underlay planes. Bits 0 through 3 specify up to 15 
        /// overlay planes and bits 4 through 7 specify up to 15 underlay planes
        /// </summary>
         byte bReserved;

        /// <summary>
        /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used
        /// </summary>
         uint dwLayerMask;

        /// <summary>
        /// Specifies the transparent color or index of an underlay plane. When the pixel type is RGBA,
        /// dwVisibleMask is a transparent RGB color value. When the pixel type is color index, it is a
        /// transparent index value
        /// </summary>
         uint dwVisibleMask;

        /// <summary>
        /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used
        /// </summary>
         uint dwDamageMask;
    }


}
