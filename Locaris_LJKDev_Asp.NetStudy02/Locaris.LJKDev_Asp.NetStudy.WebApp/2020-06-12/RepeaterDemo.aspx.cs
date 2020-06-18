using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_12
{
    public partial class RepeaterDemo : System.Web.UI.Page
    {
        public int PageIndex { set; get; }
        public int PageSize { set; get; }

        public int PageCount { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex;
            if (!int.TryParse(Request["pageIndex"],out pageIndex))
            {
                pageIndex = 1;
            }

            int pageSize = 3;
            PageSize = pageSize;

            UserInfoService userInfoService=new UserInfoService();
            int pageCount = userInfoService.GetPageCount(pageSize);
            PageCount = pageCount;

            pageIndex = pageIndex < 1 ? 1:pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            PageIndex = pageIndex;

            List<UserInfoEntity> userInfoList = userInfoService.GetPageList(pageIndex,pageCount);
            this.Repeater1.DataSource = userInfoList;
            this.Repeater1.DataBind();
        }
    }
}