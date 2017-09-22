<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowCardCreate.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentApplication.FlowCardCreate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/TimePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".select1").uedSelect({
                width: 260
            });
        })
    </script>
</head>
<body style="min-width: 200px;">
    <form id="form1" runat="server">
    <div>
        <ul class="forminfo" style=" margin-top: 30px;">
            <li>
                <label>
                    当前积分：
                </label>
                <label id="lblInt" runat="server">0</label>
                
            </li>
            <li>
                <label>
                    批次号：
                </label>
                <asp:TextBox runat="server" ID="txtTransNo" CssClass="scinput1" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*批次号不能为空！"
                    ControlToValidate="txtTransNo"></asp:RequiredFieldValidator>
                <span style="color: red" runat="server" visible="False" id="sp_trans_exists">*批次号已存在，不可重复！</span>
            </li>
            <li>
                <label>
                    数量：
                </label>
                <asp:TextBox runat="server" ID="txtNumbers" CssClass="scinput1" onchange="txtNumberChange();"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*数量不能为空！"
                    ControlToValidate="txtNumbers"></asp:RequiredFieldValidator>
            </li>
            <li>
                <label>
                    过期时间：
                </label>
                <asp:TextBox runat="server" ID="txtOverTime" CssClass="scinput1" onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',maxDate:'#F{\'2020-10-01\'}',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*过期时间不能为空！"
                    ControlToValidate="txtOverTime"></asp:RequiredFieldValidator>
            </li>
            <li>
                <label>
                    流量包：
                </label>
                <div class="vocation">
                    <select id="slt_flows" runat="server" class="select1" onchange="sltFlowsChanged();">
                    </select>
                    <span id="sp_flow_empty" style="color: red" runat="server" visible="False">*流量包未选择！</span>
                </div>
            </li>
            <li style="margin-top: 5px;">
                <label>
                    单价（积分）：
                </label>
                <label id="lblPrice" runat="server">
                </label>
            </li>
            <li style="margin-top: 5px;">
                <label>
                    总价（积分）：
                </label>
                <label id="lblTotal" runat="server">
                </label>
            </li>
            <li><span id="sp_Account_Error" style="color: red" runat="server" visible="False">*账户余额不足！</span>
            </li>
            <li style="margin-left: 86px;">
                <asp:Button runat="server" ID="btnSave" CssClass="scbtn" Text="保存" OnClick="btnSave_Click" />
            </li>
        </ul>
    </div>
    <script type="text/javascript">
        function sltFlowsChanged() {
            var flowId = $("#slt_flows").val();
            $.ajax({
                url: '../Ashx/Agent/GetCompanyInfoHandler.ashx',
                dataType: 'json',
                Type: 'PSOT',
                cache: false,
                data: { flowId: flowId },
                success: function (data) {
                    $("#lblPrice").html(data.Price);
                    calculateTotalPrice();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }
        function calculateTotalPrice() {
            var lblprice = $("#lblPrice").html();
            var lblNumber = $("#txtNumbers").val();
            var price = (lblprice.replace(/(^\s*)|(\s*$)/g, "") == "") ? 0 : parseInt($("#lblPrice").html());
            var numbers = (lblNumber.replace(/(^\s*)|(\s*$)/g, "") == "") ? 0 : parseInt($("#txtNumbers").val());
            var total = price * numbers;
            $("#lblTotal").html(total);
        }
        function txtNumberChange() {
            var values = $("#txtNumbers").val();
            var reg = new RegExp("^[0-9]*$");

            while (!reg.test(values)) {
                values = values.replace(/[^\d]/g, '');
            }
            $("#txtNumbers").val(values);

            calculateTotalPrice();
        }
    </script>
    </form>
</body>
</html>
