using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class frmCauHinh : Form
    {
        Module_CauHinh CauHinh;
        public frmCauHinh()
        {
            CauHinh = new Module_CauHinh();
            InitializeComponent();
            cbbServerName.DropDown += CbbServerName_DropDown;
            cbbDatabase.DropDown += CbbDatabase_DropDown;
        }

        private void CbbDatabase_DropDown(object sender, EventArgs e)
        {
            cbbDatabase.DataSource = CauHinh.GetDBName(cbbDatabase.Text, txtUserName.Text, txtPassword.Text);
            cbbDatabase.DisplayMember = "name";
        }

        private void CbbServerName_DropDown(object sender, EventArgs e)
        {
            cbbServerName.DataSource = CauHinh.GetServerName();
            cbbDatabase.DisplayMember = "ServerName";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length == 0)
            {
                errorProvider1.SetError(txtUserName, "Bạn chưa nhập Username");
                txtUserName.Focus();
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Bạn chưa nhập Password");
                txtPassword.Focus();
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            CauHinh.SaveConfig(cbbServerName.Text, txtUserName.Text, txtPassword.Text, cbbDatabase.Text);
            XtraMessageBox.Show("Lưu thành công!");
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            CauHinh.SaveConfig(cbbServerName.Text, txtUserName.Text, txtPassword.Text, cbbDatabase.Text);
            this.Close();
        }
    }
}
