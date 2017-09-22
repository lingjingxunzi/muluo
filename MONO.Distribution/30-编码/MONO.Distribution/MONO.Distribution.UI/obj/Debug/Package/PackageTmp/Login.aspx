<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MONO.Distribution.UI.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎登录流量分销系统</title>
    <%--<link href="CSS/reset.css" rel="stylesheet" type="text/css" />--%>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" type="text/javascript" src="Scripts/js/jquery.js"></script>
    <script src="Scripts/js/cloud.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
            $(window).resize(function () {
                $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
            });
            getVerCode();

            $("#txtPwd").focus(function () {
                var text_value = $(this).val();
                if (text_value == this.defaultValue) {
                    $("#txtPwd").hide();
                    $("#password").show().focus();
                }
            });
            $("#txtPwd").blur(function () {
                var text_value = $(this).val();
                if (text_value == "") {
                    $("#txtPwd").show();
                    $("#password").hide();
                }
            });


            if (navigator.userAgent.toLowerCase().indexOf("chrome") >= 0) {
                $(window).load(function () {
                    $('ul input:not(input[type=submit])').each(function () {
                        var outHtml = this.outerHTML;
                        $(this).append(outHtml);
                    });
                });
            }
        });

        function getVerCode() {
            $.ajax({
                url: '/Ashx/Login/ValidateCode.ashx',
                Type: 'PSOT',
                cache: false,
                success: function (data) {
                    $("#xCode").text(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    getVerCode();
                }
            });
        }
        function btnLogin() {
            $("#lblError").hide();
            var txtVerification = $("#txtVer").val();
            var txtAccount = $("#txtAccount").val();
            var txtPwd = $("#password").val();
            if (txtAccount == "") {
                $("#lblError").text("账户名不能为空！");
            }
            if (txtPwd == "") {
                $("#lblError").text("密码不能为空！");
            }
            $.ajax({
                url: '/Ashx/Login/LoginHandler.ashx',
                //                dataType: 'json',
                Type: 'PSOT',
                cache: false,
                data: { txtVerification: txtVerification, txtAccount: txtAccount, txtPwd: txtPwd },
                success: function (data) {
                    if (data.length > 200) {
                        window.location.href = "/Default.aspx";
                    } else {
                        $("#lblError").text(data.Message);
                        $("#lblError").show();
                        getVerCode();
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {

                }
            });
            return true;
        }



       
    </script>
</head>
<body style="background-color: #1c77ac; background-image: url(images/light.png);
    background-repeat: no-repeat; background-position: center top; overflow: hidden;">
    <form id="form1" runat="server">
    <div id="mainBody">
        <div id="cloud1" class="cloud">
        </div>
        <div id="cloud2" class="cloud">
        </div>
    </div>
    <div class="logintop">
        <span>欢迎登录流量分销管理平台</span>
        <ul>
            <li><a href="#">回首页</a></li>
            <li><a href="#">帮助</a></li>
            <li><a href="#">关于</a></li>
        </ul>
    </div>
    <div class="loginbody">
        <span class="systemlogo"></span>
        <div class="loginbox loginbox3">
            <ul>
                <li>
                    <input name="" type="text" id="txtAccount" class="loginuser" value="用户名" style="color: #90a2bc"
                        onclick="JavaScript:this.value='';" /></li>
                <li>
                    <input name="" type="text" id="txtPwd" class="loginpwd" value="密码" style="color: #90a2bc"
                        onclick="JavaScript:this.value='';" />
                    <input type="password" class="loginpwd" id="password" onclick="JavaScript:this.value='';"
                        style="display: none; color: #90a2bc" />
                </li>
                <li class="yzm"><span>
                    <input name="" type="text" id="txtVer" class="loginpwd" maxlength="6" style="width: 150px;
                        margin-bottom: 0px;" value="验证码" onclick="JavaScript:this.value='';" />
                </span><cite>
                    <img src="/Ashx/Login/ValidateCode.ashx" alt="点击刷新验证码" onclick="this.src='Ashx/Login/ValidateCode.ashx?t='+new Date()"
                        style="cursor: pointer" />
                </cite></li>
                <li>
                    <input name="" type="button" class="loginbtn" value="登录" onclick="btnLogin();return false;" /><label><input
                        name="" type="checkbox" value="" checked="checked" />记住密码</label><label><a href="#">忘记密码？</a></label></li>
                <li>
                    <label id="lblError" style="display: none; color: red">
                    </label>
                </li>
            </ul>
        </div>
    </div>
    <div class="loginbm">
        流量分销</div>
    </form>
</body>
