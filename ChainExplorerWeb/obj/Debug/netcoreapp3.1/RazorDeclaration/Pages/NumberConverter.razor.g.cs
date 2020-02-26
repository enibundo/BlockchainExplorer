#pragma checksum "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/NumberConverter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e77db7169825dd3a342241bce9892d999e20b304"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace ChainExplorerWeb.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/_Imports.razor"
using ChainExplorerWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/_Imports.razor"
using ChainExplorerWeb.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/NumberConverter.razor"
using ChainExplorerWeb.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/NumberConverter.razor"
using global::ChainExplorer.Reader;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/numberconverter")]
    public partial class NumberConverter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 75 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/NumberConverter.razor"
       
    
    private string HexToDec { get; set; }
    private string DecToHex { get; set; }
    private string HexLeToHex { get; set; }
    private string VarIntToDecimal { get; set; }
    private string BitsToTarget { get; set; }    
    private string BitsToDifficulty { get; set; }

    private string ResultHexToDec{ get; set; }
    private string ResultDecToHex { get; set; }
    private string ResultHexLeToHex { get; set; }
    private string ResultVarIntToDec { get; set; }
    private string ResultBitsToTarget { get; set; }
    private string ResultBitsToDifficulty { get; set; }

    private void ConvertHexToDec()
        => ResultHexToDec = NumConverter.ConvertHexToDec(HexToDec);
    
    private void ConvertDecToHex()
        => ResultDecToHex = NumConverter.ConvertDecToHex(DecToHex);

    private void ConvertHexLeToHex()
        => ResultHexLeToHex = NumConverter.ConvertHexLeToHex(HexLeToHex);

    private void ConvertVarIntToDecimal()
        => ResultVarIntToDec = NumConverter.ConvertVarIntToDecimal(VarIntToDecimal);

    private void ConvertBitsToTarget()
        => ResultBitsToTarget = NumConverter.ConvertBitsLeToTarget(BitsToTarget);

    private void ConvertBitsToDifficulty()
        => ResultBitsToDifficulty = NumConverter.ConvertBitsToDifficulty(BitsToDifficulty);


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NumConverter NumConverter { get; set; }
    }
}
#pragma warning restore 1591
