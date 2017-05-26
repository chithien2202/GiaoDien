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
    public partial class frmDanhMucPhanLoaiGia : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
        public frmDanhMucPhanLoaiGia()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                txtTenPhanLoai.Enabled = true;
                txtGhiChu.Enabled = true;

                txtTenPhanLoai.Text = String.Empty;
                txtGhiChu.Text = String.Empty;

                btnThem.Text = "Lưu";
            }
            else
            {
                if (txtTenPhanLoai.Text == String.Empty)
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    PHANLOAI phanloai = new PHANLOAI();
                    phanloai.MAPHANLOAI = tangma.ThemMaPhanLoaiGia();
                    phanloai.TENPHANLOAI = txtTenPhanLoai.Text;
                    phanloai.GHICHU = txtGhiChu.Text;
                    qltb.PHANLOAIs.InsertOnSubmit(phanloai);
                    qltb.SubmitChanges();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");
                    LoadGridViewPhanLoai();

                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;

                    btnThem.Text = "Thêm";
                    txtTenPhanLoai.Enabled = false;
                    txtGhiChu.Enabled = false;


                    txtTenPhanLoai.Text = String.Empty;
                    txtGhiChu.Text = String.Empty;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;

                txtTenPhanLoai.Enabled = true;
                txtGhiChu.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string mapl = dtgvPhanLoaiGia.CurrentRow.Cells[0].Value.ToString();
                PHANLOAI phanloai = qltb.PHANLOAIs.Where(t => t.MAPHANLOAI == mapl).FirstOrDefault();
                phanloai.TENPHANLOAI = txtTenPhanLoai.Text;
                phanloai.GHICHU = txtGhiChu.Text;
                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công", "Thông báo");
                LoadGridViewPhanLoai();

                btnThem.Enabled = true;
                btnXoa.Enabled = true;

                btnSua.Text = "Sửa";
                txtTenPhanLoai.Enabled = false;
                txtGhiChu.Enabled = false;

                txtTenPhanLoai.Text = String.Empty;
                txtGhiChu.Text = String.Empty;
            }
        }

        public void LoadGridViewPhanLoai()
        {
            var phanloai = from pl in qltb.PHANLOAIs
                      select new { pl.MAPHANLOAI, pl.TENPHANLOAI, pl.GHICHU };
            dtgvPhanLoaiGia.DataSource = phanloai;
        }

        private void frmDanhMucPhanLoaiGia_Load(object sender, EventArgs e)
        {
            txtTenPhanLoai.Enabled = false;
            txtGhiChu.Enabled = false;
            LoadGridViewPhanLoai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string mapl = dtgvPhanLoaiGia.CurrentRow.Cells[0].Value.ToString();
                    PHANLOAI phanloai = qltb.PHANLOAIs.Where(t => t.MAPHANLOAI == mapl).FirstOrDefault();
                    qltb.PHANLOAIs.DeleteOnSubmit(phanloai);
                    qltb.SubmitChanges();
                    LoadGridViewPhanLoai();
                    XtraMessageBox.Show("Xóa thành công", "Thông báo");

                }
                catch
                {
                    XtraMessageBox.Show("Dữ liệu đang được sử dụng, không thể xóa!", "Thông báo");

                }
            }

            if (dr == DialogResult.No)

            {
                this.Close();
            }
        }

        private void dtgvPhanLoaiGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenPhanLoai.Enabled = false;
            txtGhiChu.Enabled = false;
            txtTenPhanLoai.Text = dtgvPhanLoaiGia.CurrentRow.Cells[1].Value.ToString();
            if (dtgvPhanLoaiGia.CurrentRow.Cells[2].Value == null || dtgvPhanLoaiGia.CurrentRow.Cells[2].Value.ToString() == "")
            {
                txtGhiChu.Text = "";
            }
            else
            {
                txtGhiChu.Text = dtgvPhanLoaiGia.CurrentRow.Cells[2].Value.ToString();
            }
            
        }
    }
}