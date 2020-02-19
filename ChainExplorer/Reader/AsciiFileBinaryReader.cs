using System;
using System.IO;

namespace ChainExplorer.Reader
{
    public class AsciiFileBinaryReader : BinaryReader
    {
        private readonly IHexReader _hexReader;
        
        public AsciiFileBinaryReader(IHexReader hexReader, Stream stream) : base(stream)
        {
            _hexReader = hexReader;
        }

        public override byte[] ReadBytes(int count) => _hexReader.ToByteArray(base.ReadBytes(count * 2));

        public override byte ReadByte()
        {
            var b = base.ReadBytes(2);

            return _hexReader.ToByte((char) b[0], (char) b[1]);
        }

        public override uint ReadUInt32()
        {
            var b = ReadBytes(4);
            
            return BitConverter.ToUInt32(b, 0);
        }
    }
}
