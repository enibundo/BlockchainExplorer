using System.IO;
using ChainExplorer.Model;
using ChainExplorer.Reader;
using NUnit.Framework;

namespace ChainExplorerTests
{
    public class HexReaderTests
    {
        private HexReader _hexReader;

        [SetUp]
        public void SetUp()
        {
            _hexReader = new HexReader();
        }

        [Test]
        public void should_parse_little_endian()
        {
            // arrange
            var hexLittleEndian = "030201";
            
            // act
            var res = _hexReader.ToByteArray(hexLittleEndian, Endian.Little);
            
            // assert
            Assert.AreEqual(3, res.Length);
            
            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(2, res[1]);
            Assert.AreEqual(3, res[2]);
        }
        
        [Test]
        public void should_parse_big_endian()
        {
            // arrange
            var hexLittleEndian = "030201";
            
            // act
            var res = _hexReader.ToByteArray(hexLittleEndian, Endian.Big);
            
            // assert
            Assert.AreEqual(3, res.Length);
            
            Assert.AreEqual(3, res[0]);
            Assert.AreEqual(2, res[1]);
            Assert.AreEqual(1, res[2]);
        }

        [TestCase(Endian.Little, 550)]
        [TestCase(Endian.Big, 9730)]
        public void should_read_varInt(Endian endian, long expectedResult)
        {
            // arrange
            var binaryReader = ToBinaryReader(new byte[] {0xfd, 0x26, 0x02});
            
            // act
            var result = _hexReader.ReadVarInt(binaryReader, endian, out var sizeOfVarInt);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void should_swap_endianness()
        {
            // arrange
            var bytes = new byte[] {1, 2, 3};

            // act    
            _hexReader.SwapEndianness(bytes);

            // assert
            Assert.AreEqual(3, bytes[0]);
            Assert.AreEqual(2, bytes[1]);
            Assert.AreEqual(1, bytes[2]);
        }

        [Test]
        public void should_swap_endianness_pair()
        {
            // arrange
            var bytes = new byte[] {1, 2};

            // act    
            _hexReader.SwapEndianness(bytes);

            // assert
            Assert.AreEqual(2, bytes[0]);
            Assert.AreEqual(1, bytes[1]);
        }

        [Test]
        public void should_not_throw_if_swapping_empty_array()
        {
            // arrange
            var bytes = new byte[] {};

            // act    
            Assert.DoesNotThrow(()=>_hexReader.SwapEndianness(bytes));
            Assert.IsEmpty(bytes);
        }

        
        private static BinaryReader ToBinaryReader(byte[] bytes)
        {
            return new BinaryReader(new MemoryStream(bytes));
        }
    }
}