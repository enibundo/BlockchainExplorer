using ChainExplorer.Model;
using ChainExplorer.Reader;
using ChainExplorerWeb.Data;
using Moq;
using NUnit.Framework;

namespace ChainExplorerTests
{
    public class NumConverterTests
    {
        private NumConverter _numConverter;
        private Mock<IHexReader> _hexReader;

        [SetUp]
        public void Setup()
        {
            _hexReader = new Mock<IHexReader>();
            _numConverter = new NumConverter(_hexReader.Object);
        }

        [Test]
        public void should_convert_bits_to_difficulty()
        {
            // arrange
            var input = "cb04041b";
            var bitsField = new byte[4] {0x1b, 0x04, 0x04, 0xcb};
            
            // 1b => 27
            // 0404cb => 263371
            // cb0404
            // 263371 * 2**(8*(27-3)) = 1653206561150525499452195696179626311675293455763937233695932416
            // 404CB000000000000000000000000000000000000000000000000
            
            // "0x0404cb * 2**(8*(0x1b - 3)) = 0x00000000000404CB000000000000000000000000000000000000000000000000";
            _hexReader
                .Setup(x => x.ToByteArray(input, Endian.Little))
                .Returns(bitsField);
            
            // act
            var result = _numConverter.ConvertBitsLeToDifficulty(input);
            var expectedResult = "00000000000404CB000000000000000000000000000000000000000000000000";
            
            
            // assert
            Assert.AreEqual(expectedResult, result);
        }

        
        
    }
}