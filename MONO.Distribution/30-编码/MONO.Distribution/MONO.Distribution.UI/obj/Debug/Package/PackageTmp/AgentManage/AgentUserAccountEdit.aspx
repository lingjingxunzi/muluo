<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentUserAccountEdit.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentManage.AgentUserAccountEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="min-width: 200px;">
    <form id="form1" runat="server">
    <!--隐藏域区域 开始-->
    <input type="hidden" id="hiddenId" runat="server" />
    <!--隐藏域区域 结束-->
    <div>
        <ul class="forminfo">
            <li>
                <label class="title">
                    *用户账号：
                </label>
                <asp:TextBox ID="txtName" CssClass="dfinput1" runat="server" Enabled="False">
                </asp:TextBox>
            </li>
            <li>
                <label class="title">
                    *账户总积分：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtTotal" Enabled="False"></asp:TextBox>
            </li>
            <li>
                <label class="title">
                    账户剩余积分：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtLeft"></asp:TextBox>
            </li>
            
            <li style="margin-left: 86px;">
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="保存" OnClick="btnUpdate_Click" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
