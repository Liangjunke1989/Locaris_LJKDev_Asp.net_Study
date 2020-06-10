using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_04
{
    public partial class CookieDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 00_Cookie:是一个客户端状态保持机制，(网站的数据是存在客户端)，与隐藏域、ViewState对象
            //都属于客户端状态保持，Cookie中存储的是关于网站相关的文本字符串数据。

            // 00_Cookie的存储方式有两种：如果不指定过期时间，那么存储在客户端浏览器的内存中；
            // 如果我们将Cookie设置了过期时间，当用户在指定时间内访问我们的网站，属于我们网站的Cookie
            // 数据会放在请求报文中发送过来，其他网站的Cookie不会发送。

            // 01_创建Cookie：
            // Response.Cookies["cp1"].Value = "LJK";

            /*当执行到这行代码时，会在返回的响应报文的响应头中加上一个Set-cookie：cp1=LJK;path=/;返回给浏览器，
              由于这里没有指定过期时间，所以cookie数据"LJK",默认时存储在浏览器的内存中的创建Cookie并且指定过期时间。*/

            // Response.Cookies["cp2"].Value = "koko";
            // Response.Cookies["cp2"].Expires=DateTime.Now.AddDays(3);

            // 02_删除Cookie
            // Response.Cookies["cp2"].Expires=DateTime.Now.AddDays(-1);//过期时间后，浏览器会删除Cookie

            // 03_Cookie跨域的问题Domain（跨域:域名）
            // Response.Cookies["cp3"].Value = "Juhnko";
            // Response.Cookies["cp3"].Domain="www.ljk3d.com";//设置为主域的

            // 04_Cookie的path路径,其他网页无法获取Cookie （可做网站优化的点）
            Response.Cookies["cp3"].Value = "Juhnko";
            Response.Cookies["cp3"].Path = "/2020-06-04";
            Response.Cookies["cp3"].Expires = DateTime.Now.AddDays(30);

            // 05_另外一种创建Cookie的方式
            HttpCookie cookie = new HttpCookie("cp4", "keke");
            cookie.Expires = DateTime.Now.AddDays(3);
            Response.Cookies.Add(cookie);

            // 06_最后一条：cookie存储的数据是不安全的
            // 加入客户端是公共电脑更危险！！！
        }
    }
}