using System.Collections.Generic;
using System.IO;
using ChainExplorer.Model;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    public interface IOp
    {
        StepComputationResult Compute (Stack<AsciiString> data);
        IOp ReadArguments(BinaryReader binaryReader);
        bool TryGetFollowingOp(out IOp followingOp);
    }
}