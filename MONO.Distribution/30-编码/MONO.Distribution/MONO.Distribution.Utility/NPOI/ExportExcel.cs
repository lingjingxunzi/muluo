using System;
using System.Data;
using System.IO;
using System.Web;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace MONO.Distribution.Utility.NPOI
{
    public class ExportExcel
    {
        public static void ExportExcelFile(HttpResponse response, DataTable dt)
        {
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("Sheet1");
            var HeadercellStyle = GetHeadercellStyle(workbook);

            //用column name 作为列名
            var icolIndex = SetHeaderRow(dt, HeadercellStyle, sheet);

            var cellStyle = GetCellStyle(workbook);

            //建立内容行
            GetRowsValue(dt, sheet, cellStyle);

            //自适应列宽度
            SetAutoSize(sheet, icolIndex);
            // 写入到客户端  
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", DateTime.Now.ToString("yyyyMMddHHmmssfff")));
            response.BinaryWrite(ms.ToArray());
            workbook = null;
            ms.Close();
            ms.Dispose();
        }

        public static void ExportExcelFile(HttpResponse response, DataTable dt, string fileName)
        {
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("Sheet1");
            var HeadercellStyle = GetHeadercellStyle(workbook);

            //用column name 作为列名
            var icolIndex = SetHeaderRow(dt, HeadercellStyle, sheet);

            var cellStyle = GetCellStyle(workbook);

            //建立内容行
            GetRowsValue(dt, sheet, cellStyle);

            //自适应列宽度
            SetAutoSize(sheet, icolIndex);
            // 写入到客户端  
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", fileName));
            response.BinaryWrite(ms.ToArray());
            workbook = null;
            ms.Close();
            ms.Dispose();
        }

        private static void SetAutoSize(ISheet sheet, int icolIndex)
        {
            for (int i = 0; i < icolIndex; i++)
            {
                sheet.AutoSizeColumn(i);
            }
        }

        private static void GetRowsValue(DataTable dt, ISheet sheet, ICellStyle cellStyle)
        {
            int iRowIndex = 1;
            int iCellIndex = 0;
            foreach (DataRow Rowitem in dt.Rows)
            {
                IRow DataRow = sheet.CreateRow(iRowIndex);
                foreach (DataColumn Colitem in dt.Columns)
                {
                    ICell cell = DataRow.CreateCell(iCellIndex);
                    cell.SetCellValue(Rowitem[Colitem].ToString());
                    cell.CellStyle = cellStyle;
                    iCellIndex++;
                }
                iCellIndex = 0;
                iRowIndex++;
            }
        }

        private static ICellStyle GetCellStyle(HSSFWorkbook workbook)
        {
            ICellStyle cellStyle = workbook.CreateCellStyle();

            //为避免日期格式被Excel自动替换，所以设定 format 为 『@』 表示一率当成text來看
            cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
            cellStyle.BorderBottom = BorderStyle.THIN;
            cellStyle.BorderLeft = BorderStyle.THIN;
            cellStyle.BorderRight = BorderStyle.THIN;
            cellStyle.BorderTop = BorderStyle.THIN;


            var cellfont = GetCellfont(workbook);
            cellStyle.SetFont(cellfont);
            return cellStyle;
        }

        private static IFont GetCellfont(HSSFWorkbook workbook)
        {
            IFont cellfont = workbook.CreateFont();
            cellfont.Boldweight = (short)FontBoldWeight.NORMAL;
            return cellfont;
        }

        private static int SetHeaderRow(DataTable dt, ICellStyle HeadercellStyle, ISheet sheet)
        {
            int icolIndex = 0;
            IRow headerRow = sheet.CreateRow(0);
            foreach (DataColumn item in dt.Columns)
            {
                ICell cell = headerRow.CreateCell(icolIndex);
                cell.SetCellValue(item.ColumnName);
                cell.CellStyle = HeadercellStyle;
                icolIndex++;
            }
            return icolIndex;
        }

        private static ICellStyle GetHeadercellStyle(HSSFWorkbook workbook)
        {
            var HeadercellStyle = workbook.CreateCellStyle();
            HeadercellStyle.BorderBottom = BorderStyle.THIN;
            HeadercellStyle.BorderLeft = BorderStyle.THIN;
            HeadercellStyle.BorderRight = BorderStyle.THIN;
            HeadercellStyle.BorderTop = BorderStyle.THIN;
            HeadercellStyle.Alignment = HorizontalAlignment.CENTER;
            //字体
            var headerfont = GetHeaderfont(workbook);
            HeadercellStyle.SetFont(headerfont);
            return HeadercellStyle;
        }

        private static IFont GetHeaderfont(HSSFWorkbook workbook)
        {
            IFont headerfont = workbook.CreateFont();
            headerfont.Boldweight = (short)FontBoldWeight.BOLD;
            return headerfont;
        }
    }
}