<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JqueryAjax.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_09.JqueryAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Js/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        $(function() {
            $("#btnGet").click(function() {
                $.get("GetDate.ashx", {"name":"LJK","pwd":"12345"},
                    function(data) {                                       //回调函数
                        alert(data);
                    });//内部封装了XMLRequest
            });
            $("#btnPost").click(function() {
                $.post("ShowDate.aspx", {"name":"LJK","pwd":"12345"},
                    function(data) {                                       //回调函数
                        alert(data);
                    });//内部封装了XMLRequest
            });
            $("#btnAjax").click(function() {
                $.ajax({
                    type: "Post",                    //请求的类型
                    url: "GetDate.ashx",             //地址
                    data: "name=LJK&pwd=12345",      //数据
                    success: function(msg) {         //回调函数
                        alert(msg);
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" value="Get获取数据" id="btnGet"/><br/><hr/>
            <input type="button" value="Post获取数据" id="btnPost"/><br/><hr/>
            <input type="button" value="AJax获取数据" id="btnAjax"/><br/>
        </div>
    </form>
</body>
</html>
