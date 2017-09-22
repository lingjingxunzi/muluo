<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemBackupList.aspx.cs"
    Inherits="MONO.Distribution.UI.Sys.SystemBackupList" %>

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
                <li onclick="openWindow('新增备份','SystemBackupEdit.aspx?Command=Insert','520','480');">
                    <span>
                        <img src="/Images/t01.png" /></span>新增备份</li>
            </div>
            <ul class="seachform1">
                <li>
                    <label>
                        频率：</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlclycle" runat="server" CssClass="select1" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <label>
                        备份方式：</label>
                    <div class="vocation">
                        <asp:DropDownList runat="server" ID="ddlStyle" CssClass="select2" />
                    </div>
                    <asp:Button runat="server" CssClass="scbtn" ID="btnQuery" Text="查询" OnClick="btnQuery_Click" />
                </li>
            </ul>
        </div>
        <!--数据列表 开始-->
        <div class="formtitle">
            <span>系统备份设置</span>
        </div>
        <asp:GridView ID="gvBackupList" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="tablelist">
            <Columns>
                <asp:TemplateField HeaderText="备份编号">
                    <ItemTemplate>
                        <%#Eval("BackNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备份方式">
                    <ItemTemplate>
                        <%#Eval("EnumStyle.EnumValue")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备份频率">
                    <ItemTemplate>
                        <%#Eval("EnumCycle.EnumValue")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="表名">
                    <ItemTemplate>
                        <%#Eval("TableName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备份地址">
                    <ItemTemplate>
                        <%# Eval("BackupUrl")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="首次备份日期">
                    <ItemTemplate>
                        <%# Eval("BackupTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnDetailsInfo" OnClientClick='<%#Eval("DataBackupKey","javascript:openWindow(\"编辑备份设置\",\"SystemBackupEdit.aspx?Command=Edit&Id={0}\",\"750\",\"480\");return false;") %>'>编辑</asp:LinkButton>
                        <asp:LinkButton ID="linkBtnDel" CommandName="del" CommandArgument='<%#Eval("DataBackupKey") %>'
                            runat="server" OnClientClick="return (confirm('确定停止该备份？'));">停止</asp:LinkButton>
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
            <span id="editTitle">新增备份设置</span><a onclick="closeWindow(false);"></a></div>
        <div class="tipinfo">
            <iframe id="editFrame" src="/Sys/SystemBackupEdit.aspx" width="560px" height="350px"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
