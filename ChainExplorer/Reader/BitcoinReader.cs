using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using ChainExplorer.Model;

namespace ChainExplorer.Reader
{
    public class BitcoinReader : IBitcoinReader
    {
        private const int InputTransactionHashLength = 32;
        private const int OutputAmountLength = 8;

        private readonly IHexReader _hexReader;
        public BitcoinReader(IHexReader hexReader)
        {
            _hexReader = hexReader;
        }

        public Block ReadBlock(LoggedBinaryReader binaryReader)
        {
            var blockHeader = binaryReader.ReadBytes(80);
            var nbTransactions = _hexReader.ReadVarInt(binaryReader, Endian.Little, out var sizeOfNbTransactions);
            
            // todo: use transactions pool here.
            var transactions = new Transaction[nbTransactions];
            for (var i = 0; i < nbTransactions; i++)
            {
                binaryReader.Reset();
                transactions[i] = ReadTransaction(binaryReader);
            }
            
            return new Block(blockHeader, sizeOfNbTransactions, transactions);
        }

        public Block ReadBlock(LoggedBinaryReader binaryReader, Action<Transaction> onReadTransaction)
        {
            var blockHeader = binaryReader.ReadBytes(80);
            var nbTransactions = _hexReader.ReadVarInt(binaryReader, Endian.Little, out var sizeOfNbTransactions);
            
            // todo: use transactions pool here.
            var transactions = new Transaction[nbTransactions];
            for (var i = 0; i < nbTransactions; i++)
            {
                binaryReader.Reset();
                transactions[i] = ReadTransaction(binaryReader);
                onReadTransaction(transactions[i]);
            }
            
            return new Block(blockHeader, sizeOfNbTransactions, transactions);
        }

        public Transaction ReadTransaction(LoggedBinaryReader binaryReader)
        {
            var version = binaryReader.ReadUInt32();
            
            var countTransactionInputs = _hexReader.ReadVarInt(binaryReader, Endian.Little,  out _);
            var hasWitness = countTransactionInputs == 0;
            
            if (hasWitness)
            {
                // todo: use SegWit
                var __ = binaryReader.ReadByte(); 
                
                countTransactionInputs = _hexReader.ReadVarInt(binaryReader, Endian.Little, out _);
            }
            
            // todo: use transaction input pool here
            var transactionInputs = new TransactionInput[countTransactionInputs];
            for (var i = 0; i < countTransactionInputs; i++)
            {
                transactionInputs[i] = ReadTransactionInput(binaryReader);
            }

            var countTransactionOutputs = _hexReader.ReadVarInt(binaryReader, Endian.Little, out _);

            // todo: use transaction output pool here
            var transactionOutputs = new TransactionOutput[countTransactionOutputs];
            for (var i = 0; i < countTransactionOutputs; i++)
            {
                transactionOutputs[i] = ReadTransactionOutput(binaryReader);
            }

            var witnessAsciiStrings = new List<AsciiString>();
            
            if (hasWitness)
            {
                for (var i = 0; i < countTransactionInputs; i++)
                {
                    var countWitnessStackItems = _hexReader.ReadVarInt(binaryReader, Endian.Little, out _);
                    for (var j = 0; j < countWitnessStackItems; j++)
                    {
                        witnessAsciiStrings.Add(_hexReader.ReadVarString(binaryReader));
                    }
                }
            }

            var lockTime = binaryReader.ReadUInt32();
            
            var txId = GetTrxId(binaryReader.AsSpan());
            
            return new Transaction(txId, version, transactionInputs, transactionOutputs, lockTime, hasWitness, witnessAsciiStrings);
        }

        private TransactionInput ReadTransactionInput(LoggedBinaryReader binaryReader)
        {
            var transactionHash = binaryReader.ReadBytes(InputTransactionHashLength);
            var outputIndex = binaryReader.ReadUInt32();
            var scriptSig = _hexReader.ReadVarString(binaryReader);
            var sequence = binaryReader.ReadUInt32();

            return new TransactionInput(transactionHash, outputIndex, scriptSig, sequence);
        }

        private TransactionOutput ReadTransactionOutput(LoggedBinaryReader binaryReader)
        {
            var amount = binaryReader.ReadBytes(OutputAmountLength);
            var scriptPubKey = _hexReader.ReadVarString(binaryReader);
            
            return new TransactionOutput(amount, scriptPubKey);
        }
        private static byte[] GetTrxId(Span<byte> trxData)
        {
            var sha256 = SHA256.Create();
            var trxId = sha256.ComputeHash(sha256.ComputeHash(trxData.ToArray()));
            return trxId.Reverse().ToArray();
        }

    }
}