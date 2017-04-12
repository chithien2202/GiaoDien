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
                MessageBox.Show("Success");
                LoadKhachHang();
                this.Close();
            }
            else
            {
                string makhachhang = frmDanhMucKhachHang.dgvkhachang.CurrentRow.Cells[0].Value.ToString();
                KHACHHANG md = qltb.KHACHHANGs.Where(t => t.MAKHACHKHACH == makhachhang).FirstOrDefault();
               
                md.MANHOMKH = cbbnhomkhachhang.Text;
                md.TENKHACHHANG = txtTenKhachHang.Text;
                md.DIACHIKH = txtDiaChi.Text;
                md.GHICHU = txtDienGiai.Text;
                md.EMAILKH = txtEmail.Text;
                md.FAX = int.Parse(txtFax.Text);
                md.SDTKH = int.Parse(txtSoDienThoai.Text);
               
                qltb.SubmitChanges();
                LoadKhachHang();
            }
        }
        public void LoadKhachHang()
        {
            var khachhang = from md in qltb.KHACHHANGs
                        select new { md.MAKHACHKHACH, md.TENKHACHHANG, md.NHOMKHACHHANG, md.DIACHIKH, md.EMAILKH, md.FAX, md.SDTKH,md.GHICHU };
            frmDanhMucKhachHang.dgvkhachang.DataSource = khachhang;
        }
            
        }
    }
