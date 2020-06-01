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
    public partial class EditUser : System.Web.UI.Page
    {
        UserInfoService userInfoService = new UserInfoService();
        public UserInfoEntity EditUserInfo { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Get过来的请求
            {
                ShowEditUserInfo();
            }
            else            // Post过来的请求
            {
                UpdateUserInfo();
            }

        }

        private void UpdateUserInfo()
        {
            UserInfoEntity userInfoEntity = new UserInfoEntity()
            {
                UserId = Convert.ToInt32(Request.Form["txtId"]),
                UserName = Request.Form["txtName"],
                UserAge = Convert.ToInt32(Request.Form["txtAge"]),
                UserPwd = Request.Form["txtPwd"]
            };
            Response.Redirect(userInfoService.EditUserInfo(userInfoEntity) ? "UserInfo_WebForm.aspx" : "Error.html");
        }

       
        private void ShowEditUserInfo()
        {
            int id;
            if (int.TryParse(Request.QueryString["uid"], out id))
            {
                UserInfoEntity userInfoEntity = userInfoService.GetUserInfoByUserId(id);
                if (userInfoEntity != null)
                {
                    EditUserInfo = userInfoEntity;
                }
                else
                {
                    Response.Write("Id参数错误！！！");
                }
            }
            else
            {
                Response.Redirect("/Error.html");
            }

        }
    }
}