<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentUserAccountList.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentManage.AgentUserAccountList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                <asp:TemplateField HeaderText="账户保证金">
                    <ItemTemplate>
                        <%#Convert.ToDecimal(Eval("SystemAccount.Bond")).ToString("N2")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="账户允许透支额度">
                    <ItemTemplate>
                        <%#Convert.ToDecimal(Eval("SystemAccount.OverDraft")).ToString("N2")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作"  >
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnTurnIn" Visible='<%#CheckIsVisable(Eval("SysUserKey")) %>'
                            OnClientClick='<%#Eval("SysUserKey","javascript:openWindow(\"转入\",\"SystemFilling.aspx?Command=Edit&UserKey={0}&Type=in\",\"450\",\"380\");return false;") %>'>转入</asp:LinkButton>
                       <%-- <asp:LinkButton ID="linkBtnDel" runat="server" OnClientClick='<%#Eval("SysUserKey","javascript:openWindow(\"充值\",\"AgentRecharge.aspx?Command=Edit&UserKey={0}&Type=in\",\"850\",\"580\");return false;") %>'>充值</asp:LinkButton>--%>
                        <asp:LinkButton ID="LinkButton1" CommandName="reset" Visible='<%#CheckIsVisable(Eval("SysUserKey")) %>'
                            CommandArgument='<%#Eval("SysUserKey") %>' runat="server" OnClientClick='<%#Eval("SysUserKey","javascript:openWindow(\"转出\",\"AgentUserAccountChangeEdit.aspx?Command=Edit&UserKey={0}&Type=Out\",\"350\",\"320\");return false;") %>'>转出</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" CommandName="reset" Visible='<%#CheckIsAdmin(Eval("SysUserKey")) %>'
                            CommandArgument='<%#Eval("SysUserKey") %>' runat="server" OnClientClick='<%#Eval("SysUserKey","javascript:openWindow(\"编辑保证金\",\"SystemAccountBondEdit.aspx?Command=Edit&UserKey={0}&Type=Out\",\"350\",\"320\");return false;") %>'>编辑保证金</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" CommandName="reset" Visible='<%#CheckIsAdmin(Eval("SysUserKey")) %>'
                            CommandArgument='<%#Eval("SysUserKey") %>' runat="server" OnClientClick='<%#Eval("SysUserKey","javascript:openWindow(\"编辑透支额度\",\"SystemAccountOverDraftEdit.aspx?Command=Edit&UserKey={0}&Type=Out\",\"350\",\"320\");return false;") %>'>编辑授信额度</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" CommandName="reset" CommandArgument='<%#Eval("SysUserKey") %>'
                            runat="server" OnClientClick='<%#Eval("SysUserKey","javascript:openWindow(\"分销详细\",\"DistributionDetailsForUser.aspx?Command=Edit&UserKey={0}\",\"850\",\"480\");return false;") %>'>流量包账户明细</asp:LinkButton>
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
