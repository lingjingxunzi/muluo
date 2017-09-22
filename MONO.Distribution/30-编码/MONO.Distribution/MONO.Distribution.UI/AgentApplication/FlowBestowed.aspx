<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowBestowed.aspx.cs" Inherits="MONO.Distribution.UI.AgentApplication.FlowBestowed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="place">
        <span>当前位置：</span>
        <ul class="placeul">
            <li><a href="#">平台管理>>菜单编辑</a></li>
        </ul>
    </div>
     <div class="formtitle">
            <span>流量赠送</span>
        </div>
    <div class="rightinfo">
        <div class="tools">
            <div class="toolbar">
                <ul>
                    <li><a href="FlowBestowedSingel.aspx"><span>
                        <img src="/Images/t01.png" /></span>单号码赠送</a></li>
                    <li><a href="FlowBrowseBatch.aspx"><span>
                        <img src="/Images/t01.png" /></span>批量赠送</a></li>
                </ul>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
