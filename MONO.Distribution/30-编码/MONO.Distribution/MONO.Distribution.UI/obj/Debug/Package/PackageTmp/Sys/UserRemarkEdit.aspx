<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRemarkEdit.aspx.cs"
    Inherits="MONO.Distribution.UI.Sys.UserRemarkEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="min-width: 200px;">
    <form id="form1" runat="server">
    <div>
        <ul class="forminfo">
            <li>
                <label class="title">
                    备注信息：
                </label>
                <asp:TextBox runat="server" TextMode="MultiLine" Width="400px" Height="100px" CssClass="dfinput1" ID="txtRemark"></asp:TextBox>
            </li>
            <li style="margin-left: 86px;">
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="保存" OnClick="btnUpdate_Click" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
