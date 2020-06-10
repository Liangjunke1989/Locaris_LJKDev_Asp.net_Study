using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_09
{
    public partial class ShowDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request["name"];
            Response.Write(name);
            //放在Buffer缓冲区里面
            Response.End();//此时就不会渲染加载ShowDate.aspx中的缓存内容了！
        }
    }
}