<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowCardList.aspx.cs" Inherits="MONO.Distribution.UI.AgentApplication.FlowCardList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/TimePicker/WdatePicker.js" type="text/javascript"></script>
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
            <ul class="toolbar">
                <li><a href="#" onclick="openWindow('新增卡密','FlowCardCreate.aspx?Command=Insert','420','480');"><span>
                    <img src="../Images/t01.png" /></span>新增卡密</a></li>
                <li><a href="#" onclick="openWindow('卡密提取','FlowCardDirect.aspx','420','350');"><span>
                    <img src="../Images/t02.png" /></span>卡密提取</a></li>
            </ul>
            <ul class="seachform1" style="width: 950px;">
                <li>
                    <label>
                        创建时间:
                    </label>
                    <asp:TextBox runat="server" Width="120px" CssClass="scinput1" ID="txtStartQueryDateTime"
                        onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',maxDate:'#F{$dp.$D(\'txtEndQueryDateTime\')||\'2020-10-01\'}',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>-<asp:TextBox
                            runat="server" Width="120px" ID="txtEndQueryDateTime" CssClass="scinput1" onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',minDate:'#F{$dp.$D(\'txtStartQueryDateTime\')}',maxDate:'2020-10-01',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                </li>
                <li>
                    <label>
                        批次号：</label><asp:TextBox runat="server" ID="txtTransNo" CssClass="scinput2"></asp:TextBox>
                    <asp:Button runat="server" ID="Button1" Text="查询" CssClass="scbtn" OnClick="btnQuery_Click" />
                </li>
            </ul>
        </div>
        <div class="formtitle">
            <span>流量卡/卡密</span>
        </div>
        <asp:GridView ID="gvFlowCardList" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="tablelist" OnRowCommand="gvFlowCardList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="批次号">
                    <ItemTemplate>
                        <%#Eval("TransNo")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="数量">
                    <ItemTemplate>
                        <%#Eval("Numbers")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="流量包">
                    <ItemTemplate>
                         <%#Eval("SystemFlowPackets.FlowBaseInfo.FlowName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="总价">
                    <ItemTemplate>
                        <%# Eval("Amount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="过期时间">
                    <ItemTemplate>
                        <%#Eval("OverdueTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="创建时间">
                    <ItemTemplate>
                        <%#Eval("CreateTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%#Eval("EnumStatus.EnumValue")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="ltbnEdit" runat="server" Text="卡密" OnClientClick='<%#Eval("TransNo","javascript:openWindow(\"卡密\",\"FlowCardDetails.aspx?Command=Edit&NO={0}\",\"650\",\"520\");return false;") %>'></asp:LinkButton>
                        <asp:LinkButton ID="linkBtnDel" CommandName="del" CommandArgument='<%#Eval("TransNo") %>'
                            runat="server" Visible='<%# Convert.ToString(Eval("Status")).Equals("KMZC") %>'
                            OnClientClick="return (confirm('状态更改后不能恢复，确定更改此状态？'));">终止</asp:LinkButton>
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
        
        <div class="tip">
        <div class="tiptop">
            <span id="editTitle">新增卡密</span><a onclick="closeWindow(false);"></a></div>
        <div class="tipinfo">
            <iframe id="editFrame" src="FlowCardCreate.aspx" width="560px" height="350px"></iframe>
        </div>
    </div>
    </div>
    <script type="text/javascript">
        function openCreateWindow() {
            window.parent.openChildWindow("新增卡密", "FlowCardEdit.aspx", "500", "460");
        }
        function openDirectWindow() {
            window.parent.openChildWindow("卡密提取", "FlowCardDirect.aspx", "500", "360");
        }
    </script>
    </form>
</body>
</html>
