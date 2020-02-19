using System.IO;
using ChainExplorer.Model;

namespace ChainExplorer.Reader
{
    public interface IHexReader
    {
        AsciiString ReadVarString(BinaryReader binaryReader);
        long ReadVarInt(BinaryReader binaryReader, out int sizeOfVarInt);
        byte ToByte(char first, char second);
        byte[] ToByteArray(byte[] hexString);
        byte[] ToByteArray(string hexString, Endian endian);
    }
}
