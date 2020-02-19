using System;
using System.IO;
using System.Linq;
using System.Text;
using ChainExplorer.Model;
using ChainExplorer.Reader;

namespace ChainExplorerWeb.Data
{
    public class NumConverter : INumConverter
    {
        private readonly IHexReader _hexReader;

        public NumConverter(IHexReader hexReader)
        {
            _hexReader = hexReader;
        }
        
        public string ConvertHexToDec(string hex)
        {
            var res = _hexReader.ToByteArray(hex, Endian.Big).Reverse().ToArray();

            var bigInteger = new BigInteger(res);
            
            return bigInteger.ToString();   
        }

        public string ConvertDecToHex(string dec)
            =>  ToString(System.Numerics.BigInteger.Parse(dec));
        

        public string ConvertHexLeToHex(string hexLe)
        {
            var ret = new StringBuilder();

            for (var i = 0; i < hexLe.Length; i = i + 2)
            {
                ret.Append(hexLe[^(i + 2)]);
                ret.Append(hexLe[^(i + 1)]);
            }

            return ret.ToString();
        }

        public string ConvertVarIntToDecimal(string varInt)
        {
            var b = _hexReader.ToByteArray(varInt, Endian.Little);
            var binaryReader = new BinaryReader(new MemoryStream(b));
            var vInt = _hexReader.ReadVarInt(binaryReader, out _);
            
            return vInt.ToString();
        }

        public string ConvertBitsLeToDifficulty(string bits)
        {
            
            // 0x0404cb * 2**(8*(0x1b - 3)) = 0x00000000000404CB000000000000000000000000000000000000000000000000
                
            var bytesLittleEndian = _hexReader.ToByteArray(bits, Endian.Little);
            var bytesBigEndian = bytesLittleEndian.Reverse().ToArray();

            var theBase = new System.Numerics.BigInteger(bytesBigEndian[1..4]);
            var thePower = 8 * bytesLittleEndian[0]-3;
            var res = theBase * (System.Numerics.BigInteger.Pow(2, thePower));
            return ToString(res);
        }

        private static string ToString(System.Numerics.BigInteger bi)
        {
            return BitConverter.ToString(bi.ToByteArray()).Replace("-", string.Empty);
        }
    }
}