<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowCodeCarrierList.aspx.cs"
    Inherits="MONO.Distribution.UI.BaseInfo.FlowCodeCarrierList" %>

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
            $(".select3").uedSelect({
                width: 100
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!--查询区域 结束-->
    <div class="place">
        <span>当前位置：</span>
        <ul class="placeul">
            <li><a href="#">平台管理>>菜单编辑</a></li>
        </ul>
    </div>
    <div class="rightinfo">
        <div class="tools">
            <div class="toolbar">
                <li onclick="openWindow('流量包设置','FlowPacketEdit.aspx','420','380');"><span>
                    <img src="../Images/t01.png" /></span>新增流量包 </li>
            </div>
            <ul class="seachform1" style="width: 1250px;">
                <li>
                    <label style="width: 120px;">
                        流量包运营商：</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlFrom" CssClass="select3" runat="server" AutoPostBack="False">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="CM">移动</asp:ListItem>
                            <asp:ListItem Value="CU">联通</asp:ListItem>
                            <asp:ListItem Value="CT">电信</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <label style="width: 80px;">
                        流量包范围：
                    </label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlRange" CssClass="select2" runat="server" AutoPostBack="False">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="QG">全国</asp:ListItem>
                            <asp:ListItem Value="BD">本地</asp:ListItem>
                            <asp:ListItem Value="BDQG">本地全国</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <label>
                        状态：</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="select1">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="Y">启用</asp:ListItem>
                            <asp:ListItem Value="N">禁用</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <label>
                        标题：</label>
                    <asp:TextBox runat="server" ID="txtTitle" CssClass="dfinput1"></asp:TextBox>
                    &nbsp;
                    <asp:Button runat="server" ID="Button1" CssClass="scbtn" Text="查询" OnClick="btnQuery_Click" />
                </li>
            </ul>
        </div>
        <div class="formtitle">
            <span>流量包列表</span>
        </div>
        <asp:GridView ID="gvFlowPacketList" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="tablelist" OnRowCommand="gvFlowPacketList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="流量包名称">
                    <ItemTemplate>
                        <%#Eval("FlowBaseInfo.Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="折扣">
                    <ItemTemplate>
                        <%#Eval("Discounts.Deduction")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="范围">
                    <ItemTemplate>
                        <%#Eval("Size") +"M"%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="应用范围">
                    <ItemTemplate>
                        <%# Eval("StandardPrice") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="流量包范围">
                    <ItemTemplate>
                        <%#Eval("EnumRange.EnumValue")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%#Convert.ToString(Eval("Status"))=="Y" ?"启用":"<span style='color:Red'>禁用</span>"%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="平台包代码">
                    <ItemTemplate>
                        <%#Eval("PlatformCode")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkBtnEnable" CommandName="Status" CommandArgument='<%#Eval("FlowKey")%> '
                            runat="server" OnClientClick="return (confirm('确定改变此功能状态？'));"><%# Convert.ToString(Eval("Status")) == "0" ? "启用" : "禁用"%>
                        </asp:LinkButton>
                        <asp:LinkButton ID="ltbnEdit" runat="server" Text="编辑" OnClientClick='<%#Eval("FlowKey","javascript:openWindow(\"流量包编辑\",\"FlowPacketEdit.aspx?Command=Edit&id={0}\",\"550\",\"450\");return false;") %>'></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="接口设置" OnClientClick='<%#Eval("FlowKey","javascript:openWindow(\"流量包接口添加\",\"FlowCarrierEdit.aspx?Command=Insert&FlowKey={0}\",\"550\",\"450\");return false;") %>'></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" Text="接口修改" OnClientClick='<%#Eval("FlowKey","javascript:openWindow(\"接口修改\",\"FlowCodeEdit.aspx?Command=Update&FlowKey={0}\",\"550\",\"450\");return false;") %>'></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="接口查看" OnClientClick='<%#Eval("FlowKey","javascript:openWindow(\"接口查看\",\"FlowCodeReviewList.aspx?FlowKey={0}\",\"550\",\"450\");return false;") %>'></asp:LinkButton>
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
            <span id="editTitle">流量设置</span><a onclick="closeWindow(false);"></a></div>
        <div class="tipinfo">
            <iframe id="editFrame" src="/BaseInfo/FlowPacketEdit.aspx" width="560px" height="350px">
            </iframe>
        </div>
    </div>
    </form>
</body>
</html>
