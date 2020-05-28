using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;
using System.IO; 

namespace Locaris.LJKDev_Asp.NetStudy.WebApp
{
    /// <summary>
    /// ShowDetail 的摘要说明
    /// </summary>
    public class ShowDetail : IHttpHandler
    {
        private  UserInfoService userInfoService;

        public ShowDetail()
        {
            userInfoService=new UserInfoService();
        }
        
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //context.Response.Write("Hello World");
            int id;
            if (int.TryParse(context.Request.QueryString["uid"],out id))
            {
                //根据id把详细信息查询出来
                UserInfoEntity userInfo = userInfoService.GetUserInfoByUserId(id);
                if (userInfo!=null)
                {
                    string filePath = context.Request.MapPath("Detail.html");
                    string fileContent= File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("$name", userInfo.UserName)
                        .Replace("$age",userInfo.UserAge.ToString())
                        .Replace("$pwd",userInfo.UserPwd);
                    context.Response.Write(fileContent);
                }
                else
                {
                    // 如果根据id找到不到userInfo的信息
                    context.Response.Redirect("Error.html");
                }
            }
            else
            {
                context.Response.Write("参数错误！!!!");
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