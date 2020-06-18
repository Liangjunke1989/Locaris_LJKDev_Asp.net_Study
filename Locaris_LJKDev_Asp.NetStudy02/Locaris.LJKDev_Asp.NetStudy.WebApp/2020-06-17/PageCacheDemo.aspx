<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageCacheDemo.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_17.PageCacheDemo" %>
<%@ OutputCache Duration="5" VaryByParam="*"%>
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head> 
<body>
    <%-- 页面缓存，将整个页面的内容放在服务器的内存里面 --%>
    <form id="form1" runat="server">
        <div>
            <a href="ShowDetail.aspx?id=1066">用户详细信息</a> 
            <a href="ShowDetail.aspx?id=1067">用户详细信息</a> 
        </div>
    </form>
</body>
</html>
