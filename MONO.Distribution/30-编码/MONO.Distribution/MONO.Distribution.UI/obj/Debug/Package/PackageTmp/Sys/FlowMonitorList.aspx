<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowMonitorList.aspx.cs"
    Inherits="MONO.Distribution.UI.Sys.FlowMonitorList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 120
            });
            $('.tablelist tbody tr:even').addClass('odd');
            $('.imgtable tbody tr:even').addClass('odd');
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
            <ul class="seachform1">
                <li>
                    <label>
                        用户：</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlUsers" runat="server" CssClass="select1">
                        </asp:DropDownList>
                    </div>
                    &nbsp;&nbsp;
                    <asp:Button runat="server" CssClass="scbtn" ID="btnQuery" Text="查询" OnClick="btnQuery_Click" />
                </li>
            </ul>
        </div>
        <!--数据列表 开始-->
        <div class="formtitle">
            <span>用户列表</span>
        </div>
        <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="tablelist" OnRowCommand="gvUserList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="账户号">
                    <ItemTemplate>
                        <%#Eval("Account")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="昵称">
                    <ItemTemplate>
                        <%#Eval("Nick")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="账户总计积分">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <%#Convert.ToDecimal(Eval("SystemAccount.TotalAccount")).ToString("N2")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="账户剩余积分">
                    <ItemTemplate>
                        <%#Convert.ToDecimal(Eval("SystemAccount.LeftAccount")).ToString("N2")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="总订单量">
                    <ItemTemplate>
                        <%#Eval("TotalCount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="成功数量">
                    <ItemTemplate>
                        <%#Eval("SussessCount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="失败数量">
                    <ItemTemplate>
                        <%#Eval("FaildCount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="等待挂机总数">
                    <ItemTemplate>
                        <%#Eval("WaittingCount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="总花销">
                    <ItemTemplate>
                        <%#Eval("ActiveCostCount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="计算总额">
                    <ItemTemplate>
                        <%#Convert.ToInt32(Eval("SystemAccount.LeftAccount")) - Convert.ToInt32(Eval("ActiveCostCount"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="账户状态">
                    <ItemTemplate>
                        <%#(Convert.ToInt32(Eval("SystemAccount.LeftAccount")) - Convert.ToInt32(Eval("ActiveCostCount"))) == 0 ?"正常":"异常"%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" CommandName="reset" CommandArgument='<%#Eval("SysUserKey") %>'
                            runat="server" OnClientClick='<%#Eval("SysUserKey","javascript:openWindow(\"分销详细\",\"/AgentManage/DistributionDetailsForUser.aspx?Command=Edit&UserKey={0}\",\"850\",\"480\");return false;") %>'>流量包账户明细</asp:LinkButton>
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
            <span id="editTitle">分销详细</span><a onclick="closeWindow(false);"></a></div>
        <div class="tipinfo">
            <iframe id="editFrame" src="/AgentManage/DistributionDetailsForUser.aspx" width="560px" height="350px"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
