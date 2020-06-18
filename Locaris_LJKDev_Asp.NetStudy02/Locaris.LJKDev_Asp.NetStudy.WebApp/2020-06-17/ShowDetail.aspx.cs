using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_17
{
    public partial class ShowDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userId= Convert.ToInt32(Request["id"]);
            UserInfoService userInfoService=new UserInfoService();
            UserInfoEntity userInfo = userInfoService.GetUserInfoByUserId(userId);
            List<UserInfoEntity> userInfoList= new List<UserInfoEntity>();
            userInfoList.Add(userInfo);
            this.DetailsView1.DataSource = userInfoList;
            this.DetailsView1.DataBind();
        }
    }
}