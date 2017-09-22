<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessDiscountList.aspx.cs" Inherits="MONO.Distribution.UI.Sys.BusinessDiscountList" %>

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
                <li onclick="openWindow('新增权限','BusinessDiscountEdit.aspx?Command=Insert','820','550');">
                    <span>
                        <img src="/Images/t01.png" /></span>新增权限包</li>
            </div>
            <ul class="seachform1">
                <li>
                    <label>
                        账户：</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlSysuserKey" runat="server" CssClass="select1" AutoPostBack="true">
                           
                        </asp:DropDownList>
                    </div>
                    <label>
                        包名称：</label>
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
                        <%#Eval("SystemUsers.Account")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="昵称">
                    <ItemTemplate>
                        <%#Eval("SystemUsers.Nick")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="包名">
                    <ItemTemplate>
                        <%#Eval("FlowBaseInfo.Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="折扣">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <%#Eval("Discounts.Deduction")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="原价">
                    <ItemTemplate>
                        <%#Eval("FlowBaseInfo.StandardPrice")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="折后价">
                    <ItemTemplate>
                        <%#Eval("Price")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="LinkButton4" OnClientClick='<%#Eval("SystemFlowPacketKey","javascript:openWindow(\"修改折扣\",\"BusinessDiscountEdit.aspx?Command=Edit&Key={0}\",\"550\",\"280\");return false;") %>'>修改折扣</asp:LinkButton>
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
            <span id="editTitle">修改折扣</span><a onclick="closeWindow(false);"></a></div>
        <div class="tipinfo">
            <iframe id="editFrame" src="/Sys/BusinessDiscountEdit.aspx" width="560px" height="350px"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
