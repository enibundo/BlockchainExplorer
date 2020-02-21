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
    }
}