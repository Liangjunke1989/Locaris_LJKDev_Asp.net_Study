using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_03
{
    public partial class ViewStateDemo : System.Web.UI.Page
    {
        public int Count { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int count = 0;
            if (ViewState["count"]!=null)
            {
                count = Convert.ToInt32(ViewState["count"]);
                count++;
                Count = count;
            }
            ViewState["count"] = Count;
            //当我们把数据给了ViewState对象以后，该对象会将数据进行编码，
            //然后存到__ViewState隐藏域中，然后返回给浏览器。

            //当用户通过浏览器点击“提交”按钮，会向服务端发送一个Post请求，那么__ViewState隐藏域的值
            //也会提交到服务端，那么服务端自动接收__ViewState隐藏域的值，并且再反编码，重新赋值给ViewState对象。
            
            //Cookie：
            //01_存储在本机，未登录下可以记录用户信息(购物车模块)
            //02_区分客户端的数据
            //03_达到数据的持久化

        }

    }
}