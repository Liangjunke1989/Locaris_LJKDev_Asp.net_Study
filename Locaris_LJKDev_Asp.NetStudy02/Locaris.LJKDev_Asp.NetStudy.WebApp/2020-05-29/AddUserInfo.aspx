<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserInfo.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_05_29.AddUserInfo" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">//在服务端执行，生成后html返回给浏览器
        <%--//runat 在服务端执行的控件--%>
        <div>
            用户名：<input type="text" name="txtName" /><br />
            年龄：  <input type="text" name="txtAge" /><br />
            密码：  <input type="password" name="txtPwd" /><br />
          <%--  <input type="hidden" name="isPostBack" value="Post"/>--%>
            <input type="submit" value="添加用户"/>
        </div>
    </form>
</body>
</html>
