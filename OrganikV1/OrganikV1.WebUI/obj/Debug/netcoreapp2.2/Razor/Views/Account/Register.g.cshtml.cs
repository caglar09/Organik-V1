#pragma checksum "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d427b4a7d07a3ee0a0e1654d478ddb71bdf2872"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Register.cshtml", typeof(AspNetCore.Views_Account_Register))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d427b4a7d07a3ee0a0e1654d478ddb71bdf2872", @"/Views/Account/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c678b9d81118625dc7085bdb8276f7f790319a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Account/Login"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Account\Register.cshtml"
  
    ViewData["Title"] = "Kayıt Ol";
    Layout = "~/Views/Shared/_DetailLayout.cshtml";

#line default
#line hidden
            BeginContext(99, 89, true);
            WriteLiteral("\r\n\r\n<div id=\"container\">\r\n    <div class=\"container\">\r\n        <!-- Breadcrumb Start-->\r\n");
            EndContext();
#line 16 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Account\Register.cshtml"
         if (TempData["loginstatus"] != null)
        {
            

#line default
#line hidden
            BeginContext(509, 34, false);
#line 18 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Account\Register.cshtml"
       Write(TempData["loginstatus"].ToString());

#line default
#line hidden
            EndContext();
#line 18 "C:\Users\cglr1\source\Workspaces\OrganikV1\OrganikV1\OrganikV1.WebUI\Views\Account\Register.cshtml"
                                               
        }

#line default
#line hidden
            BeginContext(556, 726, true);
            WriteLiteral(@"
        <!-- Breadcrumb End-->
        <div class=""row"">
            <!--Middle Part Start-->
            <div id=""content"" class=""col-sm-12"">
                <h1 class=""title"">Hesap Girişi</h1>
                <div class=""row"">
                    <div class=""col-sm-6"">
                        <h2 class=""subtitle"">Üye  Misin?</h2>
                        <p><strong>Hesabına Giriş Yapmak Aşağıdaki Butona Tıkla</strong></p>
                        <p>
                            By creating an account you will be able to shop faster, be up to date on an order's status,
                            and keep track of the orders you have previously made.
                        </p>
                        ");
            EndContext();
            BeginContext(1282, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d427b4a7d07a3ee0a0e1654d478ddb71bdf28726837", async() => {
                BeginContext(1332, 9, true);
                WriteLiteral("Giriş Yap");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1345, 139, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-sm-6\">\r\n                        <h2 class=\"subtitle\">Yeni Kayıt ol</h2>\r\n");
            EndContext();
            BeginContext(1563, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(1587, 1844, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d427b4a7d07a3ee0a0e1654d478ddb71bdf28728491", async() => {
                BeginContext(1629, 1795, true);
                WriteLiteral(@"
                            <div class=""form-group"">
                                <label class=""control-label"" for=""input-email"">Ad</label>
                                <input type=""text"" name=""name"" value="""" placeholder=""Adınızz"" id=""input-email"" class=""form-control"" />
                            </div>
                            <div class=""form-group"">
                                <label class=""control-label"" for=""input-email"">Soyad</label>
                                <input type=""text"" name=""lastname"" value="""" placeholder=""Soyadınızz"" id=""input-email"" class=""form-control"" />
                            </div>
                            <div class=""form-group"">
                                <label class=""control-label"" for=""input-email"">E-Mail Address</label>
                                <input type=""email"" name=""email"" value="""" placeholder=""E-Mail Address"" id=""input-email"" class=""form-control"" />
                            </div>
                            <div class=""");
                WriteLiteral(@"form-group"">
                                <label class=""control-label"" for=""input-password"">Şifre</label>
                                <input type=""password"" name=""password"" value="""" placeholder=""Password"" id=""input-password"" class=""form-control"" />
                            </div>

                            <div class=""form-group"">
                                <label class=""control-label"" for=""input-password"">Şifre Tekrar</label>
                                <input type=""password"" name=""passwordConfirm"" value="""" placeholder=""Şİfre Doğrulama"" id=""input-password"" class=""form-control"" />
                            </div>
                            <input type=""submit"" value=""Kayıt Ol"" class=""btn btn-primary"" />
                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3431, 120, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        \r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
