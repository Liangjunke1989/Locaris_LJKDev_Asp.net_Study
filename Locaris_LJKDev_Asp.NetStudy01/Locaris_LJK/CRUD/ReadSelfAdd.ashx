<%@ WebHandler Language="C#" Class="ReadSelfAdd" %>

using System;
using System.IO;
using System.Web;


public class ReadSelfAdd : IHttpHandler
{
    //Http协议的无状态性。   http协议不会保存上次请求的处理结果
    //int num = 0 ;
    public void ProcessRequest (HttpContext context)
    {
        context.Response.ContentType = "text/html";
        // context.Response.Write("Hello World");
        string mapPath = context.Request.MapPath("SelfAdd.html");   //SelfAdd.html相当于模板文件
        string readAllText = File.ReadAllText(mapPath);
        int num = Convert.ToInt32(context.Request.Form["txtNum"]); //第一次为空，值为0 第一次为get无值
        num++;
        readAllText = readAllText.Replace("$num", num.ToString());
        context.Response.Write(readAllText);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}