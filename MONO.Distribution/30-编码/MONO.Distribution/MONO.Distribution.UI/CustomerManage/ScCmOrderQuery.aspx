<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScCmOrderQuery.aspx.cs"
    Inherits="MONO.Distribution.UI.CustomerManage.ScCmOrderQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 100
            });
            $(".select2").uedSelect({
                width: 100
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
            <ul class="seachform1" style="width: 1100px;">
                <li>
                    <label>
                        电话号码：</label>
                    <asp:TextBox runat="server" Width="120px" CssClass="scinput1" ID="txtMobilePhone"></asp:TextBox>
                </li>
                <li>
                    <asp:Button runat="server" CssClass="scbtn" ID="btnQuery" Text="查询" OnClick="btnQuery_Click" />
                </li>
            </ul>
        </div>
        <!--数据列表 开始-->
        <div class="formtitle">
            <span>四川移动待查询</span>
        </div>
        <asp:GridView ID="gvDisList" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="tablelist" OnRowCommand="gvDisList_OnRowCommand">
            <Columns>
                <asp:TemplateField HeaderText="订购流水号">
                    <ItemTemplate>
                        <%#Eval("BatchNo")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="电话号码">
                    <ItemTemplate>
                        <%#Eval("MobilePhone")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="订购状态">
                    <ItemTemplate>
                        <%#Eval("SystemUsers.Account")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="流量包">
                    <ItemTemplate>
                        <%#Eval("SystemFlowPackets.FlowBaseInfo.FlowName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="订购日期">
                    <ItemTemplate>
                        <%#Eval("CreateTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="更新日期">
                    <ItemTemplate>
                        <%#Eval("UpdateTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="订单编号">
                    <ItemTemplate>
                        <%# Eval("OrderNo")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="订购状态">
                    <ItemTemplate>
                        <%# Eval("EnumStatus.EnumValue")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnSendStatusAgain" CommandName="sendAgain" CommandArgument='<%#Eval("DistributionRecordKey") %>'>状态查询推送</asp:LinkButton>
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
