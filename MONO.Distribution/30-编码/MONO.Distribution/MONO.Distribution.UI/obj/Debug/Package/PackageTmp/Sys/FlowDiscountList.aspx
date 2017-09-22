<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowDiscountList.aspx.cs"
    Inherits="MONO.Distribution.UI.Sys.FlowDiscountList" %>

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
        <div runat="server" id="gv_div">
            
        </div>
       
        <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
        <!--数据列表 结束-->
    </div>
    <div class="tip">
        <div class="tiptop">
            <span id="editTitle">新增备份设置</span><a onclick="closeWindow(false);"></a></div>
        <div class="tipinfo">
            <iframe id="editFrame" src="/Sys/SystemBackupEdit.aspx" width="560px" height="350px">
            </iframe>
        </div>
    </div>
    </form>
</body>
</html>
