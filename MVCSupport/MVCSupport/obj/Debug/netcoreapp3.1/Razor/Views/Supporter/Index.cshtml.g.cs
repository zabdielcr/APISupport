#pragma checksum "C:\Users\zabdiel\Desktop\MVCSupport\MVCSupport\Views\Supporter\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c0ee0b93024aba3baf2011af9a4278aaf8f4d19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Supporter_Index), @"mvc.1.0.view", @"/Views/Supporter/Index.cshtml")]
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
#line 1 "C:\Users\zabdiel\Desktop\MVCSupport\MVCSupport\Views\_ViewImports.cshtml"
using MVCSupport;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zabdiel\Desktop\MVCSupport\MVCSupport\Views\_ViewImports.cshtml"
using MVCSupport.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c0ee0b93024aba3baf2011af9a4278aaf8f4d19", @"/Views/Supporter/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3769297360d195b0b9e3dd409a5a4736f023123", @"/Views/_ViewImports.cshtml")]
    public class Views_Supporter_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MVCSupport.Models.Domain.Supporter>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\zabdiel\Desktop\MVCSupport\MVCSupport\Views\Supporter\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row no-gutter"">

        <div class=""col-md-6 d-none d-md-flex bg-image""></div>



        <div class=""col-md-6 bg-light"">
            <div class=""login d-flex align-items-center py-5"">

                <div class=""container"">
                    <div class=""row"">
                        <div class=""col-lg-10 col-xl-7 mx-auto"">
                            <h3 class=""display-4"">Login</h3>
                            <p class=""text-muted mb-4""> </p>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c0ee0b93024aba3baf2011af9a4278aaf8f4d194027", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 24 "C:\Users\zabdiel\Desktop\MVCSupport\MVCSupport\Views\Supporter\Index.cshtml"
                                 using (Html.BeginForm("Index", "Supporter", FormMethod.Post))
                                {

                               

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div class=\"form-group mb-3\">\r\n                                    <input id=\"inputEmail\" type=\"email\" placeholder=\"Email address\"");
                BeginWriteAttribute("required", " required=\"", 963, "\"", 974, 0);
                EndWriteAttribute();
                WriteLiteral(@"  class=""form-control rounded-pill border-0 shadow-sm px-4"" autocomplete=""off"">
                                   
                                </div>
                                <div class=""form-group mb-3"">
                                    <input id=""inputPassword"" type=""password"" placeholder=""Password""");
                BeginWriteAttribute("required", " required=\"", 1296, "\"", 1307, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control rounded-pill border-0 shadow-sm px-4 text-primary"" autocomplete=""off"">
                                    
                                </div>
                                <div class=""custom-control custom-checkbox mb-3"">
                                    <input id=""customCheck1"" type=""checkbox"" checked class=""custom-control-input"">
                                    <label for=""customCheck1"" class=""custom-control-label"">Remember password</label>
                                </div>
                                <button type=""submit"" class=""btn btn-primary btn-block text-uppercase mb-2 rounded-pill shadow-sm"">Sign in</button>
                                <div class=""text-center d-flex justify-content-between mt-4"">
                                   
                                </div>
");
#nullable restore
#line 44 "C:\Users\zabdiel\Desktop\MVCSupport\MVCSupport\Views\Supporter\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n     \r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MVCSupport.Models.Domain.Supporter> Html { get; private set; }
    }
}
#pragma warning restore 1591