using System;
using System.Collections.Generic;
using System.IO;

namespace ChainExplorer.Model
{
    public class Transaction 
    {
        public bool HasWitness { get; }
        public IList<AsciiString> WitnessData { get; }
        public uint Version { get; }
        
        public TransactionInput[] TransactionInputs { get; }
        
        public TransactionOutput[] TransactionOutputs { get; }
        
        public uint LockTime { get; }
        public byte[] TrxId { get; }
        
        public Transaction(byte[] trxId, uint version, TransactionInput[] transactionInputs, TransactionOutput[] transactionOutputs, 
                           uint lockTime, bool hasWitness, IList<AsciiString> witnessData)
        {
            TrxId = trxId;
            
            HasWitness = hasWitness;
            WitnessData = witnessData;
            
            Version = version;
            TransactionInputs = transactionInputs;            
            TransactionOutputs = transactionOutputs;
            LockTime = lockTime;

            var transactionInputsSize = 0;
            var transactionOutputsSize = 0;
            var scriptLength = 0;
            
            foreach (var t in transactionInputs)
            {
                transactionInputsSize += t.Size;
                scriptLength += t.ScriptSignature.Data.Length;
            }

            foreach (var t in transactionOutputs)
            {
                transactionOutputsSize += t.Size;
                scriptLength += t.ScriptPubKey.Data.Length;
            }

            Size = sizeof(uint) + transactionInputsSize + transactionOutputsSize + sizeof(uint);
            
            Script = new byte[scriptLength];

            var counter = 0;
            foreach (var t in transactionInputs)
            {
                var len = t.ScriptSignature.Data.Length;
                Array.Copy(t.ScriptSignature.Data, 0, Script, counter, len);
                counter += len;
            }

            foreach (var t in transactionOutputs)
            {
                var len = t.ScriptPubKey.Data.Length;
                Array.Copy(t.ScriptPubKey.Data, 0, Script, counter, len);
                counter += len;
            }
        }

        public int Size { get; private set; }


        public byte[] Script { get; private set; }

        public override string ToString()
        {
            return $"Version: {Version}\n" +
                   $"Inputs: {TransactionInputs}\n" +
                   $"Outputs: {TransactionOutputs}\n" +
                   $"LockTime: {LockTime}";
        }
    }
}
