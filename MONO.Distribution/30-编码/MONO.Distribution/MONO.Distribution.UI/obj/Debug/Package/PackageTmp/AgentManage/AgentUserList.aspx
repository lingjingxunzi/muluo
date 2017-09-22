<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentUserList.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentManage.AgentUserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>账户列表</title>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 100
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
            <div class="toolbar">
                <li onclick="openWindow('新增用户','AgentUserEidt.aspx','820','550');"><span>
                    <img src="/Images/t01.png" /></span>新增用户</li>
            </div>
            <ul class="seachform1">
                <li>
                    <label>
                        状态：</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="select1" AutoPostBack="true">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="0">正常使用</asp:ListItem>
                            <asp:ListItem Value="1">已禁用</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <label>
                        账户名称：</label>
                    <asp:TextBox ID="txtName" CssClass="scinput1" runat="server"></asp:TextBox>
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
                <asp:TemplateField HeaderText="用户组">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <%#Eval("SysUserGroups.Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开户人">
                    <ItemTemplate>
                        <%#Eval("ParentSystemUsers.Nick")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%# Convert.ToString(Eval("Status")) == "0" ? "正常使用" : "<font color='red'>已禁用</font>"%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnDetailsInfo" OnClientClick='<%#Eval("SysUserKey","javascript:openWindow(\"编辑用户信息\",\"/Sys/UserEdit.aspx?Command=Edit&UserKey={0}\",\"420\",\"380\");return false;") %>'>编辑</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="LinkButton2" OnClientClick='<%#Eval("SysUserKey","javascript:openWindow(\"编辑流量包权限\",\"AgentFlowAssigned.aspx?Command=Edit&UserKey={0}\",\"750\",\"480\");return false;") %>'>编辑流量包权限</asp:LinkButton>
                        <asp:LinkButton ID="linkBtnDel" CommandName="del" Visible='<%#CheckIsVisable(Eval("SysUserKey")) %>' CommandArgument='<%#Eval("SysUserKey") %>'
                            runat="server" OnClientClick="return (confirm('确定删除此用户？'));"  >删除</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" CommandName="reset" CommandArgument='<%#Eval("SysUserKey") %>'
                            runat="server" OnClientClick="return (confirm('确定重置密码？'));" >密码重置</asp:LinkButton>
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
