using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFG.Utils;
using System.IO.Compression;

namespace XFG.Utils
{
    internal class BufferStream : Stream
    {
        public BufferStream(byte[] buffer)
        {
            Buffer = buffer;
        }
        private byte[] _buffer;
        public byte[] Buffer
        {
            get
            {
                return _buffer;
            }
            set
            {
                _buffer = value;

            }
        }
        private long position;
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        public override bool CanWrite
        {
            get
            { 
                return false;
            }
        }

        public override long Length
        {
            get
            {
                return Buffer.Length;
            }
        }

        public override long Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public override void Flush()
        {
        }
        public bool Empty
        {
            get
            {
                return Position == Length;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
           int read = (int)Math.Max(Math.Min(count, Buffer.Length - Position),0);
           System.Buffer.BlockCopy(Buffer,(int) position, buffer, offset, read);
           Position += read;
           return read;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.Begin)
                Position = offset;
            else if (origin == SeekOrigin.End)
            {
                position = Length + offset;
            }
            else
                position += offset;
            return offset;
        }

        public override void SetLength(long value)
        {
        }

        public override void Write(byte[] buffer, int offset, int count)
        {

        }
    }
    /// <summary>
    /// Simple PNG loader
    /// </summary>
    public class PNG
    {
        private enum PNGColorType : byte
        {
            Greyscale = 0,
            Truecolor = 2,
            Indexed = 3,
            GreyscaleAlpha = 4,
            TruecolorAlpha = 6,
        }
        private static byte[] SIGNATURE = { 137, 80, 78, 71, 13, 10, 26, 10 };
        private enum ChunkType : uint
        {
            IHDR = 0x49484452,
            PLTE = 0x504c5445,
            IDAT = 0x49444154,
            IEND = 0x49454e44,
            TRNS = 0x74524e53,
        }

        private const int RGBABPP = 4;
        private const int RGBBPP = 3;
        
        public int Width;
        public int Height;

        private int BitDepth = 0;
        private int BitsPerPixel = 0;
        private PNGColorType ColorType;
        private FileStream file;
        private byte[] buffer;
        private byte[] Palette;
        private byte[] APalette;

        private DeflateStream decompressStream;
        private BufferStream dataStream;

        private int ChunkLength = 0;
        private int ChunkUnread = 0;
        private ChunkType chunkType = 0;
        private long DataBegin = 0;


        private bool firstRead = true;
        private byte[] _scanline;
        private byte[] _prevScanLine;

