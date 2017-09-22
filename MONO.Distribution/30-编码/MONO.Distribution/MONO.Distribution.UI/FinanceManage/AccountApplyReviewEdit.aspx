<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountApplyReviewEdit.aspx.cs"
    Inherits="MONO.Distribution.UI.FinanceManage.AccountApplyReviewEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="min-width: 200px;">
    <form id="form1" runat="server" >
    <div>
        <ul class="forminfo">
            <li>
                <label style="width: 96px;">
                    *申请账户：
                </label>
                <asp:TextBox runat="server" ID="txtApplyAccName" CssClass="dfinput1" Enabled="False"></asp:TextBox>
            </li>
            <li>
                <label style="width: 96px;">
                    *申请金额：
                </label>
                <asp:TextBox runat="server" ID="txtAmount" CssClass="dfinput1" Enabled="False"></asp:TextBox>
            </li>
            <li>
                <label style="width: 96px;">
                    *申请人：
                </label>
                <asp:TextBox runat="server" ID="txtApplyUserName" CssClass="dfinput1" Enabled="False"></asp:TextBox>
            </li>
            <li id="Li1" runat="server">
                <label style="width: 96px;">
                    申请说明:</label>
                <asp:TextBox ID="txtRemark" CssClass="dfinput1" runat="server" Width="300px" Height="80px"
                    TextMode="MultiLine" Rows="4"></asp:TextBox>
            </li>
            <li>
                <label style="width: 96px;">
                    上传附件：
                </label>
                <asp:Image runat="server"   ID="imgs"  Width="150px" Height="100px"/>
            </li>
            <li>
                <asp:Button runat="server" CssClass="scbtn" Visible="False" Text="拒绝" ID="btnCreate"
                    OnClick="btnRefused_OnClick" />
                <asp:Button runat="server" CssClass="scbtn" Visible="False" Text="同意" ID="btnUpdate"
                    OnClick="btnAgree_OnClick" />
            </li>
        </ul>
    </div>
     
    </form>
</body>
</html>
