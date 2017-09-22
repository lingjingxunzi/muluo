<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowCodeReviewList.aspx.cs"
    Inherits="MONO.Distribution.UI.BaseInfo.FlowCodeReviewList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="min-width: 250px;">
    <form id="form1" runat="server">
    <div class="rightinfo">
        <asp:GridView ID="gvFlowPacketList" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="tablelist">
            <Columns>
                <asp:TemplateField HeaderText="接口商">
                    <ItemTemplate>
                        <%#Eval("EnumCarrier.EnumValue")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="流量包信息">
                    <ItemTemplate>
                        <%#Eval("FlowBaseInfo.FlowName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="运营商">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <%# Eval("EnumFrom.EnumValue")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="流量包范围">
                    <ItemTemplate>
                        <%#Eval("AreaName.Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="原价">
                    <ItemTemplate>
                        <%#Eval("FlowBaseInfo.StandardPrice")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="折扣">
                    <ItemTemplate>
                        <%#Eval("Discounts.Deduction")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="折扣价">
                    <ItemTemplate>
                        <%#Eval("PurchasePrice")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="优先级">
                    <ItemTemplate>
                        <%#Eval("Priority")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
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
