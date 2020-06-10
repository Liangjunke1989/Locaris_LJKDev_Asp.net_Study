<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxPostDemo.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_09.AjaxPostDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Js/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        $(function() {
            $("#btnPostDate").click(function() {
                var xhr;
                if (XMLHttpRequest) {
                    xhr = new XMLHttpRequest();
                } else {
                    xhr = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xhr.open("post", "GetDate.ashx", true);
                xhr.setRequestHeader("Content-Type","application/x-www-form-urlencoded");//规定发送请求报文的格式
                xhr.send("name=LJK&pwd=123456");
                xhr.onreadystatechange= function() {  //回调函数：当服务器将数据返回给浏览器后，自动调用该方法。
                    if (xhr.readyState==4) {          //如果已经加载完成
                        if (xhr.status==200) {        //判断响应状态码是否200，200代表成功
                            alert(xhr.responseText);
                        }
                    }
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" value="获取数据" id="btnPostDate"/>
        </div>
    </form>
</body>
</html>
