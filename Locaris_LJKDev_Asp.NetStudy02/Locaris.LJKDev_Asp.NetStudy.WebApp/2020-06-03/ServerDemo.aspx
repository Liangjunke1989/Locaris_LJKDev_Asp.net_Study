<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerDemo.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_03.ServerDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            主页面内容
            <% Server.Execute("Child.aspx"); %><%--//执行子页面--%>
             <hr/>
            <%-- //蜘蛛爬虫应用程序--%>
            <%--<iframe src="Child.aspx" frameborder="0"></iframe>--%>
            <%--//页面框架，不利于seo优化--%>
            

            <%--//服务器内部跳转，（服务端的注释方式！）--%>
            <% Server.Transfer("Child.aspx"); %>
            
            <!--与Response.Redirect的区别。（Html的注释方式）
            Server.Transfer:服务端跳转，不会向浏览器返回任何内容。所以地址栏中的URL地址不变。
            Response.Redirect:重新指向302，地址中URL发生了变化。大部分使用这种情况！！！ -->
              
            <%=Server.HtmlEncode("<font color='red'></font>") %><%--将Html标签编码了，不让浏览器执行--%>
            <%=Server.HtmlDecode("<font color='red'></font>") %><%--反编码--%>
            <a href="aa.aspx?a=<%=Server.UrlEncode("") %>"></a><%--URL编码与解码--%>
            <%-- 通过Url地址传参，如果出现乱码，需要将Url地址编码一下--%>
            
            
            ViewState:实现状态保持的对象
            隐藏域
            

        </div>
    </form>
</body>
</html>
