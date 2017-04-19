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
    public partial class frmNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmNguoiDung()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                txtTenDangNhap.Enabled = true;
                txtMatKhau.Enabled = true;

                btnThem.Text = "Lưu";
            }
            else
            {
                NGUOIDUNG nguoidung = new NGUOIDUNG();
                nguoidung.TaiKhoan = txtTenDangNhap.Text;
                nguoidung.MatKhau = txtMatKhau.Text;
                qltb.NGUOIDUNGs.InsertOnSubmit(nguoidung);
                qltb.SubmitChanges();
                MessageBox.Show("Success");
                LoadGridViewNguoiDung();

                btnThem.Text = "Thêm";
                txtTenDangNhap.Enabled = false;
                txtMatKhau.Enabled = false;


                txtTenDangNhap.Text = String.Empty;
                txtMatKhau.Text = String.Empty;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        void LoadGridViewNguoiDung()
        {
            var nguoidung = from nd in qltb.NGUOIDUNGs
                      select new { nd.TaiKhoan, nd.MatKhau};
            dtgvDSNguoiDung.DataSource = nguoidung;
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            LoadGridViewNguoiDung();
        }
    }
}