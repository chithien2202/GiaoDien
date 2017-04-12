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
    public partial class frmThongTinKhachHang : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();

        private void Loadnhomkhachhang()
        {
            cbbnhomkhachhang.DataSource = qltb.NHOMKHACHHANGs;
            cbbnhomkhachhang.DisplayMember = "TENNHOMKH";
            cbbnhomkhachhang.ValueMember = "MANHOMKH";
        }

        public frmThongTinKhachHang()
        {
            InitializeComponent();
        }

        private void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {
            Loadnhomkhachhang();
            if (frmDanhMucKhachHang.tos == true)
            {
                btnLuu.Text = "Thêm";
                txtMaKhachHang.Enabled = true;
                cbbnhomkhachhang.Enabled = true;
            }
            else
            {
                btnLuu.Text = "Sửa";
                txtMaKhachHang.Enabled = false;
                KHACHHANG khachhang = qltb.KHACHHANGs.Where(t => t.MAKHACHKHACH == frmDanhMucKhachHang.makh).FirstOrDefault();
                txtMaKhachHang.Text = khachhang.MAKHACHKHACH;
                txtTenKhachHang.Text = khachhang.TENKHACHHANG;
                cbbnhomkhachhang.Text = khachhang.MANHOMKH;
                txtDienGiai.Text = khachhang.GHICHU;
                txtDiaChi.Text = khachhang.DIACHIKH;
                txtEmail.Text = khachhang.EMAILKH;
                txtSoDienThoai.Text = khachhang.SDTKH.ToString();
                txtFax.Text = khachhang.FAX.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (frmDanhMucKhachHang.tos == true)
            {
                KHACHHANG khachhang = new KHACHHANG();
                khachhang.MAKHACHKHACH = TangMa.ATTangMa2("KH", "KHACHHANG");
                khachhang.MANHOMKH = cbbnhomkhachhang.SelectedValue.ToString();
                khachhang.TENKHACHHANG = txtTenKhachHang.Text;
                khachhang.DIACHIKH = txtDiaChi.Text;
                khachhang.GHICHU = txtDienGiai.Text;
                khachhang.EMAILKH = txtEmail.Text;
                khachhang.FAX = int.Parse(txtFax.Text);
                khachhang.SDTKH = int.Parse(txtSoDienThoai.Text);
                qltb.KHACHHANGs.InsertOnSubmit(khachhang);
                qltb.SubmitChanges();
                MessageBox.Show("Thêm thành công");
                LoadKhachHang();
                this.Close();
            }
            else
            {
                string makhachhang = frmDanhMucKhachHang.dgvkhachang.CurrentRow.Cells[0].Value.ToString();
                KHACHHANG kh = qltb.KHACHHANGs.Where(t => t.MAKHACHKHACH == makhachhang).FirstOrDefault();

                kh.MANHOMKH = cbbnhomkhachhang.Text;
                kh.TENKHACHHANG = txtTenKhachHang.Text;
                kh.DIACHIKH = txtDiaChi.Text;
                kh.GHICHU = txtDienGiai.Text;
                kh.EMAILKH = txtEmail.Text;
                kh.FAX = int.Parse(txtFax.Text);
                kh.SDTKH = int.Parse(txtSoDienThoai.Text);
               
                qltb.SubmitChanges();
                MessageBox.Show("Sửa thành công");
                LoadKhachHang();
            }
        }
        public void LoadKhachHang()
        {
            var khachhang = from kh in qltb.KHACHHANGs
                        select new { kh.MAKHACHKHACH, kh.TENKHACHHANG, kh.NHOMKHACHHANG, kh.DIACHIKH, kh.EMAILKH, kh.FAX, kh.SDTKH, kh.GHICHU };
            frmDanhMucKhachHang.dgvkhachang.DataSource = khachhang;
        }
            
        }
    }
