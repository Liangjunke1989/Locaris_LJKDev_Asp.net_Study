<%@ WebHandler Language="C#" Class="ShowAdd" %>

using System;
using System.IO;
using System.Web;

public class ShowAdd : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
       //读取模板文件
       string filePath = context.Request.MapPath("AddHtml.html");
       string readAllText = File.ReadAllText(filePath);
       context.Response.Write(readAllText);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}