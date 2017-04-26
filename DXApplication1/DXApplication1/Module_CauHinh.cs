using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    public class Module_CauHinh
    {
        //B4: Cấu hình chuỗi kết nối không phù hợp Xử lý tạo mới cấu hình nếu là trường hợp 1 và 2:
        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        public DataTable GetDBName(string pServer, string pUser, string pPass)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases",
            "Data Source=" + pServer + ";Initial Catalog=master;User ID=" + pUser + ";pwd = " + pPass + "");
            da.Fill(dt);
            return dt;
        }

        public void SaveConfig(string pServer, string pUser, string pPass, string pDBname)
        {
            Properties.Settings.Default.QLTBConnect = "Data Source=" + pServer +
             ";Initial Catalog=" + pDBname + ";User ID=" + pUser + ";Password=" + pPass + "";
            Properties.Settings.Default.Save();
        }
    }
}
