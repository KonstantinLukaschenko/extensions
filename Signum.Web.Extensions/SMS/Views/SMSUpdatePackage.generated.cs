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

namespace Signum.Web.Extensions.SMS.Views
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
    
    #line 1 "..\..\SMS\Views\SMSUpdatePackage.cshtml"
    using Signum.Entities.SMS;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/SMS/Views/SMSUpdatePackage.cshtml")]
    public class SMSUpdatePackage : System.Web.Mvc.WebViewPage<dynamic>
    {
        public SMSUpdatePackage()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\SMS\Views\SMSUpdatePackage.cshtml"
 using (var sc = Html.TypeContext<SMSUpdatePackageDN>()) 
{
	
            
            #line default
            #line hidden
            
            #line 5 "..\..\SMS\Views\SMSUpdatePackage.cshtml"
Write(Html.ValueLine(sc, s => s.Name));

            
            #line default
            #line hidden
            
            #line 5 "..\..\SMS\Views\SMSUpdatePackage.cshtml"
                                 
	
            
            #line default
            #line hidden
            
            #line 6 "..\..\SMS\Views\SMSUpdatePackage.cshtml"
Write(Html.ValueLine(sc, s => s.NumLines));

            
            #line default
            #line hidden
            
            #line 6 "..\..\SMS\Views\SMSUpdatePackage.cshtml"
                                     
	
            
            #line default
            #line hidden
            
            #line 7 "..\..\SMS\Views\SMSUpdatePackage.cshtml"
Write(Html.ValueLine(sc, s => s.NumErrors));

            
            #line default
            #line hidden
            
            #line 7 "..\..\SMS\Views\SMSUpdatePackage.cshtml"
                                      
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\SMS\Views\SMSUpdatePackage.cshtml"
Write(Html.SearchControl(new FindOptions(typeof(SMSMessageDN))
    {
        FilterOptions = { new FilterOption("Entity.UpdatePackage", sc.Value) { Frozen = true } },
        SearchOnLoad = true
    }, new Context(sc, "smpM")));

            
            #line default
            #line hidden
            
            #line 12 "..\..\SMS\Views\SMSUpdatePackage.cshtml"
                               ;
}

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
