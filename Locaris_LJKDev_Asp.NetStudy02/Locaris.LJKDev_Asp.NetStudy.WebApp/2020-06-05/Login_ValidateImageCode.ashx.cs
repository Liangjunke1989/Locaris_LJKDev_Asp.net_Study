using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.Common;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_05
{
    /// <summary>
    /// Login_ValidateImageCode 的摘要说明
    /// </summary>
    public class Login_ValidateImageCode : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string validateCode = ValidateCode.CreateValidateCode(5);
            context.Session["validateCode"] = validateCode;//系统生成的5位验证码保存到Session["validateCode"]中
            ValidateCode.CreateValidateGraphic(validateCode,context);
            
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