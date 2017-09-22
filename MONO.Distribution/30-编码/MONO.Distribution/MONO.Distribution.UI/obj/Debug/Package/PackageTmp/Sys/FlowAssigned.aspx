<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowAssigned.aspx.cs" Inherits="MONO.Distribution.UI.Sys.FlowAssigned" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        $(function () {
            $(".select1").uedSelect({
                width: 100
            });
            $(".select2").uedSelect({
                width: 100
            });
            $(".select3").uedSelect({
                width: 100
            });
            $(".selectCU").uedSelect({ width: 100 });
            $(".selectCM").uedSelect({ width: 100 });
            $(".selectCT").uedSelect({ width: 100 });
        });
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul class="forminfo" style="margin-left: 50px;">
           <%-- <li>
                <asp:CheckBox runat="server" ID="ckbIsProvice" Checked="True" />
                是否自动分配省内流量： </li>--%>
            <li>
                <label>
                    流量包：</label>
                <li id="li_flowList" style="height: 200px; width: 520px; overflow: auto">
                    <table id="tbFlows" class="tablelist">
                        <tr>
                            <th colspan="5">
                                <input type="checkbox" onclick="ckbSelectAll_click();" id="ckbSelectAll" />
                                全选
                                <asp:Button runat="server" ID="btnAllEdit" Text="批量编辑折扣" OnClientClick=" btnAlleditClick();return false;" />
                                <input type="text" runat="server" style="display: none; width: 150px; height: 28px;"
                                    class="dfinput" id="txtDiscountsAll" />
                                <input type="button" style="display: none" class="scbtn" id="btnDiscountAll" value="确定"
                                    onclick="setDiscountAll();" />
                            </th>
                        </tr>
                        <tr>
                            <th>
                                流量包
                            </th>
                            <th>
                                标准价
                            </th>
                            <th>
                                范围
                            </th>
                            <th>
                                折扣
                            </th>
                            <th>
                                折后价
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="repFlowList">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# "<input type=\"checkbox\" runat=\"server\" id=\"ckbFlow_" + Eval("FlowKey") + "_" + Eval("SystemFlowPacketKey") + "\"   " + ((Convert.ToBoolean(Eval("IsExists"))) ? "checked" : "") + "  />"%>
                                        <%#Eval("FlowName") %>
                                    </td>
                                    <td>
                                        <%#Eval("StandardPrice") %>
                                    </td>
                                    <td>
                                        <%#Eval("RangeName")%>
                                    </td>
                                    <td id='<%#Eval("StandardPrice")+"_"+Eval("FlowKey")  %>'>
                                        <input type="text" id='dis_"+<%#Eval("FlowKey") %>+"' onchange="dischanged(this);" value='<%# (Convert.ToBoolean(Eval("IsExists"))?Eval("DiscountValue"):"100")  %>' />
                                    </td>
                                    <td id='<%# "td_"+Eval("StandardPrice")+"_"+Eval("FlowKey") %>'>
                                        <label id='lblPrice_"+<%#Eval("FlowKey") %>+"'>
                                            <%# (Convert.ToBoolean(Eval("IsExists")) ? Eval("SettingPrice") : Eval("StandardPrice"))%>
                                        </label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <input type="hidden" runat="server" id="flowSomeId" />
                </li>
                <li>
                    <asp:Label runat="server" ID="lblErrorFlowInfo" Visible="False"></asp:Label>
                </li>
                <li>
                    <asp:Button runat="server" ID="btnSave" CssClass="scbtn" Text="保存" OnClientClick="beforeSave();" OnClick="btnSave_OnClick"/>
                </li>
        </ul>
    </div>
    <script type="text/javascript">
        function beforeSaved() {
            if ($("#radSome").attr("checked")) {
                var flowStr = "";
                $("#tbFlows tr td input[type=checkbox]").each(function (i, v) {
                    if ($(v).attr("checked")) {
                        var dis = $(v).parent().parent().find("input[type=text]").val();
                        flowStr += $(v).attr('id') + "_" + dis + "|";
                    }
                });
                $("#flowSomeId").val(flowStr);
            }
            var succStr = "";
            $("#tb_success tr td input[type=hidden]").each(function (i, v) {
                if ($(v).val() == "1") {
                    succStr += $(v).attr('id') + "|";
                }
            });
            $("#SuccStrs").val(succStr);


            var faildStr = "";
            $("#tb_faild tr td input[type=hidden]").each(function (i, v) {
                if ($(v).val() == "1") {
                    faildStr += $(v).attr('id') + "|";
                }
            });
            $("#faildStrs").val(faildStr);

            var temporaryStr = "";
            $("#tb_faild_TurnTo tr td input[type=hidden]").each(function (i, v) {
                if ($(v).val() == "1") {
                    temporaryStr += $(v).attr('id') + "|";
                }
            });
            $("#TemporaryStrs").val(temporaryStr);
        }






        function radSome_Select() {
            if ($("#radSome").attr('checked')) {
                $("#li_flowList").show();
                $("#li_dis_all").hide();
                $("#li_dis_YD").hide();
                $("#li_dis_DX").hide();
            } else {
                $("#li_flowList").hide();
                $("#li_dis_all").show();
                $("#li_dis_YD").show();
                $("#li_dis_DX").show();
            }
        }

        function setDiscountAll() {
            $("#tbFlows tr td input[type=text]").each(function (i, v) {
                $(v).val($("#txtDiscountsAll").val());
                dischanged(v);
            });
        }

        function dischanged(obj) {
            var price = $(obj).parent().attr('id');
            var priceArr = price.split('_');
            $("#td_" + priceArr[0] + "_" + priceArr[1]).text(parseInt((priceArr[0] * $(obj).val()) / 100));
        }


        function ckbSelectAll_click() {
            if ($("#ckbSelectAll").attr("checked")) {
                $("#tbFlows tr td input[type=checkbox]").each(function (i, v) {
                    $(v).attr("checked", "checked");
                });
            } else {
                $("#tbFlows tr td input[type=checkbox]").each(function (i, v) {
                    $(v).removeAttr("checked");
                });
            }
        }

        function beforeSave() {
            var flowStr = "";
            $("#tbFlows tr td input[type=checkbox]").each(function (i, v) {
                if ($(v).attr("checked")) {
                    var dis = $(v).parent().parent().find("input[type=text]").val();
                    flowStr += $(v).attr('id') + "_" + dis + "|";
                }
            });
            $("#flowSomeId").val(flowStr);
        }


        function btnAlleditClick() {
            $("#txtDiscountsAll").toggle();
            $("#btnDiscountAll").toggle();
        }

    </script>
    </form>
</body>
</html>
