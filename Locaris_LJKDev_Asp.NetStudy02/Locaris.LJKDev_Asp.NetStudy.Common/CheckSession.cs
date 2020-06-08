using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locaris.LJKDev_Asp.NetStudy.Common
{
    public class CheckSession:System.Web.UI.Page
    {
        //Init事件：在Load事件之前被触发，在aspx初始化的时候触发。
        public void Page_Init(object sender,EventArgs e)
        {
            if (Session["userInfo"] == null)
            {
                Response.Redirect("UserLogin.aspx");
            }
        }
       
    }
}
