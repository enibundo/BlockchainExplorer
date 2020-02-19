using System;
using System.Linq;
using ChainExplorer.Script.StackCalculator;

namespace ChainExplorer.Script.Validator
{
    public class TransactionValidator : ITransactionValidator
    {
        private readonly ICalculator _calculator;

        public TransactionValidator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public bool IsValid(Model.Transaction transaction)
        {
            var scriptSize = transaction.TransactionInputs.Sum(x=>x.ScriptSignature.Data.Length)
                           + transaction.TransactionOutputs.Sum(x=>x.ScriptPubKey.Data.Length);

            var script = new byte[scriptSize];
            var scriptOffset = 0;

            foreach (var input in transaction.TransactionInputs)
            {
                Array.Copy(input.ScriptSignature.Data, 0, script, scriptOffset, input.ScriptSignature.Data.Length);
                scriptOffset = input.ScriptSignature.Data.Length;
            }

            foreach (var output in transaction.TransactionOutputs)
            {
                Array.Copy(output.ScriptPubKey.Data, 0, script, scriptOffset, output.ScriptPubKey.Data.Length);
                scriptOffset = output.ScriptPubKey.Data.Length;
            }
            
            var calculatorResult = _calculator.Compute(script);

            return calculatorResult.Result;
        }

        public bool IsValid(byte[] script)
        {
            var calculatorResult = _calculator.Compute(script);

            return calculatorResult.Result;
        }
    }
}
