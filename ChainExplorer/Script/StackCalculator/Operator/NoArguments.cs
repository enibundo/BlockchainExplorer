using System.Collections.Generic;
using System.IO;
using ChainExplorer.Model;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    public abstract class NoArguments : IOp
    {
        public abstract StepComputationResult Compute(Stack<AsciiString> data);

        public virtual bool TryGetFollowingOp(out IOp followingOp)
        {
            followingOp = null;
            return false;
        }

        public IOp ReadArguments(BinaryReader binaryReader)
        {
            return this;
        }
    }
}
