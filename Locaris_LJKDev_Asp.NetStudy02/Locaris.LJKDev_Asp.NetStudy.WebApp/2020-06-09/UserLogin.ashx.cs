using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_09
{
    /// <summary>
    /// UserLogin 的摘要说明
    /// </summary>
    public class UserLogin : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName=context.Request["userName"];
            string userPwd = context.Request["userPwd"];
            UserInfoService userInfoService=new UserInfoService();
            string msg = string.Empty;
            UserInfoEntity userInfo = null;
            if (userInfoService.ValidateUserInfo(userName, userPwd, out msg, out userInfo))
            {
                context.Session["userInfo"] = userInfo;
                context.Response.Write("ok:"+msg);
            }
            else
            {
                context.Response.Write("no:" + msg);
            }
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