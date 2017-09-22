<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="MONO.Distribution.UI.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题文档</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" type="text/javascript" src="Scripts/js/jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            //顶部导航切换
            $(".nav li a").click(function () {
                $(".nav li a.selected").removeClass("selected");
                $(this).addClass("selected");
            });
        })	
    </script>
</head>
<body style="background: url(images/topbg.gif) repeat-x;">
    <form id="form1" runat="server">
    <div class="topleft">
        <a href="Content.aspx" target="_parent">
            <img src="Images/mono-sms4_副本.png" title="系统首页" /></a>
    </div>
    <div class="topright">
        <ul>
            <li><span>
                <img src="images/help.png" title="帮助" class="helpimg" /></span><a href="#">帮助</a></li>
            <li><a href="#">关于</a></li>
            <li>
                <%--<asp:LinkButton runat="server" ID="btnLogOut" OnClick="btnLogOut_OnClick" Text="退出"></asp:LinkButton>--%>
                <a href="LoginOut.aspx" target="_parent">退出</a> </li>
        </ul>
        <div class="user">
            <asp:Label runat="server" ID="txtAccount"></asp:Label>
            <i>积分</i> <b runat="server" id="bb"></b>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        function updateAccount() {
            $.ajax({
                url: "Ashx/Login/GetCurrentAccountHandler.ashx",
                dataType: "html",
                cache: true,
                success: function (data) {
                    $("#bb").text(data);
                }
            });

        }
    </script>
</body>
</html>
