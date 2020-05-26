using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.BLL;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp
{
    /// <summary>
    /// DeleteUser 的摘要说明
    /// </summary>
    public class DeleteUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            int id;
            if (int.TryParse(context.Request.QueryString["id"],out id))
            {
                UserInfoBll userInfoBll=new UserInfoBll();
                if (userInfoBll.RemoveUserInfo(id))
                {
                    context.Response.Redirect("UserInfoList.ashx");
                }
                else
                {
                    context.Response.Write("Error.html");
                }

             
            }
            else
            {
                context.Response.Write("参数错误！！！！");
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