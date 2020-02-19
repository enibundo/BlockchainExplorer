using System.Collections.Generic;
using ChainExplorer.Model;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    internal class One : NoArguments
    {
        public override StepComputationResult Compute(Stack<AsciiString> data)
        {
            var one = new AsciiString(0x01);

            data.Push(one);

            return StepComputationResult.DefaultSuccess;
        }
    }
}