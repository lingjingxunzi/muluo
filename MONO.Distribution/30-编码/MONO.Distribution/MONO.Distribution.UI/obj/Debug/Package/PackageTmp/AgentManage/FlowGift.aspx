<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowGift.aspx.cs" Inherits="MONO.Distribution.UI.AgentManage.FlowGift" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>流量赠送</title>
    <style type="text/css">
        .payDisabled
        {
            padding: 12px 70px;
            display: inline-block;
            font-size: 16px;
            background: #AAAAAA;
            border: 0;
            color: #fff;
            cursor: pointer;
            -moz-border-radius: 100px;
            -webkit-border-radius: 100px;
            border-radius: 100px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#div_txtUpload").uploadify({
                'auto': true,
                'height': 30,
                'buttonText': 'TXT导入',
                'swf': '/Scripts/Uploadify/uploadify.swf',
                'uploader': '/Ashx/EnterApply/ImportPhoneFile.ashx?ASPSESSID=' + $('#hfAspSessID').val() + '&AUTHID=' + $('#hfAuth').val() + '&t' + new Date().getTime(),
                'width': 90,
                'fileTypeDesc': '支持的格式：',
                'fileTypeExts': '*.txt',
                'fileSizeLimit': '20MB',
                'multi': false,
                'onUploadSuccess': function (file, data, response) {
                    $("#txtPhone").val(data);
                    CountTotal();
                }
            });
            $("#div_excelUpload").uploadify({
                'auto': true,
                'height': 30,
                'buttonText': 'excel导入',
                'swf': '/Scripts/Uploadify/uploadify.swf',
                'uploader': '/Ashx/EnterApply/ImportPhoneFile.ashx?ASPSESSID=' + $('#hfExcelSessid').val() + '&AUTHID=' + $('#hfExcelAuth').val() + '&t' + new Date().getTime(),
                'width': 90,
                'fileTypeDesc': '*.xls;*xlsx',
                'fileTypeExts': '*.xls;*xlsx',
                'fileSizeLimit': '20MB',
                'multi': false,
                'onUploadSuccess': function (file, data, response) {
                    $("#txtPhone").val(data);
                    CountTotal();
                }
            });
            $(".select1").uedSelect({
                width: 100
            });
            $(".select2").uedSelect({
                width: 180
            });
            $(".select3").uedSelect({
                width: 180
            });
            $(".select4").uedSelect({
                width: 180
            });
        });



        function doUplaod() {
            $('#div_txtUpload').uploadify('upload', '*');
        }

        function closeLoad() {
            $('#div_txtUpload').uploadify('cancel', '*');
        }
        function openItems() {
            $(".uMost").toggle();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField runat="server" ID="hfAuth" />
    <asp:HiddenField runat="server" ID="hfAspSessID" />
    <asp:HiddenField runat="server" ID="hfExcelAuth" />
    <asp:HiddenField runat="server" ID="hfExcelSessid" />
    <div class="place">
        <span>当前位置：</span>
        <ul class="placeul">
            <li><a href="#">平台管理>>菜单编辑</a></li>
        </ul>
    </div>
    <div class="rightinfo">
        <div class="formtitle">
            <span>流量分发</span>
        </div>
    </div>
    <div>
        <ul class="forminfo" style="margin-left: 90px;">
            <li id="div_result" runat="server">
                <label id="dd_err" style="color: red; display: none">
                </label>
                <label id="dd_flowerr" style="color: red; display: none">
                    *流量包未选择！</label>
                <label id="dd_Success" runat="server" style="color: red; display: none">
                    *充值成功
                </label>
                <label id="dd_Falid" runat="server" style="color: red; display: none">
                    *充值失败
                </label>
            </li>
            <li>
                <label style="width: 90px;">
                    分发方式：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" ID="ddlSendType" CssClass="select1">
                        <asp:ListItem Value="1">立即激活</asp:ListItem>
                        <asp:ListItem Value="0">短信发送</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <label style="width: 90px;">
                    充值手机号码：
                </label>
                <asp:TextBox runat="server" CssClass="scinput1" Style="width: 50%; height: 150px"
                    ID="txtPhone" TextMode="MultiLine" Rows="6" onkeyup="CountTotal();"></asp:TextBox>
                <span style="color: red; display: none" id="spPhoneError">*电话号码不能为空！</span>
            </li>
            <li><span style="margin-left: 90px;">*电话号码以';'分号隔开！</span> </li>
            <li style="margin-top: 5px; margin-left: 90px;">
                <div style="display: inline-block">
                    <div id="div_txtUpload">
                    </div>
                </div>
                <div style="display: inline-block; margin-left: 10px;">
                    <div id="div_excelUpload">
                    </div>
                </div>
                &nbsp;&nbsp;
                <asp:Button runat="server" CssClass="scbtn" Height="30px" ID="btnAddressBook" Text="通讯录"
                    OnClientClick="openBook();return false;" />
                &nbsp;&nbsp;&nbsp;<asp:Button runat="server" CssClass="scbtn" Height="30px" ID="btnFilter"
                    Text="号码过滤" OnClientClick="btnDelRepeatePhone();return false;" />
            </li>
            <li>
                <label style="width: 90px;">
                    移动流量包：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" ID="ddlYdFlows" CssClass="select2" />
                </div>
            </li>
            <li>
                <label style="width: 90px;">
                    联通流量包：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" ID="ddlLtFlows" CssClass="select3" />
                </div>
            </li>
            <li>
                <label style="width: 90px;">
                    电信流量包：
                </label>
                <div class="vocation">
                    <asp:DropDownList runat="server" ID="ddlDxFlows" CssClass="select4" />
                </div>
            </li>
            <li>
                <label style="width: 90px;">
                    共计号码：
                </label>
                <asp:TextBox runat="server" ID="iTotalPhone" CssClass="scinput1" Enabled="False"
                    Width="50px" BorderStyle="None" Text="0"></asp:TextBox>个 </li>
            <li style="margin-top: 30px; margin-left: 90px;">
                <asp:Button runat="server" ID="btnDistribution" CssClass="btn" Text="立即分发" OnClientClick="CheckPhoneAndFlows();return false;" />
            </li>
        </ul>
    </div>
    <script type="text/javascript">
        function CountTotal() {
            var phone = $("#txtPhone").val();
            if (phone != "") {
                var arr = phone.substring(0, phone.length - 1).split(';');
                $("#iTotalPhone").val(arr.length);
            } else {
                $("#iTotalPhone").val(0);
            }
        }

        function CheckPhoneAndFlows() {
            var flag = true;
            $("#dd_err").hide();
            $("#dd_flowerr").hide();
            $("#dd_Success").hide();
            $("#dd_Falid").hide();
            if ($("#iTotalPhone").text() == "0") {
                $("#spPhoneError").show();
                flag = false;
            }
            else {
                $("#spPhoneError").hide();
            }
            if ($("#ddlDxFlows").val() == "0" && $("#ddlYdFlows").val() == "0" && $("#ddlLtFlows").val() == "0") {
                {
                    $("#dd_flowerr").show();
                    flag = false;
                }
            } else {
                $("#dd_err").hide();
            }
            if (flag) {
                $("#btnDistribution").attr('disabled', 'true');
                $("#btnDistribution").attr('class', 'payDisabled');
                var LtFlowId = $("#ddlLtFlows").val();
                var YdFlowId = $("#ddlYdFlows").val();
                var DxFlowId = $("#ddlDxFlows").val();
                $.ajax({
                    url: '../Ashx/EnterApply/FlowGiftHandler.ashx',
                    dataType: 'json',
                    Type: 'PSOT',
                    cache: false,
                    data: { LtFlowId: LtFlowId, YdFlowId: YdFlowId, DxFlowId: DxFlowId, txtPhone: $("#txtPhone").val(), sendType: $("#ddlSendType").val() },
                    success: function (data) {
                        $("#btnDistribution").removeAttr('disabled');
                        $("#btnDistribution").attr('class', 'payNow');
                        if (data.Type == '2') {
                            $("#dd_Success").show();
                            $("#dd_Success").text(data.Msg);
                            $("#txtPhone").val("");
                            $("#iTotalPhone").text("0");
                        }
                        if (data.Type == '1') {
                            $("#dd_err").show();
                            $("#dd_err").text(data.Msg);
                        }
                        if (data.Type == '3') {
                            $("#dd_Falid").show();
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(errorThrown);
                        $("#btnDistribution").removeAttr('disabled');
                    }
                });
            }

        }

        function openBook() {
            window.parent.openChildWindow("通讯录", "AddressBookSelect.aspx", "350", "650");
        }

        function BindSelectInfo(str) {
            $("#txtPhone").val(str + $("#txtPhone").val());
        }

        function btnDelRepeatePhone() {
            var txtPhone = $("#txtPhone").val();
            $.ajax({
                url: '../Ashx/EnterApply/FilterUserPhoneHandler.ashx',
                dataType: 'json',
                Type: 'PSOT',
                cache: false,
                data: { txtPhone: txtPhone },
                success: function (data) {
                    $("#txtPhone").val(data);
                    CountTotal();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }
    </script>
    </form>
</body>
</html>
