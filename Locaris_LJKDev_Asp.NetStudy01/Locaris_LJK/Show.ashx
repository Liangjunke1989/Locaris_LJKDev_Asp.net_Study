<%@ WebHandler Language="C#" Class="Show" %>

using System;
using System.Web;
using System.IO;
public class Show : IHttpHandler {
    
    public void ProcessRequest (HttpContext   context) {
        context.Response.ContentType = "text/html";
        //获取要操作的模板文件的路径
        string filePath = context.Request.MapPath("showInfo.html");//获取要操作文件的物理路径
        
        //在Asp.Net中，对文件或文件夹操作一定要获取物理路径。
        //读取模板文件中的内容 
        string readAllText = File.ReadAllText(filePath);
        //用户具体的数据替换模板文件中的占位符
        readAllText = readAllText.Replace("$Name", "LJK").Replace("$Pwd","123456");
        //将替换后的内容输出给浏览器
        context.Response.Write(readAllText); 
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}