<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowCardDirect.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentApplication.FlowCardDirect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>卡密提取</title>
    <style type="text/css">
        .error_li
        {
            color: red;
            height: 18px;
        }
    </style>
</head>
<body style="min-width: 200px;">
    <form id="form1" runat="server">
    <div>
        <ul class="forminfo" style="margin-top: 30px;">
            <li>
                <label>
                    电话号码：
                </label>
                <asp:TextBox runat="server" CssClass="scinput1" ID="txtMobilePhone" MaxLength="11"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="error_li" runat="server"
                    ErrorMessage="*电话号码不能为空！" ControlToValidate="txtMobilePhone"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="Validator_ID" runat="Server" CssClass="error_li"
                    ControlToValidate="txtMobilePhone" ValidationExpression="(\d{11})$" ErrorMessage="*电话号码格式不正确"></asp:RegularExpressionValidator>
            </li>
            <li>
                <label>
                    卡号：
                </label>
                <asp:TextBox runat="server" CssClass="scinput1" ID="txtCardId" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="error_li" runat="server"
                    ErrorMessage="*卡号不能为空！" ControlToValidate="txtCardId"></asp:RequiredFieldValidator>
            </li>
            <li><span id="sp_caridNotExists" runat="server" visible="False" style="color: red">*卡号不存在！</span>
                <span id="sp_Parent_eror" runat="server" visible="False" style="color: red">*该批次的卡密已终止，不能提取！</span>
                <span id="sp_caridStatus_error" runat="server" visible="False" style="color: red">*卡号状态异常，不能激活，请联系管理员！</span>
            </li>
            <li>
                <label>
                    密码：
                </label>
                <asp:TextBox runat="server" CssClass="scinput1" ID="txtSec" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="error_li" runat="server"
                    ErrorMessage="*密码不能为空！" ControlToValidate="txtSec"></asp:RequiredFieldValidator>
            </li>
            <li><span id="sp_sec_error" runat="server" visible="False" style="color: red">*卡号密码不匹配！</span>
            </li>
            <li style="margin-left: 86px;">
                <asp:Button runat="server" ID="btnSave" CssClass="scbtn" Text="提取" OnClick="btnSave_Click" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
