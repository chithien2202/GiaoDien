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
    public partial class frmThongTinNhanVien : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmThongTinNhanVien()
        {
            InitializeComponent();
        }
        private void Loadbophan()
        {
            cbbbophan.DataSource = qltb.BOPHANs;
            cbbbophan.DisplayMember = "TENBOPHAN";
            cbbbophan.ValueMember = "MABOPHAN";
        }

        private void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            Loadbophan();
            if (frmDanhMucNhanVien.tos == true)
            {
                btnLuu.Text = "Thêm";
                txtMaNhanVien.Enabled = true;
                cbbbophan.Enabled = true;
            }
            else
            {
                btnLuu.Text = "Sửa";
                txtMaNhanVien.Enabled = false;
                NHANVIEN nhanvien = qltb.NHANVIENs.Where(t => t.MANHANVIEN == frmDanhMucNhanVien.manv).FirstOrDefault();
                txtMaNhanVien.Text = nhanvien.MANHANVIEN;
                txtTenNhanVien.Text = nhanvien.TENNHANVIEN;
                cbbbophan.Text = nhanvien.MABOPHAN;
                txtDienGiai.Text = nhanvien.GHICHU;
                txtDiaChi.Text = nhanvien.DIACHINV;
                txtEmail.Text = nhanvien.EMAILNV;
                txtSoDienThoai.Text = nhanvien.SDTNV.ToString();
                txtLuong.Text = nhanvien.LUONG.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (frmDanhMucNhanVien.tos == true)
            {
                NHANVIEN nhanvien = new NHANVIEN();
                nhanvien.MANHANVIEN = TangMa.ATTangMa2("NV", "NHANVIEN");
                nhanvien.MABOPHAN = cbbbophan.SelectedValue.ToString();
                nhanvien.TENNHANVIEN = txtTenNhanVien.Text;
                nhanvien.DIACHINV = txtDiaChi.Text;
                nhanvien.GHICHU = txtDienGiai.Text;
                nhanvien.EMAILNV = txtEmail.Text;
                nhanvien.LUONG = int.Parse(txtLuong.Text);
                nhanvien.SDTNV = int.Parse(txtSoDienThoai.Text);
                qltb.NHANVIENs.InsertOnSubmit(nhanvien);
                qltb.SubmitChanges();
                MessageBox.Show("Thêm thành công");
                Loadnhanvien();
                this.Close();
            }
            else
            {
                string manhanvien = frmDanhMucNhanVien.dgvnhanvien.CurrentRow.Cells[0].Value.ToString();
                NHANVIEN nv = qltb.NHANVIENs.Where(t => t.MANHANVIEN == manhanvien).FirstOrDefault();

                nv.MABOPHAN = cbbbophan.Text;
                nv.TENNHANVIEN = txtTenNhanVien.Text;
                nv.DIACHINV = txtDiaChi.Text;
                nv.GHICHU = txtDienGiai.Text;
                nv.EMAILNV = txtEmail.Text;
                nv.LUONG = int.Parse(txtLuong.Text);
                nv.SDTNV = int.Parse(txtSoDienThoai.Text);

                qltb.SubmitChanges();
                MessageBox.Show("Sửa thành công");
                Loadnhanvien();
            }
        }
        public void Loadnhanvien()
        {
            var nhanvien = from nv in qltb.NHANVIENs
                            select new { nv.MANHANVIEN, nv.MABOPHAN, nv.TENNHANVIEN, nv.DIACHINV, nv.SDTNV, nv.EMAILNV, nv.LUONG,  nv.GHICHU };
            frmDanhMucNhanVien.dgvnhanvien.DataSource = nhanvien;
        }
    }
}