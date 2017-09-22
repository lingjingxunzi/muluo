<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="MONO.Distribution.UI.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                url: "Ashx/Login/FunctionMenuHandler.ashx",
                dataType: "html",
                cache: true,
                success: function (data) {
                    $("#menus").html("");
                    $("#menus").append(data);
                    //导航切换
                    $(".menuson li").click(function () {
                        $(".menuson li.active").removeClass("active");
                        $(this).addClass("active");
                    });

                    $('.title').click(function () {
                        var $ul = $(this).next('ul');
                        $('dd').find('ul').slideUp();
                        if ($ul.is(':visible')) {
                            $(this).next('ul').slideUp();
                        } else {
                            $(this).next('ul').slideDown();
                        }
                    });
                }
            });

        })	
    </script>
</head>
<body style="background: #f0f9fd;">
    <form id="form1" runat="server">
    <div class="lefttop">
        <span></span>分销系统</div>
    <dl id="menus" class="leftmenu">
    </dl>
    </form>
</body>
</html>
