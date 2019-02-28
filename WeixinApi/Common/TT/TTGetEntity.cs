using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TT
{
    public class TTGetEntity
    {
        public void GetEntity()
        {
            try
            {
                string connectionString = "Data Source=data.mgcc.com.cn;User ID=mgcc_cms_sa;Password=mgcc_cms_sa;Initial Catalog=_Demo";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                string selectQuery = "SET FMTONLY ON; select * from @tableName; SET FMTONLY OFF;";
                SqlCommand command = new SqlCommand(selectQuery, conn);
                SqlDataAdapter ad = new SqlDataAdapter(command);
                System.Data.DataSet ds = new System.Data.DataSet();

                System.Data.DataTable schema = conn.GetSchema("Tables");
                foreach (System.Data.DataRow row in schema.Rows)
                {
                    ds.Tables.Clear();
                    string tb_name = row["TABLE_NAME"].ToString();
                    if (tb_name=="User")
                    {
                        tb_name = "[" + tb_name + "]";
                    }
                    command.CommandText = selectQuery.Replace("@tableName", tb_name);
                    ad.FillSchema(ds, SchemaType.Mapped, tb_name);
                    foreach (DataColumn dc in ds.Tables[0].Columns)
                    {
                        string DataType = dc.DataType.Name;
                        if (dc.DataType.Name.ToLower() == "string")
                        {
                            DataType = dc.DataType.Name;
                        }
                        string temp = "public " + DataType + (dc.AllowDBNull && dc.DataType.Name.ToLower() != "string" ? "? " : " ") + dc.ColumnName + " { get; set; }";
                    }

                }
                conn.Close();
            }
            catch (Exception e)
            {
                string ex = e.Message;
                throw;
            }

        }
    }
}
