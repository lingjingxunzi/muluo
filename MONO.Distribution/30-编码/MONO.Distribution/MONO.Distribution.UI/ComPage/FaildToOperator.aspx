<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaildToOperator.aspx.cs"
    Inherits="MONO.Distribution.UI.ComPage.FaildToOperator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/mobile-style.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/commonpage/jquery-1.10.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mNavHgt">
    </div>
    <div class="main">
        <div class="uNs">
            <ul>
                <li>电话号码：<i id="iphone" runat="server"></i></li>
                <li>暂存流量：<i id="iNumbers" runat="server">20个</i></li>
            </ul>
        </div>
        <div class="oTab mt10">
            <asp:GridView runat="server" ID="gvSavedList" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="流量包">
                        <ItemTemplate>
                            <%#Eval("SystemFlowPackets.FlowBaseInfo.FlowName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="过期日期">
                        <ItemTemplate>
                            <%#Eval("CreateTime")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="来源">
                        <ItemTemplate>
                            <%#Eval("SystemUsers.Account")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemStyle CssClass="give"></ItemStyle>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbtnDetailsInfo" OnClientClick='<%#Eval("DistributionRecordKey","javascript:showWin(\"{0}\");return false;") %>'>转送</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="LinkButton1" OnClientClick='<%#Eval("DistributionRecordKey","javascript:isActiveWin(\"{0}\");return false;") %>'>激活</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="mNavHgt">
        </div>
        <div class="msMi">
            <p class="mTi">
                说明</p>
            <p class="mt10 gray6">
                1. 文字详情。<br />
                2. 文字详情。<br />
                3. 文字详情。<br />
            </p>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        function showWin(msg) {

            //当DIV消息框存在时，先移除
            if ($(".uiMask").length !== 0 || $(".uiBox").length !== 0) {
                $(".uiMask").remove();
                $(".uiBox").remove();
            }
            var _div = "";
            _div += "<div class='uiMask'>";
            _div += "</div>";
            _div += "<div class='uiBox' style='width: 240px; margin: -100px 0 0 -120px'>";
            _div += "  <div class='uiCon'>";
            _div += "    <input type='text' id='txtPhone' placeholder='请输入电话号码'/>";
            _div += "    <p align='center'>";
            _div += "      <a  class='butnt btnm' onclick='SendToOther($(\"#txtPhone\").val() ,\"" + msg + "\");'>确定</a> ";
            _div += "      <a  class='butnt btnm2 ml5' onclick='closeWin()'>取消</a>";
            _div += "    </p>";
            _div += "  </div>";
            _div += "</div>";
            $(document.body).append(_div);
        }


        function isActiveWin(msg) {

            //当DIV消息框存在时，先移除
            if ($(".uiMask").length !== 0 || $(".uiBox").length !== 0) {
                $(".uiMask").remove();
                $(".uiBox").remove();
            }
            var _div = "";
            _div += "<div class='uiMask'>";
            _div += "</div>";
            _div += "<div class='uiBox' style='width: 240px; margin: -100px 0 0 -120px'>";
            _div += "  <div class='uiCon'>";
            _div += "    <span>是否再次激活该流量包？</span>";
            _div += "    <p align='center'>";
            _div += "      <a  class='butnt btnm' onclick='activeAgain("+msg+")'>确定</a> ";
            _div += "      <a  class='butnt btnm2 ml5' onclick='closeWin()'>取消</a>";
            _div += "    </p>";
            _div += "  </div>";
            _div += "</div>";
            $(document.body).append(_div);
        }
        function closeWin() {
            $(".uiMask").remove();
            $(".uiBox").remove();
        }

        function SendToOther(phone,id) {

            $.ajax({
                url: '../Ashx/ComPage/SendToOtherHandler.ashx',
                dataType: 'json',
                Type: 'PSOT',
                cache: false,
                data: { Key: id, Phone: phone },
                success: function (data) {
                    $(".uiMask").remove();
                    $(".uiBox").remove();
                    window.reload();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });

        }

        function activeAgain(id) {
            $.ajax({
                url: '../Ashx/ComPage/ActiveAgainHandler.ashx',
                dataType: 'json',
                Type: 'PSOT',
                cache: false,
                data: { Key: id },
                success: function (data) {
                    $(".uiMask").remove();
                    $(".uiBox").remove();
                    window.reload();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        }


    </script>
</body>
</html>
