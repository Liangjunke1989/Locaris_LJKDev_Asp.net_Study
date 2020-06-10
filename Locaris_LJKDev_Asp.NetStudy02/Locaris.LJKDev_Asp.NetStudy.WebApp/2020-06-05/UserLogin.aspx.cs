using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Common;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_05
{
    public partial class UserLogin : System.Web.UI.Page
    {
        public string Msg { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果时Post请求
            if (IsPostBack)
            {
                if (CheckValidateCode())         //先判断验证码是否正确,在校验用户名和密码是否正确
                {
                    CheckUserInfo();
                }
                else
                {
                    Msg = "验证码错误！！";      //错误，给用户提示！
                }
            }
            //如果Get时
            else
            {
                CheckCookeInfo();               //Get的话，校验Cookie，自动登录？
            }
        }

        #region 01_校验验证码，输入的验证码和系统产生的验证码是否相同
        /// <summary>
        /// 校验验证码，输入的验证码和系统产生的验证码是否相同
        /// </summary>
        /// <returns></returns>
        private bool CheckValidateCode()
        {
            bool isSucess = false;
            if (Session["validateCode"] != null)//在使用Session时,一定要校验是否为空。
            {
                string txtCode = Request.Form["txtCode"];//获取用户输入的验证码。
                string sysCode = Session["validateCode"].ToString();// 系统产生的验证码
                if (sysCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))//忽略大小写
                {
                    isSucess = true;
                    Session["validateCode"] = null;//不加的话，20分钟内可能被破解
                }
            }
            return isSucess;
        }
        #endregion

        #region 02_校验用户名密码
        /// <summary>
        /// 校验用户名密码
        /// </summary>
        private void CheckUserInfo()
        {
            string msg = string.Empty;
            //02_01获取用户输入的用户名和密码
            string userName = Request.Form["txtName"];
            string userPwd = Request.Form["txtPwd"];
            //02_02校验用户名和密码
            UserInfoService userInfoService = new UserInfoService();
            //02_02_01如果校验成功的话
            if (userInfoService.ValidateUserInfo(userName, userPwd, out msg, out var userInfo))
            {
                // 如果用户选择了“自动登录”
                // 注：页面上如果有多个复选框时，只能将选中复选框的值提交到服务端

                //02_02_01_01 复选框选中的话！将用户名密码存储在Cookie中。（接收的表单数据中有autoLogin的字段信息）
                if (!string.IsNullOrEmpty(Request.Form["autoLogin"]))
                {
                    HttpCookie cookie1 = new HttpCookie("LJK_N", userName);   //用户名不加密
                    HttpCookie cookie2 = new HttpCookie("LJK_P", MD5Helper.GetMd5String(userPwd));//MD5反编译，大数据时代的破解问题
                    cookie1.Expires = DateTime.Now.AddDays(7);
                    cookie2.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookie1);                  //创建Cookie
                    Response.Cookies.Add(cookie2);                  //创建Cookie
                }

                //02_02_01_02 在服务器端，存储userInfo用户信息！
                Session["userInfo"] = userInfo;

                //02_02_01_03 用户名密码校验正确，跳转到指定页面！
                Response.Redirect("UserInfoList.aspx");
            }
            //02_02_02如果校验不成功的话，打印错误信息
            else
            {
                Msg = msg;
            }
        }
        #endregion

        #region 03_校验Cookie信息
        /// <summary>
        /// 校验Cookie信息
        /// </summary>
        private void CheckCookeInfo()
        {
            //01_首先看浏览器中Cookies["LJK_N"]、.Cookies["LJK_P"]中是否有值
            if (Request.Cookies["LJK_N"] != null && Request.Cookies["LJK_P"] != null)
            {
                //01_01首先拿到Cookie中的用户名和密码
                string userName = Request.Cookies["LJK_N"].Value;
                string userPwd = Request.Cookies["LJK_P"].Value;
                //01_02校验用户名能否能查询到用户信息
                //注：通过用户名，查询用户信息，因为数据库中用户名未进行MD5加密，所以查询的userName也不必加密
                UserInfoService userInfoService = new UserInfoService();
                UserInfoEntity userInfo = userInfoService.GetUserInfoByUserName(userName);
                //01_02_01如果可以查询到
                if (userInfo != null)
                {
                    // 01_02_01_01校验用户电脑上的存储的Cookie信息和服务器中存储的用户密码是否一致
                    // 注意：在添加用户或注册用户时，一定要将用户输入的密码加密以后存储到数据库中
                    if (userPwd == MD5Helper.GetMd5String(userInfo.UserPwd))//数据库中用户名、密码最好使用加密的
                    {
                        Session["userInfo"] = userInfo;
                        Response.Redirect("UserInfoList.aspx");
                    }
                    // 01_02_01_02 加入不一致的话，不用跳转，继续留在本页面！继续输入用户名密码（Cookie有用才跳转！）
                }
                //01_02_02如果可以查询到用户名不能获取用户信息的话，将用户cookie删除！原先存储的Cookie没有意义了！
                Response.Cookies["LJK_N"].Expires = DateTime.Now.AddDays(-1);
                Request.Cookies["LJK_P"].Expires = DateTime.Now.AddDays(-1);
            }

        }
        #endregion
    }
}