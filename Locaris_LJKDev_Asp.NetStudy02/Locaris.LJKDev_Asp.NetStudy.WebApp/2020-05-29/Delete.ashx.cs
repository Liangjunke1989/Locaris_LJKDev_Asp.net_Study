using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.BLL;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_05_29
{
    /// <summary>
    /// Delete 的摘要说明
    /// </summary>
    public class Delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id;
            if (int.TryParse(context.Request.QueryString["id"],out id))
            {
                UserInfoService userInfoService=new UserInfoService();
                if (userInfoService.RemoveUserInfo(id))
                {
                    context.Response.Redirect("UserInfo_WebForm.aspx");
                }
                else
                {
                    context.Response.Redirect("Error.html");
                }
            }
            else
            {
                context.Response.Write("参数错误啦啦啦！！");
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