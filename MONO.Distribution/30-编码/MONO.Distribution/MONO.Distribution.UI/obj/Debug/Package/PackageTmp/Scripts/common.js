function closeWindow(isfresh) {
    $(".tip").fadeOut(100);
    if (isfresh) {
        var win = parent.document.getElementById("rightFrame").contentWindow;
        if (win == null) return;
        win.location.reload(true);
    }
}

$('.tablelist tbody tr:even').addClass('odd');
$('.imgtable tbody tr:even').addClass('odd');


function openWindow(title, url, width, height) {
    $("#editTitle").text(title);
    $("#editFrame").attr("src", url);
    $("#editFrame").attr("width", width);
    $("#editFrame").attr("height", height);
    $(".tip").attr("width", width + 50);
    $(".tip").attr("height", height + 80);
    $(".tip").fadeIn(200);
}
$(".click").click(function () {
    $(".tip").fadeIn(200);
});

$(".tiptop a").click(function () {
    $(".tip").fadeOut(200);
});

$(".sure").click(function () {
    $(".tip").fadeOut(100);
});

$(".cancel").click(function () {
    $(".tip").fadeOut(100);
});