        /// <summary>
        /// Creates new PNG reader, that will read data from provided file
        /// </summary>
        /// <param name="filename"></param>
        public PNG(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException();
            file = File.OpenRead(filename);
            buffer = new byte[8192];
            file.Read(buffer, 0, SIGNATURE.Length);
            if (!Compare(buffer, 0, SIGNATURE, 0, SIGNATURE.Length))
                throw new IOException("Invalid png file");

            ReadChunk();
            ReadIHDR();
            while (true)
            {
                ReadChunk();
                if (chunkType == ChunkType.IDAT)
                    break;
                else if (chunkType == ChunkType.IEND)
                    throw new IOException("No Idat chunks");
                else if (chunkType == ChunkType.PLTE)
                    ReadPLTE();
                else if (chunkType == ChunkType.TRNS)
                    ReadTRNS();
                else
                {
                    if (ChunkUnread > 0)
                    {
                        //If it is unknown chunk with that is bigger than buffer, we just dump the data.
                        file.Seek(ChunkUnread + 4, SeekOrigin.Current);
                        ChunkUnread = 0;
                    }
                }
            }
            DataBegin = file.Position - 8;
        }
        /// <summary>
        /// Reads numLines from file and puts in buffer, useful for loading image by parts
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numLines"></param>
        public void ReadScanlinesRGBA(ref byte[] result, int numLines)
        {
            if (firstRead)
            {
                file.Seek(DataBegin, SeekOrigin.Begin);
                ChunkLength = 0;
                ChunkUnread = 0;
                chunkType = ChunkType.IHDR;
                ReadChunkHeader();
                while (chunkType != ChunkType.IDAT)
                    ReadChunk();
                file.Seek(2, SeekOrigin.Current);
                ChunkLength -= 2;
                ChunkUnread -= 2;
                firstRead = false;
                DataRead();
                dataStream = new BufferStream(buffer);
                buffer = new byte[buffer.Length];
                DataRead();
                decompressStream = new System.IO.Compression.DeflateStream(dataStream, CompressionMode.Decompress);
                _scanline = new byte[(int)(Width * (BitsPerPixel / 8f)) + 1];
                _prevScanLine = new byte[_scanline.Length];
            }
            for (int y = 0; y < numLines; y++)
            {
                Extensions.Swap(ref _scanline, ref _prevScanLine);
                getScanline(_scanline);
                unfilter(_scanline, _prevScanLine);

                switch (ColorType)
                {
                    case PNGColorType.Greyscale:
                        GSToRGBA(result, _scanline, y);
                        break;
                    case PNGColorType.GreyscaleAlpha:
                        GSAToRGBA(result, _scanline, y);
                        break;
                    case PNGColorType.Indexed:
                        IndexedToRGBA(result, _scanline, y);
                        break;
                    case PNGColorType.Truecolor:
                        RGBToRGBA(result, _scanline, y);
                        break;
                    case PNGColorType.TruecolorAlpha:
                        RGBAToRGBA(result, _scanline, y);
                        break;
                    default:
                        Array.Copy(_scanline, 1, result, y * Width * 4, _scanline.Length - 1);
                        break;
                }
            }
        }
        /// <summary>
        /// Resets the reader, next reads will return pixels from start of the image
        /// </summary>
        public void ResetReader()
        {
            firstRead = true;
        }
        private void ReadIHDR()
        {
            if (chunkType != ChunkType.IHDR)
                throw new IOException("Unexpected chunk type");
            Width = parseInt(buffer, 0);
            Height = parseInt(buffer, 4);
            BitDepth = buffer[8];
            ColorType = (PNGColorType)buffer[9];
            if (buffer[10] != 0)
                throw new IOException("Unknown compression");
            if (buffer[11] != 0)
                throw new IOException("Unknown filter");
            if (buffer[12] != 0)
                throw new IOException("Interlaced PNGs not supported");
            switch (ColorType)
            {
                case PNGColorType.Greyscale:
                    BitsPerPixel = 1 * BitDepth;
                    if (BitDepth != 1 && BitDepth != 2 && BitDepth != 4 && BitDepth != 8 && BitDepth != 16)
                        throw new IOException("Invalid Bit depth");
                    break;
                case PNGColorType.GreyscaleAlpha:
                    BitsPerPixel = 2 * BitDepth;
                    if (BitDepth != 8 && BitDepth != 16)
                        throw new IOException("Invalid Bit depth");
                    break;
                case PNGColorType.Indexed:
                    BitsPerPixel = 1 * BitDepth;
                    if (BitDepth != 1 && BitDepth != 2 && BitDepth != 4 && BitDepth != 8)
                        throw new IOException("Invalid Bit depth");
                    break;
                case PNGColorType.Truecolor:
                    BitsPerPixel = 3 * BitDepth;
                    if (BitDepth != 8 && BitDepth != 16)
                        throw new IOException("Invalid Bit depth");
                    break;
                case PNGColorType.TruecolorAlpha:
                    if (BitDepth != 8 && BitDepth != 16)
                        throw new IOException("Invalid Bit depth");
                    BitsPerPixel = 4 * BitDepth;
                    break;
            }

        }
        private void ReadPLTE()
        {
            //We only use plte in indexed color mode.
            //PLTE chunk can appear in other modes(as a suggested palette).
            if (ColorType == PNGColorType.Indexed)
            {
                if (ChunkLength % 3 != 0)
                    throw new IOException("Invalid Palette chunk");
                Palette = new byte[ChunkLength];
                Array.Copy(buffer, 0, Palette, 0, ChunkLength);
                APalette = new byte[Palette.Length / 3];
                APalette.Fill((byte)255);
            }
        }
        private void ReadTRNS()
        {
            if (ColorType == PNGColorType.Indexed)
            {
                if (Palette == null)
                    throw new IOException("TRNS chunk must appear after PLTE chunk in indexed color mode");
                APalette = new byte[Palette.Length / 3];
                Array.Copy(buffer, 0, APalette, 0, APalette.Length);
            }
            if (ColorType == PNGColorType.Greyscale)
            {
                if (ChunkLength != 2)
                    throw new IOException("Invalid transparency chunk");
                APalette = new byte[2];
                Array.Copy(buffer, 0, APalette, 0, MathUtils.Math.Min(APalette.Length, ChunkLength));

            }
            if (ColorType == PNGColorType.Truecolor)
            {
                if (ChunkLength != 6)
                    throw new IOException("Invalid transparency chunk");
                APalette = new byte[6];
                Array.Copy(buffer, 0, APalette, 0, MathUtils.Math.Min(APalette.Length, ChunkLength));
            }
        }
        private void ReadChunkHeader()
        {
            if (ChunkUnread == 0)
            {
                file.Read(metaData, 0, 8);
                ChunkLength = parseInt(metaData, 0);
                chunkType =(ChunkType)parseInt(metaData, 4);
                ChunkUnread = ChunkLength;
            }
        }
        private void ReadChunkTrailer()
        {
            if(ChunkUnread==0)
            {
                file.Seek(4, SeekOrigin.Current);
            }
        }
        private byte[] metaData = new byte[8];
        private void ReadChunk()
        {
            ReadChunkHeader();
            if (chunkType != ChunkType.IDAT)
            {
                int read = file.Read(buffer, 0, Math.Min(ChunkLength, buffer.Length));
                ChunkUnread = ChunkLength - read;
            }
            ReadChunkTrailer();
        }
        private void DataRead()
        {
            
            lock(buffer)
            {
                ReadChunkHeader();
                int read = file.Read(buffer, 0, MathUtils.Math.Min(ChunkUnread < 0 ? 0 : ChunkUnread, buffer.Length));
                ChunkUnread -= read;
                while (read < buffer.Length && ChunkUnread == 0)
                {
                    ReadChunkTrailer();
                    ReadChunkHeader();
                    if (chunkType != ChunkType.IDAT)
                    {
                        break;//All data exhausted
                    }
                    
                    int newRead = file.Read(buffer, read, MathUtils.Math.Min(ChunkUnread, buffer.Length - read));
                    ChunkUnread -= newRead;
                    read += newRead;
                }
            }
        }
       

