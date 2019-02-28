﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TT
{
    public class TTGetSummery
    {
        string connectionString = "Data Source=data.mgcc.com.cn;User ID=mgcc_cms_sa;Password=mgcc_cms_sa;Initial Catalog=_Demo";
        public string GetColumnSummery(string tableName, string colName)
        {
            //System.Diagnostics.Debugger.Launch();		
            //System.Diagnostics.Debugger.Break();		
            string sql = string.Format(@"SELECT 字段说明=isnull(props.[value],'') FROM syscolumns cols join sysobjects objs on cols.id= objs.id and  objs.xtype='U' and  objs.name<>'dtproperties' left join sys.extended_properties props on cols.id=props.major_id and cols.colid=props.minor_id where  objs.name='{0}' and cols.name='{1}'", tableName, colName);
            string sqlcon = connectionString;
            object remark = new object();
            string Summery = colName;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(sqlcon))
            {
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn);
                remark = cmd.ExecuteScalar();
            }
            if (remark != null && !string.IsNullOrEmpty(remark.ToString()))
            {
                Summery = remark.ToString();
            }
            return Summery;
        }

        //得到列表说明备注
        public string GetTableSummery(string tableName)
        {
            //System.Diagnostics.Debugger.Launch();		
            //System.Diagnostics.Debugger.Break();				
            string sql = string.Format(@"SELECT TOP 1 TableSumary FROM (select c.Name AS TableName,isnull(f.[value],'') AS TableSumary from  sys.columns a left join sys.types b on a.user_type_id=b.user_type_id inner join  sys.objects c on a.object_id=c.object_id and c.Type='U' left join  syscomments d on a.default_object_id=d.ID left join sys.extended_properties e on e.major_id=c.object_id and e.minor_id=a.Column_id and e.class=1 left join  sys.extended_properties f on f.major_id=c.object_id and f.minor_id=0 and f.class=1) AS Mytb WHERE TableName='{0}' ", tableName);
            string sqlcon = connectionString;
            object remark = new object();
            string Summery = tableName;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(sqlcon))
            {
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn);
                remark = cmd.ExecuteScalar();
            }
            if (remark != null && !string.IsNullOrEmpty(remark.ToString()))
            {
                Summery = remark.ToString();
            }

            return Summery;
        }
    }
}
