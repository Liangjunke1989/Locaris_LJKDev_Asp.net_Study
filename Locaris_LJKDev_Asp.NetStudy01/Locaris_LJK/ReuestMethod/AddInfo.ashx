<%@ WebHandler Language="C#" Class="AddInfo" %>

using System;
using System.Web;

public class AddInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

        //get，QueryString接收了表单发过来的数据
       //string userName = context.Request.QueryString["txtName"];//接收的是表单元素Name属性的值
       //string userPwd = context.Request.QueryString["txtPwd"];

       string userName = context.Request.Form["txtName"];
       string userPwd = context.Request.Form["txtPwd"];

        context.Response.Write("接收到的用户名是："+userName+"\n");
        context.Response.Write("接收到的密码是："+userPwd);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}