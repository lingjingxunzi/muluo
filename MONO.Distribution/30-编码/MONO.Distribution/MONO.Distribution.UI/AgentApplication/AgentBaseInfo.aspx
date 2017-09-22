<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentBaseInfo.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentApplication.AgentBaseInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <!--隐藏域区域 开始-->
    <input type="hidden" id="hiddenId" runat="server" />
    <!--隐藏域区域 结束-->
    <div class="place">
        <span>当前位置：</span>
        <ul class="placeul">
            <li><a href="#">平台管理>>菜单编辑</a></li>
        </ul>
    </div>
    <div class="formbody">
        <div id="usual1" class="usual">
            <div class="itab">
                <ul id="tabs">
                    <li><a href="#" class="selected" id="1">个人信息</a></li>
                </ul>
            </div>
        </div>
        <div id="tabs-body" style="height: 280px">
            <div id="tab1" class="tabson">
                <ul class="forminfo" style="margin-left: 50px;">
                    <li>
                        <label>
                            昵称：
                        </label>
                        <asp:TextBox ID="txtNick" runat="server" CssClass="dfinput"></asp:TextBox>
                    </li>
                    <li>
                        <label>
                            *商户账户：
                        </label>
                        <asp:TextBox ID="txtAccount" runat="server" CssClass="dfinput" Enabled="False"></asp:TextBox>
                    </li>
                   
                    <li>
                        <label>
                            *订购密钥：
                        </label>
                        <asp:TextBox Enabled="False" runat="server" ID="txtSec" CssClass="dfinput"></asp:TextBox>
                        <asp:Button runat="server" ID="btnUpdateSec" Text="重置" OnClick="btnUpdateSec_OnClick" />
                    </li>
                    <li>
                        <label>
                            *回调地址：
                        </label>
                        <asp:TextBox Enabled="False" runat="server" ID="txtUrl" CssClass="dfinput"></asp:TextBox>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div id="div_button" style="margin-top: 100px; margin-left: 180px;">
        <asp:Button ID="btnUpdate" runat="server" CssClass="scbtn" Text="保存" OnClientClick="return ValidateAll()"
            OnClick="btnUpdate_Click" />
    </div>
    <script type="text/javascript">
        function showPwd() {
            if ($("#ckbIsShowPwd").attr('checked') == 'checked') {
                $("#txtPwd").attr('type', 'password');
            } else {
                $("#txtPwd").attr('type', 'text');
            }
        }

    </script>
    </form>
</body>
</html>
