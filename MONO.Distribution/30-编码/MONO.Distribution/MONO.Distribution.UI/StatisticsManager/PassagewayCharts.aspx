<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassagewayCharts.aspx.cs"
    Inherits="MONO.Distribution.UI.StatisticsManager.PassagewayCharts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://cdn.hcharts.cn/jquery/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="http://cdn.hcharts.cn/highcharts/highcharts.js" type="text/javascript"></script>
    <script src="http://cdn.hcharts.cn/highcharts/modules/exporting.js" type="text/javascript"></script>
    <script src="http://cdn.hcharts.cn/highcharts/themes/dark-unica.js" type="text/javascript"></script>
    <script src="../Scripts/TimePicker/WdatePicker.js" type="text/javascript"></script>
     <script type="text/javascript">

        var oChart = null;
        //定义oChart的布局环境
        //布局环境组成：X轴、Y轴、数据显示、图标标题
        var oOptions = {
            //设置图表关联显示块和图形样式
            chart: {
                renderTo: 'container', //设置显示的页面块
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie'
            },
            credits: {
                enabled: false
            },
            exporting: {
                enabled: false
            },
            title: {
                text: '接口商通道流量包订购排名'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                        style: {
                            color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                        }
                    }
                }
            },
            //数据列
            series: [{ type: 'pie',
                name: 'Browser aaaa',
                data: []
            }]
        };

        $(document).ready(function () {
            oChart = new Highcharts.Chart(oOptions);

            LoadSerie_Ajax();
        });

        function LoadSerie_Ajax() {
            oChart.showLoading();
            $.ajax({
                url: '../Ashx/ChartsData/GetPassagewayDataHandler.ashx',
                type: 'POST',
                dataType: 'json',
                async: false, //同步处理后面才能处理新添加的series
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                data: { name: $("#sl_interface_name").val(), start: $("#txtStartQueryDateTime").val(), end: $("#txtEndQueryDateTime").val() },
                success: function (rntData) {
                    var oSeries = {
                        name: "第二条",
                        data: rntData
                    };
                    oChart.addSeries(oSeries);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
            oChart.hideLoading();
        }
        function interfaceChanges() {
            oChart = new Highcharts.Chart(oOptions);
            LoadSerie_Ajax();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <select id="sl_interface_name"  >
            <option value="CM023New">重庆移动(新接口)</option>
            <option value="CU023">重庆联通</option>
            <option value="JT">居田</option>
            <option value="CMWhole">中兴移动</option>
            <option value="SXD">数讯达</option>
            <option value="YTK">易途客</option>
            <option value="XZ">讯众</option>
        </select>
        <asp:TextBox runat="server" Width="120px" CssClass="scinput1" ID="txtStartQueryDateTime"
            onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',maxDate:'#F{$dp.$D(\'txtEndQueryDateTime\')||\'2020-10-01\'}',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>-<asp:TextBox
                runat="server" Width="120px" CssClass="scinput1" ID="txtEndQueryDateTime" onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',minDate:'#F{$dp.$D(\'txtStartQueryDateTime\')}',maxDate:'2020-10-01',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
        <input type="button" runat="server" id="btn" value="查询" onclick="interfaceChanges();"/>
    </div>
    <div id="container" style="min-width: 400px; height: 400px;">
    </div>
    </form>
</body>
</html>
