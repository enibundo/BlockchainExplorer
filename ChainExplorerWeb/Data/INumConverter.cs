namespace ChainExplorerWeb.Data
{
    public interface INumConverter
    {

        string ConvertHexToDec(string hex);
        string ConvertDecToHex(string dec);
        string ConvertHexLeToHex(string hexLe);
        string ConvertVarIntToDecimal(string varInt);
        string ConvertBitsLeToTarget(string bits);
        string ConvertBitsToDifficulty(string bits);
    }
}