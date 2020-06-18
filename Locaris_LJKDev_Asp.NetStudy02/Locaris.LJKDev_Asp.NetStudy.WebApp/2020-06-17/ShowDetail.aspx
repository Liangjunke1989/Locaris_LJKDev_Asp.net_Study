<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDetail.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_17.ShowDetail" %>
<%@ OutputCache Duration="5" VaryByParam="*" %><%--不同的参数考虑进去 --%>
<!DOCTYPE html> 

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>页面缓存</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="170px" Width="674px"></asp:DetailsView>
        </div>
    </form>
</body>
</html>
