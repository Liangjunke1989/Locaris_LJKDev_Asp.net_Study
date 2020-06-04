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
            
            //01_如果开始浏览器未收到请求的数据时，默认将开始页设为第一页
            if (!int.TryParse(Request.QueryString["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }
            //02_得到当前页pageIndex,并对当前页码的值的范围进行判断，确保当前页的值正确
            UserInfoService userInfoService =new UserInfoService();
            //02_01获取总页数
            int pageCount = userInfoService.GetPageCount(pageSize);
            PageCount = pageCount;
            //02_02获取当前页的正确取值范围（上一页，下一页不能无限点击）
            pageIndex = pageIndex < 1 ? 1 : pageIndex; 
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            PageIndex = pageIndex;
            //03_根据当前页和页面的取多少个数，获取分页数据
            List<UserInfoEntity> userInfoList = userInfoService.GetPageList(pageIndex,pageSize);
            StringBuilder stringBuilder=new StringBuilder();
            foreach (var userInfo in userInfoList)
            {
                stringBuilder.AppendFormat("<li><span>{0}</span><a href='#' target='_blank'>{1}</a></li>",userInfo.UserAge.ToString(),userInfo.UserName);
            }
            StrHtml = stringBuilder.ToString();
        }
    }
}