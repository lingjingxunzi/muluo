<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyAccountApplyEdit.aspx.cs"
    Inherits="MONO.Distribution.UI.CustomerManage.CompanyAccountApplyEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 280
            });
            
        });
    </script>
</head>
<body style="min-width: 200px;">
    <form id="form1" runat="server" >
    <div>
        <ul class="forminfo">
            <li>
                <label style="width: 96px;">
                    *申请账户：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select1" ID="ddlCompany" />
                </div>
            </li>
            <li>
                <label style="width: 96px;">
                    *申请金额：
                </label>
                <input type="text" id="txtApplyAcc" class="dfinput1" onkeyup="txtApplyAccKeyDown();" runat="server" />
            </li>
            <li>
                <label style="width: 96px;">
                    *申请积分：
                </label>
                <asp:TextBox ID="txtApplyInter" CssClass="dfinput1" Enabled="False" runat="server"
                    MaxLength="20"></asp:TextBox>
            </li>
            <li runat="server">
                <label style="width: 96px;">
                    申请说明:</label>
                <asp:TextBox ID="txtRemark" CssClass="dfinput1" runat="server" Width="300px" Height="80px" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </li>
            <li>
                <label style="width: 96px;">
                    上传附件：
                </label>
                <input id="InputFile" style="width: 399px" type="file" runat="server" />
            </li>
            <li>
                <asp:Button runat="server" CssClass="scbtn" Text="保存" ID="btnCreate" OnClick="btnCreate_OnClick" />
                <asp:Button runat="server" CssClass="scbtn" Text="保存" ID="btnUpdate" OnClick="btnUpdate_OnClick" />
            </li>
        </ul>
    </div>
    </form>
    <script type="text/javascript">
        function txtApplyAccKeyDown() {
            var acount = $("#txtApplyAcc").val();
            $("#txtApplyInter").val(parseInt(acount) * 100);
        }
    </script>
</body>
</html>
