using System.Collections.Generic;
using ChainExplorer.Model;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    public class Addition : NoArguments
    {

        public override StepComputationResult Compute(Stack<AsciiString> data)
        {
            var firstString = data.Pop();
            var secondString = data.Pop();

            var result = new AsciiString(sizeof(byte), new byte[firstString.Data.Length + secondString.Data.Length]);

            for(var counter = 0; counter < firstString.Data.Length; counter++)
            {
                result.Data[counter] = (byte)(firstString.Data[counter] + secondString.Data[counter]);
            }

            data.Push(result);

            return StepComputationResult.DefaultSuccess;
        }
    }
}