﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Extensions.ControlPanel.Views
{
    using System;
    using System.Collections.Generic;
    
    #line 1 "..\..\ControlPanel\Views\UserChartPart.cshtml"
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
    
    #line 8 "..\..\ControlPanel\Views\UserChartPart.cshtml"
    using Signum.Engine.Chart;
    
    #line default
    #line hidden
    
    #line 9 "..\..\ControlPanel\Views\UserChartPart.cshtml"
    using Signum.Engine.DynamicQuery;
    
    #line default
    #line hidden
    using Signum.Entities;
    
    #line 6 "..\..\ControlPanel\Views\UserChartPart.cshtml"
    using Signum.Entities.Chart;
    
    #line default
    #line hidden
    
    #line 3 "..\..\ControlPanel\Views\UserChartPart.cshtml"
    using Signum.Entities.ControlPanel;
    
    #line default
    #line hidden
    
    #line 5 "..\..\ControlPanel\Views\UserChartPart.cshtml"
    using Signum.Entities.DynamicQuery;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    #line 7 "..\..\ControlPanel\Views\UserChartPart.cshtml"
    using Signum.Web.Chart;
    
    #line default
    #line hidden
    
    #line 4 "..\..\ControlPanel\Views\UserChartPart.cshtml"
    using Signum.Web.ControlPanel;
    
    #line default
    #line hidden
    
    #line 2 "..\..\ControlPanel\Views\UserChartPart.cshtml"
        
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/ControlPanel/Views/UserChartPart.cshtml")]
    public class UserChartPart : System.Web.Mvc.WebViewPage<PanelPartDN>
    {
        public UserChartPart()
        {
        }
        public override void Execute()
        {











            
            #line 11 "..\..\ControlPanel\Views\UserChartPart.cshtml"
Write(Html.ScriptsJs("~/Chart/Scripts/SF_Chart.js",
                "~/Chart/Scripts/SF_Chart_Utils.js",
                "~/scripts/d3.v2.min.js",
                "~/scripts/colorbrewer.js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 15 "..\..\ControlPanel\Views\UserChartPart.cshtml"
Write(Html.ScriptCss("~/Chart/Content/SF_Chart.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 16 "..\..\ControlPanel\Views\UserChartPart.cshtml"
   
    var ucPart = (UserChartPartDN)Model.Content;
    UserChartDN uc = ucPart.UserChart;
    ChartRequest request = uc.ToRequest();

    using (var crc = new TypeContext<ChartRequest>(request, "r{0}c{1}".Formato(Model.Row, Model.Column)))
    {
        ResultTable resultTable = ChartLogic.ExecuteChart(request);



            
            #line default
            #line hidden
WriteLiteral("    <div id=\"");


            
            #line 26 "..\..\ControlPanel\Views\UserChartPart.cshtml"
        Write(crc.Compose("sfChartControl"));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"sf-search-control sf-chart-control\" data-prefix=\"");


            
            #line 26 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                                                                                                Write(crc.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n        <div style=\"display: none\">\r\n            ");


            
            #line 28 "..\..\ControlPanel\Views\UserChartPart.cshtml"
       Write(Html.HiddenRuntimeInfo(crc));

            
            #line default
            #line hidden
WriteLiteral("\r\n            ");


            
            #line 29 "..\..\ControlPanel\Views\UserChartPart.cshtml"
       Write(Html.Hidden(crc.Compose("sfOrders"), request.Orders.IsNullOrEmpty() ? "" :
                    (request.Orders.ToString(oo => (oo.OrderType == OrderType.Ascending ? "" : "-") + oo.Token.FullKey(), ";") + ";")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 31 "..\..\ControlPanel\Views\UserChartPart.cshtml"
              
        ViewData[ViewDataKeys.QueryDescription] = DynamicQueryManager.Current.QueryDescription(request.QueryName);
        ViewData[ViewDataKeys.FilterOptions] = request.Filters.Select(f => new FilterOption { Token = f.Token, Operation = f.Operation, Value = f.Value }).ToList();
            

            
            #line default
            #line hidden
WriteLiteral("            ");


            
            #line 35 "..\..\ControlPanel\Views\UserChartPart.cshtml"
       Write(Html.Partial(Navigator.Manager.FilterBuilderView, crc));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div id=\"");


            
            #line 36 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                Write(crc.Compose("sfChartBuilderContainer"));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                ");


            
            #line 37 "..\..\ControlPanel\Views\UserChartPart.cshtml"
           Write(Html.Partial(ChartClient.ChartBuilderView, crc));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <script type=\"text/javascript\">\r\n              " +
"          $(\'#");


            
            #line 40 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                       Write(crc.Compose("sfChartBuilderContainer"));

            
            #line default
            #line hidden
WriteLiteral("\').chartBuilder($.extend({ prefix: \'");


            
            #line 40 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                                                                                                  Write(crc.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\'}, ");


            
            #line 40 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                                                                                                                    Write(MvcHtmlString.Create(uc.ToJS()));

            
            #line default
            #line hidden
WriteLiteral("));\r\n            </script>\r\n        </div>\r\n        <div id=\"");


            
            #line 43 "..\..\ControlPanel\Views\UserChartPart.cshtml"
            Write(crc.Compose("sfChartContainer"));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n            <div class=\"sf-chart-container\" style=\"display:");


            
            #line 44 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                                                       Write(ucPart.ShowData ? "none" : "block");

            
            #line default
            #line hidden
WriteLiteral("\" \r\n                    data-open-url=\"");


            
            #line 45 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                               Write(Url.Action<ChartController>(cc => cc.OpenSubgroup(crc.ControlID)));

            
            #line default
            #line hidden
WriteLiteral("\" \r\n                    data-fullscreen-url=\"");


            
            #line 46 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                                     Write(Url.Action<ChartController>(cc => cc.FullScreen(crc.ControlID)));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                    data-json=\"");


            
            #line 47 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                          Write(Html.Json(ChartUtils.DataJson(crc.Value, resultTable)).ToString());

            
            #line default
            #line hidden
WriteLiteral("\">\r\n            </div>\r\n        </div>\r\n    </div>\r\n");


            
            #line 51 "..\..\ControlPanel\Views\UserChartPart.cshtml"
    
        if (ucPart.ShowData)
        {
            ViewData[ViewDataKeys.Results] = resultTable;
            ViewData[ViewDataKeys.Navigate] = false;

            QuerySettings settings = Navigator.QuerySettings(request.QueryName);
            ViewData[ViewDataKeys.Formatters] = resultTable.Columns.Select((c, i) => new { c, i }).ToDictionary(c => c.i, c => settings.GetFormatter(c.c.Column));

            
            
            #line default
            #line hidden
            
            #line 60 "..\..\ControlPanel\Views\UserChartPart.cshtml"
       Write(Html.Partial(ChartClient.ChartResultsTableView, new TypeContext<ChartRequest>(request, "r{0}c{1}".Formato(Model.Row, Model.Column))));

            
            #line default
            #line hidden
            
            #line 60 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                                                                                                                                                 
        }
        else
        {
            MvcHtmlString divSelector = MvcHtmlString.Create("#" + crc.Compose("sfChartContainer") + " > .sf-chart-container");
   

            
            #line default
            #line hidden
WriteLiteral("            <script type=\"text/javascript\">\r\n                (function () {\r\n    " +
"                var $myChart = SF.Chart.getFor(\'");


            
            #line 68 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                                               Write(crc.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n                    $myChart.reDraw();\r\n                })();\r\n            <" +
"/script>\r\n");


            
            #line 72 "..\..\ControlPanel\Views\UserChartPart.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        <script type=\"text/javascript\">\r\n            (function () {\r\n            " +
"    $(\"#\" + SF.compose(\"");


            
            #line 75 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                               Write(crc.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\", \"sfFullScreen\")).on(\"mousedown\", function (e) {\r\n                    var $myCh" +
"art = SF.Chart.getFor(\'");


            
            #line 76 "..\..\ControlPanel\Views\UserChartPart.cshtml"
                                               Write(crc.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n                    $myChart.fullScreen(e);\r\n                });\r\n          " +
"  })();\r\n        </script>\r\n");


            
            #line 81 "..\..\ControlPanel\Views\UserChartPart.cshtml"
    }


            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
