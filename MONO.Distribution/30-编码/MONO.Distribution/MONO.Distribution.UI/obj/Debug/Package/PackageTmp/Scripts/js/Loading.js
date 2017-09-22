function av(id) {
    return document.getElementById(id);
}
function echo(obj, html) {
    av(obj).innerHTML = html;
}
function createxmlhttp() {
    var xmlhttp = false;
    try {
        xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
    }
    catch (e) {
        try {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        catch (e) {
            xmlhttp = false;
        }
    }
    if (!xmlhttp && typeof XMLHttpRequest != 'undefined') {
        xmlhttp = new XMLHttpRequest();
        if (xmlhttp.overrideMimeType) {
            //设置MiME类别 
            xmlhttp.overrideMimeType('text/xml');
        }
    }
    return xmlhttp;
}
//向服务器获取数据
function GetData(url, obj) {
    var xmlhttp = createxmlhttp();
    xmlhttp.onreadystatechange = requestdata;
    xmlhttp.open("GET", url, true);
    xmlhttp.setRequestHeader("If-Modified-Since", "0");
    xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xmlhttp.send(null);
    function requestdata() {
        echo(obj, "<IMG SRC='../images/loading.gif' />&nbsp;<span style=' font-size:12px; color:Black;'>loading.....</span>");
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200) {
                echo(obj, xmlhttp.responseText);

            }
            else {
                echo(obj, "<IMG SRC='../images/loading.gif' />&nbsp;<span style=' font-size:12px; color:Black;'>loading Error.....</span>");
            }
        }
    }
}
function GetData1(url, obj) {
    var xmlhttp = createxmlhttp();
    xmlhttp.onreadystatechange = requestdata;
    xmlhttp.open("GET", url, true);
    xmlhttp.setRequestHeader("If-Modified-Since", "0");
    xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xmlhttp.send(null);
    function requestdata() {
        echo(obj, "<IMG SRC='images/loading.gif' />&nbsp;<span style=' font-size:12px; color:Black;'>loading.....</span>");
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200) {
                echo(obj, xmlhttp.responseText);

            }
            else {
                echo(obj, "<IMG SRC='images/loading.gif' />&nbsp;<span style=' font-size:12px; color:Black;'>loading Error.....</span>");
            }
        }
    }
}