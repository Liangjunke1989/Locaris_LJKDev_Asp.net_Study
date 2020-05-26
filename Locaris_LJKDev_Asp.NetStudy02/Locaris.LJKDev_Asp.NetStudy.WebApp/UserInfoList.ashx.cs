using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp
{
    /// <summary>
    /// UserInfoList 的摘要说明
    /// </summary>
    public class UserInfoList : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            UserInfoBll userInfoBll = new UserInfoBll();
            List<UserInfoEntity> userInfoList = userInfoBll.GetUserInfoList();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (UserInfoEntity userInfo in userInfoList)
            {
                stringBuilder.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td><a href='DeleteUser.ashx?id={0}' class='deletes' >删除</td></tr>", userInfo.UserId,
                    userInfo.UserName, userInfo.UserAge, userInfo.UserPwd);
            }
            //读取模板文件
            string filePath = context.Request.MapPath("UserInfoList.html");
            string fileContent = File.ReadAllText(filePath);
            fileContent = fileContent.Replace("@LJK", stringBuilder.ToString());
            context.Response.Write(fileContent);

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