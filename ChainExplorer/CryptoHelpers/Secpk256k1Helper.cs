namespace ChainExplorer.CryptoHelpers
{
    public interface ISecpk256K1Helper
    {
        bool Verify(byte[] publicKey, byte[] message);
    }
    
    public class Secpk256K1Helper : ISecpk256K1Helper
    {
        public bool Verify(byte[] publicKey, byte[] message)
        {
            throw new System.NotImplementedException();
        }
    }
}