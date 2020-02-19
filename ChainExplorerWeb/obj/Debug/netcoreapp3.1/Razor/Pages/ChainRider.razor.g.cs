#pragma checksum "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3976c1aac8341587cf4baeaea9e33ef595ac39a0"
// <auto-generated/>
#pragma warning disable 1591
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
#line 3 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
using System.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
using ChainExplorer.Script.Validator;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
using Microsoft.AspNetCore.WebUtilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
using global::ChainExplorer.Reader;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
using global::ChainExplorer.Model;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/blockexplorer")]
    public partial class ChainRider : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Chain Rider : a BTC Block Parser</h1>\n\nBlock Id: ");
            __builder.OpenElement(1, "input");
            __builder.AddAttribute(2, "type", "text");
            __builder.AddAttribute(3, "width", "500");
            __builder.AddAttribute(4, "class", "form-control");
            __builder.AddAttribute(5, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 16 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
                                     BlockId

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => BlockId = __value, BlockId));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(7, " \n<br>\n");
            __builder.OpenElement(8, "button");
            __builder.AddAttribute(9, "class", "btn btn-primary btn-sm");
            __builder.AddAttribute(10, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
                                                  ParseBlock

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(11, "Parse Block");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "<br>\n<hr>\n\n");
#nullable restore
#line 21 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
  
    var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
    var parameters = QueryHelpers.ParseQuery(uri.Query);
    
    if (parameters.TryGetValue("block", out var blockId))
    {
        BlockId = blockId;
        ParseBlock();
    }
 

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(13, "\n");
#nullable restore
#line 32 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
 if (Block.HasValue)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(14, "    ");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "alert alert-primary");
            __builder.AddAttribute(17, "role", "alert");
            __builder.AddMarkupContent(18, "\n        Version: ");
            __builder.AddContent(19, 
#nullable restore
#line 35 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
                  PrintByteArr(@Block.Value.Version.ToArray())

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(20, "<br>\n        PrevBlock: ");
            __builder.AddContent(21, 
#nullable restore
#line 36 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
                    PrintByteArr(@Block.Value.PreviousBlockHash.ToArray())

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(22, "<br>\n        Bits: ");
            __builder.AddContent(23, 
#nullable restore
#line 37 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
               PrintByteArr(@Block.Value.Bits.ToArray())

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(24, "<br>\n        Nonce: ");
            __builder.AddContent(25, 
#nullable restore
#line 38 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
                PrintByteArr(@Block.Value.Nonce.ToArray())

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(26, "<br>\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\n");
            __builder.AddContent(28, "    ");
            __builder.OpenElement(29, "ul");
            __builder.AddAttribute(30, "style", "list-style: none;");
            __builder.AddMarkupContent(31, "\n");
#nullable restore
#line 42 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
     for (var i = 0; i < _transactions.Count; i++)
    {
        var transaction = _transactions[i];
        

#line default
#line hidden
#nullable disable
            __builder.AddContent(32, "        ");
            __builder.OpenElement(33, "li");
            __builder.AddMarkupContent(34, " \n            \n            ");
            __builder.OpenElement(35, "span");
            __builder.AddAttribute(36, "class", "badge badge-primary");
            __builder.AddContent(37, "TRX ");
            __builder.AddContent(38, 
#nullable restore
#line 48 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
                                                   i

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(39, " ");
            __builder.CloseElement();
            __builder.AddContent(40, " : ");
            __builder.AddContent(41, 
#nullable restore
#line 48 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
                                                                PrintByteArr(@transaction.TrxId)

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(42, "<br>\n            \n            ");
            __builder.AddMarkupContent(43, "<span class=\"oi oi-account-login\">&nbsp;</span>Inputs: ");
            __builder.AddContent(44, 
#nullable restore
#line 50 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
                                                                    transaction.TransactionInputs.Length

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(45, "<br>\n            ");
            __builder.AddMarkupContent(46, "<span class=\"oi oi-account-logout\">&nbsp;</span>Outputs: ");
            __builder.AddContent(47, 
#nullable restore
#line 51 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
                                                                      transaction.TransactionOutputs.Length

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(48, "<br> \n            \n            ");
            __builder.OpenElement(49, "button");
            __builder.AddAttribute(50, "class", "btn btn-info");
            __builder.AddAttribute(51, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 53 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
                                                     e=>TransactionScript(@transaction)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(52, "visualize script");
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\n\n            <hr>\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\n");
#nullable restore
#line 57 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(55, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\n");
#nullable restore
#line 59 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 62 "/home/eni/Documents/code/BlockchainExplorer/ChainExplorerWeb/Pages/ChainRider.razor"
       

    
    private string BlockId { get; set; }
    private Block? Block;
    private readonly IList<Transaction> _transactions = new List<Transaction>();
    private bool BlockParseRequested { get; set; } = false;
    
    private void TransactionScript(Transaction trx)
    {
        var script = BitConverter.ToString(trx.Script).Replace("-", string.Empty);
        NavigationManager.NavigateTo($"/trxscript?script={script}", true); 
    }

    private string PrintByteArr(byte[] arr)
    {
        return BitConverter.ToString(arr).Replace("-", string.Empty).ToLower();
    }

    private async void ParseBlock()
    {
        BlockParseRequested = true;

        // get ascii-hex from blockchain.info,
        // todo: run and query own node
        var url = $"https://blockchain.info/block/{BlockId}?format=hex";

        var objResponse = WebRequest.Create(url).GetResponse();
        var reader = new AsciiFileBinaryReader(new HexReader(), objResponse.GetResponseStream());
        var loggedReader = new LoggedBinaryReader(reader);
        
        Block = BitcoinReader.ReadBlock(loggedReader, (t =>
        {
            _transactions.Add(t);
        }));
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private TransactionValidator TransactionValidator { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BitcoinReader BitcoinReader { get; set; }
    }
}
#pragma warning restore 1591
