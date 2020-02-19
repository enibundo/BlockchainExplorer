using System.Collections.Generic;
using ChainExplorer.Model;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    public class Dup : NoArguments
    {
        public override StepComputationResult Compute(Stack<AsciiString> data)
        {
            var topAsciiString = data.Peek();

            var newOp = (AsciiString) topAsciiString.Clone();

            data.Push(newOp);

            return StepComputationResult.DefaultSuccess;
        }
    }
}
