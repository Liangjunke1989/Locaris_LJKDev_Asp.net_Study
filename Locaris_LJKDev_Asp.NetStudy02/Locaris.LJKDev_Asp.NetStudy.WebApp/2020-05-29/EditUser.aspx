<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_05_29.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：<input type="text" name="txtName" value="<% =EditUserInfo.UserName %>"/><br />
            年龄：  <input type="text" name="txtAge" value="<% =EditUserInfo.UserAge %>"/><br />
            密码：  <input type="text" name="txtPwd" value="<% =EditUserInfo.UserPwd %>"/><br />
            <input type="hidden" name="txtId" value="<% =EditUserInfo.UserId %>">
            <input type="submit" value="修改用户"/>

        </div>
    </form>
</body>
</html>
