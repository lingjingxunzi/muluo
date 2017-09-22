<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowCardExtract.aspx.cs"
    Inherits="MONO.Distribution.UI.ComPage.FlowCardExtract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/mobile-style.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/commonpage/jquery-1.10.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mNavHgt">
    </div>
    <div class="main">
        <div class="fMtab mt15">
            <ul>
                <li>
                    <input type="text" id="txtCard" runat="server" placeholder="请输入卡号" />
                </li>
                <li>
                    <input type="text" id="txtPwd" runat="server" placeholder="请输入密码" />
                </li>
                <li>
                    <input type="text" id="txtPhone" runat="server" placeholder="请输入电话号码" />
                </li>
            </ul>
        </div>
        <div class=" mt15">
            <asp:Label runat="server" CssClass="red" ID="lblError"></asp:Label>
        </div>
        <div class="siBtn">
            <asp:LinkButton runat="server" CssClass="btnm" Text="提取并激活" OnClick="btnExtract_OnClick"></asp:LinkButton>
        </div>
        <div class="msMi">
            <p class="mTi">
                说明</p>
            <p class="mt10 gray6">
                1. 文字详情。<br />
                2. 文字详情。<br />
                3. 文字详情。<br />
            </p>
        </div>
    </div>
    </form>
</body>
</html>
