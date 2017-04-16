using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    public class TangMa
    {
        public static string ATTangMa3(string ma, string tenbang)
        {
            string sql = "select * from " + tenbang;

            SqlDataAdapter da = new SqlDataAdapter(sql, Properties.Resources.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string Ma = "";
            if (dt.Rows.Count <= 0)
            {
                Ma = ma + "001";
            }
            else
            {
                int k;
                Ma = ma;
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Trim().Substring(3, 3));
                k = k + 1;
                if (k < 10)
                {
                    Ma = Ma + "00";
                }
                else
                    if (k < 100)
                {
                    Ma = Ma + "0";
                }
                Ma = Ma + k.ToString();

            }
            return Ma;
        }

        public static string ATTangMa2(string ma, string tenbang)
        {
            string sql = "select * from " + tenbang;

            SqlDataAdapter da = new SqlDataAdapter(sql, Properties.Resources.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string Ma = "";
            if (dt.Rows.Count <= 0)
            {
                Ma = ma + "001";
            }
            else
            {
                int k;
                Ma = ma;
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Trim().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                {
                    Ma = Ma + "00";
                }
                else
                    if (k < 100)
                {
                    Ma = Ma + "0";
                }
                Ma = Ma + k.ToString();

            }
            return Ma;
        }
        
    }
}
