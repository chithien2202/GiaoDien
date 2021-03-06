﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    
    public class QL_NguoiDung
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public int Check_Config()
        {
            if (Properties.Settings.Default.DATHTTConnectionString2 == string.Empty)
                return 1;// Chuỗi cấu hình không tồn tại
            SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.DATHTTConnectionString2);
            try
            {
                if (_Sqlconn.State == System.Data.ConnectionState.Closed)
                    _Sqlconn.Open();
                return 0;// Kết nối thành công chuỗi cấu hình hợp lệ
            }
            catch
            {
                return 2;// Chuỗi cấu hình không phù hợp.
            }
        }

        public LoginResult Check_User(string pUser, string pPass)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from NGUOIDUNG where TENDANGNHAP='" + pUser + "' and MATKHAU ='" + pPass + "'",
                Properties.Settings.Default.DATHTTConnectionString2);
            DataTable dt = new DataTable();
            daUser.Fill(dt);
            if (dt.Rows.Count == 0)
                return LoginResult.Invalid;// User không tồn tại
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
            {
                return LoginResult.Disabled;// Không hoạt động
            }
            return LoginResult.Success;// Đăng nhập thành công
        }

        //==========================================================================================
        //B4: Cấu hình chuỗi kết nối không phù hợp Xử lý tạo mới cấu hình nếu là trường hợp 1 và 2:
        public DataTable GetSevername()
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
            DXApplication1.Properties.Settings.Default.DATHTTConnectionString2 = "Data Source=" + pServer +
             ";Initial Catalog=" + pDBname + ";User ID=" + pUser + ";pwd= " + pPass + "";
            DXApplication1.Properties.Settings.Default.Save();
        }

        
        public DataTable GetQuyenManHinh(string tendn)
        {
            var quyen = (from ql in qltb.NGUOIDUNGs
                         join od in qltb.NGUOIDUNGNHOMNGDUNGs on ql.TENDANGNHAP equals od.TENDANGNHAP
                         join pq in qltb.PHANQUYENs on od.MANHOMNGDUNG equals pq.MANHOMNGUOIDUNG
                         where ql.TENDANGNHAP == tendn && pq.COQUYEN == true
                         orderby od.TENDANGNHAP
                         select new
                         {
                             pq.MAMANHINH,
                         });
            DataTable dt = new DataTable();

            //khoi tao database
            dt.Columns.Add("MAMANHINH");

            //duyet danh sach them database trong list quyen
            foreach(var element in quyen)
            {
                var row = dt.NewRow();
                row["MAMANHINH"] = element.MAMANHINH;
                dt.Rows.Add(row);
            }
            return dt;
        }

    }
}
