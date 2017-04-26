using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace DXApplication1
{
    public partial class frmPhucHoi : DevExpress.XtraEditors.XtraForm
    {
        public frmPhucHoi()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6V52PV4\\SQLEXPRESS;Initial Catalog=QLTB;Persist Security Info=True;User ID=sa;Password=sa2014");

        private void btnBrower_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = dlg.FileName;
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                if (txtLocation.Text == string.Empty)
                {
                    XtraMessageBox.Show("Phải chọn thư mục lưu file backup", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    string sqlStmt2 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + txtLocation.Text + "'WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                    bu4.ExecuteNonQuery();

                    XtraMessageBox.Show("Phục hồi cơ sở dữ liệu thành công", "Thông báo", MessageBoxButtons.OK);
                    con.Close();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
    }
}