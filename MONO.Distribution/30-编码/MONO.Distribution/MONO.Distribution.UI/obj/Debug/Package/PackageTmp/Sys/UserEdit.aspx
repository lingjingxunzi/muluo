<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="MONO.Distribution.UI.Sys.UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//Dlabel XHTML 1.0 liansitional//EN" "http://www.w3.org/li/xhtml1/Dlabel/xhtml1-liansitional.dlabel">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户编辑</title>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 100
            });
            
            $(".select3").uedSelect({
                width: 100
            });
        });
    </script>
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
                <asp:TextBox ID="txtName" CssClass="dfinput1" runat="server"></asp:TextBox><span
                    id="ErrorName" runat="server"></span> </li>
            <li>
                <label class="title">
                    *密码：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtScrect"></asp:TextBox>
            </li>
            <li>
                <label class="title">
                    昵称：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtNick"></asp:TextBox>
            </li>
            <li>
                <label class="title">
                    用户组：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select1" ID="ddlGroup" />
                </div>
            </li>
           
            <li>
                <label>
                    *状态：
                </label>
                <div class="vocation">
                    <asp:DropDownList ID="ddlStatus" CssClass="select3" runat="server">
                        <asp:ListItem Value="0">启用</asp:ListItem>
                        <asp:ListItem Value="1">禁用</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li style="margin-left: 86px;">
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="保存" OnClick="btnSave_Click" />
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="保存" OnClick="btnUpdate_Click" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
