<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepeaterDemo.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_12.RepeaterDemo" %>
<%@ Import Namespace="Locaris.LJKDev_Asp.NetStudy.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enableviewstate="False">
        <div>
            <%--展示列表数据 --%>
            <table style="height: 437px; width: 1390px">
                <tr><th>编号</th><th>姓名</th><th>年龄</th><th>密码</th><th>删除</th><th>详细</th><th>编辑</th></tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    
                   <ItemTemplate>  <%--类似于Foreach，必不可少！！--%>
                        <tr>
                            <td><%#Eval("UserId")  %></td>
                            <td><%#Eval("UserName")%></td>
                            <td><%#Eval("UserPwd") %></td>
                            <td><%#Eval("UserAge") %></td>
                            <td><asp:Button ID="ButtonDeleteInfo" runat="server" Text="删除" CommandName="BtnDeleteUserInfo" /></td>
                            <td><asp:Button ID="ButtonEditInfo" runat="server" Text="删除" CommandName="BtnEditUserInfo" /></td>
                        </tr>
                    </ItemTemplate>

                    <AlternatingItemTemplate> <%--交替项模板 --%>
                        <tr style="background-color:darkgray">
                            <td><%#Eval("UserId")  %></td>

                            <td><%#Eval("UserName")%></td>
                            <td><%#Eval("UserPwd") %></td>
                            <td><%#Eval("UserAge") %></td>
                            <td><asp:Button ID="ButtonDeleteInfo" runat="server" Text="删除" CommandName="BtnDeleteUserInfo" /></td>
                        </tr>
                    </AlternatingItemTemplate>

                   <SeparatorTemplate>  <%--分割项模板 --%>
                        <tr>
                            <td colspan="7"><hr/></td>
                        </tr>
                   </SeparatorTemplate>
                </asp:Repeater>
                <%=PageBarHelper.GetPageBar(PageIndex,PageCount) %>
            </table>
        </div>
    </form>
</body>
</html>
