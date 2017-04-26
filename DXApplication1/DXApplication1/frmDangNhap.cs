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
        QLTBDataContext qltb = new QLTBDataContext();
        MaHoaPass mahoa = new MaHoaPass();
        QL_NguoiDung CauHinh = new QL_NguoiDung();

        string PubicKey = "04DHTH";

        public frmDangNhap()
        {
            InitializeComponent();
            tendn = txtTaiKhoan.Text;
        }

        public static string tendn;
        
        public void ProcessLogin()
        {
           string pwd = mahoa.Encrypt(txtMatKhau.Text, PubicKey);

            LoginResult result;
            result = CauHinh.Check_User(txtTaiKhoan.Text, txtMatKhau.Text);
            // Wrong username or pass
            if (result == LoginResult.Invalid)
            {
                XtraMessageBox.Show("Sai " + lblTaiKhoan.Text + " Hoặc " + lblMatKhau.Text,"Thông báo");
                return;
            }
            // Account had been disabled
            else if (result == LoginResult.Disabled)
            {
                XtraMessageBox.Show("Tài khoản bị khóa","Thông báo");
                return;
            }
            if (Program.mainForm == null || Program.mainForm.IsDisposed)
            {
                Program.mainForm = new frmMain();
            }

            this.Visible = false;
            Program.mainForm.send(txtTaiKhoan.Text);
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
                XtraMessageBox.Show("Không được bỏ trống " + lblTaiKhoan.Text.ToLower(),"Thông báo");
                this.txtTaiKhoan.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtMatKhau.Text))
            {
                XtraMessageBox.Show("Không được bỏ trống " + lblMatKhau.Text.ToLower(),"Thông báo");
                this.txtMatKhau.Focus();
                return;
            }
           
            //luu mk
            if (chkLuuMK.Checked)
            {
                Properties.Settings.Default.luuMatKhau = chkLuuMK.Checked;
                Properties.Settings.Default.username = txtTaiKhoan.Text;
                Properties.Settings.Default.password = txtMatKhau.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.luuMatKhau = chkLuuMK.Checked;
                Properties.Settings.Default.Save();
            }
            //

            int kq = CauHinh.Check_Config(); //hàm Check_Config() thuộc Class QL_NguoiDung
            if (kq == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            }
            if (kq == 1)
            {
                XtraMessageBox.Show("Chuỗi cấu hình không tồn tại","Thông báo");// Xử lý cấu hình
                ProcessConfig();
            }
            if (kq == 2)
            {
                XtraMessageBox.Show("Chuỗi cấu hình không phù hợp","Thông báo");// Xử lý cấu hình
                ProcessConfig();
            }
        }

        public IEnumerable<PHANQUYEN> GetNhomNguoiDungByUserId(string userName)
        {
            var query = from nnd in this.qltb.NHOMNGUOIDUNGs
                        join ndnnd in this.qltb.NGUOIDUNGNHOMNGDUNGs
                        on nnd.MANHOM equals ndnnd.MANHOMNGDUNG
                        join nd in this.qltb.NGUOIDUNGs
                        on ndnnd.TENDANGNHAP equals nd.TENDANGNHAP
                        join pq in this.qltb.PHANQUYENs
                        on ndnnd.MANHOMNGDUNG equals pq.MANHOMNGUOIDUNG
                        where nd.TENDANGNHAP == userName && pq.COQUYEN == true
                        select pq;
            return query;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.luuMatKhau)
            {
                txtTaiKhoan.Text = Properties.Settings.Default.username;
                txtMatKhau.Text = Properties.Settings.Default.password;
                chkLuuMK.Checked = Properties.Settings.Default.luuMatKhau;
            }
        }
    }
}
