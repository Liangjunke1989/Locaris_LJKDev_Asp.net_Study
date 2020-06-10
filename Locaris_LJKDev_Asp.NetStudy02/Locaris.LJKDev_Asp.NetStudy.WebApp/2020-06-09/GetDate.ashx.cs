using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_09
{
    /// <summary>
    /// GetDate 的摘要说明
    /// </summary>
    public class GetDate : IHttpHandler
    {
        //处理请求
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //Get时：
            // string name = context.Request.QueryString["name"];
            //Post时：
            // string name = context.Request.Form["name"];
            //可以简写为：
            string name = context.Request["name"];
            string pwd = context.Request["pwd"];
            context.Response.Write("姓名:" + name);
            context.Response.Write("密码:" + pwd);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}