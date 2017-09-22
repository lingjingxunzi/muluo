<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminInfoView.aspx.cs" Inherits="MONO.Distribution.UI.InformationViews.AdminInfoView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     
    <div class="place">
        <span>当前位置：</span>
        <ul class="placeul">
            <li><a href="#">首页</a></li>
        </ul>
    </div>
    <div class="formbody">
        <div id="usual1" class="usual">
            <div class="itab">
                <ul id="tabs">
                    <li><a href="#" class="selected" id="1">系统管理员账户</a></li>
                </ul>
            </div>
        </div>
        <div id="tabs-body" style="height: 280px">
            <div id="tab1" class="tabson">
                <ul class="forminfo" style="margin-left: 50px;">
                    <li>
                        <label>
                            账号：
                        </label>
                        <asp:TextBox ID="txtNick" runat="server" CssClass="dfinput"></asp:TextBox>
                    </li>
                    <li>
                        <label>
                            昵称：
                        </label>
                        <asp:TextBox ID="txtAccount" runat="server" CssClass="dfinput" Enabled="False"></asp:TextBox>
                    </li>
                    <li>
                        <label>
                            密码：
                        </label>
                        <asp:TextBox runat="server" ID="txtPwd" CssClass="dfinput"></asp:TextBox>
                    </li>
                </ul>
            </div>
        </div>
    </div>
   
    
    </form>
</body>
</html>
