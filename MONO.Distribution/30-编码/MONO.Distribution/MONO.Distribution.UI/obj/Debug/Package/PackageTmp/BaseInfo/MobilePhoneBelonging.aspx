<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobilePhoneBelonging.aspx.cs"
    Inherits="MONO.Distribution.UI.BaseInfo.MobilePhoneBelonging" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>账户列表</title>
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
            <ul class="toolbar ">
                <li onclick="openWindow('号码归属地','MobilePhoneBelongEdit.aspx','380','220');"><span>
                    <img src="../Images/t01.png" /></span>新增号码归属 
                    </li>
            </ul>
            <ul class="seachform1" style="width: 950px;">
                <li>
                    <label>
                        省份：</label>
                    <div class="vocation">
                        <asp:DropDownList runat="server" CssClass="select1" ID="ddlProvince" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                            AutoPostBack="True" />
                    </div>
                    <label>
                        城市：</label>
                    <div class="vocation">
                        <asp:DropDownList runat="server" CssClass="select2" ID="ddlCity" AutoPostBack="True" />
                    </div>
                    <label style="width: 80px">
                        手机号码头：</label>
                    <asp:TextBox ID="txtPhoneHead" CssClass="scinput1" runat="server"></asp:TextBox>
                    <asp:Button runat="server" ID="btnQuery" CssClass="scbtn" Text="查询" OnClick="btnQuery_Click" />
                </li>
            </ul>
        </div>
        <div class="formtitle">
            <span>号码归属地列表</span>
        </div>
        <asp:GridView ID="gvPhoneBelongList" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="tablelist" OnRowCommand="gvPhoneBelongList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="号码头">
                    <ItemTemplate>
                        <%#Eval("MobileHead")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="省份">
                    <ItemTemplate>
                        <%#Convert.ToString(Eval("MobileAras.ParentKey")).Equals("0") ? Eval("MobileAras.Name") : Eval("MobileAras.ParentArea.Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="市">
                    <ItemTemplate>
                        <%#Eval("MobileAras.Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="ltbnEdit" runat="server" Text="编辑" OnClientClick='<%#Eval("MobileAreaKey","javascript:openWindow(\"号码归属地编辑\",\"MobilePhoneBelongEdit.aspx?Command=Edit&Id={0}\",\"480\",\"280\");return false;") %>'></asp:LinkButton>
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
            <span id="editTitle">号码归属地</span><a onclick="closeWindow(false);"></a></div>
        <div class="tipinfo">
            <iframe id="editFrame" src="/BaseInfo/MobilePhoneBelongEdit.aspx" width="560px" height="350px"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
