using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_05_29
{
    public partial class AddUserInfo : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            //如果隐藏域的值不为空，表示用户点击了提交按钮，发出了Post请求
            //if (!string.IsNullOrEmpty(Request.Form["isPostBack"]))
            //{
            //    InsertUserInfo();
            //}


            //IsPostBack：如果是Post请求，该属性的值为True。如果是Get请求，该属性的值为false。
            //IsPostBack：是根据__ViewState隐藏域进行判断的。如果是Post请求，那么该隐藏域的值会提交到服务端，那么IsPostBack的属性为True。
            //如果将Form标签的runat="server"去掉，那么就不能用该属性判断是Post请求还是Get请求！！因为该隐藏域__ViewState不会产生！！

            if (IsPostBack)
            {
                InsertUserInfo();
            }
        }

        private void InsertUserInfo()
        {
            UserInfoEntity userInfo=new UserInfoEntity()
            {
                UserName = Request.Form["txtName"],
                UserAge = int.Parse(Request.Form["txtAge"]),
                UserPwd = Request.Form["txtPwd"]
            };
            UserInfoService userInfoService=new UserInfoService();
            if (userInfoService.AddUserInfo(userInfo))
            {
                Response.Redirect("UserInfo_WebForm.aspx");
            }
            else
            {
                Response.Redirect("Error.html");
            }

            
        }
    }
}