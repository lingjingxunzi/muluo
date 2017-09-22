<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostMonthlyView.aspx.cs"
    Inherits="MONO.Distribution.UI.FinanceManage.CostMonthlyView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/TimePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightinfo">
        <div class="tools">
            <ul class="seachform1">
                <li>
                    <label>
                        月份：</label>
                    <asp:TextBox runat="server" Width="120px" CssClass="scinput1" ID="txtStartQueryDateTime"
                        onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',maxDate:'\'2020-10-01\'}',dateFmt:'yyyy-MM'})"></asp:TextBox>
                    <asp:Button ID="btnQuery" CssClass="scbtn" runat="server" Text="查询" OnClick="btnQuery_Click" />
                    <asp:Button runat="server" ID="btnLoad" Text="下载" CssClass="scbtn" OnClick="btnLoad_OnClick" />
                </li>
            </ul>
        </div>
        <div style="width: 60%; margin-top: 50px; margin-left: 250px;">
            <div>
                <ul>
                    <li style="text-align: center; font-size: 22px; font-weight: bold">
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>订购总结算</li>
                    <li style="text-align: left; font-size: 16px; margin-top: 10px;">付款周期：<asp:Label
                        runat="server" ID="lblCycle"></asp:Label>
                    </li>
                    <li style="text-align: left; font-size: 16px; margin-top: 10px;">详单： </li>
                    <li style="margin-top: 15px;">
                        <table width="90%" style="margin-left: 10px; border: 1px solid black">
                            <tr>
                                <th style="font-size: 14px; border: 1px solid black">
                                    接口商
                                </th>
                                <th style="font-size: 14px; border: 1px solid black">
                                    使用金额
                                </th>
                            </tr>
                            <asp:Repeater runat="server" ID="rep_FlowTotal">
                                <ItemTemplate>
                                    <tr>
                                        <td style="border: 1px solid black">
                                            <%# Eval("EnumName.EnumValue")%>
                                        </td>
                                        <td style="border: 1px solid black">
                                            <%# Convert.ToDecimal(Eval("counts")) /100%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                                <td style="text-align: center; font-weight: bold; border: 1px solid black">
                                    汇总：
                                </td>
                                <td style="text-align: center; font-weight: bold; border: 1px solid black">
                                    <asp:Label runat="server" ID="lblTotal"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
