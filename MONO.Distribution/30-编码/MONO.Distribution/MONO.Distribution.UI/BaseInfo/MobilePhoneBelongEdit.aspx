<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobilePhoneBelongEdit.aspx.cs"
    Inherits="MONO.Distribution.UI.BaseInfo.MobilePhoneBelongEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//Dlabel XHTML 1.0 liansitional//EN" "http://www.w3.org/li/xhtml1/Dlabel/xhtml1-liansitional.dlabel">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>终端用户编辑</title>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 150
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
                <label>
                    号码头：
                </label>
                <asp:TextBox ID="txtHead" MaxLength="7" runat="server" CssClass="dfinput1" Width="70px"></asp:TextBox>
            </li>
            <li>
                <label>
                    *区域：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select1" ID="ddlAreas" />
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
