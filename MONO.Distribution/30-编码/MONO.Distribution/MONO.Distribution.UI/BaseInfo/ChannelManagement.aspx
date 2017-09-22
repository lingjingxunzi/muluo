<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelManagement.aspx.cs"
    Inherits="MONO.Distribution.UI.BaseInfo.ChannelManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Scripts/zTree_v3-master/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/zTree_v3-master/css/zTreeStyle/zTreeStyle.css" rel="stylesheet"
        type="text/css" />
    <script src="../Scripts/zTree_v3-master/js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../Scripts/zTree_v3-master/js/jquery.ztree.core.js" type="text/javascript"></script>
    <script type="text/javascript">
        var setting = {
            view: {
                selectedMulti: true
            },
            async: {
                enable: true,
                url: "../Ashx/ZtreeAsync/ChannelListHandler.ashx",
                autoParam: ["id"],
                otherParam: [],
                dataFilter: filter
            },
            data: {
                simpleData: {
                    enable: true,
                    idKey: "uid",
                    pIdKey: "pid",
                    rootPId: 0
                },
                key: {
                    name: "Name"
                }
            },
            callback: {
                onAsyncError: onAsyncError,
                onAsyncSuccess: onAsyncSuccess
            }
        };

        function filter(treeId, parentNode, childNodes) {
            if (!childNodes) return null;
            for (var i = 0, l = childNodes.length; i < l; i++) {
                childNodes[i].name = childNodes[i].name.replace(/\.n/g, '.');
            }
            return childNodes;
        }

        function onAsyncSuccess(event, treeId, treeNode, msg) {

        }

        function onAsyncError(event, treeId, treeNode, XMLHttpRequest, textStatus, errorThrown) {
            
        }

        $(document).ready(function () {
            $.fn.zTree.init($("#treeDemo"), setting);
        });


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="zTreeDemoBackground left">
        <ul id="treeDemo" class="ztree">
        </ul>
    </div>
    </form>
</body>
</html>
