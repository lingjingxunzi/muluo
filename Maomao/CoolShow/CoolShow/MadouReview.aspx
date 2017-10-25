<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MadouReview.aspx.cs" Inherits="CoolShow.UI.MadouReview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/madou-review-common.css" rel="stylesheet" type="text/css" />
    <link href="Styles/madou-review-item.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/layer_mobile/need/layer.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="Scripts/layer_mobile/layer.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="deanmadoucontent">
        <div class="deanmdcltop">
            <span>个人资料</span></div>
        <div class="deanmdbox">
            <div class="deanmdcl">
                <div class="deanmdclinfo">
                    <div class="deancolumn_p">
                        <span class="deancolum_span">年龄</span> <em id="txtAge" runat="server"></em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">所在城市</span> <em id="txtEare" runat="server">广州</em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">身高</span> <em id="txtHeight" runat="server">165cm</em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">体重</span> <em id="txtWeight" runat="server"></em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">姓名</span> <em id="txtNick" runat="server">傅粤湘</em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">职业</span> <em id="txtOcc" runat="server">白领丽人</em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">拍摄风格</span> <em id="txtImageStyle" runat="server">能轻松驾驭各种拍摄风格</em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">期望价格</span> <em id="txtSalary" runat="server">根据工作性质再确定</em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">拍摄用材</span> <em id="txtImageTools" runat="server">手机</em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">小号信誉</span> <em id="txtWangLevel" runat="server">4心</em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">可否送拍</span> <em id="txtIsGive" runat="server">可以</em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">人气</span> <em id="txtPopularity" runat="server">可以</em>
                        <a onclick="loginShow();">+收藏</a>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="deancolumn_p">
                        <span class="deancolum_span">评价</span> <em id="txtScore" runat="server">可以</em>
                        <div class="clear">
                        </div>
                    </div>
                    <%-- <div class="deancolumn_p">
                        <span class="deancolum_span">麻豆联系方式</span> <em><span style="color: rgb(255, 0, 0);">
                            联系管理员QQ9206788认证开通VIP权限查看</span></em>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                        <img src="http://www.tbqq.net/static/image/ad.jpg"></div>--%>
                </div>
            </div>
            <div class="deanmotetl">
                <div class="deanmotepic">
                    <ul>
                        <li style="display: block;">
                            <img id="img1" runat="server" /></li>
                        <%-- <li>
                            <img id="img2" runat="server" /></li>
                        <li>
                            <img id="img3" runat="server"/></li>
                        <li>
                            <img id="img4" runat="server"/></li>--%>
                    </ul>
                </div>
                <div class="deanmotespics">
                    <ul>
                        <li class="cur">
                            <img id="imgtrue1" runat="server" /></li>
                        <li>
                            <img id="imgtrue2" runat="server" /></li>
                        <li>
                            <img id="imgtrue3" runat="server" /></li>
                        <li>
                            <img id="imgtrue4" runat="server" /></li>
                    </ul>
                </div>
            </div>
            <div class="clear">
            </div>
            <script type="text/javascript">
                function btnpopular() {

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


                function loginShow() {
                    layer.open({
                        title: [
    '商家登录',
    'background-color:#8DCE16; color:#fff;'
  ]
  , anim: 'up'
  , content: '<div><ul><li>电话号码：<input type="text" /></li><li>店铺名称：<input type="text" /></li><li><input type="button" value="登录" onclick="login();"></li></ul></div>'
  , btn: ['取消']
                    });
                }

                function login() {
                    $.ajax({
                        url: '/Ashx/Login/LoginHandler.ashx',
                        //                dataType: 'json',
                        Type: 'PSOT',
                        cache: false,
                        data: { txtVerification: txtVerification, txtAccount: txtAccount, txtPwd: txtPwd },
                        success: function (data) {
                            if (data == "0") {
                                updatepopolar();
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {

                        }
                    });
                }

                function updatepopolar() {

                }
            </script>
        </div>
    </div>
    </form>
</body>
</html>
