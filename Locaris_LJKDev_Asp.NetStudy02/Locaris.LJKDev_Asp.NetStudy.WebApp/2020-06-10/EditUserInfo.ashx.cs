using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_10
{
    /// <summary>
    /// EditUserInfo 的摘要说明
    /// </summary>
    public class EditUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfoEntity userInfo=new UserInfoEntity()
            {
                UserId = Convert.ToInt32(context.Request["txtEditUserId"]),
                UserName = context.Request["txtEditUserName"],
                UserPwd = context.Request["txtEditUserPwd"],
                UserAge=Convert.ToInt32(context.Request["txtEditUserAge"])
            };
            UserInfoService userInfoService=new UserInfoService();
            context.Response.Write(userInfoService.EditUserInfo(userInfo) ? "ok" : "no");
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