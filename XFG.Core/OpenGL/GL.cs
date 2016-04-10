using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XFG.OpenGL
{
    [Flags]
    public enum ClearBufferMask : uint
    {
        COLOR_BUFFER_BIT = 0x00004000,
        DEPTH_BUFFER_BIT = 0x00000100,
        STENCIL_BUFFER_BIT = 0x00000400,
        ALL= COLOR_BUFFER_BIT|DEPTH_BUFFER_BIT|STENCIL_BUFFER_BIT,
    }

    public enum PrimitiveType : uint
    {
        LINES = 0x0001,
        LINE_LOOP = 0x0002,//
        LINE_STRIP = 0x0003,//
        POINTS = 0x0000,//
        TRIANGLES = 0x0004,//
        TRIANGLE_FAN = 0x0006,//
        TRIANGLE_STRIP = 0x0005,//
    }
    /// <summary>
    /// Blending factor, 
    /// WARNING!!!: SRC_ALPHA_SATURATE is only for source, never destination
    /// </summary>
    public enum BlendingFactor : uint
    {
        ZERO = 0,
        ONE = 1,
        SRC_COLOR = 0x0300,
        ONE_MINUS_SRC_COLOR = 0x0301,
        DST_COLOR = 0x0306,
        ONE_MINUS_DST_COLOR = 0x0307,
        SRC_ALPHA = 0x0302,
        ONE_MINUS_SRC_ALPHA = 0x0303,
        DST_ALPHA = 0x0304,
        ONE_MINUS_DST_ALPHA = 0x0305,
        CONSTANT_COLOR = 0x8001,
        ONE_MINUS_CONSTANT_COLOR = 0x8002,
        CONSTANT_ALPHA = 0x8003,
        ONE_MINUS_CONSTANT_ALPHA = 0x8004,
        SRC_ALPHA_SATURATE = 0x0308,
    }
    public enum StencilOpType : uint
    {
        DECR = 0x1E03,
        DECR_WRAP = 0x8508,
        INCR = 0x1E02,
        INCR_WRAP= 0x8507,
        INVERT = 0x150A,
        KEEP = 0x1E00,
        REPLACE = 0x1E01,
        ZERO = 0
    }
    public enum FaceMode : uint
    {
        BACK = 0x0405,
        FRONT = 0x0404,
        FRONT_AND_BACK = 0x0408
    }
    public enum EnableCap : uint
    {
        BLEND = 0x0BE2,//
        CULL_FACE = 0x0B44,//
        DEPTH_TEST = 0x0B71,//
        DITHER = 0x0BD0,//
        POLYGON_OFFSET_FILL = 0x8037,//
        SAMPLE_ALPHA_TO_COVERAGE = 0x809E,
        SAMPLE_COVERAGE = 0x80A0,
        SCISSOR_TEST = 0x0C11,
        STENCIL_TEST = 0x0B90,

    }
    public enum GetPName : uint
    {

        ACTIVE_TEXTURE = 0x84E0,
        ALIASED_LINE_WIDTH_RANGE = 0x846E,
        ALIASED_POINT_SIZE_RANGE = 0x846D,
        ALPHA_BITS = 0x0D55,
        ARRAY_BUFFER_BINDING= 0x8894,
        BLEND = 0x0BE2,
        BLEND_COLOR = 0x8005,
        BLEND_DST_ALPHA = 0x80CA,
        BLEND_DST_RGB= 0x80C8,
        BLEND_EQUATION_ALPHA= 0x883D,
        BLEND_EQUATION_RGB= 0x8009,
        BLEND_SRC_ALPHA= 0x80CB,
        BLEND_SRC_RGB= 0x80C9,

        BLUE_BITS = 0x0D54,
        COLOR_CLEAR_VALUE = 0x0C22,
        COLOR_WRITEMASK = 0x0C23,
        COMPRESSED_TEXTURE_FORMATS= 0x86A3,

        CULL_FACE = 0x0B44,
        CULL_FACE_MODE = 0x0B45,
        CURRENT_PROGRAM= 0x8B8D,
        DEPTH_BITS = 0x0D56,
        DEPTH_CLEAR_VALUE = 0x0B73,
        DEPTH_FUNC = 0x0B74,
        DEPTH_RANGE = 0x0B70,
        DEPTH_TEST = 0x0B71,
        DEPTH_WRITEMASK = 0x0B72,


        DITHER = 0x0BD0,
        ELEMENT_ARRAY_BUFFER_BINDING= 0x8895,
        FRAMEBUFFER_BINDING= 0x8CA6,

        FRONT_FACE = 0x0B46,
        GENERATE_MIPMAP_HINT = 0x8192,


        GREEN_BITS = 0x0D53,
        IMPLEMENTATION_COLOR_READ_FORMAT= 0x8B9B,
        IMPLEMENTATION_COLOR_READ_TYPE= 0x8B9A,


        LINE_WIDTH = 0x0B21,
        MAX_COMBINED_TEXTURE_IMAGE_UNITS=0x8B4D,
        MAX_CUBE_MAP_TEXTURE_SIZE= 0x851C,
        MAX_FRAGMENT_UNIFORM_VECTORS= 0x8DFD,
        MAX_RENDERBUFFER_SIZE= 0x84E8,
        MAX_TEXTURE_IMAGE_UNITS= 0x8872,
        MAX_TEXTURE_SIZE= 0x0D33,
        MAX_VARYING_VECTORS= 0x8DFC,
        MAX_VERTEX_ATTRIBS= 0x8869,
        MAX_VERTEX_TEXTURE_IMAGE_UNITS= 0x8B4C,
        MAX_VERTEX_UNIFORM_VECTORS= 0x8DFB,
        MAX_VIEWPORT_DIMS= 0x0D3A,
        NUM_COMPRESSED_TEXTURE_FORMATS= 0x86A2,
        NUM_SHADER_BINARY_FORMATS= 0x8DF9,

        PACK_ALIGNMENT = 0x0D05,

        POLYGON_OFFSET_FACTOR = 0x8038,
        POLYGON_OFFSET_FILL = 0x8037,
        POLYGON_OFFSET_UNITS = 0x2A00,

        RED_BITS = 0x0D52,
        RENDERBUFFER_BINDING= 0x8CA7,
        SAMPLE_ALPHA_TO_COVERAGE= 0x809E,
        SAMPLE_BUFFERS=0x80A8,
        SAMPLE_COVERAGE= 0x80A0,
        SAMPLE_COVERAGE_INVERT= 0x80AB,
        SAMPLE_COVERAGE_VALUE= 0x80AA,
        SAMPLES= 0x80A9,

        SCISSOR_TEST = 0x0C11,

        SHADER_BINARY_FORMATS= 0x8DF8,
        SHADER_COMPILER= 0x8DFA,
        STENCIL_BACK_FAIL = 0x8801,
        STENCIL_BACK_FUNC= 0x8800,
        STENCIL_BACK_PASS_DEPTH_FAIL= 0x8802,
        STENCIL_BACK_PASS_DEPTH_PASS= 0x8803,
        STENCIL_BACK_REF= 0x8CA3,
        STENCIL_BACK_VALUE_MASK= 0x8CA4,
        STENCIL_BACK_WRITEMASK= 0x8CA5,
        STENCIL_BITS = 0x0D57,
        STENCIL_CLEAR_VALUE = 0x0B91,
        STENCIL_FAIL = 0x0B94,
        STENCIL_FUNC = 0x0B92,
        STENCIL_PASS_DEPTH_FAIL = 0x0B95,
        STENCIL_PASS_DEPTH_PASS = 0x0B96,
        STENCIL_REF = 0x0B97,
        STENCIL_TEST = 0x0B90,
        STENCIL_VALUE_MASK = 0x0B93,
        STENCIL_WRITEMASK = 0x0B98,
        SUBPIXEL_BITS = 0x0D50,
        TEXTURE_BINDING_2D = 0x8069,
        TEXTURE_BINDING_CUBE_MAP= 0x8514,
        UNPACK_ALIGNMENT = 0x0CF5,
        VIEWPORT = 0x0BA2,


        /// <summary>
        /// OES_vertex_array_object
        /// </summary>
        VERTEX_ARRAY_BINDING_OES = 0x85B5,
    }
    public enum TextureTarget : uint
    {
        TEXTURE_2D = 0x0DE1,
        TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515,
        TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516,
        TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517,
        TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518,
        TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519,
        TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A,
    }
    public enum TextureType : uint
    {
        TEXTURE_2D = 0x0DE1,
        TEXTURE_CUBE_MAP_POSITIVE_X = 0x8513,
    }
    public enum TextureEnvMode : uint
    {
        ADD = 0x0104,
        BLEND = 0x0BE2,
        DECAL = 0x2101,
        MODULATE = 0x2100,
        REPLACE_EXT = 0x8062,
        TEXTURE_ENV_BIAS_SGIX = 0x80BE
    }
    public enum ErrorCode : uint
    {
        INVALID_ENUM = 0x0500,
        INVALID_FRAMEBUFFER_OPERATION = 0x0506,
        INVALID_FRAMEBUFFER_OPERATION_EXT = 0x0506,
        INVALID_FRAMEBUFFER_OPERATION_OES = 0x0506,
        INVALID_OPERATION = 0x0502,
        INVALID_VALUE = 0x0501,
        NO_ERROR = 0,
        OUT_OF_MEMORY = 0x0505,
        STACK_OVERFLOW = 0x0503,
        STACK_UNDERFLOW = 0x0504,
        TABLE_TOO_LARGE = 0x8031,
        TABLE_TOO_LARGE_EXT = 0x8031,
        TEXTURE_TOO_LARGE_EXT = 0x8065
    }
    public enum FrontFaceDirection : uint
    {
        CCW = 0x0901,
        CW = 0x0900
    }
    public enum PixelStoreParameter : uint
    {
        PACK_ALIGNMENT = 0x0D05,
        UNPACK_ALIGNMENT = 0x0CF5,
    }
    public enum HintMode : uint
    {
        DONT_CARE = 0x1100,
        FASTEST = 0x1101,
        NICEST = 0x1102
    }
    public enum HintTarget : uint
    {
        GENERATE_MIPMAP_HINT = 0x8192,
    }
    public enum PixelType : uint
    {

        UNSIGNED_BYTE = 0x1401,
        UNSIGNED_SHORT_5_6_5= 0x8363,
        UNSIGNED_SHORT_4_4_4_4 = 0x8033,
        UNSIGNED_SHORT_5_5_5_1 = 0x8034,
    }
    public enum VertexPointerType : uint
    {
        BYTE= 0x1400,
        UNSIGNED_BYTE= 0x1401,
        SHORT= 0x1402,
        UNSIGNED_SHORT= 0x1403,
        FIXED= 0x140C,
        FLOAT= 0x1406,
    }
    public enum PixelFormat : uint
    {
        ALPHA = 0x1906,
        RGB = 0x1907,
        RGBA = 0x1908,
        BGR_EXT = 0x80E0,
        BGRA_EXT = 0x80E1,
        LUMINANCE = 0x1909,
        LUMINANCE_ALPHA = 0x190A,
    }

    public enum DepthFunction : uint
    {
        ALWAYS = 0x0207,
        EQUAL = 0x0202,
        GEQUAL = 0x0206,
        GREATER = 0x0204,
        LEQUAL = 0x0203,
        LESS = 0x0201,
        NEVER = 0x0200,
        NOTEQUAL = 0x0205
    }
    public enum StencilFunction : uint
    {
        ALWAYS = 0x0207,
        EQUAL = 0x0202,
        GEQUAL = 0x0206,
        GREATER = 0x0204,
        LEQUAL = 0x0203,
        LESS = 0x0201,
        NEVER = 0x0200,
        NOTEQUAL = 0x0205
    }
    public enum StringName : uint
    {
        EXTENSIONS = 0x1F03,
        RENDERER = 0x1F01,
        VENDOR = 0x1F00,
        VERSION = 0x1F02,
        SHADING_LANGUAGE_VERSION= 0x82E9,
    }
    public enum TextureMagFilter : uint
    {
        LINEAR = 0x2601,
        NEAREST = 0x2600,
    }
    public enum TextureMinFilter : uint
    {
        NEAREST = 0x2600,
        LINEAR = 0x2601,
        NEAREST_MIPMAP_NEAREST = 0x2700,
        LINEAR_MIPMAP_NEAREST = 0x2701,
        NEAREST_MIPMAP_LINEAR = 0x2702,
        LINEAR_MIPMAP_LINEAR = 0x2703,

    }

    public enum TextureParameter : uint
    {
        TEXTURE_MAG_FILTER = 0x2800,
        TEXTURE_MIN_FILTER = 0x2801,
        TEXTURE_WRAP_S = 0x2802,
        TEXTURE_WRAP_T = 0x2803
    }
  
    public enum TextureWrapMode : uint
    {
        CLAMP_TO_EDGE = 0x812F,
        CLAMP_TO_BORDER = 0x812D,
        MIRRORED_REPEAT= 0x8370,
        REPEAT = 0x2901
    }
    public enum InternalPixelFormat : uint
    {
        ALPHA = 0x1906,
        RGB = 0x1907,
        RGBA = 0x1908,
        BGR_EXT =   0x80E0,
        BGRA_EXT = 0x80E1,
        LUMINANCE = 0x1909,
        LUMINANCE_ALPHA = 0x190A,
    }
    public enum TextureUnit : int
    {
        TEXTURE0 = 0x84c0,
        TEXTURE1 = 0x84c1,
        TEXTURE2 = 0x84c2,
        TEXTURE3 = 0x84c3,
        TEXTURE4 = 0x84c4,
        TEXTURE5 = 0x84c5,
        TEXTURE6 = 0x84c6,
        TEXTURE7 = 0x84c7,
        TEXTURE8 = 0x84c8,
        TEXTURE9 = 0x84c9,
        TEXTURE10 = 0x84cA,
        TEXTURE11 = 0x84cB,
        TEXTURE12 = 0x84cC,
        TEXTURE13 = 0x84cD,
        TEXTURE14 = 0x84cE,
        TEXTURE15 = 0x84cF,
    }
    public enum BufferTarget : int
    {
        ARRAY_BUFFER = 0x8892,
        ELEMENT_ARRAY_BUFFER = 0x8893,
    }
    public enum BlendEquationType : int
    {
        FUNC_ADD = 0x8006,
        FUNC_SUBSTRACT = 0x800A,
        FUNC_REVERSE_SUBSTRACT = 0x800B,
    }
    public enum BufferUsage : int
    {
        STREAM_DRAW = 0x88E0,
        STATIC_DRAW = 0x88E4,
        DYNAMIC_DRAW = 0x88E8,
    }
    public enum FramebufferStatus : int
    {
        FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6,
        FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7,
        FRAMEBUFFER_INCOMPLETE_DIMENSIONS = 0x8CD9,
        FRAMEBUFFER_UNSUPPORTED = 0x8CDD,
    }
    public enum ShaderType : int
    {
        FRAGMENT_SHADER = 0x8B30,
        VERTEX_SHADER = 0x8B31,
    }
    public enum ElementsType : int
    {
        UNSIGNED_BYTE = 0x1401,
        UNSIGNED_SHORT = 0x1403,
    }
    public enum FramebufferAttachment : int
    {
        COLOR_ATTACHMENT0 = 0x8CE0,
        DEPTH_ATTACHMENT = 0x8D00,
        STENCIL_ATTACHMENT = 0x8D20,
    }
    public enum DataType : int
    {
        FLOAT = 0x1406,
        FLOAT_VEC2 = 0x8B50,
        FLOAT_VEC3 = 0x8B51,
        FLOAT_VEC4 = 0x8B52,
        FLOAT_MAT2 = 0x8B5A,
        FLOAT_MAT3 = 0x8B5B,
        FLOAT_MAT4 = 0x8B5C,
    }
    public enum BufferParameter : int
    {
        BUFFER_SIZE= 0x8764,
        BUFFER_USAGE= 0x8765,
    }
    public enum FramebufferParameter : int
    {
        FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE= 0x8CD0,
        FRAMEBUFFER_ATTACHMENT_OBJECT_NAME= 0x8CD1,
        FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL= 0x8CD2,
        FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE= 0x8CD3,
    }

    public enum ProgramInfoParam : int
    {
        DELETE_STATUS= 0x8B80,
        LINK_STATUS= 0x8B82,
        VALIDATE_STATUS= 0x8B83,
        INFO_LOG_LENGTH= 0x8B84,
        ATTACHED_SHADERS= 0x8B85,
        ACTIVE_ATTRIBUTES= 0x8B89,
        ACTIVE_ATTRIBUTE_MAX_LENGTH= 0x8B8A,
        ACTIVE_UNIFORMS= 0x8B86,
        ACTIVE_UNIFORM_MAX_LENGTH= 0x8B87,
    }
    public enum RenderBufferParam : int
    {
        RENDERBUFFER_WIDTH= 0x8D42,
        RENDERBUFFER_HEIGHT= 0x8D43,
        RENDERBUFFER_INTERNAL_FORMAT= 0x8D44,
        RENDERBUFFER_RED_SIZE= 0x8D50,
        RENDERBUFFER_GREEN_SIZE= 0x8D51,
        RENDERBUFFER_BLUE_SIZE= 0x8D52,
        RENDERBUFFER_ALPHA_SIZE= 0x8D53,
        RENDERBUFFER_DEPTH_SIZE= 0x8D54,
        RENDERBUFFER_STENCIL_SIZE= 0x8D55,
    }
    public enum PrecisionType : int
    {
        LOW_FLOAT= 0x8DF0,
        MEDIUM_FLOAT= 0x8DF1,
        HIGH_FLOAT= 0x8DF2,
        LOW_INT= 0x8DF3,
        MEDIUM_INT= 0x8DF4,
        HIGH_INT= 0x8DF5,
    }
    public enum ShaderParam : int
    {
        SHADER_TYPE= 0x8B4F,
        DELETE_STATUS= 0x8B80,
        COMPILE_STATUS= 0x8B81,
        INFO_LOG_LENGTH= 0x8B84,
        SHADER_SOURCE_LENGTH= 0x8B88,
    }
    public enum VertexAttribParam : uint
    {
        VERTEX_ATTRIB_ARRAY_BUFFER_BINDING= 0x889F,
        VERTEX_ATTRIB_ARRAY_ENABLED= 0x8622,
        VERTEX_ATTRIB_ARRAY_SIZE= 0x8623,
        VERTEX_ATTRIB_ARRAY_STRIDE= 0x8624,
        VERTEX_ATTRIB_ARRAY_TYPE= 0x8625,
        VERTEX_ATTRIB_ARRAY_NORMALIZED= 0x886A,
        CURRENT_VERTEX_ATTRIB= 0x8626,
    }
    public enum RenderbufferStorageFormat : int
    {
        RGBA4= 0x8056,
        RGB565= 0x8D62,
        RGB5_A1= 0x8057,
        DEPTH_COMPONENT16= 0x81A5,
        STENCIL_INDEX8= 0x8D48,
    }
    public static class GL
    {
        private const int FRAMEBUFFER = 0x8D40;
        private const int RENDERBUFFER = 0x8D41;
        private const int VERTEX_ATTRIB_ARRAY_POINTER = 34373;
        #region Generated

        public delegate void _glActiveTexture(TextureUnit texture);
        public delegate void _glAttachShader(UInt32 program, UInt32 shader);
        public delegate void _glBindAttribLocation(UInt32 program, UInt32 index, string name);
        public delegate void _glBindBuffer(BufferTarget target, Int32 buffer);
        private delegate void _glBindFramebuffer(int target, UInt32 framebuffer);
        private delegate void _glBindRenderbuffer(uint target, UInt32 renderbuffer);
        public delegate void _glBindTexture(TextureTarget target, int texture);
        public delegate void _glBlendColor(float red, float green, float blue, float alpha);
        public delegate void _glBlendEquation(BlendEquationType mode);
        public delegate void _glBlendEquationSeparate(BlendEquationType modeRGB, BlendEquationType modeAlpha);
        public delegate void _glBlendFunc(BlendingFactor sfactor, BlendingFactor dfactor);

        public delegate void _glBlendFuncSeparate(BlendingFactor sfactorRGB, BlendingFactor dfactorRGB, BlendingFactor sfactorAlpha, BlendingFactor dfactorAlpha);
        //TODO> find out if this works
        private unsafe delegate void _glBufferData(BufferTarget target, uint size, void* data, BufferUsage usage);
        public delegate void _glBufferSubData(BufferTarget target, uint offset, uint size, ValueType[] data);
        private delegate FramebufferStatus _glCheckFramebufferStatus(uint target);

        public delegate void _glClear(ClearBufferMask mask);
        public delegate void _glClearColor(float red, float green, float blue, float alpha);
        public delegate void _glClearDepthf(float d);
        public delegate void _glClearStencil(int s);
        public delegate void _glColorMask(Boolean red, Boolean green, Boolean blue, Boolean alpha);
        public delegate void _glCompileShader(UInt32 shader);

        public delegate void _glCompressedTexImage2D(TextureTarget target, Int32 level, InternalPixelFormat internalformat, UInt32 width, UInt32 height, Int32 border, UInt32 imageSize, ValueType[] data);
        public delegate void _glCompressedTexSubImage2D(TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, UInt32 width, UInt32 height, PixelFormat format, UInt32 imageSize, ValueType[] data);
        public delegate void _glCopyTexImage2D(TextureTarget target, Int32 level, InternalPixelFormat internalformat, int x, int y, UInt32 width, UInt32 height, Int32 border);
        public delegate void _glCopyTexSubImage2D(TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, int x, int y, UInt32 width, UInt32 height);
        public delegate UInt32 _glCreateProgram();
        public delegate UInt32 _glCreateShader(ShaderType type);
        public delegate void _glCullFace(FaceMode mode);
        private delegate void _glDeleteBuffers(UInt32 n, ref UInt32 buffers);
        private delegate void _glDeleteFramebuffers(UInt32 n, ref UInt32 framebuffers);
        public delegate void _glDeleteProgram(UInt32 program);
        private delegate void _glDeleteRenderbuffers(UInt32 n, ref UInt32 renderbuffers);
        public delegate void _glDeleteShader(UInt32 shader);
        private delegate void _glDeleteTextures(UInt32 n, ref uint textures);

        public delegate void _glDepthFunc(DepthFunction func);
        public delegate void _glDepthMask(Boolean flag);
        public delegate void _glDepthRangef(float n, float f);
        public delegate void _glDetachShader(UInt32 program, UInt32 shader);
        public delegate void _glDisable(EnableCap cap);
        public delegate void _glDisableVertexAttribArray(Int32 index);
        public delegate void _glDrawArrays(PrimitiveType mode, Int32 first, UInt32 count);
        public delegate void _glDrawElements(PrimitiveType mode, UInt32 count, ElementsType type, IntPtr indices);
        public delegate void _glEnable(EnableCap cap);
        public delegate void _glEnableVertexAttribArray(int index);
        public delegate void _glFinish();
        public delegate void _glFlush();

        private delegate void _glFramebufferRenderbuffer(int target, FramebufferAttachment attachment, int renderbuffertarget, UInt32 renderbuffer);
        private delegate void _glFramebufferTexture2D(int target, FramebufferAttachment attachment, TextureTarget textarget, UInt32 texture, Int32 level);
        public delegate void _glFrontFace(FrontFaceDirection mode);
        public delegate void _glGenBuffers(UInt32 n, ref Int32 buffers);
        public delegate void _glGenFramebuffers(UInt32 n, ref Int32 framebuffers);
        public delegate void _glGenRenderbuffers(UInt32 n, ref Int32 renderbuffers);
        public delegate void _glGenTextures(UInt32 n, ref int textures);
        public delegate void _glGenerateMipmap(TextureType target);
        public delegate void _glGetActiveAttrib(UInt32 program, UInt32 index, UInt32 bufSize, ref UInt32 length, ref Int32 size, ref DataType type, [MarshalAs(UnmanagedType.LPStr)]string name);
        public delegate void _glGetActiveUniform(UInt32 program, UInt32 index, UInt32 bufSize, ref UInt32 length, ref Int32 size, ref DataType type, [MarshalAs(UnmanagedType.LPStr)]string name);
        public delegate void _glGetAttachedShaders(UInt32 program, UInt32 maxCount, ref UInt32 count, ref UInt32 shaders);
        public delegate Int32 _glGetAttribLocation(UInt32 program, [MarshalAs(UnmanagedType.LPStr)]string name);
        public delegate void _glGetBooleanv(GetPName pname, bool[] data);
        public delegate void _glGetBufferParameteriv(BufferTarget target, BufferParameter pname, ref Int32 data);
        public delegate ErrorCode _glGetError();
        public delegate void _glGetFloatv(GetPName pname, float[] data);
        private delegate void _glGetFramebufferAttachmentParameteriv(int target, FramebufferAttachment attachment, FramebufferParameter pname, ref Int32 data);
        public delegate void _glGetIntegerv(GetPName pname, int[] data);
        private delegate void _glGetProgramInfoLog(UInt32 program, Int32 bufSize, ref Int32 length, StringBuilder infoLog);
        private delegate void _glGetProgramiv(UInt32 program, ProgramInfoParam pname, ref Int32 data);
        private delegate void _glGetRenderbufferParameteriv(uint target, RenderBufferParam pname, ref Int32 data);
        private delegate void _glGetShaderInfoLog(UInt32 shader, Int32 bufSize, ref Int32 length, [MarshalAs(UnmanagedType.LPStr)]StringBuilder infoLog);
        public delegate void _glGetShaderPrecisionFormat(ShaderType shadertype, PrecisionType precisiontype, ref Int32 range, ref Int32 precision);
        private delegate void _glGetShaderSource(UInt32 shader, Int32 bufSize, ref Int32 length, StringBuilder infoLog);
        private delegate void _glGetShaderiv(UInt32 shader, ShaderParam pname, ref Int32 data);

        private delegate IntPtr _glGetString(StringName name);

        public delegate void _glGetTexParameterfv(TextureType target, TextureParameter pname, ref float param);
        public delegate void _glGetTexParameteriv(TextureType target, TextureParameter pname, ref Int32 param);
        public delegate Int32 _glGetUniformLocation(UInt32 program, string name);
        public delegate void _glGetUniformfv(UInt32 program, Int32 location, float[] param);
        public delegate void _glGetUniformiv(UInt32 program, Int32 location, int[] param);
        public delegate void _glGetVertexAttribfv(UInt32 index, VertexAttribParam pname, ref float param);
        public delegate void _glGetVertexAttribiv(UInt32 index, VertexAttribParam pname, ref Int32 param);
        public delegate void _glHint(HintTarget target, HintMode mode);
        public delegate Boolean _glIsBuffer(UInt32 buffer);
        public delegate Boolean _glIsEnabled(EnableCap cap);
        public delegate Boolean _glIsFramebuffer(UInt32 framebuffer);
        public delegate Boolean _glIsProgram(UInt32 program);
        public delegate Boolean _glIsRenderbuffer(UInt32 renderbuffer);
        public delegate Boolean _glIsShader(UInt32 shader);
        public delegate Boolean _glIsTexture(uint texture);
        public delegate void _glLineWidth(float width);
        public delegate void _glLinkProgram(UInt32 program);
        public delegate void _glPixelStorei(PixelStoreParameter pname, Int32 param);
        public delegate void _glPolygonOffset(float factor, float units);
        public delegate void _glReadPixels(int x, int y, UInt32 width, UInt32 height, PixelFormat format, PixelType type, ValueType[] pixels);
        public delegate void _glReleaseShaderCompiler();
        private delegate void _glRenderbufferStorage(int target, RenderbufferStorageFormat internalformat, UInt32 width, UInt32 height);
        public delegate void _glSampleCoverage(float value, Boolean invert);
        public delegate void _glScissor(int x, int y, UInt32 width, UInt32 height);
        public delegate void _glShaderBinary(UInt32 count, ref UInt32 shaders, UInt32 binaryformat, byte[] binary, UInt32 length);
        private delegate void _glShaderSource(UInt32 shader, UInt32 count, [In] ref String str, ref Int32 length);
        public delegate void _glStencilFunc(StencilFunction func, int reference, uint mask);
        public delegate void _glStencilFuncSeparate(FaceMode face, StencilFunction func, int reference, uint mask);
        public delegate void _glStencilMask(uint mask);
        public delegate void _glStencilMaskSeparate(FaceMode face, uint mask);
        public delegate void _glStencilOp(StencilOpType fail, StencilOpType zfail, StencilOpType zpass);
        public delegate void _glStencilOpSeparate(FaceMode face, StencilOpType sfail, StencilOpType dpfail, StencilOpType dppass);
        public delegate void _glTexImage2D(TextureTarget target, Int32 level, InternalPixelFormat internalformat, Int32 width, Int32 height, Int32 border, PixelFormat format, PixelType type, IntPtr pixels);
        public delegate void _glTexParameterf(TextureType target, TextureParameter pname, float param);
        public delegate void _glTexParameterfv(TextureTarget target, TextureParameter pname, ref float param);
        public delegate void _glTexParameteri(TextureTarget target, TextureParameter pname, Int32 param);
        public delegate void _glTexParameteriv(TextureTarget target, TextureParameter pname, ref Int32 param);
        public delegate void _glTexSubImage2D(TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, PixelFormat format, PixelType type, IntPtr pixels);
        public delegate void _glUniform1f(Int32 location, float v0);
        public delegate void _glUniform1fv(Int32 location, UInt32 count, float[] value);
        public delegate void _glUniform1i(Int32 location, Int32 v0);
        public delegate void _glUniform1iv(Int32 location, UInt32 count, int[] value);
        public delegate void _glUniform2f(Int32 location, float v0, float v1);
        public delegate void _glUniform2fv(Int32 location, UInt32 count, float[] value);
        public delegate void _glUniform2i(Int32 location, Int32 v0, Int32 v1);
        public delegate void _glUniform2iv(Int32 location, UInt32 count, int[] value);
        public delegate void _glUniform3f(Int32 location, float v0, float v1, float v2);
        public delegate void _glUniform3fv(Int32 location, UInt32 count, float[] value);
        public delegate void _glUniform3i(Int32 location, Int32 v0, Int32 v1, Int32 v2);
        public delegate void _glUniform3iv(Int32 location, UInt32 count, int[] value);
        public delegate void _glUniform4f(Int32 location, float v0, float v1, float v2, float v3);
        public delegate void _glUniform4fv(Int32 location, UInt32 count, float[] value);
        public delegate void _glUniform4i(Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3);
        public delegate void _glUniform4iv(Int32 location, UInt32 count, int[] value);
        public delegate void _glUniformMatrix2fv(Int32 location, UInt32 count, Boolean transpose, float[] value);
        public delegate void _glUniformMatrix3fv(Int32 location, UInt32 count, Boolean transpose, ref MathUtils.Matrix3 value);
        public delegate void _glUniformMatrix4fv(Int32 location, UInt32 count, Boolean transpose, params MathUtils.Matrix4[] value);
        public delegate void _glUseProgram(UInt32 program);
        public delegate void _glValidateProgram(UInt32 program);
        public delegate void _glVertexAttrib1f(UInt32 index, float x);
        public delegate void _glVertexAttrib1fv(UInt32 index, float[] v);
        public delegate void _glVertexAttrib2f(UInt32 index, float x, float y);
        public delegate void _glVertexAttrib2fv(UInt32 index, float[] v);
        public delegate void _glVertexAttrib3f(UInt32 index, float x, float y, float z);
        public delegate void _glVertexAttrib3fv(UInt32 index, float[] v);
        public delegate void _glVertexAttrib4f(UInt32 index, float x, float y, float z, float w);
        public delegate void _glVertexAttrib4fv(UInt32 index, float[] v);
        public delegate void _glVertexAttribPointer(Int32 index, Int32 size, VertexPointerType type, Boolean normalized, Int32 stride, int pointer);
        public delegate void _glViewport(Int32 x, Int32 y, Int32 width, Int32 height);

        /// <summary>
        /// OES_vertex_array_object
        /// </summary>
        public delegate void _glBindVertexArrayOES(uint array);
        public delegate void _glDeleteVertexArraysOES(int n, ref uint arr);
        public delegate void _glGenVertexArrayOES(int n, ref uint arr);
        public delegate bool _glIsVertexArrayOES(uint array);


        public static _glActiveTexture ActiveTexture;
        public static _glAttachShader AttachShader;
        public static _glBindAttribLocation BindAttribLocation;
        public static _glBindBuffer BindBuffer;
        private static _glBindFramebuffer _BindFramebuffer;
        public static void BindFramebuffer(uint framebuffer)
        {
            //FRAMEBUFFER
            _BindFramebuffer(0x8D40, framebuffer);
        }
        private static _glBindRenderbuffer _BindRenderbuffer;
        public static void BindRenderBuffer(uint renderbuffer)
        {
            //RENDERBUFFER
            _BindRenderbuffer(0x8D41, renderbuffer);
        }

        public static _glBindTexture BindTexture;
        public static _glBlendColor BlendColor;
        public static _glBlendEquation BlendEquation;
        public static _glBlendEquationSeparate BlendEquationSeparate;
        public static _glBlendFunc BlendFunc;
        public static _glBlendFuncSeparate BlendFuncSeparate;
        private static _glBufferData _BufferData;
        public static _glBufferSubData BufferSubData;
        private static _glCheckFramebufferStatus _CheckFramebufferStatus;
        public static FramebufferStatus CheckFrameBufferStatus()
        {
            //FRAMEBUFFER
            return _CheckFramebufferStatus(0x8D40);
        }
        public static _glClear Clear;
        public static _glClearColor ClearColor;
        public static _glClearDepthf ClearDepthf;
        public static _glClearStencil ClearStencil;
        public static _glColorMask ColorMask;
        public static _glCompileShader CompileShader;
        public static _glCompressedTexImage2D CompressedTexImage2D;
        public static _glCompressedTexSubImage2D CompressedTexSubImage2D;
        public static _glCopyTexImage2D CopyTexImage2D;
        public static _glCopyTexSubImage2D CopyTexSubImage2D;
        public static _glCreateProgram CreateProgram;
        public static _glCreateShader CreateShader;
        public static _glCullFace CullFace;
        private static _glDeleteBuffers _DeleteBuffers;
        public static void DeleteBuffer(uint buffer)
        {
            _DeleteBuffers(1, ref buffer);
        }
        private static _glDeleteFramebuffers _DeleteFramebuffers;
        public static void DeleteFramebuffer(uint framebuffer)
        {
            _DeleteFramebuffers(1, ref framebuffer);
        }
        public static _glDeleteProgram DeleteProgram;
        private static _glDeleteRenderbuffers _DeleteRenderbuffers;
        public static void DeleteRenderbuffer(uint buffer)
        {
            _DeleteRenderbuffers(1, ref buffer);
        }
        public static _glDeleteShader DeleteShader;
        private static _glDeleteTextures _DeleteTextures;
        public static void DeleteTexture(uint text)
        {
            _DeleteTextures(1, ref text);
        }
        public static _glDepthFunc DepthFunc;
        public static _glDepthMask DepthMask;
        public static _glDepthRangef DepthRangef;
        public static _glDetachShader DetachShader;
        public static _glDisable Disable;
        public static _glDisableVertexAttribArray DisableVertexAttribArray;
        public static _glDrawArrays DrawArrays;
        public static _glDrawElements DrawElements;
        public static _glEnable Enable;
        public static _glEnableVertexAttribArray EnableVertexAttribArray;
        public static _glFinish Finish;
        public static _glFlush Flush;
        private static _glFramebufferRenderbuffer _FramebufferRenderbuffer;
        public static void FrameBufferRenderBuffer(FramebufferAttachment attachment, uint renderbuffer)
        {
            _FramebufferRenderbuffer(FRAMEBUFFER, attachment, RENDERBUFFER, renderbuffer);
        }
        private static _glFramebufferTexture2D _FramebufferTexture2D;
        public static void FramebufferTexture2D(FramebufferAttachment attachment, TextureTarget target, uint texture)
        {
            _FramebufferTexture2D(FRAMEBUFFER, attachment, target, texture, 0);
        }
        public static _glFrontFace FrontFace;
        public static _glGenBuffers GenBuffers;
        public static int GenBuffer()
        {
            int res = 0;
            GenBuffers(1, ref res);
            return  res;
        }
        public static _glGenFramebuffers GenFramebuffers;
        public static int GenFramebuffer()
        {
            int res = 0;
            GenFramebuffers(1, ref res);
            return res;
        }
        public static _glGenRenderbuffers GenRenderbuffers;
        public static int GenRenderbuffer()
        {
            int res = 0;
            GenRenderbuffers(1, ref res);
            return res;
        }
        public static _glGenTextures GenTextures;
        public static int GenTexture()
        {
            int res = 0;
            GenTextures(1, ref res);
            return res;
        }
        public static _glGenerateMipmap GenerateMipmap;
        public static _glGetActiveAttrib GetActiveAttrib;
        public static _glGetActiveUniform GetActiveUniform;
        public static _glGetAttachedShaders GetAttachedShaders;
        public static _glGetAttribLocation GetAttribLocation;
        public static _glGetBooleanv GetBooleanv;
        public static _glGetBufferParameteriv GetBufferParameteriv;
        public static _glGetError GetError;
        public static _glGetFloatv GetFloatv;
        private static _glGetFramebufferAttachmentParameteriv _GetFramebufferAttachmentParameteriv;
        public static int GetFramebufferAttachmentParameteriv(FramebufferAttachment attachment, FramebufferParameter pname)
        {
            int res = 0;
            _GetFramebufferAttachmentParameteriv(FRAMEBUFFER, attachment, pname, ref res);
            return res;
        }
        public static _glGetIntegerv GetIntegerv;
        private static _glGetProgramInfoLog _GetProgramInfoLog;
        public static string GetProgramInfoLog(uint program)
        {
            builder.Clear();
            int length = 0;
            _GetProgramiv(program, ProgramInfoParam.INFO_LOG_LENGTH, ref length);
            builder.EnsureCapacity(length);
            _GetProgramInfoLog(program, length, ref length, builder);
            return builder.ToString();
        }
        private static _glGetProgramiv _GetProgramiv;
        public static int GetProgramiv(uint program, ProgramInfoParam pname)
        {
            int res=0;
            _GetProgramiv(program, pname, ref res);
            return res;
        }
        private static _glGetRenderbufferParameteriv _GetRenderbufferParameteriv;
        public static int GetRenderbufferParameter(RenderBufferParam pname)
        {
            int res = 0;
            _GetRenderbufferParameteriv(RENDERBUFFER, pname, ref res);
            return res;
        } 
        private static _glGetShaderInfoLog _GetShaderInfoLog;
        public static _glGetShaderPrecisionFormat GetShaderPrecisionFormat;
        private static _glGetShaderSource _GetShaderSource;
        private static _glGetShaderiv _GetShaderiv;
        private static _glGetString _GetString;
        public static string GetString(StringName str)
        {
            var res = _GetString(str);
            return Marshal.PtrToStringAnsi(res);
        }
        public static _glGetTexParameterfv GetTexParameterfv;
        public static _glGetTexParameteriv GetTexParameteriv;
        public static _glGetUniformLocation GetUniformLocation;
        public static _glGetUniformfv GetUniformfv;
        public static _glGetUniformiv GetUniformiv;
        public static _glGetVertexAttribfv GetVertexAttribfv;
        public static _glGetVertexAttribiv GetVertexAttribiv;
        public static _glHint Hint;
        public static _glIsBuffer IsBuffer;
        public static _glIsEnabled IsEnabled;
        public static _glIsFramebuffer IsFramebuffer;
        public static _glIsProgram IsProgram;
        public static _glIsRenderbuffer IsRenderbuffer;
        public static _glIsShader IsShader;
        public static _glIsTexture IsTexture;
        public static _glLineWidth LineWidth;
        public static _glLinkProgram LinkProgram;
        public static _glPixelStorei PixelStorei;
        public static _glPolygonOffset PolygonOffset;
        public static _glReadPixels ReadPixels;
        public static _glReleaseShaderCompiler ReleaseShaderCompiler;
        private static _glRenderbufferStorage _RenderbufferStorage;
        public static void RenderBufferStorage(RenderbufferStorageFormat format, uint width, uint height)
        {
            _RenderbufferStorage(RENDERBUFFER, format, width, height);
        }
        public static _glSampleCoverage SampleCoverage;
        public static _glScissor Scissor;
        public static _glShaderBinary ShaderBinary;
        private static _glShaderSource _ShaderSource;
        public static _glStencilFunc StencilFunc;
        public static _glStencilFuncSeparate StencilFuncSeparate;
        public static _glStencilMask StencilMask;
        public static _glStencilMaskSeparate StencilMaskSeparate;
        public static _glStencilOp StencilOp;
        public static _glStencilOpSeparate StencilOpSeparate;
        public static _glTexImage2D TexImage2D;
        public static _glTexParameterf TexParameterf;
        public static _glTexParameterfv TexParameterfv;
        public static _glTexParameteri TexParameteri;
        public static _glTexParameteriv TexParameteriv;
        public static _glTexSubImage2D TexSubImage2D;
        public static _glUniform1f Uniform1f;
        public static _glUniform1fv Uniform1fv;
        public static _glUniform1i Uniform1i;
        public static _glUniform1iv Uniform1iv;
        public static _glUniform2f Uniform2f;
        public static _glUniform2fv Uniform2fv;
        public static _glUniform2i Uniform2i;
        public static _glUniform2iv Uniform2iv;
        public static _glUniform3f Uniform3f;
        public static _glUniform3fv Uniform3fv;
        public static _glUniform3i Uniform3i;
        public static _glUniform3iv Uniform3iv;
        public static _glUniform4f Uniform4f;
        public static _glUniform4fv Uniform4fv;
        public static _glUniform4i Uniform4i;
        public static _glUniform4iv Uniform4iv;
        public static _glUniformMatrix2fv UniformMatrix2fv;
        public static _glUniformMatrix3fv UniformMatrix3fv;
        public static _glUniformMatrix4fv UniformMatrix4fv;
        public static _glUseProgram UseProgram;
        public static _glValidateProgram ValidateProgram;
        public static _glVertexAttrib1f VertexAttrib1f;
        public static _glVertexAttrib1fv VertexAttrib1fv;
        public static _glVertexAttrib2f VertexAttrib2f;
        public static _glVertexAttrib2fv VertexAttrib2fv;
        public static _glVertexAttrib3f VertexAttrib3f;
        public static _glVertexAttrib3fv VertexAttrib3fv;
        public static _glVertexAttrib4f VertexAttrib4f;
        public static _glVertexAttrib4fv VertexAttrib4fv;
        public static _glVertexAttribPointer VertexAttribPointer;
        public static _glViewport Viewport;

        /// <summary>
        /// OES_vertex_array_object
        /// </summary>
        public static _glBindVertexArrayOES BindVertexArray;
        private static _glDeleteVertexArraysOES _DeleteVertexArray;
        public static uint DeleteVertexArray()
        {
            uint res = 0;
            _DeleteVertexArray(1, ref res);
            return res;
        }
        private static _glGenVertexArrayOES _GenVertexArray;
        public static uint GenVertexArray()
        {
            uint res = 0;
            _GenVertexArray(1, ref res);
            return res;
        }
        public static _glIsVertexArrayOES IsVertexArray;

        public static void ShaderSource(uint shader, string source)
        {
            int l = source.Length;
            _ShaderSource(shader, 1, ref source, ref l);
        }
        public static string GetShaderSource(uint shader)
        {
            builder.Clear();
            int length = 0;
            _GetShaderiv(shader, ShaderParam.SHADER_SOURCE_LENGTH, ref length);
            builder.EnsureCapacity(length);
            _GetShaderSource(shader, length, ref length, builder);
            return builder.ToString();
        }
        /// <summary>
        /// We can use shared object, since we have to access gl from one thread
        /// </summary>
        private static StringBuilder builder = new StringBuilder(256);
        public static string GetShaderInfoLog(uint shader)
        {
            builder.Clear();
            int length = 0;
            _GetShaderiv(shader, ShaderParam.INFO_LOG_LENGTH, ref length);
            builder.EnsureCapacity(length);
            _GetShaderInfoLog(shader,length,ref length, builder);
            return builder.ToString();
        }
        public static int GetShaderiv(uint shader, ShaderParam param)
        {
            int res = 0;
            _GetShaderiv(shader, param, ref res);
            return res;
        }
        public static void BufferData<T>(BufferTarget target, uint size, T[] data, BufferUsage usage) where T : struct
        {
            unsafe
            {
                IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
                _BufferData(target, size, ptr.ToPointer(), usage);
             }
        }
       
        public static void Load(Func<string,IntPtr> loadFunc)
        {
            Loader = loadFunc;
            ActiveTexture = GetProc<_glActiveTexture>("glActiveTexture");
            AttachShader = GetProc<_glAttachShader>("glAttachShader");
            BindAttribLocation = GetProc<_glBindAttribLocation>("glBindAttribLocation");
            BindBuffer = GetProc<_glBindBuffer>("glBindBuffer");
            _BindFramebuffer = GetProc<_glBindFramebuffer>("glBindFramebuffer");
            _BindRenderbuffer = GetProc<_glBindRenderbuffer>("glBindRenderbuffer");
            BindTexture = GetProc<_glBindTexture>("glBindTexture");
            BlendColor = GetProc<_glBlendColor>("glBlendColor");
            BlendEquation = GetProc<_glBlendEquation>("glBlendEquation");
            BlendEquationSeparate = GetProc<_glBlendEquationSeparate>("glBlendEquationSeparate");
            BlendFunc = GetProc<_glBlendFunc>("glBlendFunc");
            BlendFuncSeparate = GetProc<_glBlendFuncSeparate>("glBlendFuncSeparate");
            _BufferData = GetProc<_glBufferData>("glBufferData");
            BufferSubData = GetProc<_glBufferSubData>("glBufferSubData");
            _CheckFramebufferStatus = GetProc<_glCheckFramebufferStatus>("glCheckFramebufferStatus");
            Clear = GetProc<_glClear>("glClear");
            ClearColor = GetProc<_glClearColor>("glClearColor");
            ClearDepthf = GetProc<_glClearDepthf>("glClearDepthf");
            ClearStencil = GetProc<_glClearStencil>("glClearStencil");
            ColorMask = GetProc<_glColorMask>("glColorMask");
            CompileShader = GetProc<_glCompileShader>("glCompileShader");
            CompressedTexImage2D = GetProc<_glCompressedTexImage2D>("glCompressedTexImage2D");
            CompressedTexSubImage2D = GetProc<_glCompressedTexSubImage2D>("glCompressedTexSubImage2D");
            CopyTexImage2D = GetProc<_glCopyTexImage2D>("glCopyTexImage2D");
            CopyTexSubImage2D = GetProc<_glCopyTexSubImage2D>("glCopyTexSubImage2D");
            CreateProgram = GetProc<_glCreateProgram>("glCreateProgram");
            CreateShader = GetProc<_glCreateShader>("glCreateShader");
            CullFace = GetProc<_glCullFace>("glCullFace");
            _DeleteBuffers = GetProc<_glDeleteBuffers>("glDeleteBuffers");
            _DeleteFramebuffers = GetProc<_glDeleteFramebuffers>("glDeleteFramebuffers");
            DeleteProgram = GetProc<_glDeleteProgram>("glDeleteProgram");
            _DeleteRenderbuffers = GetProc<_glDeleteRenderbuffers>("glDeleteRenderbuffers");
            DeleteShader = GetProc<_glDeleteShader>("glDeleteShader");
            _DeleteTextures = GetProc<_glDeleteTextures>("glDeleteTextures");
            DepthFunc = GetProc<_glDepthFunc>("glDepthFunc");
            DepthMask = GetProc<_glDepthMask>("glDepthMask");
            DepthRangef = GetProc<_glDepthRangef>("glDepthRangef");
            DetachShader = GetProc<_glDetachShader>("glDetachShader");
            Disable = GetProc<_glDisable>("glDisable");
            DisableVertexAttribArray = GetProc<_glDisableVertexAttribArray>("glDisableVertexAttribArray");
            DrawArrays = GetProc<_glDrawArrays>("glDrawArrays");
            DrawElements = GetProc<_glDrawElements>("glDrawElements");
            Enable = GetProc<_glEnable>("glEnable");
            EnableVertexAttribArray = GetProc<_glEnableVertexAttribArray>("glEnableVertexAttribArray");
            Finish = GetProc<_glFinish>("glFinish");
            Flush = GetProc<_glFlush>("glFlush");
            _FramebufferRenderbuffer = GetProc<_glFramebufferRenderbuffer>("glFramebufferRenderbuffer");
            _FramebufferTexture2D = GetProc<_glFramebufferTexture2D>("glFramebufferTexture2D");
            FrontFace = GetProc<_glFrontFace>("glFrontFace");
            GenBuffers = GetProc<_glGenBuffers>("glGenBuffers");
            GenFramebuffers = GetProc<_glGenFramebuffers>("glGenFramebuffers");
            GenRenderbuffers = GetProc<_glGenRenderbuffers>("glGenRenderbuffers");
            GenTextures = GetProc<_glGenTextures>("glGenTextures");
            GenerateMipmap = GetProc<_glGenerateMipmap>("glGenerateMipmap");
            GetActiveAttrib = GetProc<_glGetActiveAttrib>("glGetActiveAttrib");
            GetActiveUniform = GetProc<_glGetActiveUniform>("glGetActiveUniform");
            GetAttachedShaders = GetProc<_glGetAttachedShaders>("glGetAttachedShaders");
            GetAttribLocation = GetProc<_glGetAttribLocation>("glGetAttribLocation");
            GetBooleanv = GetProc<_glGetBooleanv>("glGetBooleanv");
            GetBufferParameteriv = GetProc<_glGetBufferParameteriv>("glGetBufferParameteriv");
            GetError = GetProc<_glGetError>("glGetError");
            GetFloatv = GetProc<_glGetFloatv>("glGetFloatv");
            _GetFramebufferAttachmentParameteriv = GetProc<_glGetFramebufferAttachmentParameteriv>("glGetFramebufferAttachmentParameteriv");
            GetIntegerv = GetProc<_glGetIntegerv>("glGetIntegerv");
            _GetProgramInfoLog = GetProc<_glGetProgramInfoLog>("glGetProgramInfoLog");
            _GetProgramiv = GetProc<_glGetProgramiv>("glGetProgramiv");
            _GetRenderbufferParameteriv = GetProc<_glGetRenderbufferParameteriv>("glGetRenderbufferParameteriv");
            _GetShaderInfoLog = GetProc<_glGetShaderInfoLog>("glGetShaderInfoLog");
            GetShaderPrecisionFormat = GetProc<_glGetShaderPrecisionFormat>("glGetShaderPrecisionFormat");
            _GetShaderSource = GetProc<_glGetShaderSource>("glGetShaderSource");
            _GetShaderiv = GetProc<_glGetShaderiv>("glGetShaderiv");
            _GetString = GetProc<_glGetString>("glGetString");
            GetTexParameterfv = GetProc<_glGetTexParameterfv>("glGetTexParameterfv");
            GetTexParameteriv = GetProc<_glGetTexParameteriv>("glGetTexParameteriv");
            GetUniformLocation = GetProc<_glGetUniformLocation>("glGetUniformLocation");
            GetUniformfv = GetProc<_glGetUniformfv>("glGetUniformfv");
            GetUniformiv = GetProc<_glGetUniformiv>("glGetUniformiv");
            GetVertexAttribfv = GetProc<_glGetVertexAttribfv>("glGetVertexAttribfv");
            GetVertexAttribiv = GetProc<_glGetVertexAttribiv>("glGetVertexAttribiv");
            Hint = GetProc<_glHint>("glHint");
            IsBuffer = GetProc<_glIsBuffer>("glIsBuffer");
            IsEnabled = GetProc<_glIsEnabled>("glIsEnabled");
            IsFramebuffer = GetProc<_glIsFramebuffer>("glIsFramebuffer");
            IsProgram = GetProc<_glIsProgram>("glIsProgram");
            IsRenderbuffer = GetProc<_glIsRenderbuffer>("glIsRenderbuffer");
            IsShader = GetProc<_glIsShader>("glIsShader");
            IsTexture = GetProc<_glIsTexture>("glIsTexture");
            LineWidth = GetProc<_glLineWidth>("glLineWidth");
            LinkProgram = GetProc<_glLinkProgram>("glLinkProgram");
            PixelStorei = GetProc<_glPixelStorei>("glPixelStorei");
            PolygonOffset = GetProc<_glPolygonOffset>("glPolygonOffset");
            ReadPixels = GetProc<_glReadPixels>("glReadPixels");
            ReleaseShaderCompiler = GetProc<_glReleaseShaderCompiler>("glReleaseShaderCompiler");
            _RenderbufferStorage = GetProc<_glRenderbufferStorage>("glRenderbufferStorage");
            SampleCoverage = GetProc<_glSampleCoverage>("glSampleCoverage");
            Scissor = GetProc<_glScissor>("glScissor");
            ShaderBinary = GetProc<_glShaderBinary>("glShaderBinary");
            _ShaderSource = GetProc<_glShaderSource>("glShaderSource");
            StencilFunc = GetProc<_glStencilFunc>("glStencilFunc");
            StencilFuncSeparate = GetProc<_glStencilFuncSeparate>("glStencilFuncSeparate");
            StencilMask = GetProc<_glStencilMask>("glStencilMask");
            StencilMaskSeparate = GetProc<_glStencilMaskSeparate>("glStencilMaskSeparate");
            StencilOp = GetProc<_glStencilOp>("glStencilOp");
            StencilOpSeparate = GetProc<_glStencilOpSeparate>("glStencilOpSeparate");
            TexImage2D = GetProc<_glTexImage2D>("glTexImage2D");
            TexParameterf = GetProc<_glTexParameterf>("glTexParameterf");
            TexParameterfv = GetProc<_glTexParameterfv>("glTexParameterfv");
            TexParameteri = GetProc<_glTexParameteri>("glTexParameteri");
            TexParameteriv = GetProc<_glTexParameteriv>("glTexParameteriv");
            TexSubImage2D = GetProc<_glTexSubImage2D>("glTexSubImage2D");
            Uniform1f = GetProc<_glUniform1f>("glUniform1f");
            Uniform1fv = GetProc<_glUniform1fv>("glUniform1fv");
            Uniform1i = GetProc<_glUniform1i>("glUniform1i");
            Uniform1iv = GetProc<_glUniform1iv>("glUniform1iv");
            Uniform2f = GetProc<_glUniform2f>("glUniform2f");
            Uniform2fv = GetProc<_glUniform2fv>("glUniform2fv");
            Uniform2i = GetProc<_glUniform2i>("glUniform2i");
            Uniform2iv = GetProc<_glUniform2iv>("glUniform2iv");
            Uniform3f = GetProc<_glUniform3f>("glUniform3f");
            Uniform3fv = GetProc<_glUniform3fv>("glUniform3fv");
            Uniform3i = GetProc<_glUniform3i>("glUniform3i");
            Uniform3iv = GetProc<_glUniform3iv>("glUniform3iv");
            Uniform4f = GetProc<_glUniform4f>("glUniform4f");
            Uniform4fv = GetProc<_glUniform4fv>("glUniform4fv");
            Uniform4i = GetProc<_glUniform4i>("glUniform4i");
            Uniform4iv = GetProc<_glUniform4iv>("glUniform4iv");
            UniformMatrix2fv = GetProc<_glUniformMatrix2fv>("glUniformMatrix2fv");
            UniformMatrix3fv = GetProc<_glUniformMatrix3fv>("glUniformMatrix3fv");
            UniformMatrix4fv = GetProc<_glUniformMatrix4fv>("glUniformMatrix4fv");
            UseProgram = GetProc<_glUseProgram>("glUseProgram");
            ValidateProgram = GetProc<_glValidateProgram>("glValidateProgram");
            VertexAttrib1f = GetProc<_glVertexAttrib1f>("glVertexAttrib1f");
            VertexAttrib1fv = GetProc<_glVertexAttrib1fv>("glVertexAttrib1fv");
            VertexAttrib2f = GetProc<_glVertexAttrib2f>("glVertexAttrib2f");
            VertexAttrib2fv = GetProc<_glVertexAttrib2fv>("glVertexAttrib2fv");
            VertexAttrib3f = GetProc<_glVertexAttrib3f>("glVertexAttrib3f");
            VertexAttrib3fv = GetProc<_glVertexAttrib3fv>("glVertexAttrib3fv");
            VertexAttrib4f = GetProc<_glVertexAttrib4f>("glVertexAttrib4f");
            VertexAttrib4fv = GetProc<_glVertexAttrib4fv>("glVertexAttrib4fv");
            VertexAttribPointer = GetProc<_glVertexAttribPointer>("glVertexAttribPointer");
            Viewport = GetProc<_glViewport>("glViewport");

        }
        private static Func<string, IntPtr> Loader;
        private static T GetProc<T>(string v)
        {
            
            IntPtr ptr = Loader(v);
            if(ptr == IntPtr.Zero)
            {
                Logger.Debug("could not obtain address of: " + v);
                return default(T);
            }
            return (T)Convert.ChangeType( Marshal.GetDelegateForFunctionPointer(ptr, typeof(T)),typeof(T));
           
          
        }

        #endregion




    }
}
