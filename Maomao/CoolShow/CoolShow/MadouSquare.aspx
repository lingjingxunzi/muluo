<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MadouSquare.aspx.cs" Inherits="CoolShow.UI.MadouSquare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/madousquare-list.css" rel="stylesheet" type="text/css" />
    <link href="Styles/madou-square-sigel.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="deanmadoulist">
        <ul>
            <asp:Repeater runat="server" ID="repList">
                <ItemTemplate>
                    <li class="deanactions fadeInUp animated" style="visibility: visible; animation-name: fadeInUp;">
                        <div class="deanmadoupic">
                            <a href="/MadouReview.aspx?id=<%# Eval("MadouBaseInfoKey") %>" target="_blank">
                                <img src="forum.php?mod=image&amp;aid=7748&amp;size=280x350&amp;key=d7b6d354666bd58e"></a></div>
                        <div class="deanmadouinfos">
                            <div class="deanmadoutitle">
                                <div class="deanmadouname">
                                    <a href="/MadouReview.aspx?id=<%# Eval("MadouBaseInfoKey") %>" target="_blank">
                                        <%# Eval("Nick") %></a></div>
                                <div class="deanmadouzhiye">
                                    职业:<span><%# Eval("Occupation") %></span></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="deanmadouinfo">
                                <div class="deanmdl">
                                    <span>
                                        <%# Eval("Hight") %></span>cm/<span><%# Eval("Weight") %></span>kg</div>
                                <div class="deanmdr">
                                    人气：<span>20</span></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="deanmadouinfo">
                                模特佣金:￥<%# Eval("ExpectedSalary") %>
                            </div>
                            <div class="deanmadouinfo">
                                地域:<%# Eval("AreaRegion") %>
                            </div>
                        </div>
                        <a href="/MadouReview.aspx?id=<%# Eval("MadouBaseInfoKey") %>" class="deanbtn"
                            target="_blank">查看详情</a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    </form>
</body>
</html>
