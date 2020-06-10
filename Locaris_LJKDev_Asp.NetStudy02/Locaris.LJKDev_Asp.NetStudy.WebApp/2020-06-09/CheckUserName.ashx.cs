using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.BLL;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_09
{
    /// <summary>
    /// CheckUserName 的摘要说明
    /// </summary>
    public class CheckUserName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request["name"];
            UserInfoService userInfoService=new UserInfoService();
            if (userInfoService.GetUserInfoByUserName(userName) != null)
            {
                context.Response.Write("用户名已被注册！！！");
            }
            else
            {
                context.Response.Write("用户名不能为空！！！");
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