#pragma checksum "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Account\ResetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2eb119f99275b8414f5e563223abbf5cc77a7214"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ResetPassword), @"mvc.1.0.view", @"/Views/Account/ResetPassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/ResetPassword.cshtml", typeof(AspNetCore.Views_Account_ResetPassword))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2eb119f99275b8414f5e563223abbf5cc77a7214", @"/Views/Account/ResetPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c678b9d81118625dc7085bdb8276f7f790319a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ResetPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Confirm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Account\ResetPassword.cshtml"
  
    ViewData["Title"] = "ResetPassword";
    Layout = "~/Views/Shared/_DetailLayout.cshtml";

#line default
#line hidden
#line 6 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Account\ResetPassword.cshtml"
 if (TempData["loginstatus"] != null)
{

#line default
#line hidden
            BeginContext(146, 44, true);
            WriteLiteral("    <div class=\"alert alert-info\">\r\n        ");
            EndContext();
            BeginContext(191, 24, false);
#line 9 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Account\ResetPassword.cshtml"
   Write(TempData["updateStatus"]);

#line default
#line hidden
            EndContext();
            BeginContext(215, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 11 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Account\ResetPassword.cshtml"
}

#line default
#line hidden
            BeginContext(232, 39, true);
            WriteLiteral("\r\n<div class=\"col-sm-9 col-md-9\">\r\n    ");
            EndContext();
            BeginContext(271, 660, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2eb119f99275b8414f5e563223abbf5cc77a72145293", async() => {
                BeginContext(312, 612, true);
                WriteLiteral(@"
        <fieldset id=""account"">
            <div class=""form-group required"">
                <label for=""email"" class=""col-sm-2 control-label"">Email Adresiniz</label>
                <div class=""col-sm-10"">
                    <input type=""email"" class=""form-control"" id=""email"" placeholder=""Email Adresiniz.."" name=""email"">
                </div>
            </div>
        </fieldset>
        <div class=""buttons"">
            <div class=""pull-right"">

                <input type=""submit"" class=""btn btn-primary"" value=""Şifre sıfırlama linkini gönder!"">
            </div>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(931, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591