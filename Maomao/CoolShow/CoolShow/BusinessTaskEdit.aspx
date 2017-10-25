<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessTaskEdit.aspx.cs"
    Inherits="CoolShow.UI.BusinessTaskEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="form-content container-fluid">
        <div class="row">
            <div class="fields clearfix">
                <div class="field field-text-field col-sm-12" data-api-code="field_1" data-type="TextField"
                    data-label="您的QQ号是" data-validations="[]">
                    <div class="form-group">
                        <div class="field-label-container" onclick="">
                            <label class="field-label font-family-inherit" for="entry_field_1">
                                产品类目
                            </label>
                        </div>
                        <div class="field-content">
                            <asp:DropDownList runat="server" ID="ddlProductCategory">
                                <asp:ListItem Text="女装" Value="Ladies"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="field field-text-field col-sm-12" data-api-code="field_1" data-type="TextField"
                    data-label="您的QQ号是" data-validations="[]">
                    <div class="form-group">
                        <div class="field-label-container" onclick="">
                            <label class="field-label font-family-inherit" for="entry_field_1">
                                做单方式
                            </label>
                        </div>
                        <div class="field-content">
                            <asp:DropDownList runat="server" ID="ddlTaskStyle" OnSelectedIndexChanged="ddlTaskStyleChanged">
                                <asp:ListItem Text="关键词" Value="Keyword"></asp:ListItem>
                                <asp:ListItem Text="二维码" Value="QRCode"></asp:ListItem>
                                <asp:ListItem Text="淘口令" Value="AmoyPassword"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="field field-text-field col-sm-12" data-api-code="field_1" data-type="TextField"
                    data-label="您的QQ号是" data-validations="[]">
                    <div class="form-group">
                        <div class="field-label-container" onclick="">
                            <label class="field-label font-family-inherit" for="entry_field_1">
                               信息
                            </label>
                        </div>
                        <div class="field-content">
                            <asp:DropDownList runat="server" ID="DropDownList1" OnSelectedIndexChanged="ddlTaskStyleChanged">
                                <asp:ListItem Text="关键词" Value="Keyword"></asp:ListItem>
                                <asp:ListItem Text="二维码" Value="QRCode"></asp:ListItem>
                                <asp:ListItem Text="淘口令" Value="AmoyPassword"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="field field-text-field col-sm-12" data-api-code="field_1" data-type="TextField"
                    data-label="您的QQ号是" data-validations="[]">
                    <div class="form-group">
                        <div class="field-label-container" onclick="">
                            <label class="field-label font-family-inherit" for="entry_field_1">
                                主图：
                            </label>
                        </div>
                        <div class="field-content">
                            <asp:TextBox runat="server" ID="TextBox3" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                 <div class="field field-text-field col-sm-12" data-api-code="field_1" data-type="TextField"
                    data-label="您的QQ号是" data-validations="[]">
                    <div class="form-group">
                        <div class="field-label-container" onclick="">
                            <label class="field-label font-family-inherit" for="entry_field_1">
                                拍下款式颜色：
                            </label>
                        </div>
                        <div class="field-content">
                            <asp:TextBox runat="server" ID="TextBox2" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="field field-text-field col-sm-12" data-api-code="field_1" data-type="TextField"
                    data-label="您的QQ号是" data-validations="[]">
                    <div class="form-group">
                        <div class="field-label-container" onclick="">
                            <label class="field-label font-family-inherit" for="entry_field_1">
                                拍摄要求：
                            </label>
                        </div>
                        <div class="field-content">
                            <asp:TextBox runat="server" ID="txtShootingRequir" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="field field-text-field col-sm-12" data-api-code="field_1" data-type="TextField"
                    data-label="您的QQ号是" data-validations="[]">
                    <div class="form-group">
                        <div class="field-label-container" onclick="">
                            <label class="field-label font-family-inherit" for="entry_field_1">
                                寄回地址：
                            </label>
                        </div>
                        <div class="field-content">
                            <asp:TextBox runat="server" ID="TextBox1" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
