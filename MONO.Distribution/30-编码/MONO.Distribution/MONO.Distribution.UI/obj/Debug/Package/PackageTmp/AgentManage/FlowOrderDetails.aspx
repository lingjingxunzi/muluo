<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowOrderDetails.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentManage.FlowOrderDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/TimePicker/WdatePicker.js" type="text/javascript"></script>
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
                        用户：</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlUsers" runat="server" CssClass="select1">
                        </asp:DropDownList>
                    </div>
                    <label>
                        订购状态：
                    </label>
                    <div class="vocation">
                        <asp:DropDownList runat="server" CssClass="select2" ID="ddlorderStatus" />
                    </div>
                    <label>
                        批次号：</label>
                    <asp:TextBox ID="txtTransNo" CssClass="scinput1" runat="server"></asp:TextBox>
                   
                </li>
            </ul>
            <ul class="seachform1" style="width: 1100px;">
                <li>
                     <label>
                        电话号码：</label>
                    <asp:TextBox ID="txtPhone" CssClass="scinput1" runat="server"></asp:TextBox>
                    
                    <asp:TextBox runat="server" Width="120px" CssClass="scinput1" ID="txtStartQueryDateTime"
                        onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',maxDate:'#F{$dp.$D(\'txtEndQueryDateTime\')||\'2020-10-01\'}',dateFmt:'yyyy-MM-dd'})" Text="选择开始时间" ></asp:TextBox>-<asp:TextBox
                            runat="server" Width="120px" CssClass="scinput1" ID="txtEndQueryDateTime" onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',minDate:'#F{$dp.$D(\'txtStartQueryDateTime\')}',maxDate:'2020-10-01',dateFmt:'yyyy-MM-dd'})" Text="选择结束时间"  ></asp:TextBox>
                    <asp:Button runat="server" CssClass="scbtn" ID="btnQuery" Text="查询" OnClick="btnQuery_Click" />
                    <asp:Button runat="server" ID="btnLoad" Text="下载" CssClass="scbtn" OnClick="btnLoad_OnClick" />
                </li>
            </ul>
        </div>
        <!--数据列表 开始-->
        <div class="formtitle" style="margin-top: 50px;">
            <span>流量日志</span>
        </div>
        <asp:GridView ID="gvDisList" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="tablelist">
            <Columns>
                <asp:TemplateField HeaderText="批次号">
                    <ItemTemplate>
                        <%#Eval("BatchNo")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="电话号码">
                    <ItemTemplate>
                        <%#Eval("MobilePhone")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="分销用户">
                    <ItemTemplate>
                        <%#Eval("SystemUsers.Account")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="流量包">
                    <ItemTemplate>
                        <%#Eval("SystemFlowPackets.FlowBaseInfo.FlowName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="花销">
                    <ItemTemplate>
                        <%# Eval("SystemAccountLog.Integral")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="订购日期">
                    <ItemTemplate>
                        <%#Eval("CreateTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="更新日期">
                    <ItemTemplate>
                        <%#Eval("UpdateTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="订单编号">
                    <ItemTemplate>
                        <%# Eval("DistributionRecordKey")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="订购状态">
                    <ItemTemplate>
                        <%# Eval("EnumStatus.EnumValue")%>
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
