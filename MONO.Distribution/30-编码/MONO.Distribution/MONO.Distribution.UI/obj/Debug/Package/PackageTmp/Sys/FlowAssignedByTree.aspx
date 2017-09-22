<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowAssignedByTree.aspx.cs"
    Inherits="MONO.Distribution.UI.Sys.FlowAssignedByTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Scripts/zTree_v3-master/css/zTreeStyle/zTreeStyle.css" rel="stylesheet"
        type="text/css" />
    <link href="../Scripts/commonpage/Ztree-default-css.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/zTree_v3-master/js/jquery.ztree.all.min.js" type="text/javascript"></script>
    <script src="../Scripts/zTree_v3-master/js/jquery.ztree.core.js" type="text/javascript"></script>
    <script src="../Scripts/zTree_v3-master/js/jquery.ztree.excheck.js" type="text/javascript"></script>
    <script src="../Scripts/zTree_v3-master/js/jquery.ztree.exedit.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _groupId;
        var zTreeGroup;
        var zTreeFunction;
        FlowSetting = {
            view: {
                selectedMulti: true,
                addDiyDom: addDiyDom
            },
            async: {
                enable: true,
                url: "../Ashx/Sys/GetSystemEnableFlowInfo.ashx",
                autoParam: ["Key", "name=Name", "level=lv"],
                otherParam: ["sysuserKey", getQueryString("UserKey")],
                dataFilter: filter
            },
            check: {
                enable: true,
                chkboxType: { "Y": "p", "N": "s" }
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
            },
            callback: {
                onCheck: onCheck,
                onAsyncSuccess: onAsyncSuccess
            }
        };

        function onCheck(event, treeId, treeNode) {
            cancelHalf(treeNode);
        }
        function onAsyncSuccess(event, treeId, treeNode, msg) {
            cancelHalf(treeNode);
        }


        function cancelHalf(treeNode) {
//            var zTree = $.fn.zTree.getZTreeObj("FlowTree");
//            for (var i = 0; i < treeNode.children.length; i++) {
//                treeNode.children[i].checked = true;
//            }
            //zTree.updateNode(treeNode);
        }


        function addDiyDom(treeId, treeNode) {
            if (treeNode.IsAddEdit == "1") {
                var aObj = $("#" + treeNode.tId + "_a");
                if ($("#diyBtn_" + treeNode.id).length > 0) return;
                var editStr = "<a id='diyBtn_" + treeNode.key + "' onclick='batchEditDiscount("+treeNode.tId+")'  style='margin:0 0 0 5px;'>批量编辑折扣</a>";
                aObj.append(editStr);
                var btn = $("#diyBtn_" + treeNode.tId);
                if (btn) btn.bind("click",  batchEditDiscount(treeNode));
            }
        };


        function batchEditDiscount(id) {
            alert(id);
        }

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
                childNodes[i].checked = childNodes[i].ISChecked;
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
