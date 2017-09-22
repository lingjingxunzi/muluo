<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowCarrierEdit.aspx.cs"
    Inherits="MONO.Distribution.UI.BaseInfo.FlowCarrierEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 100
            });
            $(".select3").uedSelect({
                width: 100
            });
            $(".select2").uedSelect({
                width: 100
            });
            $(".select5").uedSelect({
                width: 100
            });
            $(".select4").uedSelect({
                width: 280
            });
            $(".select6").uedSelect({
                width: 100
            });
        });
    </script>
</head>
<body style="min-width: 200px;">
    <form id="form1" runat="server">
    <div style="margin-left: 50px;">
        <ul class="forminfo">
            <li>
                <label>
                    *流量包：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select4" ID="ddlFlows" />
                </div>
            </li>
            <li>
                <label>
                    *接口别名：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtName"></asp:TextBox>
            </li>
            <li>
                <label>
                    *折扣比例：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select2" ID="ddlDiscounts" />
                </div>
            </li>
            <li>
                <label>
                    *承运商：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select3" ID="ddlCarries" />
                </div>
            </li>
            <li>
                <label>
                    *产品代码：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtInterfaceCode"></asp:TextBox>
            </li>
            <li>
                <label>
                    *省份：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select5" ID="ddlProvice" />
                </div>
            </li>
            <li>
                <label>
                    *漫游类型：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select6" ID="ddlRoamType">
                        
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <label>
                    *优先级：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtProtify"></asp:TextBox>
            </li>
            <li>
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="保存" OnClick="btnSave_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="保存" CssClass="btn" OnClick="btnUpdate_Click" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
