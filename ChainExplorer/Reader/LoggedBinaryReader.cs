using System;
using System.IO;
using System.Text;

namespace ChainExplorer.Reader
{
    public class LoggedBinaryReader : BinaryReader
    {
        private readonly BinaryReader _binaryReader;
        
        // max size of transaction in bytes.
        private readonly byte[] _data = new byte[100_000];
        
        private int _position = 0;

        public LoggedBinaryReader(Stream input) : base(input)
        {
        }

        public LoggedBinaryReader(BinaryReader binaryReader) : base(binaryReader.BaseStream)
        {
            _binaryReader = binaryReader;
        }

        public void Reset() => _position = 0;

        
        public override uint ReadUInt32() => BitConverter.ToUInt32(ReadSomeBytes(4));
        public override byte ReadByte() => _data[_position++] = ReadOneByte();
        public override byte[] ReadBytes(int count) => ReadSomeBytes(count);

        
        private byte[] ReadSomeBytes(int count)
        {
            
            var data =_binaryReader?.ReadBytes(count) ?? base.ReadBytes(count);
            
            Array.Copy(data, 0, _data, _position, count);
            _position += count;
            return data;
        }

        private byte ReadOneByte() => _binaryReader?.ReadByte() ?? base.ReadByte();
        public Span<byte> AsSpan() => _data[.._position].AsSpan();

        public static LoggedBinaryReader FromAsciiFile(string asciiFilePath) 
            => new LoggedBinaryReader(new FileStream(asciiFilePath, FileMode.Open));
    }
}