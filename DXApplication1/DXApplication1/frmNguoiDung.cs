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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {

                txtTenDangNhap.Enabled = false;
                txtMatKhau.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string taikhoan = dtgvDSNguoiDung.CurrentRow.Cells[0].Value.ToString();
                NGUOIDUNG nd = qltb.NGUOIDUNGs.Where(t => t.TaiKhoan == taikhoan).FirstOrDefault();
                nd.MatKhau = txtMatKhau.Text;
                qltb.SubmitChanges();
                LoadGridViewNguoiDung();
                MessageBox.Show("Sửa thành công");

                btnSua.Text = "Sửa";
                txtTenDangNhap.Enabled = false;
                txtMatKhau.Enabled = false;

                txtTenDangNhap.Text = String.Empty;
                txtMatKhau.Text = String.Empty;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string taikhoan = dtgvDSNguoiDung.CurrentRow.Cells[0].Value.ToString();
                    NGUOIDUNG nd = qltb.NGUOIDUNGs.Where(t => t.TaiKhoan == taikhoan).FirstOrDefault();
                    qltb.NGUOIDUNGs.DeleteOnSubmit(nd);
                    qltb.SubmitChanges();
                    LoadGridViewNguoiDung();
                    MessageBox.Show("Delete Success!");

                }
                catch
                {
                    MessageBox.Show("Dữ liệu đang được sử dụng, không thể xóa!");

                }
            }

            if (dr == DialogResult.No)

            {
                this.Close();
            }
        }

        private void dtgvDSNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtTenDangNhap.Enabled = false;
                txtMatKhau.Enabled = false;
                txtTenDangNhap.Text = dtgvDSNguoiDung.CurrentRow.Cells[0].Value.ToString();
                txtMatKhau.Text = dtgvDSNguoiDung.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
        }
    }
}