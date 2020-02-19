using ChainExplorer.Script.StackCalculator.Operator;

namespace ChainExplorer.Script.StackCalculator
{
    public struct StepComputationResult
    {
        public bool IsSuccess { get; }
        public bool HasEnded { get; }
        public bool HasNextOp { get; }
        public IOp NextOp { get; }

        public StepComputationResult(bool isSuccess, bool hasEnded, bool hasNextOp, IOp nextOp)
        {
            IsSuccess = isSuccess;
            HasEnded = hasEnded;
            HasNextOp = hasNextOp;
            NextOp = nextOp;
        }

        public static StepComputationResult DefaultSuccess = new StepComputationResult(true, false, false, null);

        public static StepComputationResult DefaultSuccessNextOp(IOp nextOp)
        {
            return new StepComputationResult(true, false, true, nextOp);
        }
        
        public static StepComputationResult DefaultFail = new StepComputationResult(false, false, false, null);
        public static StepComputationResult DefaultHasEnded = new StepComputationResult(true, true, false, null);
    }
}
