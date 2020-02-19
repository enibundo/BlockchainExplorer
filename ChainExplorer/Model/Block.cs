using System;

namespace ChainExplorer.Model
{
    public struct Block
    {
        public uint Beginning { get; }
        public uint BlockSize { get; }
        public byte[] BlockHeader { get; }
        public int SizeOfNbTransactions {get;}
        public Transaction[] Transactions { get; }
        public int Size { get; }

        public Span<byte> Version => BlockHeader.AsSpan().Slice(0, 4);

        public Span<byte> PreviousBlockHash => BlockHeader.AsSpan().Slice(4, 32);

        public Span<byte> MerkleRoot => BlockHeader.AsSpan().Slice(36, 32);

        public Span<byte> Time => BlockHeader.AsSpan().Slice(68, 4);

        public Span<byte> Bits => BlockHeader.AsSpan().Slice(72, 4);

        public Span<byte> Nonce => BlockHeader.AsSpan().Slice(76, 4);
        
        
        public Block(byte[] blockHeader, int sizeOfNbTransactions, Transaction[] transactions)
        {
            // todo: fix this
            BlockSize = 0;
            
            Beginning = 4189372153; // 0xf9b4bef9
            
            BlockHeader = blockHeader;
            
            SizeOfNbTransactions = sizeOfNbTransactions;
            Transactions = transactions;

            Size = sizeof(uint) // beginning 
                + sizeof(uint)  // blocksize
                + sizeof(byte) * 80 // blockheader
                + SizeOfNbTransactions // nbTransactions
                ;

            
        } 
    }
}
