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

namespace Signum.Web.Extensions.Auth.Views
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
    using Signum.Entities.Authorization;
    using Signum.Utilities;
    using Signum.Web;
    using Signum.Web.Auth;
    using Signum.Web.Extensions.Properties;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Auth/Views/Login.cshtml")]
    public class Login : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Login()
        {
        }
        public override void Execute()
        {

            
            #line 1 "..\..\Auth\Views\Login.cshtml"
    
    ViewBag.Title = Resources.LoginEnter;


            
            #line default
            #line hidden
WriteLiteral("<script type=\"text/javascript\">\r\n    $(function () { $(\"#username\").focus(); });\r" +
"\n</script>\r\n<div class=\"sf-login-page\">\r\n<h2>\r\n    Login</h2>\r\n<p>\r\n    ");


            
            #line 11 "..\..\Auth\Views\Login.cshtml"
Write(Resources.IntroduceYourUserNameAndPassword);

            
            #line default
            #line hidden
WriteLiteral("\r\n</p>\r\n");


            
            #line 13 "..\..\Auth\Views\Login.cshtml"
Write(Html.ValidationSummary());

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 14 "..\..\Auth\Views\Login.cshtml"
 using (Html.BeginForm())
{

            
            #line default
            #line hidden
WriteLiteral("    <div>\r\n        <table>\r\n            <tr>\r\n                <td>\r\n             " +
"       ");


            
            #line 20 "..\..\Auth\Views\Login.cshtml"
               Write(Resources.User);

            
            #line default
            #line hidden
WriteLiteral(":\r\n                </td>\r\n                <td>\r\n                    ");


            
            #line 23 "..\..\Auth\Views\Login.cshtml"
               Write(Html.TextBox("username"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    ");


            
            #line 24 "..\..\Auth\Views\Login.cshtml"
               Write(Html.ValidationMessage("username"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td" +
">\r\n                    ");


            
            #line 29 "..\..\Auth\Views\Login.cshtml"
               Write(Resources.Password);

            
            #line default
            #line hidden
WriteLiteral(":\r\n                </td>\r\n                <td>\r\n                    ");


            
            #line 32 "..\..\Auth\Views\Login.cshtml"
               Write(Html.Password("password"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    ");


            
            #line 33 "..\..\Auth\Views\Login.cshtml"
               Write(Html.ValidationMessage("password"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td" +
">\r\n                </td>\r\n                <td>\r\n");


            
            #line 40 "..\..\Auth\Views\Login.cshtml"
                     if (Request.Browser.Cookies)
                    {
                        
            
            #line default
            #line hidden
            
            #line 42 "..\..\Auth\Views\Login.cshtml"
                   Write(Html.CheckBox("rememberMe"));

            
            #line default
            #line hidden
            
            #line 42 "..\..\Auth\Views\Login.cshtml"
                                                     
            
            #line default
            #line hidden
            
            #line 42 "..\..\Auth\Views\Login.cshtml"
                                                Write(Resources.RememberMe);

            
            #line default
            #line hidden
            
            #line 42 "..\..\Auth\Views\Login.cshtml"
                                                                          
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\r\n            </tr>\r\n            <tr>\r\n                <td>\r" +
"\n                </td>\r\n                <td>\r\n                    <input class=\"" +
"sf-button login\" type=\"submit\" value=\"");


            
            #line 50 "..\..\Auth\Views\Login.cshtml"
                                                                   Write(Resources.LoginEnter);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n                </td>\r\n            </tr>\r\n");


            
            #line 53 "..\..\Auth\Views\Login.cshtml"
             if (AuthClient.ResetPasswordStarted)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>\r\n                    </td>\r\n      " +
"              <td>\r\n                        <div id=\"sf-login-reset-password\">");


            
            #line 59 "..\..\Auth\Views\Login.cshtml"
                                                     Write(Html.ActionLink(Resources.IHaveForgottenMyPassword, "resetPassword", "auth"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </td>\r\n                </tr>\r\n");


            
            #line 62 "..\..\Auth\Views\Login.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </table>\r\n");


            
            #line 64 "..\..\Auth\Views\Login.cshtml"
         if (ViewData.ContainsKey("referrer"))
        { 
            
            
            #line default
            #line hidden
            
            #line 66 "..\..\Auth\Views\Login.cshtml"
       Write(Html.Hidden("referrer", ViewData["referrer"]));

            
            #line default
            #line hidden
            
            #line 66 "..\..\Auth\Views\Login.cshtml"
                                                           
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");


            
            #line 69 "..\..\Auth\Views\Login.cshtml"
} 

            
            #line default
            #line hidden
WriteLiteral("</div>");


        }
    }
}
#pragma warning restore 1591