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
    public partial class frmSaoLuu : DevExpress.XtraEditors.XtraForm
    {
        
        public frmSaoLuu()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6V52PV4\\SQLEXPRESS;Initial Catalog=QLTB;Persist Security Info=True;User ID=sa;Password=sa2014");

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            try
            {
                if (txtLocation.Text == string.Empty)
                {
                    XtraMessageBox.Show("Hãy chọn thư mục lưu", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    string cmd = "BACKUP DATABASE [" + database + "] TO DISK='" + txtLocation.Text + "\\" + database + "_" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".bak'";

                    SqlCommand command = new SqlCommand(cmd, con);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    command.ExecuteNonQuery();
                    con.Close();
                    XtraMessageBox.Show("Sao lưu thành công", "Thông báo", MessageBoxButtons.OK);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void btnBrower_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = dlg.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}