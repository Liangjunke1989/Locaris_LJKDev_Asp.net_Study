using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_05_29
{
    public partial class UserInfo_WebForm : System.Web.UI.Page
    {
        public string StrHtml { get; set; }
        public  List<UserInfoEntity> UserInfoEntitiesList;
        //服务端事件
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfoService userInfoService=new UserInfoService();
            UserInfoEntitiesList = userInfoService.GetUserInfoList();
            //this.GridView1.DataSource = UserInfoEntitiesList;//使用DataView控件，开发效率快
            //this.GridView1.DataBind();
            //方法一：
            //StringBuilder stringBuilder = new StringBuilder();
            //foreach (UserInfoEntity userInfoEntity in UserInfoEntitiesList)
            //{
            //    stringBuilder.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", userInfoEntity.UserId, userInfoEntity.UserName,
            //        userInfoEntity.UserAge, userInfoEntity.UserPwd);
            //}
            //StrHtml = stringBuilder.ToString();
        }
    }
}