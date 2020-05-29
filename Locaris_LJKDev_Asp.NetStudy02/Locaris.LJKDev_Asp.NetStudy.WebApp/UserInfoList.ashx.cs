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
            context.Response.ContentType = "text/html";//响应文本为Html样式

            UserInfoService userInfoService = new UserInfoService();
            List<UserInfoEntity> userInfoList = userInfoService.GetUserInfoList();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (UserInfoEntity userInfo in userInfoList)
            {
                stringBuilder.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>" +
                                           "<td><a href='DeleteUser.ashx?id={0}'  class='deletes' >删除</td>" +
                                           "<td><a href='ShowDetail.ashx?uid={0}' >详细</td>" +
                                           "<td><a href='ShowEdit.ashx?id={0}' >编辑</td>"+
                                           "</tr>", userInfo.UserId, userInfo.UserName, 
                    userInfo.UserAge, userInfo.UserPwd); 
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