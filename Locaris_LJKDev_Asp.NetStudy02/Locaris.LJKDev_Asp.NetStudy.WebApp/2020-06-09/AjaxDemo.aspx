<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxDemo.aspx.cs" Inherits="Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_09.AjaxDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Js/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        $(function() {
            $("#btnGetDate").click(function() {
                //开始通过Ajax向服务器发送请求
                var xhr;
                if (XMLHttpRequest) { //表示用户使用的是高版本的IE浏览器、谷歌、火狐等浏览器
                    xhr =new XMLHttpRequest();
                } else {              //低版本浏览器，使用另外一种创建方式
                    xhr = new ActiveXObject("Microsoft.XMLHTTP!");
                }
                xhr.open("get", "GetDate.ashx?name=LJK&age=32", true);
                xhr.send();//开始发送！！
                //回调函数：当服务器将数据返回给浏览器后，自动调用该方法。
                xhr.onreadystatechange = function () {
                    //xhr.readyState==0 未初始化。对象已经创建，但还未初始化，即还没调用open方法
                    //xhr.readyState==1 已打开。  对象已经创建并初始化，但还为调用send方法；
                    //xhr.readyState==2 已发送。  已经调用send方法，但该对象正在等等状态码和头的返回；
                    //xhr.readyState==3 正在接收。已经接受了部分数据，但还不能使用该对象的属性和方法，因为状态和响应头不完整；
                    //xhr.readyState==4 已加载。  所有数据接收完毕
                    if (xhr.readyState==4) {  //表示服务端已经将数据完整返回，并且浏览器全部接收完毕。
                        if (xhr.status==200) {//判断响应状态码是否200，200代表成功
                            alert(xhr.responseText);
                        }
                    }
                }
            });

        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" value="获取服务端的时间" id="btnGetDate"/>
        </div>
    </form>
</body>
</html>
