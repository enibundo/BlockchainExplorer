using ChainExplorer.Model;

namespace ChainExplorer.Script.Validator
{
    public interface ITransactionValidator
    {
        bool IsValid(Transaction transaction);
        bool IsValid(byte[] script);
    }
}
