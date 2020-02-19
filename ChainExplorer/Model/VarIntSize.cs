namespace ChainExplorer.Model
{
    public enum VarIntSize
    {
        SingleByte = 0x00, // 
        TwoBytes   = 0xfd, // fd
        FourBytes  = 0xfe, // fe
        EightBytes = 0xff  // ff
    }
}