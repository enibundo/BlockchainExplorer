using System;
using System.IO;
using ChainExplorer.Reader;
using NUnit.Framework;

namespace ChainExplorerTests
{
    public class TransactionBinaryReaderTests
    {

        public TransactionBinaryReaderTests()
        {
        }

        [Test]
        public void should_store_when_data()
        {
            // arrange
            var data = new byte[] { 1,2,3 };
            var binaryReader = new LoggedBinaryReader(new MemoryStream(data));

            // act
            var res = binaryReader.ReadBytes(3);
            var readData = res.AsSpan();
            
            // assert
            Assert.AreEqual(3, res.Length);
            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(2, res[1]);
            Assert.AreEqual(3, res[2]);
            
            Assert.AreEqual(1, readData[0]);
            Assert.AreEqual(2, readData[1]);
            Assert.AreEqual(3, readData[2]);
        }
        
        [Test]
        public void should_store_with_stream()
        {
            // arrange
            var data = new byte[] { 1,2,3 };
            var memoryStream = new MemoryStream(data);
            var binaryReader = new BinaryReader(memoryStream);
            var transactionBinaryReader = new LoggedBinaryReader(memoryStream);

            // act
            var one = binaryReader.ReadByte();
            var two = transactionBinaryReader.ReadByte();
            var otherTwo = transactionBinaryReader.AsSpan()[0];
            
            transactionBinaryReader.Reset();
            var three = transactionBinaryReader.ReadByte();
            var otherThree = transactionBinaryReader.AsSpan()[0];
            
            // assert
            Assert.AreEqual(1, one);
            Assert.AreEqual(2, two);
            Assert.AreEqual(2, otherTwo);
            Assert.AreEqual(3, three);            
            Assert.AreEqual(3, otherThree);
        }
    }
}