<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemAccountOverDraftEdit.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentManage.SystemAccountOverDraftEdit" %>

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
        <ul class="forminfo">
            <li>
                <label style="width: 120px;">
                    *用户账号：
                </label>
                <asp:TextBox ID="txtName" CssClass="dfinput1" runat="server" Enabled="False">
                </asp:TextBox>
            </li>
            <li>
                <label style="width: 120px;">
                    *账户总积分：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtTotal" Enabled="False"></asp:TextBox>
            </li>
            <li>
                <label style="width: 120px;">
                    待转出账户剩余积分：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtLeft" Enabled="False"></asp:TextBox>
            </li>
            <li>
                <label style="width: 120px;">
                    当前透支额度：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtCurrentLeft" Enabled="False"></asp:TextBox>
            </li>
            <li id="tr_turnout" runat="server">
                <label style="width: 120px;">
                    透支额度：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtTurnOut"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*透支额度不能为空！"
                    CssClass="red" ControlToValidate="txtTurnOut"></asp:RequiredFieldValidator>
            </li>
            <li style="margin-left: 120px;">
                <asp:Label runat="server" ID="lblError" CssClass="red" Visible="False"></asp:Label>
            </li>
            <li style="margin-left: 120px;">
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="保存" OnClick="btnUpdate_Click" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
