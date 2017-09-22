<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowPacketEdit.aspx.cs"
    Inherits="MONO.Distribution.UI.BaseInfo.FlowPacketEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>流量包编辑</title>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 100
            });
            $(".select2").uedSelect({
                width: 100
            });
            $(".select3").uedSelect({
                width: 100
            });
            $(".select4").uedSelect({
                width: 100
            });
            $(".select5").uedSelect({
                width: 100
            });
            $(".select6").uedSelect({
                width: 100
            });
            $(".select7").uedSelect({
                width: 100
            });
            $(".select8").uedSelect({
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
    <div style="margin-left: 30px;">
        <ul class="forminfo">
            <li>
                <label>
                    *流量包名称：
                </label>
                <asp:TextBox runat="server" ID="txtName" CssClass="dfinput1"></asp:TextBox>
            </li>
            <li>
                <label>
                    *运营商：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select1" ID="ddlFrom" />
                </div>
            </li>
            <li>
                <label>
                    *大小：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1 floatLeft" Width="100px" ID="txtSize"></asp:TextBox>
                (M) </li>
            <li>
                <label>
                    *标准价：</label>
                <asp:TextBox runat="server" CssClass="dfinput1 " Width="100px" ID="txtPrice"></asp:TextBox>
            </li>
            <li>
                <label>
                    *范围：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select4" ID="ddlRange" />
                </div>
            </li>
            <li>
                <label>
                    *平台包代码：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtFlowCode"></asp:TextBox>
            </li>
            <li>
                <label>
                    *接口并行：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select8" ID="ddlIsParallel">
                        <asp:ListItem Value="N">串行</asp:ListItem>
                        <asp:ListItem Value="Y">并行</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <label style="margin-left: 50px;">
                    *失败循环：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select8" ID="ddlRecyle">
                        <asp:ListItem Value="N">单次</asp:ListItem>
                        <asp:ListItem Value="Y">循环</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <label>
                    *通道状态：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select8" ID="ddlChannelStatus">
                        <asp:ListItem Value="Y">正常</asp:ListItem>
                        <asp:ListItem Value="N">维护</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <label style="margin-left: 50px;">
                    *状态：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select8" ID="ddlStatus">
                        <asp:ListItem Value="Y">启用</asp:ListItem>
                        <asp:ListItem Value="N">禁用</asp:ListItem>
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
