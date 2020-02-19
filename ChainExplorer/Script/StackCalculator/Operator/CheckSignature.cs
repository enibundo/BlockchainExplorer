using System.Collections.Generic;
using ChainExplorer.CryptoHelpers;
using ChainExplorer.Model;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    public class CheckSignature  : NoArguments
    {
        private readonly ISecpk256K1Helper _secpk256K1Helper;

        public CheckSignature(ISecpk256K1Helper secpk256K1Helper)
        {
            _secpk256K1Helper = secpk256K1Helper;
        }
        
        public override StepComputationResult Compute(Stack<AsciiString> data)
        {
            var publicKey = data.Pop().Data;
            var signature = data.Pop().Data;

            var ret = _secpk256K1Helper.Verify(publicKey, signature);
            
            return StepComputationResult.DefaultFail;
        }
    }
}

