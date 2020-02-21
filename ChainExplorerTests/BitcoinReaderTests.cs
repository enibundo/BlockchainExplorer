using System;
using System.IO;
using ChainExplorer.Reader;
using NUnit.Framework;

namespace ChainExplorerTests
{
    public class BitcoinReaderTests
    {
        private BitcoinReader _bitcoinReader;
        
        [SetUp]
        public void SetUp()
        {
            _bitcoinReader = new BitcoinReader(new HexReader());
            
        }

        [Test]
        public void should_parse_pizza_transaction()
        {
            // arrange
            var pizzaPath = "data/pizza_transaction_hex.txt";
            var loggedBinaryReader = LoggedBinaryReader.FromAsciiFile(pizzaPath);
            
            // act
            var transaction = _bitcoinReader.ReadTransaction(loggedBinaryReader);
            
            // assert
            var trxHash = BitConverter.ToString(transaction.TrxId);
        
            Assert.AreEqual("a1075db55d416d3ca199f55b6084e2115b9345e16c5cf302fc80e9d5fbf5d48d", trxHash);
        }
    }
}