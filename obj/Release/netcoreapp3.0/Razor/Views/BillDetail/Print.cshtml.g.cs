#pragma checksum "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Print.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f87fa6d4f6216d1cae7beef15fc16ebf11a7d51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BillDetail_Print), @"mvc.1.0.view", @"/Views/BillDetail/Print.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f87fa6d4f6216d1cae7beef15fc16ebf11a7d51", @"/Views/BillDetail/Print.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12db8319006053a00c9642548ae6eb4d2930a4d1", @"/Views/_ViewImports.cshtml")]
    public class Views_BillDetail_Print : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Zedx.Models.DTO.BillRequest>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_BillDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Print.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id=""divPrint"">
    <div>
        <div class=""row border border-dark"">
            <div class=""col-md-3""></div>
            <div class=""col-md-6""><h4>Haji Aluminum,Glass and Hardware Store</h4></div>
            <div class=""col-md-3""></div>
        </div>
        <div class=""row border border-dark mt-1 mb-1"">
            <div class=""col-md-1"">Bill Id</div><div class=""col-md-1"">");
#nullable restore
#line 14 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Print.cshtml"
                                                                Write(Model.BillId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"col-md-1\">Customer</div><div class=\"col-md-2\">");
#nullable restore
#line 15 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Print.cshtml"
                                                                 Write(Model.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"col-md-1\">Date</div><div class=\"col-md-2\">");
#nullable restore
#line 16 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Print.cshtml"
                                                             Write(Model.BillDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6f87fa6d4f6216d1cae7beef15fc16ebf11a7d514992", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 20 "H:\ali softwares solutions\zedx\Zedx\Views\BillDetail\Print.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <style>\r\n        tfoot td {\r\n            border: none !important;\r\n        }\r\n\r\n        tfoot {\r\n            border-top: 1px solid black;\r\n        }\r\n\r\n        ");
                WriteLiteral("@media print {\r\n            body {\r\n                width: 21cm;\r\n                height: 29.7cm;\r\n                margin: 5mm 5mm 5mm 5mm;\r\n            }\r\n        }\r\n    </style>\r\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        jQuery(document).ready(function () {
            RemoveExtraInfo();
            HeightWidthExist();
            Print();
        });

        function HeightWidthExist() {
            var IsRemove = true;
            $("".sheetWidth"").each(function () {
                if ($.trim($(this).text()) > 0) { IsRemove = false; }
            });
            $("".sheetHeight"").each(function () {
                if ($.trim($(this).text()) > 0) { IsRemove = false; }
            });
            if (IsRemove) {
                $("".sheetHeight,.sheetWidth,.thHeight,.thwidth"").remove();
            }
        }
        function RemoveExtraInfo() {
            $("".tdAction"").remove();
            $(""table"").removeClass(""table-striped"");
            $(""footer"").remove();
        }
        function Print() {
            window.print();
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Zedx.Models.DTO.BillRequest> Html { get; private set; }
    }
}
#pragma warning restore 1591