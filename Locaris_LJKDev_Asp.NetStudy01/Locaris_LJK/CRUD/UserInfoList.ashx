<%@ WebHandler Language="C#" Class="UserInfoList" %>

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;

public class UserInfoList : IHttpHandler {

    public void ProcessRequest (HttpContext context)
    {
        context.Response.ContentType = "text/html";
        //context.Response.Write("Hello World");
        string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlCommandText = @"SELECT TOP 1000 [User_ID]
                                     ,[User_Name]
                                     ,[User_Gender]
                                     ,[User_Age]
                                     ,[User_Address]
                                     ,[User_Birthday]
                                     ,[User_Remark]
                                     ,[User_Money]
                                     ,[User_GUIDDemo]
                                     ,[User_Pwd]
                                     FROM [LJK_SQLServerDB].[dbo].[User_Info]"; 
            using (SqlDataAdapter adapter=new SqlDataAdapter(sqlCommandText,conn))
            {
                DataTable dataTable=new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count>0)
                {
                    StringBuilder stringBuilder=new StringBuilder();
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        stringBuilder.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td>" +
                                                   "<td>{3}</td><td>{4}</td><td>" +
                                                   "<a href='ShowDetail.ashx?id={0}'>详细</a></td><td>" +
                                                   "<a href='DeleteUser.ashx?id={0}' class='deletes'>删除</a></td><td >" +
                                                   "<a href='ShowEdit.ashx?id={0}'>编辑</a></td></tr>", 
                                                    dataRow["User_ID"].ToString(), dataRow["User_Name"].ToString(),
                                                    dataRow["User_Gender"].ToString(), dataRow["User_Address"].ToString(), 
                                                    dataRow["User_Pwd"].ToString());  
                    }
                    //读取模板文件，替换占位符
                    string mapPath = context.Request.MapPath("UserInfoList.html");
                    string readAllText = File.ReadAllText(mapPath);
                    readAllText = readAllText.Replace("@LJK", stringBuilder.ToString());
                    context.Response.Write(readAllText);
                }
                else
                {
                    context.Response.Write("暂无数据！！！");
                }
            }
        }
        
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}