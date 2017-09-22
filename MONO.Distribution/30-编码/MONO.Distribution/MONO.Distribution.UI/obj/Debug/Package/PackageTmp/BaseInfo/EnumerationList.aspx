<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnumerationList.aspx.cs"
    Inherits="MONO.Distribution.UI.BaseInfo.EnumerationList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>类型代码列表</title>
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
    <form id="form1" runat="server" defaultbutton="btnQuery">
    <div class="place">
        <span>当前位置：</span>
        <ul class="placeul">
            <li><a href="#">平台管理>>菜单编辑</a></li>
        </ul>
    </div>
    <div class="rightinfo">
        <div class="tools">
            <ul class="toolbar">
                <li onclick="openWindow('数据字典','EnumerationEdit.aspx','450','380')"><span>
                    <img src="../Images/t01.png" /></span>新增 </li>
            </ul>
            <ul class="seachform1">
                <li>
                    <label>
                        状态：</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlStatus" CssClass="select1" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Width="100">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="0">启用</asp:ListItem>
                            <asp:ListItem Value="1">禁用</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <label style="width: 100px;">
                        数据字典值：</label><asp:TextBox ID="txtEnumValue" CssClass="scinput1" runat="server" Width="100"></asp:TextBox>
                    <asp:Button runat="server" ID="btnQuery" CssClass="scbtn" Text="查询" OnClick="btnQuery_Click" />
                </li>
            </ul>
        </div>
        <div class="formtitle">
            <span>类型代码列表</span>
        </div>
        <asp:GridView ID="gvEnumerationList" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="tablelist" OnRowCommand="gvEnumerationList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="编号">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="数据字典编号">
                    <ItemTemplate>
                        <%#Eval("EnumKey")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="数据字典值">
                    <ItemTemplate>
                        <%#Eval("EnumValue")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="数据字典类型">
                    <ItemTemplate>
                        <%# Eval("ParentName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="启用标志">
                    <ItemTemplate>
                        <%# Convert.ToString(Eval("Status")) =="0"?"启用":"<font color='red'>禁用</font>"%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="ltbnEdit" runat="server" Text="编辑" OnClientClick='<%#Eval("EnumKey","javascript:openWindow(\"数据字典\",\"EnumerationEdit.aspx?Command=Edit&Key={0}\",\"450\",\"380\");return false;") %>'></asp:LinkButton>
                        <asp:LinkButton ID="linkBtnEnable" CommandName="enable" CommandArgument='<%#Eval("EnumKey") + "," +Eval( "Status")%> '
                            runat="server" OnClientClick="return (confirm('确定改变此功能状态？'));"><%# Convert.ToString(Eval("Status")) == "1" ? "启用" : "禁用"%></asp:LinkButton>
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
        <!--分页 结束-->
    </div>
    <div class="tip">
        <div class="tiptop">
            <span id="editTitle">数据字典</span><a onclick="closeWindow(false);"></a></div>
        <div class="tipinfo">
            <iframe id="editFrame" src="/BaseInfo/EnumerationEdit.aspx" width="560px" height="350px">
            </iframe>
        </div>
    </div>
    </form>
</body>
</html>
