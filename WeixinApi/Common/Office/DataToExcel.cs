using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Web;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using Common;

namespace Common.Office
{
 public   class DataToExcel
    {

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="title"></param>
        /// <param name="dt"></param>
        /// <param name="sheetName"></param>
     public static void Export(string[] fileName, string[] title, string sheetName, DataTable dt)
        {

            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet(sheetName);
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            for (int i = 0; i < title.Length; i++)
            {
                row.CreateCell(i).SetCellValue(title[i].ToString());
            }
            List<string> ids = new List<string>();
            int index = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (ids.Contains(dt.Rows[i]["ID"].ToString()))
                {
                    continue;
                }
                else
                {
                    ids.Add(dt.Rows[i]["ID"].ToString());
                    row = sheet.CreateRow(index + 1);
                    index++;
                    for (int j = 0; j <= fileName.Length; j++)
                    {
                        if (j == 0)
                        {
                            row.CreateCell(j).SetCellValue(index + 1);
                        }
                        else
                        {
                            row.CreateCell(j).SetCellValue(dt.Rows[i][fileName[j - 1]].ToString());
                        }

                    }
                }
            }


            //写入到客户端   
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + sheetName + DateTime.Now.ToString("yyyy-MM-dd") + ".xls"));
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
           
            book = null;
            ms.Close();
            ms.Dispose();
      
        }
        /// <summary>
        /// 服务商结算订单导出
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="title"></param>
        /// <param name="sheetName"></param>
        /// <param name="dt"></param>
     public static System.IO.MemoryStream ExcelSettlementOrder(string[] fileName, string[] title, string sheetName, DataTable dt)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet(sheetName);
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            for (int i = 0; i < title.Length; i++)
            {
                row.CreateCell(i).SetCellValue(title[i]);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                        NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(i + 1);
                        for (int j = 0; j < fileName.Length; j++)
                        {
                            row2.CreateCell(j).SetCellValue(dt.Rows[i][fileName[j]].ToString());
                        }
                }
            }
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            //ms.Seek(0, SeekOrigin.Begin);
            ms.Flush();
            ms.Position = 0;//流位置归零
            return ms;
            //写入到客户端   
        }

     /// <summary>
     /// Excel导出返回文件路径
     /// </summary>
     /// <param name="fileName"></param>
     /// <param name="title"></param>
     /// <param name="sheetName"></param>
     /// <param name="dt"></param>
     /// <param name="FilePath"></param>
     /// <param name="ext"></param>
     /// <returns></returns>
     public static string ExcelFilePath(string[] fileName, string[] title, string sheetName, DataTable dt, string FilePath, string ext)
     {
         NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
         NPOI.SS.UserModel.ISheet sheet = book.CreateSheet(sheetName);
         NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
         for (int i = 0; i < title.Length; i++)
         {
             row.CreateCell(i).SetCellValue(title[i]);
         }
         if (dt != null && dt.Rows.Count > 0)
         {
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(i + 1);
                 for (int j = 0; j < fileName.Length; j++)
                 {
                     row2.CreateCell(j).SetCellValue(dt.Rows[i][fileName[j]].ToString());
                 }
             }
         }    

         if (!Directory.Exists(HttpContext.Current.Server.MapPath(FilePath))) Directory.CreateDirectory(HttpContext.Current.Server.MapPath(FilePath));
         FilePath += "/" + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000) + Path.GetExtension(ext);
         FileStream fs2 = File.Create(HttpContext.Current.Server.MapPath(FilePath));
    
         book.Write(fs2);
         fs2.Close();
 
      
         return FilePath;
         //写入到客户端   
     }
    }
}
