using System;
using System.Collections.Generic;
using System.IO;
using ChainExplorer.CryptoHelpers;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    public class OpReader : IOpReader
    {
        private static readonly Dictionary<Op, Func<byte, IOp>> OpPool =
            new Dictionary<Op, Func<byte, IOp>> {
                { Op.Op1, (_) => new One() },
                { Op.OpDuplicate, (_) => new Dup() },
                { Op.OpAdd, (_) => new Addition()},
                { Op.OpEqualVerify, (_) => new EqualVerify()},
                { Op.OpEqual, (_) => new Equal()},
                { Op.OpHash160, (_) => new Hash160()},
                // todo: fix this
                { Op.OpChecksignature, (_) => new CheckSignature(new Secpk256K1Helper())},
                { Op.OpAsciiString, (length)=> new Push(length)}
            };

        private readonly BinaryReader _reader;

        public OpReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public bool TryReadOp(out IOp result)
        {
            try
            {
                var b = _reader.ReadByte();
                var op = GetOp(b);

                result = op.ReadArguments(_reader);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }

        public bool HasEnded => _reader.BaseStream.Position == _reader.BaseStream.Length;

        private static IOp GetOp(byte b)
        {
            var opType = (Op)b;

            if (!OpPool.TryGetValue(opType, out var getOp))
            {
                getOp = OpPool[Op.OpAsciiString];
            }
            

            var op = getOp(b);

            return op;
        }
    }
}