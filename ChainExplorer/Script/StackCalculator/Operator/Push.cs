using System.Collections.Generic;
using System.IO;
using ChainExplorer.Model;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    public class Push : IOp
    {
        public AsciiString? String { get; private set; }
        public byte Length { get; private set; }

        public Push(byte length, AsciiString? s = null)
        {
            Length = length;
            String = s;
        }

        public StepComputationResult Compute(Stack<AsciiString> data)
        {
            data.Push(String.Value);
            return StepComputationResult.DefaultSuccess;
        }

        public IOp ReadArguments(BinaryReader binaryReader)
        {
            var data = binaryReader.ReadBytes(Length);
            String = new AsciiString(sizeof(byte), data);
            return this;
        }

        public bool TryGetFollowingOp(out IOp op)
        {
            op = null;
            return false;
        }
    }
}
