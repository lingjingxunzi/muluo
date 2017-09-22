<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowCardDetails.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentApplication.FlowCardDetails" %>

 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body style="min-width: 300px;">
    <form id="form1" runat="server">
    <div>
        <div style="width: 100%; display: inline-block; clear: both; text-align: right">
            <asp:Button runat="server" ID="btnExport" CssClass="scbtn"
                Text="下载" OnClick="btnExport_Click" />
        </div>
    </div>
    <div>
        <asp:GridView ID="gvFlowCardDetailsList" runat="server" AutoGenerateColumns="False"
            Width="100%" CssClass="tablelist" OnRowCommand="gvFlowCardDetailsList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="批次号">
                    <ItemTemplate>
                        <%# Eval("TransNo")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="卡号">
                    <ItemTemplate>
                        <%#Eval("CardID")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="密码">
                    <ItemTemplate>
                        <%#Eval("Serect")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="电话号码">
                    <ItemTemplate>
                        <%#Eval("MobilePhone")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="流量包">
                    <ItemTemplate>
                        <%# string.IsNullOrEmpty(Convert.ToString(Eval("MobilePhone")))?"": Eval("CompanyFlowPackets.FlowPacketInfos.EnumFrom.EnumValue") + "." + Eval("CompanyFlowPackets.FlowPacketInfos.EnumRange.EnumValue") + "." + Eval("CompanyFlowPackets.FlowPacketInfos.Size") + "M"%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="提取时间">
                    <ItemTemplate>
                        <%# string.IsNullOrEmpty(Convert.ToString(Eval("MobilePhone"))) ? "" : Eval("RechargeTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%#Eval("EnumStatus.EnumValue")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkBtnDel" CommandName="Status" CommandArgument='<%#Eval("CardID") %>'
                            runat="server" Visible='<%# Convert.ToString(Eval("Status")).Equals("KMWSY") && Convert.ToString(Eval("FlowActiveCard.Status")).Equals("KMZZ") %>'
                            OnClientClick="return (confirm('确定要申请退款吗？'));">退款</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <!--数据列表 结束-->
        <!--分页 开始-->
        <div class="pagin">
            <div class="message" id="recordinfo" runat="server">
            </div>
            <span style="display: none">
                <asp:Button ID="btnPage" runat="server" Text="" OnClick="btnPage_Click" /><asp:HiddenField
                    ID="hidePage" runat="server" />
            </span>
            <ul class="paginList" id="pageinfo" runat="server">
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
