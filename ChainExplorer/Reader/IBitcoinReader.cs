using System;
using System.IO;
using System.Threading.Tasks;
using ChainExplorer.Model;

namespace ChainExplorer.Reader
{
    public interface IBitcoinReader
    {
        Block ReadBlock(LoggedBinaryReader binaryReader, Action<Transaction> onReadTransaction);
        Block ReadBlock(LoggedBinaryReader binaryReader);
        Transaction ReadTransaction(LoggedBinaryReader binaryReader);
    }
}