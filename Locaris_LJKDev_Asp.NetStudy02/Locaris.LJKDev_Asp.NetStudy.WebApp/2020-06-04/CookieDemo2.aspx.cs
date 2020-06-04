using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_04
{
    public partial class CookieDemo2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取Cookie的值
            //if (Request.Cookies["cp1"].Value != null)
            //{
            //    Response.Write(Request.Cookies["cp1"].Value);
            //}
            
            if (Request.Cookies["cp3"]?.Value != null)
            { 
                Response.Write(Request.Cookies["cp3"].Value);
            }


        }
    }
}