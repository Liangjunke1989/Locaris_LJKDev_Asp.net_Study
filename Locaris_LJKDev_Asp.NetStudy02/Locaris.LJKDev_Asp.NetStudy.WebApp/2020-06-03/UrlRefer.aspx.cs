using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_03
{
    public partial class UrlRefer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Request.Url.ToString());//获取当前请求的Url地址
            Response.Write("<hr/>");
            Response.Write(Request.UrlReferrer.ToString());//获取上次请求的Url地址，获取请求的来源
            //防止盗链  
            //Response.Write(Request.UserHostAddress.ToString());

            Response.End();// 后面的代码无法执行
            Response.Clear();//清空缓存区的内容

           // Server
            

           //Session
        }
    }
}