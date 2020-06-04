using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_04
{
    public partial class Login : System.Web.UI.Page
    {
        public string LoginUserName { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string userName = Request.Form["txtName"];
                //写到Cookie中
                Response.Cookies["userName"].Value=Server.UrlEncode(userName);//假如存中文的话，需要将其编码
                Response.Cookies["userName"].Expires=DateTime.Now.AddDays(7);
            }
            else
            {
                if (Request.Cookies["userName"]!=null)
                {
                    string name = Server.UrlDecode(Request.Cookies["userName"].Value);
                    LoginUserName = name;
                    //时间延后
                    Response.Cookies["userName"].Value = Server.UrlEncode(name);//假如存中文的话，需要将其编码
                    Response.Cookies["userName"].Expires = DateTime.Now.AddDays(7);
                }
            }
        }
    }
}