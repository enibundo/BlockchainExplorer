using System.Collections.Generic;
using ChainExplorer.Model;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    internal class EqualVerify : NoArguments
    {
        private readonly Equal _equalOperator = new Equal();
        private readonly Verify _verifyOperator = new Verify();
        
        public override StepComputationResult Compute(Stack<AsciiString> data)
        {
            _equalOperator.Compute(data);
            
            return StepComputationResult.DefaultSuccessNextOp(_verifyOperator);
        }

        public override bool TryGetFollowingOp(out IOp followingOp)
        {
            followingOp = new Verify();
            return true;
        }
    }
}