using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Locaris.LJKDev_Asp.NetStudy.Common
{
    public class ValidateSessionHttpModule : IHttpModule
    {
        //请求管道
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 完成请求管道中事件的注册
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += Context_AcquireRequestState;
        }
        /// <summary>
        /// 请求管道中的第9个事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Context_AcquireRequestState(object sender, EventArgs e)
        {
            if (sender is HttpApplication application)
            {
                HttpContext context = application.Context;               //获取当前的HttpContext,context就是请求报文！
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
