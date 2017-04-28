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
    public partial class frmDanhMucNhanVien : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
        public frmDanhMucNhanVien()
        {
            InitializeComponent();

        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                cbbBoPhan.Enabled = true;
                txtTenNV.Enabled = true;
                txtDChi.Enabled = true;
                txtEmail.Enabled = true;
                txtSDT.Enabled = true;
                txtLuong.Enabled = true;
                cbbBoPhan.Enabled = true;
                txtDienGiai.Enabled = true;

                txtTenNV.Text = String.Empty;
                txtDienGiai.Text = String.Empty;

                btnThem.Text = "Lưu";
            }
            else
            {
                if (txtTenNV.Text == String.Empty || txtDChi.Text == String.Empty || txtSDT.Text == String.Empty || txtSDT.Text == String.Empty || txtSDT.Text == String.Empty)
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    NHANVIEN nhanvien = new NHANVIEN();
                    //nhanvien.MANHANVIEN = TangMa.ATTangMa2("NV", "NHANVIEN");
                    nhanvien.MANHANVIEN = tangma.ThemMaNhanVien();
                    nhanvien.TENNHANVIEN = txtTenNV.Text;
                    nhanvien.SDTNV = int.Parse(txtSDT.Text);
                    nhanvien.DIACHINV = txtDChi.Text;
                    if (txtDienGiai.Text == null)
                    {
                        nhanvien.GHICHU = txtDienGiai.Text = "";
                    }
                    else
                    {
                        nhanvien.GHICHU = txtDienGiai.Text;
                    }
                    nhanvien.LUONG = int.Parse(txtLuong.Text);
                    nhanvien.EMAILNV = txtEmail.Text;
                    nhanvien.MABOPHAN = cbbBoPhan.SelectedValue.ToString();
                    qltb.NHANVIENs.InsertOnSubmit(nhanvien);
                    qltb.SubmitChanges();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");
                    LoadGridviewnhanvien();

                    btnThem.Text = "Thêm";
                    cbbBoPhan.Enabled = false;
                    txtTenNV.Enabled = false;
                    txtDChi.Enabled = false;
                    txtEmail.Enabled = false;
                    txtSDT.Enabled = false;
                    txtLuong.Enabled = false;
                    cbbBoPhan.Enabled = false;
                    txtDienGiai.Enabled = false;

                    txtTenNV.Text = String.Empty;
                    txtDienGiai.Text = String.Empty;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                cbbBoPhan.Enabled = true;
                txtTenNV.Enabled = true;
                txtDChi.Enabled = true;
                txtEmail.Enabled = true;
                txtSDT.Enabled = true;
                txtLuong.Enabled = true;
                cbbBoPhan.Enabled = true;
                txtDienGiai.Enabled = true;

                txtDienGiai.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string manv = dtgvnhanvien.CurrentRow.Cells[0].Value.ToString();
                NHANVIEN nv = qltb.NHANVIENs.Where(t => t.MANHANVIEN == manv).FirstOrDefault();
                nv.TENNHANVIEN = txtTenNV.Text;
                nv.SDTNV = int.Parse(txtSDT.Text);
                nv.DIACHINV = txtDChi.Text;
                nv.GHICHU = txtDienGiai.Text;
                nv.LUONG = int.Parse(txtLuong.Text);
                nv.EMAILNV = txtEmail.Text;
                nv.MABOPHAN = cbbBoPhan.Text;
                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công","Thông báo");
                LoadGridviewnhanvien();

                btnSua.Text = "Sửa";
                btnThem.Text = "Thêm";
                cbbBoPhan.Enabled = false;
                txtTenNV.Enabled = false;
                txtDChi.Enabled = false;
                txtEmail.Enabled = false;
                txtSDT.Enabled = false;
                txtLuong.Enabled = false;
                cbbBoPhan.Enabled = false;
                txtDienGiai.Enabled = false;

                txtTenNV.Text = String.Empty;
                txtDienGiai.Text = String.Empty;
            }
        }
        public void LoadGridviewnhanvien()
        {
            var nhanvien = from md in qltb.NHANVIENs
                            select new { md.MANHANVIEN, md.MABOPHAN, md.TENNHANVIEN, md.DIACHINV, md.SDTNV, md.EMAILNV, md.LUONG, md.GHICHU };
            dtgvnhanvien.DataSource = nhanvien;
        }

        private void frmDanhMucNhanVien_Load(object sender, EventArgs e)
        {
            cbbBoPhan.Enabled = false;
            txtTenNV.Enabled = false;
            txtDChi.Enabled = false;
            txtEmail.Enabled = false;
            txtSDT.Enabled = false;
            txtLuong.Enabled = false;
            cbbBoPhan.Enabled = false;
            txtDienGiai.Enabled = false;
            txtDienGiai.Enabled = false;

            LoadBoPhan();
            LoadGridviewnhanvien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                string manhanvien = dtgvnhanvien.CurrentRow.Cells[0].Value.ToString();
                NHANVIEN nhanvien = qltb.NHANVIENs.Where(t => t.MANHANVIEN == manhanvien).FirstOrDefault();
                qltb.NHANVIENs.DeleteOnSubmit(nhanvien);
                qltb.SubmitChanges();
                XtraMessageBox.Show("Xóa thành công","Thông báo");
                LoadGridviewnhanvien();
            }

            if (dr == DialogResult.No)
            {
                this.Close();
            }
        }

        private void LoadBoPhan()
        {
            cbbBoPhan.DataSource = qltb.BOPHANs;
            cbbBoPhan.DisplayMember = "TENBOPHAN";
            cbbBoPhan.ValueMember = "MABOPHAN";
        }

        private void dtgvnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbbBoPhan.Enabled = false;
                txtTenNV.Enabled = false;
                txtDChi.Enabled = false;
                txtEmail.Enabled = false;
                txtSDT.Enabled = false;
                txtLuong.Enabled = false;
                cbbBoPhan.Enabled = false;
                txtDienGiai.Enabled = false;
                txtDienGiai.Enabled = false;

                cbbBoPhan.Text = dtgvnhanvien.CurrentRow.Cells[1].Value.ToString();
                txtTenNV.Text = dtgvnhanvien.CurrentRow.Cells[2].Value.ToString();
                txtDChi.Text = dtgvnhanvien.CurrentRow.Cells[3].Value.ToString();
                txtSDT.Text = dtgvnhanvien.CurrentRow.Cells[4].Value.ToString();
                txtEmail.Text = dtgvnhanvien.CurrentRow.Cells[5].Value.ToString();
                txtLuong.Text = dtgvnhanvien.CurrentRow.Cells[6].Value.ToString();
                txtDienGiai.Text = dtgvnhanvien.CurrentRow.Cells[7].Value.ToString();
            }
            catch { }
        }
    }
}