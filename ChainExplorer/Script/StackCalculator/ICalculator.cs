using System.Collections.Generic;
using ChainExplorer.Model;
using ChainExplorer.Script.StackCalculator.Operator;

namespace ChainExplorer.Script.StackCalculator
{
    public interface ICalculator
    {
        public Stack<AsciiString> Stack { get; }
        ScriptComputationResult Compute(byte[] script);
    }
}