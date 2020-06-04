<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Child.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_03.Child" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            子页面
            <%--//服务器内部跳转，（服务端的注释方式！不会返回浏览器）--%>
            <!--与Response.Redirect的区别。（Html的注释方式，返回给浏览器，传输浪费资源）-->
        </div>
    </form>
</body>
</html>
