<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessBaseInfoCommit.aspx.cs"
    Inherits="CoolShow.UI.BusinessBaseInfoCommit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Published.css" rel="stylesheet" type="text/css" />
</head>
<body class="entry-container published_forms-show-page" data-locale="zh-CN">
    <div class="entry-container-inner">
        <%--  <header class="clearfix">
        <div class="center user-info">
          <a class="avatar-link" href="https://jinshuju.net/">
            <span class="user-name">魔宝</span>
          </a>
          <a class="logout-link" href="/logout.json">退出登录</a>
        </div>
      </header>--%>
        <form runat="server" class="center with-shadow indent-on-large-phone" data-form-token="9WmQTC" data-validate-url="/f/9WmQTC/validate_fields"
        id="new_entry"   >
        <input type="hidden" name="utf8" value="✓"><input type="hidden" name="authenticity_token"
            value="GUZ7VsL5zD8Zi8V9wc6s1YMvbAN9jt/cqoYY41vams2cilKEg7DNdDmjhPaWSTMXMVr9cH4NBFV430YUPaKV2g==">
        <div class="banner font-family-inherit">
            <div class="banner-text">
            </div>
        </div>
        <div class="form-header container-fluid">
            <div class="row">
                <h1 class="form-title col-md-12 font-family-inherit">
                    酷秀首次放单商家登记表
                </h1>
                <div class="form-description col-md-12">
                    <p>
                        如果您是第一次来我们酷秀买家秀放单，欢迎您，如果有什么反馈或者建议可以联系微信（一根毛）</p>
                </div>
            </div>
        </div>
        <div class="form-content container-fluid">
            <div class="row">
                <div class="fields clearfix">
                    <div class="field field-text-field col-sm-12" data-api-code="field_1" data-type="TextField"
                        data-label="您的QQ号是" data-validations="[]">
                        <div class="form-group">
                            <div class="field-label-container" onclick="">
                                <label class="field-label font-family-inherit" for="entry_field_1">
                                    您的QQ号是
                                </label>
                            </div>
                            <div class="field-content">
                                <asp:TextBox runat="server" ID="txtQQ"></asp:TextBox>
                               <%-- <input type="text" name="entry[field_1]" id="entry_field_1">--%>
                            </div>
                        </div>
                    </div>
                    <div class="field field-text-field col-sm-12" data-api-code="field_2" data-type="TextField"
                        data-label="您的微信昵称是" data-validations="[]">
                        <div class="form-group">
                            <div class="field-label-container" onclick="">
                                <label class="field-label font-family-inherit" for="entry_field_2">
                                    您的微信昵称是
                                </label>
                            </div>
                            <div class="field-content">
                                <asp:TextBox runat="server" ID="txtWechart"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="field field-text-field col-sm-12" data-api-code="field_3" data-type="TextField"
                        data-label="店铺名称（如有多个，填其中一个）" data-validations="[]">
                        <div class="form-group">
                            <div class="field-label-container" onclick="">
                                <label class="field-label font-family-inherit" for="entry_field_3">
                                    店铺名称（如有多个，填其中一个）
                                </label>
                            </div>
                            <div class="field-content">
                                <asp:TextBox runat="server" ID="txtStoreName"></asp:TextBox>
                                <input type="text" name="entry[field_3]" id="entry_field_3">
                            </div>
                        </div>
                    </div>
                    <div class="field field-text-field col-sm-12" data-api-code="field_4" data-type="TextField"
                        data-label="手机号(每次登录凭证，需要更换手机号时，联系管理员)" data-validations="[]">
                        <div class="form-group">
                            <div class="field-label-container" onclick="">
                                <label class="field-label font-family-inherit" for="entry_field_4">
                                    手机号(每次登录凭证，需要更换手机号时，联系管理员)
                                </label>
                            </div>
                            <div class="field-content">
                                <asp:TextBox runat="server" ID="txtMobilePhone"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="field field-check-box col-sm-12" data-api-code="field_5" data-type="CheckBox"
                        data-label="还需要其他外包服务吗？" data-validations="[]">
                        <div class="form-group">
                            <div class="field-label-container" onclick="">
                                <label class="field-label font-family-inherit" for="entry_field_5">
                                    还需要其他外包服务吗？
                                </label>
                            </div>
                            <div class="field-content">
                                <div class="choices font-family-inherit">
                                    <label onclick="" class="checkbox ">
                                        <div class="check-box-wrapper">
                                            <input type="checkbox" value="0x9F" name="entry[field_5][]" class="field-transformed"><i
                                                class="selected-icon"></i></div>
                                        <div class="choice-description">
                                            基础销量资源
                                        </div>
                                    </label>
                                    <label onclick="" class="checkbox ">
                                        <div class="check-box-wrapper">
                                            <input type="checkbox" value="VWXP" name="entry[field_5][]" class="field-transformed"><i
                                                class="selected-icon"></i></div>
                                        <div class="choice-description">
                                            主图视频或者详情视频
                                        </div>
                                    </label>
                                    <label onclick="" class="checkbox ">
                                        <div class="check-box-wrapper">
                                            <input type="checkbox" value="3q3F" name="entry[field_5][]" class="field-transformed"><i
                                                class="selected-icon"></i></div>
                                        <div class="choice-description">
                                            代运营或者代驾
                                        </div>
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="field submit-field col-md-12 clearfix">
                    <asp:Button ID="txtCommit" runat="server" Text="提交" data-disable-with="提交中..." CssClass="submit gd-btn gd-btn-primary-solid font-family-inherit with-shadow" OnClick="BtnCommitClick"/>
                </div>
            </div>
        </div>
        </form>
    </div>
</body>
</html>
