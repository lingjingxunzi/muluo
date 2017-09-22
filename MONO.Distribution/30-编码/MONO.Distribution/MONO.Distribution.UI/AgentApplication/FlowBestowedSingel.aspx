<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowBestowedSingel.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentApplication.FlowBestowedSingel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 320
            });
        });
      
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="place">
        <span>当前位置：</span>
        <ul class="placeul">
            <li><a href="#">平台管理>>菜单编辑</a></li>
        </ul>
    </div>
    <div class="rightinfo">
        <div class="tools">
            <div class="toolbar">
                <ul>
                    <li><a href="FlowBestowed.aspx"><span>
                        <img src="/Images/t01.png" /></span>返回</a></li>
                </ul>
            </div>
        </div>
        <!--数据列表 开始-->
        <div class="formtitle">
            <span>单号码赠送</span>
        </div>
        <div>
            <ul class="forminfo">
                <li>
                    <label>
                        当前积分：
                    </label>
                    <label id="lblInter" runat="server">
                        0
                    </label>
                </li>
                <li>
                    <label>
                        电话号码：</label>
                    <asp:TextBox runat="server" ID="txtPhone" CssClass="scinput1" MaxLength="11" OnTextChanged="txtPhone_OnTextChanged"
                        AutoPostBack="True"></asp:TextBox>
                </li>
                <li>
                    <label>
                        可充值流量包：</label>
                    <div class="vocation">
                        <asp:DropDownList runat="server" CssClass="select1" ID="ddlFlow" AutoPostBack="True" />
                    </div>
                </li>
                <li>
                    <asp:Label runat="server" ID="lblError"></asp:Label>
                </li>
                <li style="margin-left: 86px;">
                    <asp:Button runat="server" ID="btnSend" Text="赠送" CssClass="scbtn" OnClick="btnSend_OnClick" />
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
