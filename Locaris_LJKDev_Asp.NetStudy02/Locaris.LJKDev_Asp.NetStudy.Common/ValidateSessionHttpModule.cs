using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Locaris.LJKDev_Asp.NetStudy.Common
{
    public class ValidateSessionHttpModule : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += Context_AcquireRequestState;
        }

        private void Context_AcquireRequestState(object sender, EventArgs e)
        {
            if (sender is HttpApplication application)
            {
                HttpContext context = application.Context;               //获取当前的HttpContext
                string url = context.Request.Url.ToString();             //获取用户  请求的URL的地址
                if (url.Contains("Admin"))
                {
                    if (context.Session["userInfo"]==null)              
                    {
                        context.Response.Redirect("/Login.aspx");    //报404，应该呈现404指向页面,地址的指向问题！！！！
                    }
                }
            }
            
        }
    }
}
