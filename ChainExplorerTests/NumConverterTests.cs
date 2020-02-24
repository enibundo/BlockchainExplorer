using System;
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

        /*
            1b => 27
            0404cb => 263371

            263371 * 2**(8*(27-3)) 
            = 1653206561150525499452195696179626311675293455763937233695932416
            = 0x404CB000000000000000000000000000000000000000000000000
            
            0x0404cb * 2**(8*(0x1b - 3)) 
            = 0x00000000000404CB000000000000000000000000000000000000000000000000
            
         */
        [Test]
        public void should_convert_bits_to_difficulty()
        {
            // arrange
            var input = "cb04041b";
            var bigEndianBytes = new byte[4] {0x1b, 0x04, 0x04, 0xcb};
            var expectedResult = "00000000000404CB000000000000000000000000000000000000000000000000";
            
            _hexReader
                .Setup(x => x.ToByteArray(input, Endian.Little))
                .Returns(bigEndianBytes);
            
            // act
            var result = _numConverter.ConvertBitsLeToDifficulty(input);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}