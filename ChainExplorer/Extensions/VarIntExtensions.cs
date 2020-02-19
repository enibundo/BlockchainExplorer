using ChainExplorer.Model;

namespace ChainExplorer.Extensions
{
    public static class VarIntExtensions
    {
        public static int ToBytesLength(this VarIntSize varIntSize)
        => varIntSize switch
        {
            VarIntSize.TwoBytes => 2,
            VarIntSize.FourBytes => 4,
            VarIntSize.EightBytes => 8,
            _ => 0
        };
        
    }
}