        private void GSToRGBA(byte[] buffer, byte[] scanline, int y)
        {
            bool transparency = APalette != null;
            bool notTransparency = APalette == null;
            if (BitDepth == 16)
            {
                for (int i = 0; i < Width; i++)
                {
                    int add = (y * Width + i) * RGBABPP;
                    buffer[add] = buffer[add + 1] = buffer[add + 2] = scanline[1 + i * 2];
                    buffer[add + 3] = (byte)(transparency && APalette[0] == scanline[1 + i * 2] && APalette[1] == scanline[2 + i * 2] ? 0 : 255);
                }
            }
            else
            {
                int samplesPerByte = 8 / BitDepth;//Amount of samples packed into one byte
                int sampleMask = samplesPerByte - 1; //used as aquick way to get remainder, samples will always be powers of two and a%b==a&(b-1)
                int lowmask = ((1 << BitDepth) - 1);
                int mask = ((1 << BitDepth) - 1) << (8 - BitDepth);// We need to create mask that has x upper bits set
                int addBase = y * Width * RGBABPP;
                for (int i = 0; i < Width; i++)
                {

                    int a = i / samplesPerByte;
                    int b = i & sampleMask;
                    int col = ((scanline[1 + a] << (b * BitDepth)) & mask);
                    col |= col >> BitDepth;
                    col |= col >> (BitDepth << 1);
                    col |= col >> (BitDepth << 2);
                    int add = addBase + i * RGBABPP;
                    buffer[add] = buffer[add + 1] = buffer[add + 2] = (byte)col;
                    buffer[add + 3] = (byte)(notTransparency ? 255 :
                        (col & lowmask) == (APalette[1] & lowmask) ? 0 : 255);

                }
            }
        }
        private void GSAToRGBA(byte[] buffer, byte[] scanline, int y)
        {
            int bpp = this.BitsPerPixel / 8;//Bytes per pixel
            int bps = BitDepth / 8;//bytes per sample
            for (int i = 0; i < Width; i++)
            {
                int add = (y * Width + i) * RGBABPP;
                buffer[add] = buffer[add + 1] = buffer[add + 2] = scanline[1 + (i * bpp)];
                buffer[add + 3] = scanline[1 + (i * bpp) + bps];
            }
        }
        private void IndexedToRGBA(byte[] buffer, byte[] scanline, int y)
        {
            int samplesPerByte = 8 / BitDepth;//Amount of samples packed into one byte
            int sampleMask = samplesPerByte - 1; //used as aquick way to get remainder, samples will always be powers of two and a%b==a&(b-1)
            int mask = (1 << BitDepth) - 1;// bitmask used to mask only
            int addBase = y * Width * RGBABPP;
            for (int i = 0; i < Width; i++)
            {

                int a = i / samplesPerByte;
                int b = i & sampleMask;
                int index = ((scanline[1 + a] >> (b * BitDepth)) & mask);
                int add = addBase + i * RGBABPP;
                buffer[add] = Palette[index * 3];
                buffer[add + 1] = Palette[index * 3 + 1];
                buffer[add + 2] = Palette[index * 3 + 2];
                buffer[add + 3] = APalette[index];
            }
        }
        private void RGBToRGBA(byte[] buffer, byte[] scanline, int y)
        {
            bool noTransparency = APalette == null;
            if (BitDepth == 8)
            {
                int baseAdd = y * Width * RGBABPP;
                for (int i = 0; i < Width; i++)
                {
                    int dstAdd = baseAdd + i * RGBABPP;

                    buffer[dstAdd] = scanline[i * RGBBPP + 1];
                    buffer[dstAdd + 1] = scanline[i * RGBBPP + 2];
                    buffer[dstAdd + 2] = scanline[i * RGBBPP + 3];
                    buffer[dstAdd + 3] = (byte)(noTransparency ? 255 :
                        APalette[1] == buffer[dstAdd] &&
                        APalette[3] == buffer[dstAdd + 1] &&
                        APalette[5] == buffer[dstAdd + 2]
                        ? 0 : 255);
                }
            }
            else
            {
                int baseAdd = y * Width * RGBABPP;
                int bpp = BitDepth / 8 * 3;
                int bps = BitDepth / 8;
                for (int i = 0; i < Width; i++)
                {
                    int dstAdd = baseAdd + i * RGBABPP;

                    buffer[dstAdd] = scanline[i * bpp + 1];
                    buffer[dstAdd + 1] = scanline[i * bpp + 3];
                    buffer[dstAdd + 2] = scanline[i * bpp + 5];
                    buffer[dstAdd + 3] = (byte)(noTransparency ? 255 :
                        APalette[0] == scanline[i * bpp + 1] &&
                        APalette[1] == scanline[i * bpp + 2] &&
                        APalette[2] == scanline[i * bpp + 3] &&
                        APalette[3] == scanline[i * bpp + 4] &&
                        APalette[4] == scanline[i * bpp + 5] &&
                        APalette[5] == scanline[i * bpp + 6]
                        ? 0 : 255);
                }
            }

        }
        private void RGBAToRGBA(byte[] buffer, byte[] scanline, int y)
        {
            if (BitDepth == 8)
            {
                Array.Copy(scanline, 1, buffer, y * Width * RGBABPP, scanline.Length - 1);
            }
            else
            {
                int baseAdd = y * Width * RGBABPP;
                int bpp = BitDepth / 8 * 4;
                for (int i = 0; i < Width; i++)
                {
                    int dstAdd = baseAdd + i * RGBABPP;

                    buffer[dstAdd] = scanline[i * bpp + 1];
                    buffer[dstAdd + 1] = scanline[i * bpp + 3];
                    buffer[dstAdd + 2] = scanline[i * bpp + 5];
                    buffer[dstAdd + 3] = scanline[i * bpp + 7];
                }

            }

        }
        private void unfilter(byte[] curLine, byte[] prevLine)
        {
            if (curLine[0] != 0)
            {
                int bpp = BitsPerPixel < 8 ? 1 : this.BitsPerPixel / 8;
                switch (curLine[0])
                {
                    case 1:
                        for (int i = bpp + 1; i < curLine.Length; i++)
                        {
                            curLine[i] += curLine[i - bpp];
                        }
                        break;
                    case 2:
                        for (int i = 1; i < curLine.Length; ++i)
                        {
                            curLine[i] += prevLine[i];
                        }
                        break;
                    case 3:
                        for (int i = 1; i < curLine.Length; i++)
                        {
                            curLine[i] += (byte)((prevLine[i] +
                                (i - bpp < 1 ? 0 : curLine[i - bpp])) / 2);
                        }
                        break;
                    case 4:
                        for (int i = 1; i < curLine.Length; i++)
                        {
                            int a = i - bpp < 1 ? 0 : curLine[i - bpp],
                                b = prevLine[i],
                                c = i - bpp < 1 ? 0 : prevLine[i - bpp];
                            int p = a + b - c,
                               pa = p > a ? (p - a) : (a - p),
                               pb = p > b ? (p - b) : (b - p),
                               pc = p > c ? (p - c) : (c - p);

                            curLine[i] += (byte)((pa <= pb && pa <= pc) ? a : pb <= pc ? b : c);
                        }
                        break;
                    default:
                        throw new IOException("invalid filter type in scanline: " + curLine[0]);
                }
            }
        }
        private void getScanline(byte[] scanline)
        {
            int read = decompressStream.Read(scanline, 0, scanline.Length);
            for (int i = 0;
                read != scanline.Length && i < 64;
                i++)//Safeguard agains incoplete data stream
            {
                lock(buffer)
                {
                    byte[] tmp = buffer;
                    //Swap buffers in compressed data stream
                    buffer = dataStream.Buffer;
                    dataStream.Buffer = tmp;
                    dataStream.Position = 0;
                    
                    new Task(DataRead).Start();
                }
                int now = decompressStream.Read(scanline, read, scanline.Length - read);
                read += now;
            }
        }
        private int parseInt(byte[] buffer, int offset)
        {
            return ((buffer[offset]) << 24) |
                ((buffer[offset + 1] & 255) << 16) |
                ((buffer[offset + 2] & 255) << 8) |
                ((buffer[offset + 3] & 255));
        }
        private static bool Compare(byte[] array, int offset, byte[] other, int offset2, int count)
        {

            for (int i = 0; i < count; i++)
            {
                if (array[offset + i] != other[offset2 + i])
                    return false;
            }
            return true;
        }
    }
}
