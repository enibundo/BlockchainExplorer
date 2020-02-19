using System;
using System.IO;
using ChainExplorer.Model;
using ChainExplorer.Extensions;

namespace ChainExplorer.Reader
{
    public class HexReader : IHexReader
    {
        private static byte ToByte(char c)
        {
            if (c >= '0' && c <= '9')
                return (byte)(c - '0');

            if (c >= 'a' && c <= 'f')
                return (byte)(c - 'a' + 10);

            if (c >= 'A' && c <= 'F')
                return (byte)(c - 'A' + 10);

            return 0;
        }

        public byte ToByte(char first, char second)
        {
            return (byte)(ToByte(first) * 16 + ToByte(second));
        }

        public byte[] ToByteArray(byte[] hexString)
        {
            var ret = new byte[hexString.Length / 2];

            for (var i = 0; i < hexString.Length / 2; i++)
            {
                ret[i] = ToByte((char)hexString[i*2], (char)hexString[i*2+1]);
            }

            return ret;
        }

        public byte[] ToByteArray(string hexString, Endian endian = Endian.Little)
        {
            var nextCounter = endian == Endian.Little 
                ? (Func<int, int>)(x => x + 1) 
                : (x => x - 1);

            if (hexString.Length % 2 != 0)
                hexString = "0" + hexString;

            var counter = endian == Endian.Little ?  0 : (hexString.Length / 2 - 1);
            var ret = new byte[hexString.Length / 2];

            for (var i = 0; i < hexString.Length; i = i + 2)
            {
                var first = hexString[i];
                var second = hexString[i + 1];

                ret[counter] = ToByte(first, second);
                counter = nextCounter(counter);
            }

            return ret;
        }

        public uint ReadUint32(BinaryReader binaryReader, Endian endian = Endian.Big)
        {
            var b = binaryReader.ReadBytes(4);

            return BitConverter.ToUInt32(b);
        }
        
        public AsciiString ReadVarString(BinaryReader binaryReader)
        {
            var count = ReadVarInt(binaryReader, out var varIntSize);
            var data = binaryReader.ReadBytes((int)count);

            // todo: have pools of AsciiString
            return new AsciiString(varIntSize, data);
        }

        public long ReadVarInt(BinaryReader binaryReader, out int sizeOfVarInt)
        {
            var firstByte = binaryReader.ReadByte();

            var size = (VarIntSize)firstByte;
            var nbElements = size.ToBytesLength();

            sizeOfVarInt = nbElements + 1;

            if (nbElements == 0)
            {
                return firstByte;
            }
            else
            {
                var data = binaryReader.ReadBytes(nbElements);

                var value = (long)data[0];

                for (var i = 1; i < data.Length; i++)
                {
                    value = value | data[i] << (8 * i);
                }

                return value;
            }
        }
    }
}
