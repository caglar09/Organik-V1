#pragma checksum "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Shared\Components\Categories\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad69bc737b374741980c42531d15f6051a7a1b82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Categories_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Categories/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Categories/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Categories_Default))]
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
#line 1 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\_ViewImports.cshtml"
using OrganikV1.WebUI;

#line default
#line hidden
#line 2 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\_ViewImports.cshtml"
using OrganikV1.WebUI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad69bc737b374741980c42531d15f6051a7a1b82", @"/Views/Shared/Components/Categories/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c678b9d81118625dc7085bdb8276f7f790319a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Categories_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrganikV1.WebUI.ViewModel.HomeViewModel>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(57, 32, true);
            WriteLiteral("<ul id=\"cat_accordion\"> \r\n    \r\n");
            EndContext();
#line 7 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Shared\Components\Categories\Default.cshtml"
     foreach (var item in Model.Categories.Where(x => x.altCatId == 0))
    {
        var subCat = Model.Categories.Where(x => x.altCatId != 0);

#line default
#line hidden
            BeginContext(237, 26, true);
            WriteLiteral("        <li>\r\n            ");
            EndContext();
            BeginContext(263, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad69bc737b374741980c42531d15f6051a7a1b823934", async() => {
                BeginContext(287, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(289, 22, false);
#line 11 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Shared\Components\Categories\Default.cshtml"
                                Write(item.catName.ToUpper());

#line default
#line hidden
                EndContext();
                BeginContext(311, 1, true);
                WriteLiteral(" ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 272, "~/", 272, 2, true);
#line 11 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Shared\Components\Categories\Default.cshtml"
AddHtmlAttributeValue("", 274, item.catId, 274, 11, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(316, 64, true);
            WriteLiteral("<span class=\"down\"></span>\r\n           \r\n                <ul >\r\n");
            EndContext();
#line 14 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Shared\Components\Categories\Default.cshtml"
                     foreach (var altCat in subCat)
                    {

                        

#line default
#line hidden
#line 17 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Shared\Components\Categories\Default.cshtml"
                         if (altCat.altCatId == item.catId)
                        {

#line default
#line hidden
            BeginContext(546, 33, true);
            WriteLiteral("                            <li> ");
            EndContext();
            BeginContext(579, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad69bc737b374741980c42531d15f6051a7a1b826792", async() => {
                BeginContext(606, 24, false);
#line 19 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Shared\Components\Categories\Default.cshtml"
                                                      Write(altCat.catName.ToUpper());

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 588, "~/", 588, 2, true);
#line 19 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Shared\Components\Categories\Default.cshtml"
AddHtmlAttributeValue("", 590, altCat.catId, 590, 13, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(634, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 20 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Shared\Components\Categories\Default.cshtml"
                        }

#line default
#line hidden
#line 20 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Shared\Components\Categories\Default.cshtml"
                         

                    }

#line default
#line hidden
            BeginContext(693, 49, true);
            WriteLiteral("                </ul>\r\n         \r\n        </li>\r\n");
            EndContext();
#line 26 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Shared\Components\Categories\Default.cshtml"

    }

#line default
#line hidden
            BeginContext(751, 9, true);
            WriteLiteral("\r\n</ul>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrganikV1.WebUI.ViewModel.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
