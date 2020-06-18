<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_12.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        function show (parameters) {
            document.getElementById("TextBox1").value();
        }
    </script>
    <style type="text/css">
        .txt {
            margin-left: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom: 0px">
            <%-- 服务端控件 必须放在form标签中 --%>
            <%-- 在服务端执行，要生成对应的Html代码，返回给浏览器 --%>
            <asp:TextBox ID="TextBox1" runat="server" Height="261px" OnTextChanged="TextBox1_TextChanged" 
                         AutoPostBack="True"
                         style="margin-bottom: 77px" TextMode="MultiLine" Width="433px"></asp:TextBox> 
            <asp:Button ID="Button1" runat="server" Text="对按钮额外添加事件" CssClass="txt" />
        </div>
        <div>
            <%-- span标签 --%>
            <asp:Label ID="Label001" runat="server" Text="001_Label"></asp:Label><br/>
            <%-- AssociatedControlID：关联另外一个控件的Id --%>
            <asp:Label ID="Label002" runat="server" AssociatedControlID="TextBox1" Text="002_Associated"></asp:Label><br/>
            <%-- 单独写Label标签的关联 --%>
            <label for="TextBox1" id="Label003">003_标签ID</label>
        </div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        男<asp:RadioButton GroupName="01" ID="RadioButton1" runat="server" />
        女<asp:RadioButton GroupName="01" ID="RadioButton2" runat="server" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="398px">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="UserPwd" HeaderText="UserPwd" SortExpression="UserPwd" />
                <asp:BoundField DataField="UserAge" HeaderText="UserAge" SortExpression="UserAge" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUserInfoList" TypeName="Locaris.LJKDev_Asp.NetStudy.BLL.UserInfoService"></asp:ObjectDataSource>
        
        
        
        
        

        <%-- DropDownList下拉框获取数据的4种方式 --%>

        <%-- 01/02_DropDownList下拉框获取数据的1、2种方式：手动和DataSource数据绑定,隐藏域代码量巨大 --%>
      <%--  <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource1" DataTextField="UserName" DataValueField="UserId">
            <asp:ListItem Text="北京">北京</asp:ListItem>
            <asp:ListItem Text="天津">天津</asp:ListItem>
            <asp:ListItem Text="大连" Selected="True">大连</asp:ListItem>
        </asp:DropDownList>--%>

        <%-- 03_DropDownList下拉框获取数据的3种方式：DataSource和代码生成 --%>
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        <hr/>
        <%-- 04_DropDownList下拉框获取数据的4种方式：全部代码生成 --%>
        <select name="UserInfos">
            <%=SelectStr %>
        </select>
    </form>
 
</body>
</html>
