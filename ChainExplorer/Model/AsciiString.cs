using System;

namespace ChainExplorer.Model
{
   public struct AsciiString : ICloneable
   {
        private readonly int _sizeOfLength;

        public byte[] Data { get; }

        public AsciiString(byte b)
        : this(1, new byte[] { b })
        {
            
        }
        public AsciiString(int sizeOfLength, byte[] data)
        {
            Data = data;

            _sizeOfLength = sizeOfLength;

            Size = data.Length + sizeOfLength;
        }

        public int Size { get; private set; }

        public bool Equals(AsciiString other)
        {
            if (Size != other.Size)
                return false;

            for (var i = 0; i < Data.Length; i++)
            {
                if (Data[i] != other.Data[i])
                    return false;
            }

            return true;
        }

        public object Clone()
        {
            var data = new byte[Data.Length];

            Array.Copy(Data, data, Data.Length);

            return new AsciiString(_sizeOfLength, data);
        }
    }
}
