<%@ Page Title="" Language="C#" MasterPageFile="~/2020-06-12/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_12.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function showResult() {
            document.getElementById("TextBox1").value();//目前拿到的是母版中的TextBox1
            document.getElementById(<%=TextBox1.ClientID%>).value();//目前拿到的是aspx页面中的TextBox1
            //TextBox1和TextBox1.ClientID区别                 
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    aspx页面<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
  
    </asp:Content>
