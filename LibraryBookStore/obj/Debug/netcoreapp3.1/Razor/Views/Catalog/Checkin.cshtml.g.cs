#pragma checksum "C:\Users\Clark\RiderProjects\Library-Management-System\LibraryBookStore\Views\Catalog\Checkin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f89bab57ec2ddbe25518683c70e3b842a8d433f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Catalog_Checkin), @"mvc.1.0.view", @"/Views/Catalog/Checkin.cshtml")]
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
#line 1 "C:\Users\Clark\RiderProjects\Library-Management-System\LibraryBookStore\Views\_ViewImports.cshtml"
using LibraryBookStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Clark\RiderProjects\Library-Management-System\LibraryBookStore\Views\_ViewImports.cshtml"
using LibraryBookStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f89bab57ec2ddbe25518683c70e3b842a8d433f", @"/Views/Catalog/Checkin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2051447eebcc15cefc67893a22bb7bdf2cbe51dd", @"/Views/_ViewImports.cshtml")]
    public class Views_Catalog_Checkin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LibraryBookStore.Models.Checkin.CheckinModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""container"">
    <div class=""header clearfix"">
        <h3 class=""text-muted"">Checkin Item</h3>
    </div>
    <div class=""jumbotron"">
        <div class=""row"">
            <div class=""col-md-3"">
                <div>
                    <p>");
#nullable restore
#line 11 "C:\Users\Clark\RiderProjects\Library-Management-System\LibraryBookStore\Views\Catalog\Checkin.cshtml"
                  Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 357, "\"", 378, 1);
#nullable restore
#line 12 "C:\Users\Clark\RiderProjects\Library-Management-System\LibraryBookStore\Views\Catalog\Checkin.cshtml"
WriteAttributeValue("", 363, Model.ImageUrl, 363, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:90%\" />\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-9\">\r\n");
#nullable restore
#line 16 "C:\Users\Clark\RiderProjects\Library-Management-System\LibraryBookStore\Views\Catalog\Checkin.cshtml"
                 using (Html.BeginForm("CheckIn", "Catalog", FormMethod.Post))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Clark\RiderProjects\Library-Management-System\LibraryBookStore\Views\Catalog\Checkin.cshtml"
               Write(Html.HiddenFor(a=>a.AssetId));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div>\r\n                        Please enter Library Card ID\r\n                        ");
#nullable restore
#line 21 "C:\Users\Clark\RiderProjects\Library-Management-System\LibraryBookStore\Views\Catalog\Checkin.cshtml"
                   Write(Html.TextBoxFor(a=>a.LibraryCardId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        <button type=\"submit\" class=\"btn btn-success btn-lg\">Check In</button>\r\n                    </div>\r\n");
#nullable restore
#line 26 "C:\Users\Clark\RiderProjects\Library-Management-System\LibraryBookStore\Views\Catalog\Checkin.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LibraryBookStore.Models.Checkin.CheckinModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
