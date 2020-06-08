using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_05
{
    public partial class UserInfoList : Common.CheckSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userInfo"]==null)
            //{
            //    Response.Redirect("UserLogin.aspx");
            //}
            //else
            //{
            //    UserInfoEntity userInfo = (UserInfoEntity)Session["userInfo"];
            //    Response.Write("欢迎"+ userInfo.UserName + "登录系统!!!");
            //}
        }
    }
}