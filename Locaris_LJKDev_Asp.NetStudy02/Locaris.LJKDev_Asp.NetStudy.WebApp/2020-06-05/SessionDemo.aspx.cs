using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_05
{
    public partial class SessionDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1.Session原理:
            /* 00_Session是服务端的一种状态保持机制，可以将各种类型的数据存储到Session，
               最终这些数据存储到服务器端的内存中。*/

            if (IsPostBack)
            {
                string name = Request.Form["txtName"];
                Session["userName"] = name;
                Session.Timeout=30;//过期时间为“滑动过期时间”
                Response.Redirect("Test.aspx");
            }

            /* 01_当给Session赋值时，那么会存储到服务器的内存中（因为Session是服务端状态保持机制）,
               在内存中存储数据时，服务器会开辟Session的存储区域，这个区域再分响应的存储单元，
               并且每个单元加上一个编号，这个编号叫SessionId。 */

            /* 02_当执行到Response.Redirect时，这时服务器会向浏览器返回一个302和Location，
               这时SessionID会以Cookie的形式返回给浏览器，存储在浏览器的内存中！*/

            /* 03_每个用户都有一个单独的自己的Session对象。*/

            /* 04_Session的默认过期时间是20min。*/

            /* 05_由于Session数据是存储在服务端内存中，不要将过大的数据赋值给Session */


            // 2.Session的应用场景:

            //2_01登录方案的应用

            /* 01_登录时需要校验用户输入的用户名和密码，如果都正确，那么我们会将用户的信息存储到Session中。
               在需要登录以后才能访问的页面中校验Session，如果Session有值，说明用户登录了，可以继续访问页面，
               如果没有值，说明用户没有登录，（非法得到的URL）需要跳转到登录界面，重新登录！ */

            /* 02_登录超时！请重新登录！！！*/

            /* 03_存储数据会更加安全！！！*/

        }
    }
}
