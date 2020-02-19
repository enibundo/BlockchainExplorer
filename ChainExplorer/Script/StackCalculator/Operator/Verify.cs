using System.Collections.Generic;
using ChainExplorer.Model;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    public class Verify : NoArguments
    {
        public override StepComputationResult Compute(Stack<AsciiString> data)
        {
            var topString = data.Pop();

            if (topString.Data.Length != 1 || topString.Data[0] != 1)
                return StepComputationResult.DefaultFail;

            return StepComputationResult.DefaultSuccess;
        }
    }
}
