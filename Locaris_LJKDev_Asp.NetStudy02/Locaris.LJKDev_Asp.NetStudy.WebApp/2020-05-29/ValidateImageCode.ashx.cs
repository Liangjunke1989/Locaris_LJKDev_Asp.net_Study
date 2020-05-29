using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.Common;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_05_29
{
    /// <summary>
    /// ValidateImageCode 的摘要说明
    /// </summary>
    public class ValidateImageCode : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ValidateCode validateCode=new ValidateCode();
            string code = validateCode.CreateValidateCode(5);
            //HttpContext context: 用户发过来的请求报文数据，都封装到了这个类中
            validateCode.CreateValidateGraphic(code, context);
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