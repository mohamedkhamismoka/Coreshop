#pragma checksum "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\Users\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2328d79b476014dec4410faeec3013c9f40faada"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_Profile), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/Profile.cshtml")]
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
#line 1 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\_ViewImports.cshtml"
using coreShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\_ViewImports.cshtml"
using coreShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\_ViewImports.cshtml"
using coreShop.BL.VM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\_ViewImports.cshtml"
using coreShop.DAL.Extend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2328d79b476014dec4410faeec3013c9f40faada", @"/Areas/Admin/Views/Users/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8b1ec5fee974b38ad65f814a1bf16f677c2d565", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Users_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationUser>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\Users\Profile.cshtml"
  
    ViewData["Title"] = "Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">

            <div class=""col-md-12"">
                <div class=""card"">
                    <div class=""header"">
                        <h4 class=""title"">User Profile</h4>

                    </div>
                    <div class=""content table-responsive table-full-width"">
                        <table class=""table table-striped"">
                            <tbody>

                                <tr>
                                    <th>ID</th>
                                    <td>");
#nullable restore
#line 23 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\Users\Profile.cshtml"
                                   Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n\r\n                                <tr>\r\n                                    <th>Name</th>\r\n");
#nullable restore
#line 28 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\Users\Profile.cshtml"
                                     for (int i = 0; i < Model.UserName.Length; i++)
                                    {
                                        if (Model.UserName[i] == '@')
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>");
#nullable restore
#line 32 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\Users\Profile.cshtml"
                                           Write(Model.UserName.Substring(0,i));

#line default
#line hidden
#nullable disable
            WriteLiteral("  </td>\r\n");
#nullable restore
#line 33 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\Users\Profile.cshtml"
                                        }


                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tr>\r\n\r\n                                <tr>\r\n                                    <th>Email</th>\r\n                                    <td>");
#nullable restore
#line 41 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\Users\Profile.cshtml"
                                   Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n\r\n                                <tr>\r\n                                    <th>address</th>\r\n                                    <td>");
#nullable restore
#line 46 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\Users\Profile.cshtml"
                                   Write(Model.address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n\r\n\r\n\r\n                                <tr>\r\n                                    <th>Status</th>\r\n");
#nullable restore
#line 53 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\Users\Profile.cshtml"
                                     if (Model.isActive)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>Active</td>\r\n");
#nullable restore
#line 56 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\Users\Profile.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>Blocked</td>\r\n");
#nullable restore
#line 60 "C:\Users\EL-Masria\Desktop\coreShop\coreShop\Areas\Admin\Views\Users\Profile.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </tr>\r\n\r\n                            </tbody>\r\n\r\n                        </table>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591