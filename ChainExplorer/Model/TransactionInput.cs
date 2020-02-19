namespace ChainExplorer.Model
{
    public struct TransactionInput
    {
        public byte[] TransactionHash { get; }
        public uint OutputIndex { get; }
        public AsciiString ScriptSignature { get; }
        public uint Sequence { get; }
        
        public TransactionInput(byte[] transactionHash, uint outputIndex, AsciiString scriptSignature, uint sequence)
        {
            TransactionHash = transactionHash;
            OutputIndex = outputIndex;
            Sequence = sequence;
            ScriptSignature = scriptSignature;

            Size = transactionHash.Length + sizeof(uint) + scriptSignature.Size + sizeof(uint);
        }

        public int Size { get; private set; }
    }
}