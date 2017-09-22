<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterfaceIsUnobstructed.aspx.cs"
    Inherits="MONO.Distribution.UI.InterfaceRequest.InterfaceIsUnobstructed" %>

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
    <div class="formbody">
        <div id="usual1" class="usual">
            <div class="itab">
                <ul id="tabs">
                    <li><a href="#" class="selected" id="1">通道测试</a></li>
                </ul>
            </div>
        </div>
        <div id="tabs-body" style="height: 280px">
            <div id="tab1" class="tabson">
                <ul class="forminfo" style="margin-left: 50px;">
                    <li>
                        <label>
                            重庆移动（新接口）：
                        </label>
                        <asp:TextBox ID="txtNick" runat="server" CssClass="dfinput" Text="http://cqdata.4ggogo.com/web-in/auth.html"></asp:TextBox>
                        <asp:Button runat="server" ID="btnTestCM023New" OnClick="btnTestCM023New_OnClick" Text="测试"/>
                        <asp:TextBox runat="server" ID="txtCM023TestResult"  CssClass="dfinput" ></asp:TextBox>
                    </li>
                     
                </ul>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
