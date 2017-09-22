$(function () {
    if (document.getElementById("form1") == null) return;
    var src = document.getElementById("form1").action;
    $(".placeul").html("");
    $.ajax({
        url: "../Ashx/Menu/GetMenuInfoHandler.ashx",
        dataType: 'json',
        Type: 'PSOT',
        cache: false,
        data: { src: src },
        success: function (data) {
            var str = "<li><a href='" + data.HomePath + "'>首页</a></li>";
            if (data != "") {
                if (data.ParentName != "") {
                    str += "<li>" + "<a href='" + data.ParentPath + "'>" + data.ParentName + "</a></li>";
                }
                if (data.CurrentName != "") {
                    str += "<li>" + "<a href='" + data.CurrentPath + "'>" + data.CurrentName + "</a></li>";
                }
            }
            $(".placeul").html(str);

            $('.tablelist tbody tr:even').addClass('odd');
            $('.imgtable tbody tr:even').addClass('odd');

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
});
