<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemBackupEdit.aspx.cs"
    Inherits="MONO.Distribution.UI.Sys.SystemBackupEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/TimePicker/WdatePicker.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 100
            });
            $(".select2").uedSelect({
                width: 100
            });

            $(".select3").uedSelect({
                width: 200
            });
        });
    </script>
</head>
<body style="min-width: 200px;">
    <form id="form1" runat="server">
    <input type="hidden" id="hiddenId" runat="server" />
    <!--隐藏域区域 结束-->
    <div>
        <ul class="forminfo">
            <li>
                <label  style="width:96px;">
                    *备份编号：
                </label>
                <asp:TextBox ID="txtNumber" CssClass="dfinput1" runat="server" MaxLength="20"></asp:TextBox><span
                    id="ErrorName" runat="server"></span> </li>
            <li>
                <label style="width: 96px;">
                    *备份类型：
                </label>
                <input type="radio" name="style" runat="server" id="styleAll" onclick="styleOnchenged();" />完全备份
                <input type="radio" name="style" runat="server" id="styleSome" onclick="styleOnchenged();" />
                表备份 </li>
            <li id="li_tableNameList" runat="server" style="display: none">
                <label  style="width:96px;">
                    表名:</label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select3" ID="ddlTables" />
                </div>
            </li>
            <li>
                <label style="width: 96px;">
                    *备份频率：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select1" ID="ddlClycle" />
                </div>
            </li>
            <li>
                <label style="width: 96px;">
                    *首次备份日期：
                </label>
                 <asp:TextBox runat="server" ID="txtTime" CssClass="scinput1" onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',maxDate:'#F{\'2020-10-01\'}',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
            </li>
            <li>
                <label style="width: 96px;">
                    目标地址:
                </label>
                <asp:TextBox runat="server" ID="txtPath" CssClass="dfinput"></asp:TextBox>
            </li>
            <li>
              <asp:Label runat="server" ID="lblError" Visible="False"></asp:Label>
            </li>
            <li style="margin-left: 86px;">
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="保存" OnClick="btnSave_Click" />
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="保存" OnClick="btnUpdate_Click" />
            </li>
        </ul>
    </div>
    </form>
    <script type="text/javascript">
        function styleOnchenged() {
            if ($("#styleSome").attr("checked")) {
                $("#li_tableNameList").show();
            } else {
                $("#li_tableNameList").hide();
            }
        }
    </script>
</body>
</html>
