#pragma checksum "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf1da0f4cf3b6bd46fcdfb6926e0094c710a5604"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Details.cshtml", typeof(AspNetCore.Views_Home_Details))]
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
#line 1 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\_ViewImports.cshtml"
using EatAp;

#line default
#line hidden
#line 2 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\_ViewImports.cshtml"
using EatAp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf1da0f4cf3b6bd46fcdfb6926e0094c710a5604", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73c92f6dd228500076687911e8ed880e84630a8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(6, 2302, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d49565f1ab6e4be38c35e794b20399e9", async() => {
                BeginContext(12, 74, true);
                WriteLiteral("\r\n        <div class=\"container\">\r\n            <div class=\"page-header\">\r\n");
                EndContext();
#line 5 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                   
                    if(@ViewBag.UserId != null || @ViewBag.AdminId != null ){

#line default
#line hidden
                BeginContext(186, 54, true);
                WriteLiteral("                        <a href=\"/logout\">Logout</a>\r\n");
                EndContext();
#line 8 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                    }
                    else {

#line default
#line hidden
                BeginContext(291, 55, true);
                WriteLiteral("                        <a href=\"/signin\">Login |</a>\r\n");
                EndContext();
                BeginContext(372, 58, true);
                WriteLiteral("                        <a href=\"/business\">Business</a>\r\n");
                EndContext();
#line 13 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                    }
                
               
                  
                  

#line default
#line hidden
                BeginContext(529, 707, true);
                WriteLiteral(@"                
            </div>
            <div class=""row"">
                <div class=""col-xs-9 col-md-7"">
                        <input
                            type=""hidden""
                            role=""uploadcare-uploader""
                            data-multiple=""true""
                            data-multiple-min=""1""
                            data-multiple-max=""10"" />
                </div>
            </div>
           
            <div class=""row"">
            <div class=""col-xs-9 col-md-7"">
              
            </div>
            </div>
           
            <div class=""row"">
                <div class=""col-xs-9 col-md-7"">
                  
");
                EndContext();
#line 40 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                         if(@ViewBag.UserId == null || @ViewBag.AdminId == null ){

#line default
#line hidden
                BeginContext(1320, 108, true);
                WriteLiteral("                            <br>\r\n                            <h6>Must be logged in to leave a review</h6>\r\n");
                EndContext();
#line 43 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                            
                        }

#line default
#line hidden
                BeginContext(1485, 24, true);
                WriteLiteral("                        ");
                EndContext();
#line 45 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                         if (@ViewBag.UserId != null || @ViewBag.AdminId != null ){

#line default
#line hidden
                BeginContext(1570, 30, true);
                WriteLiteral("                            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1600, "\"", 1647, 2);
                WriteAttributeValue("", 1607, "/newreview/", 1607, 11, true);
#line 46 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
WriteAttributeValue("", 1618, ViewBag.CurrentAdmin.AdminId, 1618, 29, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1648, 21, true);
                WriteLiteral(">Leave a Review</a>\r\n");
                EndContext();
#line 47 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                        }

#line default
#line hidden
                BeginContext(1696, 134, true);
                WriteLiteral("                \r\n                    \r\n                    <div class=\"pre-scrollable\" style=\"max-width: 100%; max-height: 300px;\">\r\n");
                EndContext();
#line 51 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                         foreach(var i in @ViewBag.AllReviews){

#line default
#line hidden
                BeginContext(1895, 32, true);
                WriteLiteral("                            <h4>");
                EndContext();
                BeginContext(1928, 6, false);
#line 52 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                           Write(i.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1934, 38, true);
                WriteLiteral("</h4>\r\n                            <p>");
                EndContext();
                BeginContext(1973, 12, false);
#line 53 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                          Write(i.ReviewDesc);

#line default
#line hidden
                EndContext();
                BeginContext(1985, 6, true);
                WriteLiteral("</p>\r\n");
                EndContext();
#line 54 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                             if(i.UserId == @ViewBag.UserId){

#line default
#line hidden
                BeginContext(2054, 34, true);
                WriteLiteral("                                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 2088, "\"", 2114, 2);
                WriteAttributeValue("", 2095, "/delete/", 2095, 8, true);
#line 55 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
WriteAttributeValue("", 2103, i.ReviewId, 2103, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2115, 13, true);
                WriteLiteral(">Delete</a>\r\n");
                EndContext();
#line 56 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                            }

#line default
#line hidden
#line 56 "C:\Users\jaypa\OneDrive\CodingDojo\C#\EatAp\Views\Home\Details.cshtml"
                             
                        }

#line default
#line hidden
                BeginContext(2186, 115, true);
                WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n           \r\n        \r\n        </div>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2308, 9, true);
            WriteLiteral("\r\n</html>");
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
