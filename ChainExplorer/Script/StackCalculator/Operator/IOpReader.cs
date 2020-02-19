namespace ChainExplorer.Script.StackCalculator.Operator
{
    public interface IOpReader
    {
        bool TryReadOp(out IOp result);
        bool HasEnded { get; }
    }
}