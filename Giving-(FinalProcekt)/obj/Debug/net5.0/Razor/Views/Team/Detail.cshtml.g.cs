#pragma checksum "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b0264a22a2189dff09c03a813678963cd4973fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Team_Detail), @"mvc.1.0.view", @"/Views/Team/Detail.cshtml")]
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
#line 1 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\_ViewImports.cshtml"
using Giving__FinalProcekt_;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\_ViewImports.cshtml"
using Giving__FinalProcekt_.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\_ViewImports.cshtml"
using Giving__FinalProcekt_.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b0264a22a2189dff09c03a813678963cd4973fe", @"/Views/Team/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49a68e18925983fb9377b5c78fbffa2b7728d7a3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Team_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VmVolunteer>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Team", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-width:100%;height:auto;object-fit:cover;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Banner start -->\r\n<section>\r\n    <div class=\"banner\">\r\n        <div class=\"bg-image\"");
            BeginWriteAttribute("style", " style=\"", 198, "\"", 258, 4);
            WriteAttributeValue("", 206, "background-image:", 206, 17, true);
            WriteAttributeValue(" ", 223, "url(/Uploads/", 224, 14, true);
#nullable restore
#line 9 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml"
WriteAttributeValue("", 237, Model.Banner.Image, 237, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 256, ");", 256, 2, true);
            EndWriteAttribute();
            WriteLiteral(@">
            <div class=""wpb-wraper"">
            </div>
        </div>
    </div>
    <div class=""banner-title"">
        <div class=""container"">
            <div class=""row"">
                <div class=""pens"">
                    <div class=""left"">
                        <h3>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b0264a22a2189dff09c03a813678963cd4973fe6204", async() => {
                WriteLiteral("Team Detail");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Banner End -->
<!-- Team Details Start -->
<section>
    <div class=""contentdt"">
        <div class=""container"">
            <div class=""row"">
                <div class=""image col-sm-4 col-md-4"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2b0264a22a2189dff09c03a813678963cd4973fe7949", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1022, "~/Uploads/", 1022, 10, true);
#nullable restore
#line 35 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml"
AddHtmlAttributeValue("", 1032, Model.Volunteer.Image, 1032, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"context col-sm-8 col-md-8\">\r\n                    <h3 class=\"vlt-title\">");
#nullable restore
#line 38 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml"
                                     Write(Model.Volunteer.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <span class=\"vlt-role\">");
#nullable restore
#line 39 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml"
                                      Write(Model.Volunteer.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    <h3 class=\"bio\">Biography</h3>\r\n                    <div class=\"vlt-desc\">\r\n                        <p>");
#nullable restore
#line 42 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml"
                      Write(Model.Volunteer.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"vlt-exp\">\r\n                        Experience in volunteering:\r\n                        <span class=\"text\">");
#nullable restore
#line 46 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml"
                                      Write(Model.Volunteer.Experience);

#line default
#line hidden
#nullable disable
            WriteLiteral(" years</span>\r\n                    </div>\r\n");
            WriteLiteral(@"                </div>
                <div class=""u-fade-type-down js-scroll-trigger"">
                    <div class=""row"" style=""padding-left: 100px;"">
                        <div class=""plugns col-md-4"">
                            <h3>01. Donator</h3>
                            <p>");
#nullable restore
#line 75 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml"
                          Write(Model.Volunteer.DonaterTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            <div class=""vlt-circle-wrap"">
                                <div class=""vlt-circle-inner"">
                                    <i class=""fas fa-heart""></i>
                                </div>
                                <div class=""vlt-info"">
                                    <span class=""text"">$ ");
#nullable restore
#line 81 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml"
                                                    Write(Model.Volunteer.DonaterCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    <span>Donation made</span>
                                </div>
                            </div>
                        </div>
                        <div class=""plugns col-md-4"">
                            <h3>01. Volunteer</h3>
                            <p>");
#nullable restore
#line 88 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml"
                          Write(Model.Volunteer.VoluteerTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </p>
                            <div class=""vlt-circle-wrap"">
                                <div class=""vlt-circle-inner"">
                                    <i class=""fas fa-user-plus""></i>
                                </div>
                                <div class=""vlt-info"">
                                    <span class=""text"">");
#nullable restore
#line 94 "C:\Users\Sahib\Desktop\BackEnd\Giving-(FinalProcekt)\Giving-(FinalProcekt)\Views\Team\Detail.cshtml"
                                                  Write(Model.Volunteer.VoluteerCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    <span>People volunteered</span>
                                </div>
                            </div>
                        </div>
                        <div class=""plugns col-md-4"">
                            <h3>01. Adopter</h3>
                            <!-- <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis um voluptatum deleniti atque orrupti quos </p> -->
                            <div class=""vlt-circle-wrap"">
                                <div class=""vlt-circle-inner"">
                                    <i class=""fas fa-home""></i>
                                </div>
                                <div class=""vlt-info"">
                                    <span class=""text"">5</span>
                                    <span>Children adopted</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </d");
            WriteLiteral("iv>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- Team Details End -->");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VmVolunteer> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591