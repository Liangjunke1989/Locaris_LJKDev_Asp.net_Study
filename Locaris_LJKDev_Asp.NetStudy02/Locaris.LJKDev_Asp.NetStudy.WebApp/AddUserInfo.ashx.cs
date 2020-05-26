using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp
{
    /// <summary>
    /// AddUserInfo 的摘要说明
    /// </summary>
    public class AddUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //context.Response.Write("Hello World");
            
            string userName = context.Request.Form["txtName"];
            string userAge = context.Request.Form["txtAge"];
            string userPwd = context.Request.Form["txtPwd"];
            UserInfoEntity userInfoEntity=new UserInfoEntity()
            {
                UserName = userName,
                UserAge = int.Parse(userAge),
                UserPwd = userPwd
            };
             UserInfoBll userInfoBll=new UserInfoBll();
             if (userInfoBll.AddUserInfo(userInfoEntity))
             {
                 context.Response.Redirect("UserInfoList.html");
             }
             else
             {
                 context.Response.Redirect("Error.html");
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