

$(function () {
    GetMenus();
});

function GetMenus() {
    $.ajax({
        url: "Ashx/FunctionMenuHandler.ashx",
        dataType: "html",
        cache: true,
        success: function (data) {
            $("#menus").append(data);
        }
    });
}




 
