#pragma checksum "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51c8ddf0a3e36969eceb173a695972b88ef85f46"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BillDetail_Details), @"mvc.1.0.view", @"/Views/BillDetail/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "H:\ali softwares solutions\zedx\Zedx\Views\_ViewImports.cshtml"
using Zedx;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\ali softwares solutions\zedx\Zedx\Views\_ViewImports.cshtml"
using Zedx.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51c8ddf0a3e36969eceb173a695972b88ef85f46", @"/Views/BillDetail/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12db8319006053a00c9642548ae6eb4d2930a4d1", @"/Views/_ViewImports.cshtml")]
    public class Views_BillDetail_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Zedx.Models.BillDetail>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>BillDetail</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AluminumColor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.AluminumColor.AluminumColorId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AluminumGage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.AluminumGage.AluminumGageId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Rate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.Rate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Feet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.Feet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalFeet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.TotalFeet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 62 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NetAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 65 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.NetAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 68 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DiscountedAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 71 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.DiscountedAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 74 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AmountToBePaid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 77 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.AmountToBePaid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 80 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Bill));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 83 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.Bill.BillId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 86 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SheetHeight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 89 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.SheetHeight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 92 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SheetWidth));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 95 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.SheetWidth));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 98 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedById));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 101 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedById));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 104 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ModifiedById));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 107 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.ModifiedById));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 110 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 113 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 116 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ModifiedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 119 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.ModifiedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 122 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Deleted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 125 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
       Write(Html.DisplayFor(model => model.Deleted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51c8ddf0a3e36969eceb173a695972b88ef85f4615922", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 130 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Details.cshtml"
                           WriteLiteral(Model.BillDetailId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51c8ddf0a3e36969eceb173a695972b88ef85f4618065", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Zedx.Models.BillDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591
