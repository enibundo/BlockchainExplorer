using System;
using System.Collections.Generic;
using System.IO;
using ChainExplorer.Model;
using ChainExplorer.Script.StackCalculator.Operator;

namespace ChainExplorer.Script.StackCalculator
{
    public class Calculator : ICalculator
    {
        public event Action<IOp, Stack<AsciiString>> BeforeExecution = (_, __) => { };
        
        public Stack<AsciiString> Stack { get; } = new Stack<AsciiString>();
        private StepComputationResult Step(IOpReader opReader)
        {
            if (!opReader.TryReadOp(out var currentOp))
            {
                return opReader.HasEnded 
                    ? StepComputationResult.DefaultHasEnded 
                    : StepComputationResult.DefaultFail;
            }
            
            BeforeExecution(currentOp, Stack);

            var opComputationResult = currentOp.Compute(Stack);

            while(opComputationResult.IsSuccess && opComputationResult.HasNextOp)
            {
                BeforeExecution(opComputationResult.NextOp, Stack);
                opComputationResult = opComputationResult.NextOp.Compute(Stack);
            }

            return opComputationResult;
        }

        public ScriptComputationResult Compute(byte[] script)
        {
            var opReader = new OpReader(new BinaryReader(new MemoryStream(script)));
            
            while (true)
            {
                var stepResult = Step(opReader);

                if (!stepResult.IsSuccess || stepResult.HasEnded)
                    return new ScriptComputationResult {Result = stepResult.IsSuccess};
            }
        }
    }
}