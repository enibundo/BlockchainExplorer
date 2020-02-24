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
            var res = _hexReader.ToByteArray(hex, Endian.Big).ToArray();
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
            var b = _hexReader.ToByteArray(varInt, Endian.Big);
            var binaryReader = new BinaryReader(new MemoryStream(b));
            var vInt = _hexReader.ReadVarInt(binaryReader, Endian.Little, out _);
            
            return vInt.ToString();
        }

        public string ConvertBitsLeToDifficulty(string bits)
        {
            
            // 0x0404cb * 2**(8*(0x1b - 3)) = 0x00000000000404CB000000000000000000000000000000000000000000000000
                
            var bytes = _hexReader.ToByteArray(bits, Endian.Little);

            var num = new byte[4]
            {
                bytes[3],
                bytes[2],
                bytes[1],
                0
            };
            
            var theBase = BitConverter.ToUInt32(num);
            
            var thePower = 8 * (bytes[0] - 3);

            var res = new BigInteger(1);

            for (var i = 0; i < thePower; i++) 
                res *= 2;

            var result = ToString(theBase*res);
            
            return new string('0', 64-result.Length) + result;
        }

        private static string ToString(BigInteger bi)
        {
            return BitConverter
                .ToString(bi.getBytes())
                .Replace("-", string.Empty);
        }
        
        private static string ToString(System.Numerics.BigInteger bi)
        {
            return BitConverter
                .ToString(bi.ToByteArray())
                .Replace("-", string.Empty);
        }
        
    }
}