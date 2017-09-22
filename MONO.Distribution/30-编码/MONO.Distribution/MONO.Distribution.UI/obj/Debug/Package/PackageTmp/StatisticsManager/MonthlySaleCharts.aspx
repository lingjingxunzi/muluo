<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonthlySaleCharts.aspx.cs" Inherits="MONO.Distribution.UI.StatisticsManager.MonthlySaleCharts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>月统计柱状图</title>
  <script src="http://cdn.hcharts.cn/jquery/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="http://cdn.hcharts.cn/highcharts/highcharts.js" type="text/javascript"></script>
 
   <script src="../Scripts/TimePicker/WdatePicker.js" type="text/javascript"></script>
   
    
     <script type="text/javascript">
         var chart;
         var oOptions = {
             chart: {
                 type: 'column'
             },
             title: {
                 text: '月统计柱状图'
             },
             subtitle: {
                 text: '响应式切换位置和样式'
             },
             legend: {
                 align: 'right',
                 verticalAlign: 'middle',
                 layout: 'vertical'
             },
             xAxis: {
                 categories: [],
                 labels: {
                     x: -10
                 }
             },
             yAxis: {
                 allowDecimals: false,
                 title: {
                     text: '金额'
                 }
             },
             series: [],
             responsive: {
                 rules: [{
                     condition: {
                         maxWidth: 500
                     },
                     chartOptions: {
                         legend: {
                             align: 'center',
                             verticalAlign: 'bottom',
                             layout: 'horizontal'
                         },
                         yAxis: {
                             labels: {
                                 align: 'left',
                                 x: 0,
                                 y: -5
                             },
                             title: {
                                 text: null
                             }
                         },
                         subtitle: {
                             text: null
                         },
                         credits: {
                             enabled: false
                         }
                     }
                 }]
             }
         }
         $(function () {
             pageStart();
         });
         function pageStart() {
             chart = Highcharts.chart('container', {
                 chart: {
                     type: 'column'
                 },
                 title: {
                     text: '月统计柱状图'
                 },
                 subtitle: {
                     text: '响应式切换位置和样式'
                 },
                 legend: {
                     align: 'right',
                     verticalAlign: 'middle',
                     layout: 'vertical'
                 },
                 xAxis: {
                     categories: ['20170701', '20170702', '20170703', '20170704', '20170705', '20170706'],
                     labels: {
                         x: -10
                     }
                 },
                 yAxis: {
                     allowDecimals: false,
                     title: {
                         text: '金额'
                     }
                 },
                 series: [],
                 responsive: {
                     rules: [{
                         condition: {
                             maxWidth: 500
                         },
                         chartOptions: {
                             legend: {
                                 align: 'center',
                                 verticalAlign: 'bottom',
                                 layout: 'horizontal'
                             },
                             yAxis: {
                                 labels: {
                                     align: 'left',
                                     x: 0,
                                     y: -5
                                 },
                                 title: {
                                     text: null
                                 }
                             },
                             subtitle: {
                                 text: null
                             },
                             credits: {
                                 enabled: false
                             }
                         }
                     }]
                 }
             });
             $('#small').click(function () {
                 chart.setSize(400, 300);
             });
             $('#large').click(function () {
                 chart.setSize(800, 300);
             });
             LoadDate_Ajax(chart);
             LoadSerie_Ajax(chart);
         }


         function LoadSerie_Ajax(chart) {
             alert($("#sl_interface_name").val());
             chart.showLoading();
             $.ajax({
                 url: '../Ashx/ChartsData/MonthlySaleHandler.ashx',
                 type: 'POST',
                 dataType: 'json',
                 async: false, //同步处理后面才能处理新添加的series
                 contentType: "application/x-www-form-urlencoded; charset=utf-8",
                 data: { name: $("#sl_interface_name").val(), dates: $("#txtStartQueryDateTime").val()  },
                 success: function (rntData) {
                     var i = 0;
                     for (i = 0; i < rntData.length; i++) {
                         var oSeries = {
                             name: rntData[i].Nick,
                             data: rntData[i].OrderPrice
                         };
                         alert(rntData[i].OrderPrice);
                         alert(rntData[i].Nick);
                         chart.addSeries(oSeries);
                     }
                    
                 },
                 error: function (XMLHttpRequest, textStatus, errorThrown) {
                     alert(errorThrown);
                 }
             });
             chart.hideLoading();
         }
         function interfaceChanges() {
             pageStart();
         }

         function LoadDate_Ajax(chart) {
             $.ajax({
                 url: '../Ashx/ChartsData/GetDateDIsplay.ashx',
                 type: 'POST',
                 dataType: 'json',
                 async: false, //同步处理后面才能处理新添加的series
                 contentType: "application/x-www-form-urlencoded; charset=utf-8",
                 data: { dates: $("#txtStartQueryDateTime").val()+"-01" },
                 success: function (rntData) {
                     chart.xAxis[0].setCategories(rntData, true);
                 },
                 error: function (XMLHttpRequest, textStatus, errorThrown) {
                     alert(errorThrown);
                 }
             });
         }


     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <select id="sl_interface_name"  >
              <option value="电信.全国">电信全国包</option>
            <option value="电信.重庆漫游">重庆电信漫游包</option>
            <option value="电信.重庆本地">重庆电信本地包</option>
            <option value="联通.重庆漫游">重庆联通本地包</option>
        </select>
        <asp:TextBox runat="server" Width="120px" CssClass="scinput1" ID="txtStartQueryDateTime"
            onFocus="JavaScript:this.value='';WdatePicker({skin:'whyGreen',maxDate:'#F{\'2020-10-01\'}',dateFmt:'yyyy-MM'})"></asp:TextBox>
        <input type="button" runat="server" id="btn" value="查询" onclick="interfaceChanges();"/>
    </div>
    <div id="container" style="min-width: 400px; height: 400px;">
    </div>
    </form>
</body>
</html>