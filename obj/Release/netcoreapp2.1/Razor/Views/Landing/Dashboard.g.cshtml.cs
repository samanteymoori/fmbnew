#pragma checksum "C:\Users\saman\documents\visual studio 2017\Projects\FMB\FMB\Views\Landing\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a2030e0439eeb11a1a3946c8439b887ce447acd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Landing_Dashboard), @"mvc.1.0.view", @"/Views/Landing/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Landing/Dashboard.cshtml", typeof(AspNetCore.Views_Landing_Dashboard))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a2030e0439eeb11a1a3946c8439b887ce447acd", @"/Views/Landing/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32c16790e5bb6d9b96896fb8f8b5c886fea16ef3", @"/Views/_ViewImports.cshtml")]
    public class Views_Landing_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "50", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "100", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "200", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(132, 1903, true);
            WriteLiteral(@"<script src=""https://cdn.jsdelivr.net/npm/vue/dist/vue.js""></script>
<div id=""app"">

    <div class=""x_panel"">
        <div class=""x_title"">
            <h2>Claims Dashboard <small></small></h2>
            <ul class=""nav navbar-right panel_toolbox"">
                <li>
                    <a class=""collapse-link""><i class=""fa fa-chevron-up""></i></a>
                </li>
                <li class=""dropdown"">
                    <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"" role=""button"" aria-expanded=""false""><i class=""fa fa-wrench""></i></a>
                    <ul class=""dropdown-menu"" role=""menu"">
                        <li>
                            <a href=""#"">Settings 1</a>
                        </li>
                        <li>
                            <a href=""#"">Settings 2</a>
                        </li>
                    </ul>
                </li>
                <li>
                    <a class=""close-link""><i class=""fa fa-close""></i></a>
         ");
            WriteLiteral(@"       </li>
            </ul>
            <div class=""clearfix""></div>
        </div>
        <div class=""x_content"">
            <p class=""text-muted font-13 m-b-30"">
            </p>
            <div id=""datatable_wrapper"" class=""dataTables_wrapper form-inline dt-bootstrap no-footer"">
                <div class=""row"">
                    <div class=""col-sm-6"">
                        <div class=""dataTables_length"" id=""datatable_length"">
                            <label>
                                Show <select name=""datatable_length""
                                             v-on:change=""loadData(1)""
                                             id=""pageSize""
                                             aria-controls=""datatable""
                                             class=""form-control input-sm"">
                                    ");
            EndContext();
            BeginContext(2035, 30, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b5b44186a0c4267a0077347ef851ffb", async() => {
                BeginContext(2054, 2, true);
                WriteLiteral("50");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2065, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(2103, 32, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a877b2d1081427591c65771d4090c57", async() => {
                BeginContext(2123, 3, true);
                WriteLiteral("100");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2135, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(2173, 32, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2ff37dd6eac46a5ae50d605645bc59c", async() => {
                BeginContext(2193, 3, true);
                WriteLiteral("200");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2205, 8272, true);
            WriteLiteral(@"
                                </select> entries
                            </label>
                        </div>
                    </div><div class=""col-sm-6""><div id=""datatable_filter"" class=""dataTables_filter""><label><input type=""search"" placeholder=""Search"" name=""search_criteria"" id=""search_criteria"" class=""form-control input-sm"" placeholder="""" aria-controls=""datatable""><input type=""button"" value=""Search"" style=""font-size:8pt;padding:7px;margin:0px"" class=""btn btn-info btn-lg"" v-on:click=""loadData"" /></label></div></div>
                </div>
                <div class=""row"">
                    <div class=""col-sm-5""></div><div class=""col-sm-7"">
                        <div class=""dataTables_paginate paging_simple_numbers"" id=""datatable_paginate"">
                            <ul class=""pagination"">

                                <li v-for=""p in pages"" class=""paginate_button "">
                                    <a href=""#"" v-if=""p!=pi"" aria-controls=""datatable"" :data-dt-idx=""p"" v-on");
            WriteLiteral(@":click=""loadData(p)"" tabindex=""0"">{{p}}</a>
                                    <a href=""#"" v-else aria-controls=""datatable"" :data-dt-idx=""p"" v-on:click=""loadData(p)"" tabindex=""0""><b>{{p}}</b></a>

                                </li>

                            </ul>
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-sm-12"">
                        <table id=""datatable"" class=""table table-striped table-bordered dataTable no-footer"" role=""grid"" aria-describedby=""datatable_info"">
                            <thead>
                                <tr role=""row"">
                                    <th class=""sorting_asc"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-sort=""ascending"" aria-label=""Name: activate to sort column descending"">
                                        #
                                    </th>
                                    <th class=""sorting_asc"" tabind");
            WriteLiteral(@"ex=""0"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-sort=""ascending"" aria-label=""Name: activate to sort column descending"">
                                        Claim
                                    </th>
                                    <th class=""sorting"" style=""width:225px"" tabindex=""0"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-label=""Position: activate to sort column ascending"">
                                        Patient
                                    </th>
                                    <th class=""sorting"" tabindex=""0"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-label=""Office: activate to sort column ascending"">
                                        Provider
                                    </th>
                                    <th tabindex=""0"" style=""width:225px"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-label=""Age: activate to sort column ascending"">
                                        Carrier
              ");
            WriteLiteral(@"                      </th>
                                    <th tabindex=""0"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-label=""Age: activate to sort column ascending"">
                                        Date
                                    </th>
                                    <th tabindex=""0"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-label=""Age: activate to sort column ascending"">
                                        Status
                                    </th>
                                    <th tabindex=""0"" class=""ctd"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-label=""Age: activate to sort column ascending"">
                                        Billed
                                    </th>
                                    <th tabindex=""0"" class=""ctd"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-label=""Age: activate to sort column ascending"">
                                        Ins
                           ");
            WriteLiteral(@"         </th>
                                    <th tabindex=""0"" class=""ctd"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-label=""Age: activate to sort column ascending"">
                                        Adj
                                    </th>
                                    <th tabindex=""0"" class=""ctd"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-label=""Age: activate to sort column ascending"">
                                        Pat Pay
                                    </th>
                                    <th tabindex=""0"" class=""ctd"" aria-controls=""datatable"" rowspan=""1"" colspan=""1"" aria-label=""Age: activate to sort column ascending"">
                                        Balance
                                    </th>
                                    <th  class=""ctd"">
                                        Action
                                    </th>
                                </tr>

                            </thead>
    ");
            WriteLiteral(@"                        <tbody>
                                <tr v-for=""item in rows"" role=""row"" class=""odd"">
                                    <td>
                                        {{item.rn}}
                                    </td>
                                    <td>
                                        {{item.claimnumber}}
                                    </td>
                                    <td>
                                        {{item.patientfullname}}
                                    </td>
                                    <td>
                                        {{item.providerfullname}}
                                    </td>
                                    <td>
                                        {{item.carriername}}
                                    </td>
                                    <td>
                                        {{item.datefiled}}
                                    </td>
                             ");
            WriteLiteral(@"       <td>
                                        {{item.claimStatus}}
                                    </td>
                                    <td  class=""ctd"">
                                        {{item.billed}}
                                    </td>
                                    <td class=""ctd"">
                                        {{item.insurance}}
                                    </td>
                                    <td class=""ctd"">
                                        {{item.adjustments}}
                                    </td>
                                    <td class=""ctd"">
                                        {{item.patientPay}}
                                    </td>
                                    <td class=""ctd"">
                                        {{item.balance}}
                                    </td>
                                    <td class=""ctd"">
                                        <a href=""#"" v-on:click=""edit");
            WriteLiteral(@"(item)""><i class=""fa fa-edit""></i></a>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div><div class=""row"">
                    <div class=""col-sm-5""></div><div class=""col-sm-7"">
                        <div class=""dataTables_paginate paging_simple_numbers"" id=""datatable_paginate"">
                            <ul class=""pagination"">

                                <li v-for=""p in pages"" class=""paginate_button "">
                                    <a href=""#"" v-if=""p!=pi"" aria-controls=""datatable"" :data-dt-idx=""p"" v-on:click=""loadData(p)"" tabindex=""0"">{{p}}</a>
                                    <a href=""#"" v-else aria-controls=""datatable"" :data-dt-idx=""p"" v-on:click=""loadData(p)"" tabindex=""0""><b>{{p}}</b></a>

                                </li>

                            </ul>
                        </div>
                    </div>
");
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            BeginContext(10477, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c15a861cf5e8490d8e685b1721ba6c7e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(10519, 1865, true);
            WriteLiteral(@"

<script type=""text/javascript"">
    var $ = window.jQuery;
    var app = new Vue({
        el: '#app',
        data: {
            rows: [],
            pi: 0,
            pages: [],
            
        },
        mounted() {
            this.loadData();
        },
        methods: {
            edit(item) {
                alert(JSON.stringify( item));
            },
            loadData(pageIndex=1) {
                let that = this;
                var ps = $(""#pageSize"").val();
                var search = $(""#search_criteria"").val();
                var vic = 0;
                this.pi = pageIndex;
                that.rows = new Array();
                $.ajax({
                    type: ""POST"",
                    url: ""Dashboard"",
                    dataType: ""json"",
                    contentType: ""application/json; charset=utf-8"",
                    data: JSON.stringify({ ""SearchCriteria"": search, ""PageIndex"": pageIndex-1, ""PageSize"": ps }),
                    ");
            WriteLiteral(@"success: function (data) {
                        $(data).each(function (index, d) {
                            if (index == 0) {
                                vic = d.virtualItemCount;
                            }
                            if (d) {
                                that.rows.push(d);
                            }
                        });
                        that.pages = new Array();
                        for (var i = 0; i <= vic / ps; i++) {
                            that.pages.push(i+1);
                        }
                    },
                    failure: function (errMsg) {
                        alert(errMsg);
                    }
                });
            }
        }
    })
</script>
<style>
    
    .ctd {
        text-align: center;
    }
</style>");
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