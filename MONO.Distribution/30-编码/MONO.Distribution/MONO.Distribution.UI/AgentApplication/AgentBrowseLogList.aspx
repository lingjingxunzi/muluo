<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentBrowseLogList.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentApplication.AgentBrowseLogList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 120
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
                        日志模块：
                    </label>
                    <div class="vocation">
                        <asp:DropDownList runat="server" CssClass="select1" ID="ddlLogModual" />
                    </div>
                    <label>
                        操作日期：</label>
                    <asp:TextBox runat="server" Width="120px" CssClass="scinput1" ID="txtStartQueryDateTime"
                        onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',maxDate:'#F{$dp.$D(\'txtEndQueryDateTime\')||\'2020-10-01\'}',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>-<asp:TextBox
                            runat="server" Width="120px" CssClass="scinput1" ID="txtEndQueryDateTime" onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',minDate:'#F{$dp.$D(\'txtStartQueryDateTime\')}',maxDate:'2020-10-01',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                    <asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="scbtn" OnClick="btnQuery_Click" />
                </li>
            </ul>
        </div>
    </div>
    <!--查询区域 结束-->
    <asp:GridView ID="gvSystemLogList" runat="server" AutoGenerateColumns="False" Width="100%"
        CssClass="tablelist" OnRowCommand="gvSystemLogList_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="操作账号">
                <ItemTemplate>
                    <%#Eval("User.Account")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作日期">
                <ItemTemplate>
                    <%#Eval("InsertTime")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作内容">
                <ItemTemplate>
                    <%#Eval("Content")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="功能模块">
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                <ItemTemplate>
                    <%#Eval("Module")%>
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
    </form>
</body>
</html>
