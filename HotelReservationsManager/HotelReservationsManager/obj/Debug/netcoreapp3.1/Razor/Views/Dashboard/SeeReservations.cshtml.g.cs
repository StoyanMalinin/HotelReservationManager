#pragma checksum "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f00763f51efe0d4af3fa42c3520f42178e02bda6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_SeeReservations), @"mvc.1.0.view", @"/Views/Dashboard/SeeReservations.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f00763f51efe0d4af3fa42c3520f42178e02bda6", @"/Views/Dashboard/SeeReservations.cshtml")]
    public class Views_Dashboard_SeeReservations : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HotelReservationsManager.Controllers.Models.ReservationDashboardViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<style>
    table {
        width: 100%;
    }

    th, td {
        text-align: left;
        padding: 8px;
    }

    tr:nth-child(even) {
        background-color: #f2f2f2
    }

    th {
        background-color: #4CAF50;
        color: white;
    }
</style>

");
            WriteLiteral("\n");
#nullable restore
#line 23 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
   ViewData["Title"] = "Reservations"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<table class=\"table\">\n");
            WriteLiteral(@"    <thead>
        <tr>
            <th>
                id
            </th>
            <th>
                RoomNumber
            </th>
            <th>
                Cost
            </th>
            <th>
                Clients
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 44 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
         foreach (var item in Model.Items)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 48 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
           Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 51 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
           Write(item.room.number);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 54 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
           Write(item.cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 57 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
           Write(string.Join("|", item.clients.Select(x => $"{x.client.firstName} {x.client.lastName}")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 60 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n    <ul class=\"pagination\">\n");
#nullable restore
#line 63 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
         for (var i = 1; i <= Model.Pager.PagesCount; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<li");
            BeginWriteAttribute("class", " class=\"", 1314, "\"", 1379, 2);
            WriteAttributeValue("", 1322, "page-item", 1322, 9, true);
#nullable restore
#line 65 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
WriteAttributeValue(" ", 1331, i == Model.Pager.CurrentPage ? "active" : "", 1332, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f00763f51efe0d4af3fa42c3520f42178e02bda66742", async() => {
#nullable restore
#line 66 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
                                                     Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Pager.CurrentPage", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
                        WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Pager.CurrentPage"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Pager.CurrentPage", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Pager.CurrentPage"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</li>");
#nullable restore
#line 67 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\n</table>\n\n<br> </br>\n<input type=\"button\" value=\"Go back to the Dashboard\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1538, "\"", 1596, 3);
            WriteAttributeValue("", 1548, "location.href=\'", 1548, 15, true);
#nullable restore
#line 72 "C:\Users\Stoyan\source\repos\HotelReservationsManager\HotelReservationsManager\Views\Dashboard\SeeReservations.cshtml"
WriteAttributeValue("", 1563, Url.Action("Dashboard", "Home"), 1563, 32, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1595, "\'", 1595, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HotelReservationsManager.Controllers.Models.ReservationDashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
