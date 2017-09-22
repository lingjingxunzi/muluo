<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowInfoList.aspx.cs" Inherits="MONO.Distribution.UI.AgentApplication.FlowInfoList" %>

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
                        名称：</label>
                   <asp:TextBox runat="server" CssClass="dfinput1" ID="txtName"></asp:TextBox>
                </li>
                <li>
                    <asp:Button runat="server" CssClass="scbtn" ID="btnQuery" Text="查询" OnClick="btnQuery_Click" />
                    <asp:Button runat="server" ID="btnLoad" Text="下载" CssClass="scbtn" OnClick="btnLoad_OnClick" />
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
                <asp:TemplateField HeaderText="流量包名称">
                    <ItemTemplate>
                        <%#Eval("FlowBaseInfo.Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="产品编码">
                    <ItemTemplate>
                        <%#Eval("FlowBaseInfo.PlatformCode")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="原价">
                    <ItemTemplate>
                        <%#Convert.ToDecimal(Eval("FlowBaseInfo.StandardPrice")).ToString("N2")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="折扣">
                    <ItemTemplate>
                        <%#Convert.ToDecimal(Eval("Discounts.Deduction")).ToString("N2")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="折扣价">
                    <ItemTemplate>
                        <%# Convert.ToDecimal(Eval("Price")).ToString("N2")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="范围">
                    <ItemTemplate>
                        <%#Eval("FlowBaseInfo.EnumGRange.EnumValue")%>
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
