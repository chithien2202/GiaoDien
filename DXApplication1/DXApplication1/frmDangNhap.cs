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

namespace DXApplication1
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        MaHoaPass mahoa = new MaHoaPass();
        QL_NguoiDung CauHinh = new QL_NguoiDung();

        string PubicKey = "04DHTH";

        public frmDangNhap()
        {
            InitializeComponent();
        }
        

        public void ProcessLogin()
        {
           string pwd = mahoa.Encrypt(txtMatKhau.Text, PubicKey);

            LoginResult result;
            result = CauHinh.Check_User(txtTaiKhoan.Text, txtMatKhau.Text);
            // Wrong username or pass
            if (result == LoginResult.Invalid)
            {
                MessageBox.Show("Sai " + lblTaiKhoan.Text + " Hoặc " + lblMatKhau.Text);
                return;
            }
            // Account had been disabled
            else if (result == LoginResult.Disabled)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            if (Program.mainForm == null || Program.mainForm.IsDisposed)
            {
                Program.mainForm = new frmMain();
            }
            this.Visible = false;
            Program.mainForm.Show();
        }


        private void ProcessConfig()
        {
            frmCauHinh fm = new frmCauHinh();
            this.Hide();
            fm.ShowDialog();
            this.Show();
        }



        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lblTaiKhoan.Text.ToLower());
                this.txtTaiKhoan.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtMatKhau.Text))
            {
                MessageBox.Show("Không được bỏ trống " + lblMatKhau.Text.ToLower());
                this.txtMatKhau.Focus();
                return;
            }
            int kq = CauHinh.Check_Config(); //hàm Check_Config() thuộc Class QL_NguoiDung
            if (kq == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình
                ProcessConfig();
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình
                ProcessConfig();
            }
        }
    }
}
