namespace ChainExplorerWeb.Data
{
    public interface INumConverter
    {

        string ConvertHexToDec(string hex);
        string ConvertDecToHex(string dec);
        string ConvertHexLeToHex(string hexLe);
        string ConvertVarIntToDecimal(string varInt);
        string ConvertBitsLeToDifficulty(string bits);
        
    }
}