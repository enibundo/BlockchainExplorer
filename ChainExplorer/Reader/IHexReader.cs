using System.IO;
using ChainExplorer.Model;

namespace ChainExplorer.Reader
{
    public interface IHexReader
    {
        AsciiString ReadVarString(BinaryReader binaryReader);
        long ReadVarInt(BinaryReader binaryReader, Endian endian, out int sizeOfVarInt);
        void SwapEndianness(byte[] data);
        byte ToByte(char first, char second);
        byte[] ToByteArray(byte[] hexString);
        byte[] ToByteArray(string hexString, Endian endian);
    }
}
