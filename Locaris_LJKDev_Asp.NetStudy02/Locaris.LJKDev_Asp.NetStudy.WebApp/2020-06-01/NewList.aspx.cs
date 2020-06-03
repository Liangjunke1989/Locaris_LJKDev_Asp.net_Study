using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_01
{
    public partial class NewList : System.Web.UI.Page
    {
        public string StrHtml;
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = 3;
            int pageIndex;
            
            if (!int.TryParse(Request.QueryString["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }
            UserInfoService userInfoService=new UserInfoService();
            int pageCount = userInfoService.GetPageCount(pageSize);//获取总页数
            PageCount = pageCount;
            //对当前页码值得范围进行判断
            pageIndex = pageIndex < 1 ? 1 : pageIndex; 
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            PageIndex = pageIndex;
            List<UserInfoEntity> userInfoList = userInfoService.GetPageList(pageIndex,pageSize);//获取分页数据
            StringBuilder stringBuilder=new StringBuilder();
            foreach (var userInfo in userInfoList)
            {
                stringBuilder.AppendFormat("<li><span>{0}</span><a href='#' target='_blank'>{1}</a></li>",userInfo.UserAge.ToString(),userInfo.UserName);
            }
            StrHtml = stringBuilder.ToString();
        }
    }
}