#pragma checksum "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86500657a9f62212e8a043698d52cb337af52656"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserProfiles_Show), @"mvc.1.0.view", @"/Views/UserProfiles/Show.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UserProfiles/Show.cshtml", typeof(AspNetCore.Views_UserProfiles_Show))]
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
#line 1 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\_ViewImports.cshtml"
using Musportz;

#line default
#line hidden
#line 2 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\_ViewImports.cshtml"
using Musportz.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86500657a9f62212e8a043698d52cb337af52656", @"/Views/UserProfiles/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"161baffb6d7d8c6079b85a1f992cd00151aa4bf9", @"/Views/_ViewImports.cshtml")]
    public class Views_UserProfiles_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Musportz.Models.UserProfile>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Browse", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(36, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml"
  
    ViewData["Title"] = "Show Profile";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(133, 163, true);
            WriteLiteral("\r\n<h2>Showing Profile for this Musportz user.</h2>\r\n\r\n<div>\r\n    <h4>Musportz Profiles</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(297, 45, false);
#line 15 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(342, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(386, 41, false);
#line 18 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(427, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(471, 44, false);
#line 21 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(515, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(559, 40, false);
#line 24 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(599, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(643, 42, false);
#line 27 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml"
       Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(685, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(729, 38, false);
#line 30 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml"
       Write(Html.DisplayFor(model => model.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(767, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(811, 45, false);
#line 33 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml"
       Write(Html.DisplayNameFor(model => model.PhotoPath));

#line default
#line hidden
            EndContext();
            BeginContext(856, 47, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 903, "\"", 963, 2);
            WriteAttributeValue("", 909, "\\userPhotos\\", 909, 12, true);
#line 36 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml"
WriteAttributeValue("", 921, Html.DisplayFor(model => model.PhotoPath), 921, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(964, 71, true);
            WriteLiteral(" width=\"200\" height=\"200\" />\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1036, 39, false);
#line 39 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml"
       Write(Html.DisplayNameFor(model => model.Bio));

#line default
#line hidden
            EndContext();
            BeginContext(1075, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1119, 35, false);
#line 42 "C:\Users\ACT-Student\Source\Repos\samalade\SD2103\Musportz\Musportz\Views\UserProfiles\Show.cshtml"
       Write(Html.DisplayFor(model => model.Bio));

#line default
#line hidden
            EndContext();
            BeginContext(1154, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1201, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b26d871a81bc4219b6333e3daf9fddd4", async() => {
                BeginContext(1224, 14, true);
                WriteLiteral("Back to Browse");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1242, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Musportz.Models.UserProfile> Html { get; private set; }
    }
}
#pragma warning restore 1591
