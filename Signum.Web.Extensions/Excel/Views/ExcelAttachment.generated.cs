﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
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
    
    #line 1 "..\..\Excel\Views\ExcelAttachment.cshtml"
    using Signum.Entities.Excel;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    #line 2 "..\..\Excel\Views\ExcelAttachment.cshtml"
    using Signum.Web.Excel;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Excel\Views\ExcelAttachment.cshtml"
    using Signum.Web.UserQueries;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Excel/Views/ExcelAttachment.cshtml")]
    public partial class _Excel_Views_ExcelAttachment_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Excel_Views_ExcelAttachment_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Excel\Views\ExcelAttachment.cshtml"
 using (var sc = Html.TypeContext<ExcelAttachmentEntity>())
{
    
            
            #line default
            #line hidden
            
            #line 6 "..\..\Excel\Views\ExcelAttachment.cshtml"
Write(Html.ValueLine(sc, s => s.FileName));

            
            #line default
            #line hidden
            
            #line 6 "..\..\Excel\Views\ExcelAttachment.cshtml"
                                        
    
            
            #line default
            #line hidden
            
            #line 7 "..\..\Excel\Views\ExcelAttachment.cshtml"
Write(Html.ValueLine(sc, s => s.Title));

            
            #line default
            #line hidden
            
            #line 7 "..\..\Excel\Views\ExcelAttachment.cshtml"
                                     
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Excel\Views\ExcelAttachment.cshtml"
Write(Html.EntityLine(sc, s => s.UserQuery, el => el.AttachFunction = ExcelClient.Module["attachUserQuery"](el,
    sc.SubContextPrefix(a => a.Related),
    Url.Action((UserQueriesController c) => c.GetUserQueryImplementations()))));

            
            #line default
            #line hidden
            
            #line 10 "..\..\Excel\Views\ExcelAttachment.cshtml"
                                                                              
    
            
            #line default
            #line hidden
            
            #line 11 "..\..\Excel\Views\ExcelAttachment.cshtml"
Write(Html.EntityLine(sc, s => s.Related, el => { el.Autocomplete = true; el.Find = true; }));

            
            #line default
            #line hidden
            
            #line 11 "..\..\Excel\Views\ExcelAttachment.cshtml"
                                                                                           
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591