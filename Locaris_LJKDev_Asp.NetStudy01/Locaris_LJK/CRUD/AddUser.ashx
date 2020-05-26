<%@ WebHandler Language="C#" Class="AddUser" %>

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

public class AddUser : IHttpHandler {

    public void ProcessRequest (HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        // context.Response.Write("Hello World");
        //1.接收表单数据 
        string userName = context.Request.Form["txtName"];
        string userPwd = context.Request.Form["txtPwd"];
        string userAge = context.Request.Form["txtAge"];

        //2.链接数据库，构建相应的SQL语句，最后执行Sql语句
        string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        using (SqlConnection conn=new SqlConnection(connStr))
        {
            using (SqlCommand cmd=conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "insert into User_Info(User_Name,User_Pwd,User_Age)values(@UserName,@UserPwd,@UserAge)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@UserName", userName),
                    new SqlParameter("@UserPwd", userPwd),
                    new SqlParameter("@UserAge", userAge),
                };
                cmd.Parameters.AddRange(parameters);
                if (cmd.ExecuteNonQuery()>0)
                {
                   // context.Response.Write();//输出
                   context.Response.Redirect("UserInfoList.ashx");//实现页面的跳转 get请求
                   //本质上也是向UserInfoList页面发送了一个Get请求
                }
                else
                {
                    context.Response.Write("错误！！！！");
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