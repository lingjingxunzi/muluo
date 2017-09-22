<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyAccountApplyList.aspx.cs"
    Inherits="MONO.Distribution.UI.CustomerManage.CompanyAccountApplyList" %>

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
        <div class="tools" style="width: 1320px;">
            <div class="toolbar">
                <li onclick="openWindow('新增申请','CompanyAccountApplyEdit.aspx?Command=Insert','820','550');">
                    <span>
                        <img src="/Images/t01.png" /></span>新增申请</li>
            </div>
            <ul class="seachform1" style="width: 1100px;">
                <li>
                    <label>
                        商户：</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="select1">
                        </asp:DropDownList>
                    </div>
                    <label>
                        申请状态：
                    </label>
                    <div class="vocation">
                        <asp:DropDownList runat="server" CssClass="select2" ID="ddlorderStatus" />
                    </div>
                </li>
                <li>
                    <asp:Button runat="server" CssClass="scbtn" ID="btnQuery" Text="查询" OnClick="btnQuery_Click" />
                </li>
            </ul>
        </div>
        <!--数据列表 开始-->
        <div class="formtitle">
            <span>流量日志</span>
        </div>
        <asp:GridView ID="gvDisList" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="tablelist">
            <Columns>
                <asp:TemplateField HeaderText="申请日期">
                    <ItemTemplate>
                        <%#Eval("CreateTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申请账号">
                    <ItemTemplate>
                        <%#Eval("BeApplyUser.Account")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申请人">
                    <ItemTemplate>
                        <%#Eval("ApplyUser.Nick")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="说明">
                    <ItemTemplate>
                        <%#Eval("Remark")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="审核状态">
                    <ItemTemplate>
                        <%#Eval("EnumStatus.EnumValue")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnSendStatusAgain" CommandName="sendAgain" CommandArgument='<%#Eval("AccountAddApplyKey") %>'>撤销</asp:LinkButton>
                        
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
            <iframe id="editFrame" src="/CustomerManage/CompanyAccountApplyEdit.aspx" width="560px"
                height="350px"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
