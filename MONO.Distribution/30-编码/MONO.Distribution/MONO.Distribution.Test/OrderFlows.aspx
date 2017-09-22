<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderFlows.aspx.cs" Inherits="MONO.Distribution.Test.OrderFlows" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul>
            <li>
                <asp:Label runat="server">测试方法：</asp:Label>
                <asp:DropDownList runat="server" ID="ddlMethod">
                    <asp:ListItem Value="orderpkg">订购</asp:ListItem>
                    <asp:ListItem Value="orderbce">查询余额</asp:ListItem>
                    <asp:ListItem Value="orderquery">订购查询</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <asp:Label runat="server">账户名：</asp:Label>
                <asp:TextBox runat="server" ID="txtAccount"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label1" runat="server">密码：</asp:Label>
                <asp:TextBox runat="server" ID="txtSec"></asp:TextBox>
            </li>
            <li>
                <asp:Label runat="server"> 电话号码：</asp:Label>
                <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox></li>
            <li>
                <asp:Label runat="server">产品编号：</asp:Label>
                <asp:TextBox runat="server" ID="txtProductId"></asp:TextBox>
            </li>
        </ul>
        <asp:Button runat="server" ID="btnTest" Text="测试" OnClick="btnTest_OnClick" />
    </div>
    </form>
</body>
</html>
