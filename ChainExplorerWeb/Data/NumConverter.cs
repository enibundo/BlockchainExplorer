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
        {
            var bigInteger = System.Numerics.BigInteger.Parse(dec);

            return BitConverter.ToString(bigInteger.ToByteArray()).Replace("-", string.Empty);
        }

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
    }
}