<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowCommitFaild.aspx.cs" Inherits="MONO.Distribution.UI.AgentApplication.FlowCommitFaild" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
        <div style="height: 50px">
            <ul class="forminfo">
                <li style="">
                    <label>
                        批次号：</label>
                    <label id="lblBatch" runat="server" style="width: 200px">
                    </label>
                    <label>
                        已提交！
                    </label>
                </li>
            </ul>
        </div>
        <div class="formtitle">
            <span>流量赠送</span>
        </div>
        <div>
            <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False" CssClass="tablelist">
                <Columns>
                    <asp:TemplateField HeaderText="批次号">
                        <ItemTemplate>
                            <%#Eval("BatchNo")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="流量包">
                        <ItemTemplate>
                            <%#Eval("SystemFlowPackets.FlowBaseInfo.FlowNameWithPrice")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="电话号码">
                        <ItemTemplate>
                            <%#Eval("MobilePhone")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="提交日期">
                        <ItemTemplate>
                            <%#Eval("SystemFlowPackets.FlowBaseInfo.FlowName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="更新日期">
                        <ItemTemplate>
                            <%#Eval("SystemFlowPackets.FlowBaseInfo.FlowName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="失败原因">
                        <ItemTemplate>
                            <%#Eval("ResultMsg")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#Eval("EnumStatus.EnumValue")%>
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
    </div>
    </form>
</body>
</html>
