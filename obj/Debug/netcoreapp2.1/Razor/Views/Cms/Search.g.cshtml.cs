#pragma checksum "C:\Users\saman\documents\visual studio 2017\Projects\FMB\FMB\Views\Cms\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abe01ce8c3a97be34c3c2e0c4a065f969dce264b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cms_Search), @"mvc.1.0.view", @"/Views/Cms/Search.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cms/Search.cshtml", typeof(AspNetCore.Views_Cms_Search))]
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
#line 1 "C:\Users\saman\documents\visual studio 2017\Projects\FMB\FMB\Views\_ViewImports.cshtml"
using FMBPublic;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abe01ce8c3a97be34c3c2e0c4a065f969dce264b", @"/Views/Cms/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32c16790e5bb6d9b96896fb8f8b5c886fea16ef3", @"/Views/_ViewImports.cshtml")]
    public class Views_Cms_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<FMBPublic.Model.Icd10SearchResponse>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(173, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(182, 599, true);
            WriteLiteral(@"<div class=""x_panel"">
    <div class=""x_title"">
        <h2>Icd 10</h2>
    </div>
    <div class=""x_content"">

        <table class=""table"">
            <thead>
                <tr>
                    <th>
                        #
                    </th>
                    <th>
                        Code
                    </th>
                    <th>
                        Is header
                    </th>
                    <th>
                        Description
                    </th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 31 "C:\Users\saman\documents\visual studio 2017\Projects\FMB\FMB\Views\Cms\Search.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(846, 193, true);
            WriteLiteral("                    <tr>\r\n                        <td></td>\r\n                        <td></td>\r\n                        <td></td>\r\n                        <td></td>\r\n                    </tr>\r\n");
            EndContext();
#line 39 "C:\Users\saman\documents\visual studio 2017\Projects\FMB\FMB\Views\Cms\Search.cshtml"
                }

#line default
#line hidden
            BeginContext(1058, 64, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<FMBPublic.Model.Icd10SearchResponse>> Html { get; private set; }
    }
}
#pragma warning restore 1591