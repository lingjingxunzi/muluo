<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessDiscountEdit.aspx.cs"
    Inherits="MONO.Distribution.UI.Sys.BusinessDiscountEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>折扣一览</title>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 200
            });

            $(".select3").uedSelect({
                width: 300
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
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select1" ID="DropDownList1" />
                </div>
            </li>
            <li>
                <label class="title">
                    *流量包：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select3" ID="DropDownList2" />
                </div>
            </li>
            <li>
                <label class="title">
                    折扣：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtNick"></asp:TextBox>
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
