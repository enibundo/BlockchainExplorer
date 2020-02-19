namespace ChainExplorer.Model
{
    public struct TransactionOutput
    {
        public byte[] Amount { get; }
        
        public AsciiString ScriptPubKey { get; }

        public TransactionOutput(byte[] amount, AsciiString scriptPubKey)
        {
            Amount = amount;
            ScriptPubKey = scriptPubKey;

            Size = Amount.Length + ScriptPubKey.Size + sizeof(int);
        }
        
        public int Size { get; private set; }
    }
}