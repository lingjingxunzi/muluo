<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowCodeEdit.aspx.cs" Inherits="MONO.Distribution.UI.BaseInfo.FlowCodeEdit" %>

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
                width: 200
            });
            $(".select2").uedSelect({
                width: 100
            });
            $(".select5").uedSelect({
                width: 100
            });
            $(".select4").uedSelect({
                width: 300
            });
            $(".select6").uedSelect({
                width: 200
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
                    *接口：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select6" AutoPostBack="True" ID="ddlFlowCode"
                        OnSelectedIndexChanged="ddlFlowCode_OnSelectedIndexChanged" />
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
                    *别名：
                </label>
                 <asp:TextBox runat="server" ID="txtName" CssClass="dfinput1"></asp:TextBox>
            </li>
            <li>
                <label>
                    *产品代码：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtInterfaceCode"></asp:TextBox>
            </li>
            <li>
                <label>
                    *折扣比例：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select2" ID="ddlDiscounts" />
                </div>
                 
                <label style="margin-left:50px;">
                    *省份：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select5" ID="ddlProvice" />
                </div>
            </li>
            <li>
                <label>
                    *优先级：
                </label>
                <asp:TextBox runat="server" CssClass="dfinput1" ID="txtProtify"></asp:TextBox>（*输入数字，执行顺序为升序）
            </li>
            <li>
                <label>
                    *执行状态：
                </label>
                 <div class="vocation">
                    <asp:DropDownList runat="server" CssClass="select5" ID="ddlStatus" >
                        <asp:ListItem Text="启用" Value="Y"></asp:ListItem>
                        <asp:ListItem Text="禁用" Value="N"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <asp:Button ID="btnUpdate" runat="server" Text="保存" CssClass="btn" OnClick="btnUpdate_Click" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
