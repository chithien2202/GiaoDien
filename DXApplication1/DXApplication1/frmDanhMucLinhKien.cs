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
    public partial class frmDanhMucLinhKien : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucLinhKien()
        {
            InitializeComponent();
            //dtgvlk = dtgvDSLinhKien;
        }

        public static DevExpress.XtraGrid.GridControl dtgvlk;

        public static bool tos;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                cbbThietBi.Enabled = true;
                dtpNgaySX.Enabled = true;
                txtTenLinhKien.Enabled = true;
                dtpNgayMua.Enabled = true;
                dtpNgayHetBH.Enabled = true;
                txtDienGiai.Enabled = true;

                btnThem.Text = "Lưu";
            }
            else
            {
                LINHKIEN lk = new LINHKIEN();
                lk.MALINHKIEN = TangMa.ATTangMa2("LK", "LINHKIEN");
                lk.MATHIETBI = cbbThietBi.SelectedValue.ToString();
                lk.TENLINHKIEN = txtTenLinhKien.Text;
                lk.NGAYSX = dtpNgaySX.Value;
                lk.NGAYKETTHUC = dtpNgayHetBH.Value;
                lk.NGAYMUA_SUACHUA = dtpNgayMua.Value;
                lk.GHICHULINHKIEN = txtDienGiai.Text;
                qltb.LINHKIENs.InsertOnSubmit(lk);
                qltb.SubmitChanges();     
                LoadGridViewLinhKien();
                MessageBox.Show("Success");

                btnThem.Text = "Thêm";
                cbbThietBi.Enabled = false;
                dtpNgaySX.Enabled = false;
                txtTenLinhKien.Enabled = false;
                dtpNgayMua.Enabled = false;
                dtpNgayHetBH.Enabled = false;
                txtDienGiai.Enabled = false;


                cbbThietBi.Text = String.Empty;
                dtpNgaySX.Text = String.Empty;
                txtTenLinhKien.Text = String.Empty;
                dtpNgayMua.Text = String.Empty;
                dtpNgayHetBH.Text = String.Empty;
                txtDienGiai.Text = String.Empty;

            }
        }

        public static string mlk = "";
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                cbbThietBi.Enabled = true;
                dtpNgaySX.Enabled = true;
                txtTenLinhKien.Enabled = true;
                dtpNgayMua.Enabled = true;
                dtpNgayHetBH.Enabled = true;
                txtDienGiai.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string malk = dtgvDSLinhKien.CurrentRow.Cells[0].Value.ToString();
                LINHKIEN lk = qltb.LINHKIENs.Where(t => t.MALINHKIEN == malk).FirstOrDefault();
                lk.TENLINHKIEN = txtTenLinhKien.Text;
                lk.NGAYSX = dtpNgaySX.Value;
                lk.NGAYKETTHUC = dtpNgayHetBH.Value;
                lk.NGAYMUA_SUACHUA = dtpNgayMua.Value;
                lk.GHICHULINHKIEN = txtDienGiai.Text;
                qltb.SubmitChanges();
                LoadGridViewLinhKien();
                MessageBox.Show("Sửa thành công");


                btnSua.Text = "Sửa";
                cbbThietBi.Enabled = false;
                dtpNgaySX.Enabled = false;
                txtTenLinhKien.Enabled = false;
                dtpNgayMua.Enabled = false;
                dtpNgayHetBH.Enabled = false;
                txtDienGiai.Enabled = false;

                cbbThietBi.Text = String.Empty;
                dtpNgaySX.Text = String.Empty;
                txtTenLinhKien.Text = String.Empty;
                dtpNgayMua.Text = String.Empty;
                dtpNgayHetBH.Text = String.Empty;
                txtDienGiai.Text = String.Empty;
            }
        }

        private void LoadGridViewLinhKien()
        {
            var linhkien = from lk in qltb.LINHKIENs
                           select new { lk.MALINHKIEN, lk.MATHIETBI, lk.TENLINHKIEN, lk.NGAYSX, lk.NGAYKETTHUC, lk.NGAYMUA_SUACHUA, lk.GHICHULINHKIEN };
            dtgvDSLinhKien.DataSource = linhkien;
        }

        private void frmDanhMucLinhKien_Load(object sender, EventArgs e)
        {
            cbbThietBi.Enabled = false;
            dtpNgaySX.Enabled = false;
            txtTenLinhKien.Enabled = false;
            dtpNgayMua.Enabled = false;
            dtpNgayHetBH.Enabled = false;
            txtDienGiai.Enabled = false;

            LoadCbbThietBi();
            LoadGridViewLinhKien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string malk = dtgvDSLinhKien.CurrentRow.Cells[0].Value.ToString();
                    LINHKIEN lk = qltb.LINHKIENs.Where(t => t.MALINHKIEN == malk).FirstOrDefault();
                    qltb.LINHKIENs.DeleteOnSubmit(lk);
                    qltb.SubmitChanges();
                    LoadGridViewLinhKien();
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

        private void dtgvDSLinhKien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbThietBi.Enabled = false;
            dtpNgaySX.Enabled = false;
            txtTenLinhKien.Enabled = false;
            dtpNgayMua.Enabled = false;
            dtpNgayHetBH.Enabled = false;
            txtDienGiai.Enabled = false;
            cbbThietBi.Text = dtgvDSLinhKien.CurrentRow.Cells[1].Value.ToString();
            dtpNgaySX.Text = dtgvDSLinhKien.CurrentRow.Cells[3].Value.ToString();
            txtTenLinhKien.Text = dtgvDSLinhKien.CurrentRow.Cells[2].Value.ToString();
            dtpNgayMua.Text = dtgvDSLinhKien.CurrentRow.Cells[5].Value.ToString();
            dtpNgayHetBH.Text = dtgvDSLinhKien.CurrentRow.Cells[4].Value.ToString();
            txtDienGiai.Text = dtgvDSLinhKien.CurrentRow.Cells[6].Value.ToString();
        }

        private void LoadCbbThietBi()
        {
            cbbThietBi.DataSource = qltb.THIETBIs;
            cbbThietBi.DisplayMember = "TENTHIETBI";
            cbbThietBi.ValueMember = "MATHIETBI";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}