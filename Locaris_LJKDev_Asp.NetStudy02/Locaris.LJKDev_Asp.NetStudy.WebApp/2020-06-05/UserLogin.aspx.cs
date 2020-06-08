using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_05
{
    public partial class UserLogin : System.Web.UI.Page
    {
        public string Msg { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)//如果时Post请求
            {
                if (CheckValidateCode())//先判断验证码是否正确
                {
                    CheckUserInfo();
                }
                else
                {
                    //验证码错误，给用户提示！
                    Msg = "验证码错误！！";
                }
            }
            else//如果Get时
            {
               
            }
        }
        //01_校验验证码，输入的验证码和系统产生的验证码是否相同
        private bool CheckValidateCode()
        {
            bool isSucess = false;
            if (Session["validateCode"]!=null)//在使用Session时,一定要校验是否为空。
            {
                string txtCode = Request.Form["txtCode"];//获取用户输入的验证码。
                string sysCode = Session["validateCode"].ToString();// 系统产生的验证码
                if (sysCode.Equals(txtCode,StringComparison.InvariantCultureIgnoreCase))//忽略大小写
                {
                    isSucess = true;
                    Session["validateCode"] = null;//不加的话，20分钟内可能被破解
                }
            } return isSucess; }

        //02_校验用户名密码，
        private void CheckUserInfo()
        {
            string msg = string.Empty;
            //02_01获取用户输入的用户名和密码
            string userName = Request.Form["txtName"];
            string userPwd = Request.Form["txtPwd"];
            //02_02校验用户名和密码
            UserInfoService userInfoService=new UserInfoService();
            //如果校验成功的话
            if (userInfoService.ValidateUserInfo(userName, userPwd, out msg, out var userInfo))
            {
                Session["userInfo"] = userInfo;
                Response.Redirect("UserInfoList.aspx");
            }
            //如果校验不成功的话
            else
            {
                Msg = msg;
            }
        }

    }
}