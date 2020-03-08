using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using ChainExplorer.Model;
using System.Numerics;
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
            var result = _hexReader.ToByteArray(hex, Endian.Big).ToArray();
            var bigInteger = new System.Numerics.BigInteger(result);

            return bigInteger.ToString();   
        }

        public string ConvertDecToHex(string dec)
            =>  ToString(BigInteger.Parse(dec));
        

        public string ConvertHexLeToHex(string hexLe)
        {
            var result = new StringBuilder();

            for (var i = 0; i < hexLe.Length; i = i + 2)
            {
                result.Append(hexLe[^(i + 2)]);
                result.Append(hexLe[^(i + 1)]);
            }

            return result.ToString();
        }

        public string ConvertVarIntToDecimal(string varInt)
        {
            var bytes = _hexReader.ToByteArray(varInt, Endian.Big);
            var binaryReader = new BinaryReader(new MemoryStream(bytes));
            var vInt = _hexReader.ReadVarInt(binaryReader, Endian.Little, out _);
            
            return vInt.ToString();
        }

        private BigInteger ConvertBitsToBigIntResult(string bits)
        {
            var bytes = _hexReader.ToByteArray(bits, Endian.Little);

            var num = new byte[4]
            {
                bytes[3],
                bytes[2],
                bytes[1],
                0
            };
            
            Console.WriteLine($"num : {num[0]}, {num[1]}, {num[2]}, {num[3]}");
            
            var theBase = BitConverter.ToUInt32(num);
            
            Console.WriteLine($"the base :  {theBase}");
            
            var thePower = 8 * (bytes[0] - 3);

            Console.WriteLine($"the power :  {thePower}");

            var res = new BigInteger(1);

            for (var i = 0; i < thePower; i++) 
                res *= 2;

            Console.WriteLine($"res = {res}");
            
            var result = theBase * res;
            
            Console.WriteLine($"bits = {bits} => result = {result}");

            return result;
        }
        
        public string ConvertBitsLeToTarget(string bits)
        {
            var result = ConvertHexLeToHex(ToString(ConvertBitsToBigIntResult(bits)));
            return new string('0', 64-result.Length) + result;
        }

        public string ConvertBitsToDifficulty(string bits)
        {
            var poolDifficultyOne = ConvertHexLeToHex("00000000FFFF0000000000000000000000000000000000000000000000000000");
                
            var bigIntegerResult = ConvertBitsToBigIntResult(bits);
            var poolDifficultyBytes = _hexReader.ToByteArray(poolDifficultyOne, Endian.Big);
            
            foreach (var b in poolDifficultyBytes)
                Console.Write($"{b},");
            
            var v = new BigInteger(poolDifficultyBytes);
            
            return ((double)v / (double)bigIntegerResult).ToString(CultureInfo.InvariantCulture);
        }

        private static string ToString(System.Numerics.BigInteger bi)
        {
            return BitConverter
                .ToString(bi.ToByteArray())
                .Replace("-", string.Empty);
        }
        
    }
}