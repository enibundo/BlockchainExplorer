using System.ComponentModel;

namespace ChainExplorer.Script.StackCalculator.Operator
{
    public enum Op
    {
        [Description("OP_0")]
        Op0 = 0x00,
        
        [Description("OP_1")]
        Op1 = 0x51,

        [Description("OP_DUP")]
        OpDuplicate = 0x76,
        
        [Description("OP_VERIFY")]
        OpVerify = 0x69,
        
        [Description("OP_EQUAL")]
        OpEqual = 0x87,
        
        [Description("OP_EQUALVERIFY")]
        OpEqualVerify = 0x88,

        [Description("OP_ADD")]
        OpAdd = 0x93,

        [Description("OP_HASH160")]
        OpHash160 = 0xa9,
        
        [Description("OP_CHECKSIG")]
        OpChecksignature = 0xac,

        OpChecklocktimeverify = 0xb1,

        OpAsciiString,
        OpHashString
    }
}
