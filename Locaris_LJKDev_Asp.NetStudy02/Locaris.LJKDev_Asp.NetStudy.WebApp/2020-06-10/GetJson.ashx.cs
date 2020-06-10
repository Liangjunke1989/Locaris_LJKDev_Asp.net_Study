using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_10
{
    /// <summary>
    /// GetJson 的摘要说明
    /// </summary>
    public class GetJson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("{\"Name\":\"LJK\",\"Age\":\"32\"}");
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