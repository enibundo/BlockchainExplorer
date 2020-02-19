using System.Collections.Generic;
using ChainExplorer.Model;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    internal class Equal : NoArguments
    {
        private static readonly AsciiString TrueAsciiString = new AsciiString(1, new byte[] { 1 });
        private static readonly AsciiString FalseAsciiString = new AsciiString(1, new byte[] { 0 });

        public override StepComputationResult Compute(Stack<AsciiString> data)
        {
            var first = data.Pop();
            var second = data.Pop();

            var result = first.Equals(second) ? TrueAsciiString : FalseAsciiString;

            data.Push(result);

            return StepComputationResult.DefaultSuccess;
        }
    }
}