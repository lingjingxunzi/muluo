<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentUserEidt.aspx.cs"
    Inherits="MONO.Distribution.UI.AgentManage.AgentUserEidt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#tabs li a").bind("click", function () {
                var index = $(this).attr("id");
                var divs = $("#tabs-body > div");
                $("#tabs li a").removeClass("selected"); //将所有选项置为未选中
                $(this).attr("class", "selected"); //设置当前选中项为选中样式
                divs.hide(); //隐藏所有选中项内容
                $("#tab" + index).show(); //显示选中项对应内容
            });

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
<body style="min-width: 200px;">
    <form id="form1" runat="server">
    <div class="formbody">
        <div id="usual1" class="usual">
            <div class="itab">
                <ul id="tabs">
                    <li><a href="#" class="selected" id="1">账户基本信息</a></li>
                    <li><a href="#" id="2">流量包设置</a></li>
                    <li><a href="#" id="3">短信设置</a></li>
                    <li><a href="#" id="4">订购失败设置</a></li>
                </ul>
            </div>
        </div>
        <div id="tabs-body" style="height: 280px">
            <div id="tab1" class="tabson">
                <ul class="forminfo" style="margin-left: 50px;">
                    <li>
                        <label class="title">
                            *用户账号：
                        </label>
                        <asp:TextBox runat="server" ID="txtAccounts" CssClass="dfinput1" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*账户名不能为空！"
                            CssClass="red" ControlToValidate="txtAccounts"></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <label class="title">
                            *密码：
                        </label>
                        <asp:TextBox runat="server" CssClass="dfinput1" ID="txtScrect" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*密码不能为空！"
                            CssClass="red" ControlToValidate="txtScrect"></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <label class="title">
                            用户组：
                        </label>
                        <div class="vocation">
                            <asp:DropDownList runat="server" CssClass="select1" ID="ddlGroup" />
                        </div>
                    </li>
                    <li>
                        <label>
                            *状态：
                        </label>
                        <div class="vocation">
                            <asp:DropDownList ID="ddlStatus" CssClass="select3" runat="server">
                                <asp:ListItem Value="0">启用</asp:ListItem>
                                <asp:ListItem Value="1">禁用</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </li>
                    <li>
                        <asp:Label runat="server" CssClass="red" ID="lblErrorBase" Visible="False"></asp:Label>
                    </li>
                </ul>
            </div>
            <div id="tab2" class="tabson" style="display: none">
                <ul class="forminfo" style="margin-left: 50px;">
                    <li>
                        <asp:CheckBox runat="server" ID="ckbIsProvice" Checked="True" />
                        是否自动分配省内流量： </li>
                    <li>
                        <label>
                            流量包：</label>
                        <span style="padding-top: 10px;">
                            <input type="radio" style="padding-top: 5px;" name="flows" id="radAll" runat="server"
                                onclick="radSome_Select();" />全部
                            <input type="radio" name="flows" id="radSome" runat="server" onclick="radSome_Select();" />
                            部分 </span></li>
                    <li id="li_flowList" style="display: none; height: 200px; width: 520px; overflow: auto">
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
                                            <%# "<input type=\"checkbox\" runat=\"server\" id=\"ckbFlow_" + Eval("SystemFlowPacketKey") + "\" />"%>
                                            <%#Eval("FlowBaseInfo.FlowName")%>
                                        </td>
                                        <td>
                                            <%#Eval("FlowBaseInfo.StandardPrice")%>
                                        </td>
                                        <td>
                                            <%#Eval("FlowBaseInfo.EnumRange.EnumValue")%>
                                        </td>
                                        <td id='<%#Eval("FlowBaseInfo.StandardPrice")+"_"+Eval("SystemFlowPacketKey")  %>'>
                                            <input type="text" id='dis_"+<%#Eval("SystemFlowPacketKey") %>+"' onchange="dischanged(this);" />
                                        </td>
                                        <td id='<%# "td_"+Eval("FlowBaseInfo.StandardPrice")+"_"+Eval("SystemFlowPacketKey") %>'>
                                            <label id='lblPrice_"+<%#Eval("SystemFlowPacketKey") %>+"'>
                                            </label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <input type="hidden" runat="server" id="flowSomeId" />
                    </li>
                    <li id="li_dis_all" style="display: none">
                        <label>
                            联通：</label>
                        <div class="vocation">
                            <asp:DropDownList runat="server" CssClass="selectCU" ID="ddlCUDis" />
                        </div>
                    </li>
                    <li id="li_dis_YD" style="display: none">
                        <label>
                            移动：</label>
                        <div class="vocation">
                            <asp:DropDownList runat="server" CssClass="selectCM" ID="ddlCMDis" />
                        </div>
                    </li>
                    <li id="li_dis_DX" style="display: none">
                        <label>
                            电信：</label>
                        <div class="vocation">
                            <asp:DropDownList runat="server" CssClass="selectCT" ID="ddlCTDis" />
                        </div>
                    </li>
                    <li>
                        <asp:Label runat="server" ID="lblErrorFlowInfo" Visible="False"></asp:Label>
                    </li>
                </ul>
            </div>
            <div id="tab3" class="tabson" style="display: none">
                <ul class="forminfo" style="margin-left: 50px;">
                    <li>
                        <asp:CheckBox runat="server" ID="ckbIsSend" />订购成功是否发送短信 </li>
                    <li>
                        <label>
                            成功模版：
                        </label>
                        <table id="tb_success">
                            <asp:Repeater runat="server" ID="rep_Success">
                                <ItemTemplate>
                                    <%#(Container.ItemIndex% 3==0)?"<tr>":""%>
                                    <td>
                                        <%# "<div class=\"unutm\"> <em class=\"umems\" ></em><a  onclick=\"contentClick('succ_',this);\"><input type=\"text\" runat=\"server\" id=\"" + Eval("MessageTemplateKey") + "\" class=\"dfinput\" style=\"width:150px;height:80px;\"  disabled=\"true\"  value=\"" + Eval("Content") + "\"></input></a></div>"%>
                                        <%# "<input type=\"hidden\" runat=\"server\" id=\"succ_" + Eval("MessageTemplateKey") + "\"  ></input>"%>
                                    </td>
                                    <%#(Container.ItemIndex% 3==0)?"</tr>":""%>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </li>
                    <li>
                        <asp:Label runat="server" ID="lblMsgSuccess" Visible="False"></asp:Label>
                    </li>
                </ul>
            </div>
            <div id="tab4" class="tabson" style="display: none">
                <ul class="forminfo" style="margin-left: 50px;">
                    <li>
                        <asp:CheckBox runat="server" ID="ckbIsFaildSaved" Checked="True" />
                        流量失败后是否可以转送或者暂存提取 </li>
                    <li>
                        <label>
                            失败模版：
                        </label>
                        <table id="tb_faild_TurnTo">
                            <asp:Repeater runat="server" ID="rep_faild_turn">
                                <ItemTemplate>
                                    <%#(Container.ItemIndex% 3==0)?"<tr>":""%>
                                    <td>
                                        <%# "<div class=\"unutm\"> <em class=\"umems\" ></em><a  onclick=\"contentClick('turn_',this);\"><input type=\"text\" runat=\"server\" id=\"" + Eval("MessageTemplateKey") + "\" class=\"dfinput\" style=\"width:150px;height:80px;\"  disabled=\"true\"  value=\"" + Eval("Content") + "\"></input></a></div>"%>
                                        <%# "<input type=\"hidden\" runat=\"server\" id=\"turn_" + Eval("MessageTemplateKey") + "\" ></input>"%>
                                    </td>
                                    <%#(Container.ItemIndex% 3==0)?"</tr>":""%>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </li>
                    <li>
                        <asp:Label runat="server" ID="lblErrorMsgFaild" Visible="False"></asp:Label>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div>
    </div>
    <div id="div_button" style="margin-top: 20px; margin-left: 180px;">
        <asp:Button runat="server" ID="btnSave" CssClass="scbtn" Text="保存" OnClientClick="beforeSaved();"
            OnClick="btnSave_OnClick" />
        <%--<asp:Button ID="btnUpdate" runat="server" CssClass="scbtn" Text="保存" OnClientClick="return ValidateAll()"
            OnClick="btnUpdate_Click" />--%>
        <input type="hidden" runat="server" id="TemporaryStrs" />
        <input type="hidden" runat="server" id="faildStrs" />
        <input type="hidden" runat="server" id="SuccStrs" />
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


        function showPwd() {
            if ($("#ckbIsShowPwd").attr('checked') == 'checked') {
                $("#txtPwd").attr('type', 'password');
            } else {
                $("#txtPwd").attr('type', 'text');
            }
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

        function btnAlleditClick() {
            $("#txtDiscountsAll").toggle();
            $("#btnDiscountAll").toggle();
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

        function dischanged(obj) {
            var price = $(obj).parent().attr('id');
            var priceArr = price.split('_');
            $("#td_" + priceArr[0] + "_" + priceArr[1]).text(parseInt((priceArr[0] * $(obj).val()) / 100));
        }

        function contentClick(name, obj) {
            var classname = $(obj).parent().attr("class");
            if (classname == "utm") {
                $(obj).parent().attr("class", "unutm");
                $(obj).parent().find("em").attr("class", "unems");
                var key = $(obj).find("input").attr("id");
                $("#" + name + key).val("0");
            } else {
                $(obj).parent().attr("class", "utm");
                $(obj).parent().find("em").attr("class", "ems");
                var keyvalue = $(obj).find("input").attr("id");
                $("#" + name + keyvalue).val("1");
            }
        }
    </script>
    </form>
</body>
</html>
