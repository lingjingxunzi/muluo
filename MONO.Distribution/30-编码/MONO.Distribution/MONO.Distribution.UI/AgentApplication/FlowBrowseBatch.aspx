<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowBrowseBatch.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentApplication.FlowBrowseBatch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Scripts/Uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Uploadify/jquery.uploadify.min.js" type="text/javascript"></script>
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
                width: 280
            });
            $(".select3").uedSelect({
                width: 280
            });
            $(".select4").uedSelect({
                width: 280
            });
        });
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
        <div class="tools">
            <div class="toolbar">
                <ul>
                    <li><a href="FlowBestowed.aspx"><span>
                        <img src="/Images/t01.png" /></span>返回</a></li>
                </ul>
            </div>
        </div>
        <div class="formtitle">
            <span>流量赠送</span>
        </div>
        <ul class="forminfo" style="margin-left: 90px;">
            <li id="div_result" runat="server">
                <label id="lblError" style="width: 300px; color: red; display: none">
                </label>
                <asp:Label runat="server" Width="200px" CssClass="red" ID="lblAccountLess" Visible="False"></asp:Label>
            </li>
            <li>
                <label>
                    当前积分：
                </label>
                <label id="lblInter" runat="server">
                    0
                </label>
            </li>
            <li>
                <label style="width: 90px;">
                    充值手机号码：
                </label>
                <asp:TextBox runat="server" CssClass="scinput1" Style="width: 50%; height: 150px"
                    ID="txtPhone" TextMode="MultiLine" Rows="6" onkeyup="CountTotal();"></asp:TextBox>
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
                <asp:Button runat="server" ID="btnDistribution" CssClass="btn" Text="立即赠送" OnClientClick="return CheckPhoneAndFlows();"
                    OnClick="btnDistribution_OnClick" />
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
            $("#lblError").hide();
            $("#dd_err").hide();
            $("#dd_flowerr").hide();
            $("#dd_Success").hide();
            $("#dd_Falid").hide();
            if ($("#iTotalPhone").val() == "0") {
                $("#lblError").text("*电话号码不能为空!");
                $("#lblError").show();
                return false;
            }

            if ($("#ddlDxFlows").val() == "0" && $("#ddlYdFlows").val() == "0" && $("#ddlLtFlows").val() == "0") {
                {
                    $("#lblError").text("*流量包未选择！");
                    $("#lblError").show();
                    return false;
                }
            }
            return true;
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
                url: '../Ashx/Agent/FilterUserPhoneHandler.ashx',
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
