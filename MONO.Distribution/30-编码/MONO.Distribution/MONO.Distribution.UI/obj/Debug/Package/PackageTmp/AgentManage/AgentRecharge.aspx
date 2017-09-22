<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentRecharge.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentManage.AgentRecharge" %>

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
    <div>
        <ul class="forminfo" style="margin-left:200px;">
            <li>
                <label class="title">
                    *用户账号：
                </label>
                <asp:TextBox ID="txtName" CssClass="dfinput1" Enabled="False" runat="server">
                </asp:TextBox>
            </li>
            <li>
                <label class="title">
                    *账户总积分：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" Enabled="False" ID="txtTotal"></asp:TextBox>
            </li>
            <li>
                <label class="title">
                    账户剩余积分：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" Enabled="False" ID="txtLeft"></asp:TextBox>
            </li>
            <li id="tr_turnin" runat="server">
                <label class="title">
                    充值积分：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtTurnIn"></asp:TextBox>
            </li>
            <li style="margin-left: 86px;">
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="保存" OnClick="btnUpdate_Click" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
