<%@ WebHandler Language="C#" Class="First" %>

using System;
using System.Text;
using System.Web;

public class First : IHttpHandler {
    
    //请求过来 找到一般处理程序文件，自动执行ProcessRequest方法
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";// 指定返回给浏览器的数据类型是文本字符串
        //context.Response.Write("Hello World");
        StringBuilder sb=new StringBuilder();
        sb.Append("<table bord er='1'><tr><td>用户名</td><td>itcast</td></tr>");
        sb.Append("<tr><td>密码</td><td>123</td></tr></table>");
        context.Response.Write(sb.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}