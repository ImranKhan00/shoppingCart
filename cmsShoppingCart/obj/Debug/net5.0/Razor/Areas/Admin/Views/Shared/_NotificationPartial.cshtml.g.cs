#pragma checksum "C:\Users\636\source\repos\CmsShoppingCart\cmsShoppingCart\Areas\Admin\Views\Shared\_NotificationPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31f94866479f10e885c36c883f564ab29cba9473"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__NotificationPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_NotificationPartial.cshtml")]
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
#line 1 "C:\Users\636\source\repos\CmsShoppingCart\cmsShoppingCart\Areas\Admin\Views\_ViewImports.cshtml"
using cmsShoppingCart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\636\source\repos\CmsShoppingCart\cmsShoppingCart\Areas\Admin\Views\_ViewImports.cshtml"
using cmsShoppingCart.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31f94866479f10e885c36c883f564ab29cba9473", @"/Areas/Admin/Views/Shared/_NotificationPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33324cf3ace512fab67311ee85d94a47121c9c6f", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__NotificationPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\636\source\repos\CmsShoppingCart\cmsShoppingCart\Areas\Admin\Views\Shared\_NotificationPartial.cshtml"
 if(TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div class=\"alert alert-success notification\">\r\n\t\t");
#nullable restore
#line 4 "C:\Users\636\source\repos\CmsShoppingCart\cmsShoppingCart\Areas\Admin\Views\Shared\_NotificationPartial.cshtml"
   Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t</div>\r\n");
#nullable restore
#line 6 "C:\Users\636\source\repos\CmsShoppingCart\cmsShoppingCart\Areas\Admin\Views\Shared\_NotificationPartial.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\636\source\repos\CmsShoppingCart\cmsShoppingCart\Areas\Admin\Views\Shared\_NotificationPartial.cshtml"
 if(TempData["Error"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div class=\"alert alert-danger notification\">\r\n\t\t");
#nullable restore
#line 11 "C:\Users\636\source\repos\CmsShoppingCart\cmsShoppingCart\Areas\Admin\Views\Shared\_NotificationPartial.cshtml"
   Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t</div>\r\n");
#nullable restore
#line 13 "C:\Users\636\source\repos\CmsShoppingCart\cmsShoppingCart\Areas\Admin\Views\Shared\_NotificationPartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
