<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistributionDetailsForUser.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentManage.DistributionDetailsForUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/TimePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body style="min-width: 200px;">
    <form id="form1" runat="server">
    <div class="rightinfo">
        <div class="tools">
            <ul class="seachform1">
                <li>
                    <label>
                        操作日期：</label>
                    <asp:TextBox runat="server" Width="120px" CssClass="scinput1" ID="txtStartQueryDateTime"
                        onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',maxDate:'#F{$dp.$D(\'txtEndQueryDateTime\')||\'2020-10-01\'}',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>-<asp:TextBox
                            runat="server" Width="120px" CssClass="scinput1" ID="txtEndQueryDateTime" onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',minDate:'#F{$dp.$D(\'txtStartQueryDateTime\')}',maxDate:'2020-10-01',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button runat="server" CssClass="scbtn" ID="btnQuery" Text="查询" OnClick="btnQuery_Click" />
                </li>
            </ul>
        </div>
        <asp:GridView ID="gvDisList" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="tablelist">
            <Columns>
                <asp:TemplateField HeaderText="批次号">
                    <ItemTemplate>
                        <%#Eval("BatchNo")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="电话号码">
                    <ItemTemplate>
                        <%#Eval("MobilePhone")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="流量包">
                    <ItemTemplate>
                        <%#Eval("SystemFlowPackets.FlowBaseInfo.FlowName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="订购日期">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <%#Eval("CreateTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="订购状态">
                    <ItemTemplate>
                        <%# Eval("EnumStatus.EnumValue")%>
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
        <!--分页 结束-->
    </div>
    <div class="tip">
        <div class="tiptop">
            <span id="editTitle">新增用户</span><a onclick="closeWindow(false);"></a></div>
        <div class="tipinfo">
            <iframe id="editFrame" src="/Sys/UserEdit.aspx" width="560px" height="350px"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
