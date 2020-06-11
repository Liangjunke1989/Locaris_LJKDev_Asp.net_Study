using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.BLL;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_10
{
    /// <summary>
    /// DeleteUser 的摘要说明
    /// </summary>
    public class DeleteUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id =Convert.ToInt32(context.Request["id"]);
            UserInfoService userInfoService=new UserInfoService();
            context.Response.Write(userInfoService.RemoveUserInfo(id) ? "ok" : "no");
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