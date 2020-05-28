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
                UserInfoService userInfoService=new UserInfoService();
                //根据从表现层获取的id信息，发给逻辑层进行相关逻辑操作
                if (userInfoService.RemoveUserInfo(id))
                {
                    context.Response.Redirect("UserInfoList.ashx");//重新更新用户信息页面
                }
                else
                {
                    context.Response.Redirect("Error.html");
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