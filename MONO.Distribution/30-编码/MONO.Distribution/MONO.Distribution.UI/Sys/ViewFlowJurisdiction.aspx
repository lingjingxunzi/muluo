<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFlowJurisdiction.aspx.cs"
    Inherits="MONO.Distribution.UI.Sys.ViewFlowJurisdiction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Scripts/zTree_v3-master/css/zTreeStyle/zTreeStyle.css" rel="stylesheet"
        type="text/css" />
    <link href="../Scripts/commonpage/Ztree-default-css.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/zTree_v3-master/js/jquery.ztree.all.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _groupId;
        var zTreeGroup;
        var zTreeFunction;
        FlowSetting = {
            view: {
                selectedMulti: false
            },
            async: {
                enable: true,
                url: "../Ashx/Sys/GetFlowJurisdictionInfoByKey.ashx",
                autoParam: ["Key", "name=Name", "level=lv"],
                otherParam: ["sysuserKey", getQueryString("UserKey")],
                dataFilter: filter
            },
            check: {
                enable: false
            },
            data: {
                simpleData: {
                    enable: true,
                    idKey: "key",
                    pIdKey: "parentKey",
                    rootPId: 0
                },
                key: {
                    name: "Name"
                }
            }
        };

        //成功加载后，获取div比例高度
        function zTreeOnAsyncSuccess() {
            $("#divFunction,.div_users,.div_left_group").mCustomScrollbar({
                scrollButtons: {
                    enable: true
                }
            });
        }
        function filter(treeId, parentNode, childNodes) {
            if (!childNodes) return null;
            for (var i = 0, l = childNodes.length; i < l; i++) {
                childNodes[i].Name = childNodes[i].Name.replace(/\.n/g, '.');
            }
            return childNodes;
        }

        $(document).ready(function () {

            zTreeGroup = $.fn.zTree.init($("#FlowTree"), FlowSetting, null);
        });

        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]);
            return null;
        }  
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_left_group">
        <ul id="FlowTree" class="ztree">
        </ul>
    </div>
    </form>
</body>
</html>
