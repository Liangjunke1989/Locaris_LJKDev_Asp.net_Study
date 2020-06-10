<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_05.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>自动登录</title>
    <script type="text/javascript">
        window.onload= function() {
            document.getElementById("validateCode").onclick= function() {
                document.getElementById("imgCode").src = "Login_ValidateImageCode.ashx?d="+new Date().getMilliseconds();
            }
        } 
    </script>
</head>
<%--完整登录方案--%>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：<input type="text" name="txtName"/><br/>
            密码：<input type="password" name="txtPwd"/><br/>
            验证码：<input type="text" name="txtCode"/><img src="Login_ValidateImageCode.ashx" id="imgCode"/>
            <a href="javascript:void(0)" id="validateCode">看不清，更换</a><br/>
            <input type="submit" value="登录"/>
            <input type="checkbox" name="autoLogin" value="auto"/>自动登录
            <span style="font-size: 14px; color: red">
                <%=Msg %>  
            </span>
        </div>
    </form>
</body>
</html>
