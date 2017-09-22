<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnumerationEdit.aspx.cs"
    Inherits="MONO.Distribution.UI.BaseInfo.EnumerationEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑字典</title>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 200
            });
            $(".select2").uedSelect({
                width: 100
            });
        });
        function regNum(obj) {
            obj.value = obj.value.replace(/\D/g, '');
        }
    </script>
</head>
<body style="min-width: 200px;">
    <form id="form1" runat="server">
    <!--导航区域 开始-->
    <!--导航区域 结束-->
    <div>
        <ul class="forminfo">
            <li>
                <label>
                    *字典编号：
                </label>
                <asp:TextBox ID="txtEnumKey" CssClass="dfinput1" runat="server" MaxLength="20"></asp:TextBox>
            </li>
            <li>
                <label>
                    *字典值：
                </label>
                <asp:TextBox ID="txtEnumValue" CssClass="dfinput1" runat="server" MaxLength="20"></asp:TextBox>
            </li>
            <li>
                <label>
                    父节点：
                </label>
                <div class="vocation">
                    <asp:DropDownList ID="ddlEnumType" CssClass="select1" runat="server">
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <label>
                    备注：
                </label>
                <asp:TextBox ID="txtRemarks" CssClass="dfinput" Width="200px" runat="server" MaxLength="20"></asp:TextBox>
            </li>
            <li>
                <label>
                    *启用标志：
                </label>
                <div class="vocation">
                    <asp:DropDownList ID="ddlStatus" CssClass="select2" runat="server">
                        <asp:ListItem Value="0">启用</asp:ListItem>
                        <asp:ListItem Value="1">停用</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li style="margin-left: 86px;">
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="保存" OnClick="btnSave_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="保存" CssClass="btn" OnClick="btnUpdate_Click" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
