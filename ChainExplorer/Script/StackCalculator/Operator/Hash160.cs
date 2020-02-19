using System.Collections.Generic;
using System.Security.Cryptography;
using ChainExplorer.Model;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    public class Hash160 : NoArguments
    {
        public override StepComputationResult Compute(Stack<AsciiString> data)
        {
            var topString = data.Pop();

            var sha256 = SHA256.Create();
            var ripemd160 = RIPEMD160.Create();
            
            var sha256Result = sha256.ComputeHash(topString.Data);
            var result = ripemd160.ComputeHash(sha256Result);

            var resultAsciiString = new AsciiString(sizeof(byte), result);

            data.Push(resultAsciiString);

            return StepComputationResult.DefaultSuccess;
        }
    }
}
