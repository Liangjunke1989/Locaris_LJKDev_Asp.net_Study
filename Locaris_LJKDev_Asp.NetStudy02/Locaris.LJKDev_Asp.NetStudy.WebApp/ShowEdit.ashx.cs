using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp
{
    /// <summary>
    /// ShowEdit 的摘要说明
    /// </summary>
    public class ShowEdit : IHttpHandler
    {
        private UserInfoService userInfoService;

        public ShowEdit()
        {
            userInfoService=new UserInfoService();
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["id"],out id))
            {
                UserInfoEntity userInfo = userInfoService.GetUserInfoByUserId(id);
                if (userInfo!=null)
                {
                    string filePath = context.Request.MapPath("ShowEditUser.html");
                    string fileContent = File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("$name", userInfo.UserName)
                        .Replace("$age", userInfo.UserAge.ToString())
                        .Replace("$pwd", userInfo.UserPwd)
                        .Replace("$Id",userInfo.UserId.ToString());
                    context.Response.Write(fileContent);
                }
                else
                {
                    context.Response.Write("查无此人！！！");
                }
            }
            else
            {
                context.Response.Write("参数错了！！！");
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