using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp
{
    /// <summary>
    /// EditUser 的摘要说明
    /// </summary>
    public class EditUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //接收数据，显示未修改之前的值
            int id=Convert.ToInt32(context.Request.Form["txtId"]);//接收隐藏域的值
            UserInfoService userInfoService=new UserInfoService();

            //拿到userInfo对象方式一：
            //UserInfoEntity userInfo = userInfoService.GetUserInfoByUserId(id);
            ////将修改的数据，发给业务逻辑层，保存到数据库中
            //userInfo.UserName = context.Request.Form["txtName"];
            //userInfo.UserAge = Convert.ToInt32(context.Request.Form["txtAge"]);
            //userInfo.UserPwd = context.Request.Form["txtPwd"];

            //拿到userInfo对象方式二：
            UserInfoEntity userInfo =new UserInfoEntity()
            {
                UserId = id,
                UserName = context.Request.Form["txtName"],
                UserAge = Convert.ToInt32(context.Request.Form["txtAge"]),
                UserPwd = context.Request.Form["txtPwd"]
            };

            if (userInfoService.EditUserInfo(userInfo ))
            {
                context.Response.Redirect("UserInfoList.ashx");//如果成功的话，跳转到用户信息页面
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