﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Extensions.ControlPanel.Views
{
    using System;
    using System.Collections.Generic;
    
    #line 1 "..\..\ControlPanel\Views\PanelPartView.cshtml"
    using System.Configuration;
    
    #line default
    #line hidden
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Signum.Entities;
    
    #line 3 "..\..\ControlPanel\Views\PanelPartView.cshtml"
    using Signum.Entities.ControlPanel;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    #line 4 "..\..\ControlPanel\Views\PanelPartView.cshtml"
    using Signum.Web.ControlPanel;
    
    #line default
    #line hidden
    
    #line 2 "..\..\ControlPanel\Views\PanelPartView.cshtml"
        
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/ControlPanel/Views/PanelPartView.cshtml")]
    public class PanelPartView : System.Web.Mvc.WebViewPage<PanelPartDN>
    {
        public PanelPartView()
        {
        }
        public override void Execute()
        {





WriteLiteral("           \r\n");


            
            #line 7 "..\..\ControlPanel\Views\PanelPartView.cshtml"
   
    string prefix = "r{0}c{1}".Formato(Model.Row, Model.Column);
    ControlPanelClient.PartViews config = ControlPanelClient.PanelPartViews[Model.Content.GetType()];


            
            #line default
            #line hidden
WriteLiteral("<div class=\"ui-widget ui-widget-content ui-corner-all sf-ftbl-part\">\r\n    <div cl" +
"ass=\"ui-widget-header ui-corner-all sf-ftbl-part-header\">\r\n        ");


            
            #line 13 "..\..\ControlPanel\Views\PanelPartView.cshtml"
   Write(Model.ToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n        ");


            
            #line 14 "..\..\ControlPanel\Views\PanelPartView.cshtml"
   Write(Html.TextBox(prefix + "Title", Model.Title, new { style = "display:none" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 15 "..\..\ControlPanel\Views\PanelPartView.cshtml"
         if (config.FullScreenLink)
        {

            
            #line default
            #line hidden
WriteLiteral("            <a id=\"");


            
            #line 17 "..\..\ControlPanel\Views\PanelPartView.cshtml"
              Write(TypeContextUtilities.Compose(prefix, "sfFullScreen"));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"sf-ftbl-header-fullscreen\">\r\n                <span class=\"ui-icon ui-ico" +
"n-extlink\">fullscreen</span>\r\n            </a>\r\n");


            
            #line 20 "..\..\ControlPanel\Views\PanelPartView.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n    <div>\r\n");


            
            #line 23 "..\..\ControlPanel\Views\PanelPartView.cshtml"
           Html.RenderPartial(config.FrontEnd, Model); 

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n    <div>\r\n        ");


            
            #line 26 "..\..\ControlPanel\Views\PanelPartView.cshtml"
   Write(Html.Hidden(prefix + "Row", Model.Row, new { @class = "sf-ftbl-part-row" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        ");


            
            #line 27 "..\..\ControlPanel\Views\PanelPartView.cshtml"
   Write(Html.Hidden(prefix + "Column", Model.Column, new { @class = "sf-ftbl-part-col" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>");


        }
    }
}
#pragma warning restore 1591
