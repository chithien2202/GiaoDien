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
using DevExpress.XtraReports.UI;

namespace DXApplication1
{
    public partial class frmDanhMucLinhKien : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
        public frmDanhMucLinhKien()
        {
            InitializeComponent();
        }


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

                cbbThietBi.Text = String.Empty;
                dtpNgaySX.Text = String.Empty;
                txtTenLinhKien.Text = String.Empty;
                dtpNgayMua.Text = String.Empty;
                dtpNgayHetBH.Text = String.Empty;
                txtDienGiai.Text = String.Empty;

                btnThem.Text = "Lưu";
            }
            else
            {
                if (txtTenLinhKien.Text == String.Empty)
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    LINHKIEN lk = new LINHKIEN();
                    //lk.MALINHKIEN = TangMa.ATTangMa2("LK", "LINHKIEN");
                    lk.MALINHKIEN = tangma.ThemMaLinhKien();
                    lk.MATHIETBI = cbbThietBi.SelectedValue.ToString();
                    lk.TENLINHKIEN = txtTenLinhKien.Text;
                    lk.NGAYSX = dtpNgaySX.Value;
                    lk.NGAYKETTHUC = dtpNgayHetBH.Value;
                    lk.NGAYMUA_SUACHUA = dtpNgayMua.Value;
                    if (txtDienGiai.Text == null)
                    {
                        lk.GHICHULINHKIEN = txtDienGiai.Text = "";
                    }
                    else
                    {
                        lk.GHICHULINHKIEN = txtDienGiai.Text;
                    }
                    qltb.LINHKIENs.InsertOnSubmit(lk);
                    qltb.SubmitChanges();
                    LoadGridViewLinhKien();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");

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
        }

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
                XtraMessageBox.Show("Sửa thành công","Thông báo");


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
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string malk = dtgvDSLinhKien.CurrentRow.Cells[0].Value.ToString();
                    LINHKIEN lk = qltb.LINHKIENs.Where(t => t.MALINHKIEN == malk).FirstOrDefault();
                    qltb.LINHKIENs.DeleteOnSubmit(lk);
                    qltb.SubmitChanges();
                    LoadGridViewLinhKien();
                    XtraMessageBox.Show("Xóa thành công","Thông báo");
                    
                }
                catch
                {
                    XtraMessageBox.Show("Dữ liệu đang được sử dụng, không thể xóa!","Thông báo");

                }
            }

            if (dr == DialogResult.No)

            {
                this.Close();
            }
        }

        private void dtgvDSLinhKien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch { }
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            Report.DanhMucLinhKien_Report report = new Report.DanhMucLinhKien_Report();
            ReportPrintTool rpt = new ReportPrintTool(report);
            report.CreateDocument(false);
            report.ShowPreviewDialog();
        }
    }
}