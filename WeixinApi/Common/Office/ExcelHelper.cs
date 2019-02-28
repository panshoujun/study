using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Web;

using org.in2bits.MyXls;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Reflection;

namespace Common
{
    public class ExcelHelper
    {
        private static readonly string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/");

        /// <summary>
        /// Excel转换DataTable
        /// </summary>
        /// <param name="strExcelFileName">Excel文件路径</param>
        /// <param name="strSheetName">表格名字</param>
        /// <returns></returns>
        public static System.Data.DataTable ExcelToDataTable(string strExcelFileName, string strSheetName)
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strExcelFileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";
            string strExcel = string.Format("select * from [{0}$]", strSheetName);
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
                adapter.Fill(ds, strSheetName);
                conn.Close();
            }
            return ds.Tables[strSheetName];
        }

        /// <summary>
        /// DataTable导出数据到Excel
        /// </summary>
        public static void DataTableToExcel(System.Data.DataTable dt, string[] sHeader)
        {
            XlsDocument xls = new XlsDocument();
            xls.FileName = "List" + DateTime.Now.ToString("yyyyMMddhhmmss");

            org.in2bits.MyXls.Worksheet sheet = xls.Workbook.Worksheets.Add("Sheet1");//状态栏标题名称

            //设置文档列属性 
            ColumnInfo cinfo = new ColumnInfo(xls, sheet);//设置xls文档的指定工作页的列属性

            cinfo.Collapsed = true;
            cinfo.ColumnIndexStart = 0;//列开始
            cinfo.ColumnIndexEnd = 6;//列结束
            cinfo.Collapsed = true;
            cinfo.Width = 15 * 256;//列宽度

            sheet.AddColumnInfo(cinfo);

            //设置文档列属性结束

            Cells cells = sheet.Cells;//Cells实例是sheet页中单元格（cell）集合

            //单元格1-base
            Cell[] cellHeader = new Cell[sHeader.Length];
            #region 对Excel进行赋值
            for (int j = 0; j < dt.Rows.Count; j++)//行数
            {
                for (int i = 0; i < sHeader.Length; i++)//列数
                {
                    cellHeader[i] = cells.Add(1, i + 1, sHeader[i]);
                    cellHeader[i].Font.Height = 20 * 10;
                    cellHeader[i].BottomLineColor = Colors.Black;
                    cellHeader[i].BottomLineStyle = 2;
                    cellHeader[i].Pattern = 1;
                    cellHeader[i].PatternBackgroundColor = Colors.Black;
                    cellHeader[i].PatternColor = Colors.White;// "#ECE9D8";
                    if (j + 2 < 65536)   //excel2003的最大行
                    {
                        cellHeader[i] = cells.Add(j + 2, i + 1, dt.Rows[j][i].ToString());
                    }

                }
            }
            #endregion
            xls.Send();
        }

        /// <summary>
        /// Excel转化DataTable
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataTable GetDataByReadExcel(string path)
        {
            FileStream stream = null;
            ISheet sheet;

            path = string.Format("{0}{1}", filePath, path);
            try
            {
                stream = File.OpenRead(path);
                HSSFWorkbook wk = new HSSFWorkbook(stream);
                sheet = wk.GetSheet("库存");
            }
            catch (System.Exception)
            {
                stream = File.OpenRead(path);
                XSSFWorkbook wk = new XSSFWorkbook(stream);
                sheet = wk.GetSheet("库存");
            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }

            DataTable table = new DataTable();
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            int rowCount = sheet.LastRowNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                if (row != null)
                {
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = row.GetCell(j);
                        //using (StreamWriter sw = System.IO.File.AppendText("D:/Test_Log/CreateIndex.txt"))
                        //{
                        //    sw.WriteLine("------------------" + row.GetCell(j) + "访问记录：" + row.GetCell(j) + "     执行了一次任务" + "------------------");
                        //    sw.Flush();
                        //}
                    }
                    if (row.GetCell(0) != null)
                        table.Rows.Add(dataRow);
                }

                // utf-8 HttpUtility.UrlEncode(row.GetCell(j).ToString(), Encoding.GetEncoding("utf-8"));
                // Encoding.Default.GetBytes()

            }

            return table;
        }

 

        /// <summary>
        /// 使用NPOI将数据转为Excel格式
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="dataSource">数据源</param>
        /// <param name="response">响应体</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="column">导出所需列</param>
        public static void ExportExcel<T>(IList<T> dataSource, HttpResponseBase response, string fileName
            , List<KeyValuePair<string, string>> column) where T : class
        {
            var type = typeof(T);
            if (column == null) column = new List<KeyValuePair<string, string>>(0);

            var dst = new Dictionary<string, PropertyInfo>();
            //遍历每一个属性
            foreach (PropertyInfo prop in type.GetProperties())
            { 
                dst.Add(prop.Name, prop);
            }

            var hssfworkbook = new XSSFWorkbook();
            var sheet = hssfworkbook.CreateSheet(fileName);
            sheet.CreateFreezePane(0, 1);
          
            #region 设置表头

            var headerRow = sheet.CreateRow(0);
            var headerCellIndex = 0;
            foreach (var col in column)
            {
                sheet.SetColumnWidth(headerCellIndex, 10 * 256);
                var cell = headerRow.CreateCell(headerCellIndex++);
                cell.SetCellValue(col.Value);
            }

            #endregion

            #region 设置内容

            var contentRowIndex = 1;
            var contentCellIndex = 0;
            foreach (var data in dataSource)
            {
                var contentRow = sheet.CreateRow(contentRowIndex++);
                foreach (var col in column)
                {
                    var cell = contentRow.CreateCell(contentCellIndex++);
                   
                    var obj = dst[col.Key].GetValue(data);
                    cell.SetCellValue(obj == null ? "" : obj.ToString());
                    if (dst[col.Key].PropertyType == typeof(DateTime) || dst[col.Key].PropertyType == typeof(DateTime?))
                    {
                        cell.SetCellValue(obj == null ? "" : DateTime.Parse(obj.ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (dst[col.Key].PropertyType == typeof(int) || dst[col.Key].PropertyType == typeof(int?))
                    {
                        cell.SetCellValue(obj == null ? 0 : int.Parse(obj.ToString()));
                    }
                }
                contentCellIndex = 0;
            }

            #endregion

            #region 转为字节数组

            var stream = new MemoryStream();
            hssfworkbook.Write(stream);
            var buf = stream.ToArray();

            #endregion
             
            #region 保存为(Web)下载文件

            if (HttpContext.Current.Request.Browser.Browser.Contains("IE") || HttpContext.Current.Request.Browser.Browser.Contains("InternetExplorer"))
            {
                fileName = HttpUtility.UrlEncode(fileName);
            }

            response.Clear();
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName + ".xls");
            response.BinaryWrite(buf);
            response.End(); 
            #endregion
        }
 


        /// <summary>
        /// Excel转化DataTable获取发货单()
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataTable GetDispatchBillByReadExcel(string path)
        {
            FileStream stream = null;
            ISheet sheet;

            path = string.Format("{0}{1}", filePath, path);
            try
            {
                stream = File.OpenRead(path);
                HSSFWorkbook wk = new HSSFWorkbook(stream);
                sheet = wk.GetSheet("发货单");
            }
            catch (System.Exception)
            {
                stream = File.OpenRead(path);
                XSSFWorkbook wk = new XSSFWorkbook(stream);
                sheet = wk.GetSheet("发货单");
            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }

            DataTable table = new DataTable();
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            int rowCount = sheet.LastRowNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                if (row != null)
                {
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = row.GetCell(j);
                        //using (StreamWriter sw = System.IO.File.AppendText("D:/Test_Log/CreateIndex.txt"))
                        //{
                        //    sw.WriteLine("------------------" + row.GetCell(j) + "访问记录：" + row.GetCell(j) + "     执行了一次任务" + "------------------");
                        //    sw.Flush();
                        //}
                    }
                    if (row.GetCell(0) != null)
                        table.Rows.Add(dataRow);
                }

                // utf-8 HttpUtility.UrlEncode(row.GetCell(j).ToString(), Encoding.GetEncoding("utf-8"));
                // Encoding.Default.GetBytes()

            }

            return table;
        }

 
    }
}
