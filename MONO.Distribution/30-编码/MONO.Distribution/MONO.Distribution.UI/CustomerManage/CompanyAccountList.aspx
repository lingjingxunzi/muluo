<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyAccountList.aspx.cs" Inherits="MONO.Distribution.UI.CustomerManage.CompanyAccountList" %>

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
                        <%#Eval("SystemAccount.TotalAccount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="账户剩余积分">
                    <ItemTemplate>
                        <%#Eval("SystemAccount.LeftAccount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="账户保证金">
                    <ItemTemplate>
                        <%#Eval("SystemAccount.Bond")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="账户允许透支额度">
                    <ItemTemplate>
                        <%#Eval("SystemAccount.OverDraft")%>
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
     
    </form>
</body>
</html>
