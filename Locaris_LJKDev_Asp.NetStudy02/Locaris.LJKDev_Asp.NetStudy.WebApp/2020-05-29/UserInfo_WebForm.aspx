<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo_WebForm.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_05_29.UserInfo_WebForm" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../CSS/tableStyle.css" rel="stylesheet" />
    <script type="text/javascript">

        //浏览器端事件，前端事件
        window.onload= function() {
            var datas = document.getElementByClassName("deletes");
            var dataLength = datas.length;
            for (var i = 0; i < dataLength; i++) {
                datas[i].onclick = function() {
                    if (!confirm("确定要删除吗？")) {
                        return false;
                    }
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="AddUserInfo.aspx">添加用户</a>
            <table>
               <tr><th>编号</th><th>姓名</th><th>年龄</th><th>密码</th><th>删除</th><th>详细</th><th>编辑</th></tr>
              <%--  <%= StrHtml %>--%>
                <% foreach (var userInfoEntity in UserInfoEntitiesList){ %>
                    <tr>
                        <td><%=userInfoEntity.UserId %></td>
                        <td><%=userInfoEntity.UserName%></td>
                        <td><%=userInfoEntity.UserAge %></td>
                        <td><%=userInfoEntity.UserPwd %></td>
                        <td><a href="Delete.ashx?id=<%=userInfoEntity.UserId %>" class="deletes">删除</a></td>
                        <td>详细</td>
                        <td><a href="EditUser.aspx?uid=<%=userInfoEntity.UserId %>">编辑</a></td>
                    </tr>
                <% } %>
            </table>
            <hr/>
            //sp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
