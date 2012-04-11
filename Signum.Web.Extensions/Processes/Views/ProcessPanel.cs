﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using Signum.Utilities;
    using Signum.Entities;
    using Signum.Web;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web.Caching;
    using System.Web.DynamicData;
    using System.Web.SessionState;
    using System.Web.Profile;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Xml.Linq;
    using Signum.Utilities.ExpressionTrees;
    using Signum.Engine.Processes;
    using Signum.Web.Processes;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MvcRazorClassGenerator", "1.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Processes/Views/ProcessPanel.cshtml")]
    public class _Page_Processes_Views_ProcessPanel_cshtml : System.Web.Mvc.WebViewPage<ProcessLogicState>
    {


        public _Page_Processes_Views_ProcessPanel_cshtml()
        {
        }
        protected System.Web.HttpApplication ApplicationInstance
        {
            get
            {
                return ((System.Web.HttpApplication)(Context.ApplicationInstance));
            }
        }
        public override void Execute()
        {




WriteLiteral("<div id=\"processMainDiv\">\r\n    <h2>");


   Write(ViewData[ViewDataKeys.Title]);

WriteLiteral("</h2>\r\n    <div>\r\n        <a href=\"");


            Write(Url.Action((ProcessController pc) => pc.Stop()));

WriteLiteral("\" class=\"sf-button\" style=\"");


                                                                                        Write(Model.Running ? "" : "display:none");

WriteLiteral(";color:red\" id=\"sfProcessDisable\">\r\n            Stop </a>\r\n        <a href=\"");


            Write(Url.Action((ProcessController pc) => pc.Start()));

WriteLiteral("\" class=\"sf-button\"  style=\"");


                                                                                          Write(!Model.Running ? "" : "display:none");

WriteLiteral("\" id=\"sfProcessEnable\">\r\n                Start </a>\r\n    </div>\r\n    \r\n    ");


Write(Html.ScriptsJs("~/signum/scripts/SF_FindNavigator.js", 
                    "~/Processes/Scripts/SF_Process.js"));

WriteLiteral("\r\n\r\n    ");


Write(Html.Partial(ProcessesClient.ViewPrefix.Formato("ProcessPanelTable")));

WriteLiteral("\r\n    <script language=\"javascript\">\r\n        $(function () {\r\n            SF.Pro" +
"cess.init(function () {\r\n                $.get(\"");


                  Write(Url.Action((ProcessController p) => p.View()));

WriteLiteral("\", function (data) {\r\n                    $(\"div.processMainDiv\").replaceWith(dat" +
"a);\r\n                });\r\n            });\r\n        });\r\n    </script>\r\n</div>\r\n");


        }
    }
}