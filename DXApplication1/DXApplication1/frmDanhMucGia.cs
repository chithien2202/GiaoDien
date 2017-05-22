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
    public partial class frmDanhMucGia : DevExpress.XtraEditors.XtraForm
    {
        TangMa tangma = new TangMa();
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucGia()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                cbbMaPhanLoai.Enabled = true;
                txtTenBBG.Enabled = true;
                txtDonGia.Enabled = true;
                txtGhiChu.Enabled = true;
                txtMaBBG.Text = String.Empty;
                txtTenBBG.Text = String.Empty;
                txtDonGia.Text = String.Empty;
                txtGhiChu.Text = String.Empty;

                btnThem.Text = "Lưu";
            }

            else
            {
                if (txtTenBBG.Text == String.Empty || txtDonGia.Text == String.Empty)
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    BANGBAOGIA bbg = new BANGBAOGIA();
                    bbg.MABG = tangma.ThemMaBBG();
                    bbg.MAPHANLOAI = cbbMaPhanLoai.SelectedValue.ToString();
                    bbg.TENBAOGIA = txtTenBBG.Text;
                    bbg.DONGIA = decimal.Parse(txtDonGia.Text);
                    if (txtGhiChu.Text == null)
                    {
                        bbg.GHICHUBAOGIA = txtGhiChu.Text = "";
                    }
                    else
                    {
                        bbg.GHICHUBAOGIA = txtGhiChu.Text;
                    }
                    qltb.BANGBAOGIAs.InsertOnSubmit(bbg);
                    qltb.SubmitChanges();
                    LoadGridViewBangBaoGia();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");


                    btnThem.Text = "Thêm";
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;

                    cbbMaPhanLoai.Enabled = false;
                    txtTenBBG.Enabled = false;
                    txtDonGia.Enabled = false;
                    txtGhiChu.Enabled = false;


                    txtMaBBG.Text = String.Empty;
                    txtTenBBG.Text = String.Empty;
                    txtDonGia.Text = String.Empty;
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

                cbbMaPhanLoai.Enabled = true;
                txtTenBBG.Enabled = true;
                txtDonGia.Enabled = true;
                txtGhiChu.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string mabbg = dtgvBangBaoGia.CurrentRow.Cells[0].Value.ToString();
                BANGBAOGIA bbg = qltb.BANGBAOGIAs.Where(t => t.MABG == mabbg).FirstOrDefault();
                bbg.MAPHANLOAI = cbbMaPhanLoai.Text;
                bbg.TENBAOGIA = txtTenBBG.Text;
                bbg.DONGIA = decimal.Parse(txtDonGia.Text);
                bbg.GHICHUBAOGIA = txtGhiChu.Text;
                qltb.SubmitChanges();
                LoadGridViewBangBaoGia();
                XtraMessageBox.Show("Sửa thành công", "Thông báo");

                btnSua.Text = "Sửa";
                btnThem.Enabled = true;
                btnXoa.Enabled = true;

                cbbMaPhanLoai.Enabled = false;
                txtTenBBG.Enabled = false;
                txtDonGia.Enabled = false;
                txtGhiChu.Enabled = false;


                txtMaBBG.Text = String.Empty;
                txtTenBBG.Text = String.Empty;
                txtDonGia.Text = String.Empty;
                txtGhiChu.Text = String.Empty;
            }
        }

        public void LoadGridViewBangBaoGia()
        {
            var bangbaogia = from bbg in qltb.BANGBAOGIAs
                         select new { bbg.MABG, bbg.MAPHANLOAI, bbg.TENBAOGIA, bbg.DONGIA, bbg.GHICHUBAOGIA };
            dtgvBangBaoGia.DataSource = bangbaogia;
        }

        private void frmDanhMucGia_Load(object sender, EventArgs e)
        {
            cbbMaPhanLoai.Enabled = false;
            txtTenBBG.Enabled = false;
            txtDonGia.Enabled = false;
            txtGhiChu.Enabled = false;

            LoadGridViewBangBaoGia();
            LoadCbbMaPhanLoai();
        }

        public void LoadCbbMaPhanLoai()
        {
            cbbMaPhanLoai.DataSource = qltb.PHANLOAIs;
            cbbMaPhanLoai.DisplayMember = "TENPHANLOAI";
            cbbMaPhanLoai.ValueMember = "MAPHANLOAI";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string mabbg = dtgvBangBaoGia.CurrentRow.Cells[0].Value.ToString();
                    BANGBAOGIA bbg = qltb.BANGBAOGIAs.Where(t => t.MABG == mabbg).FirstOrDefault();
                    qltb.BANGBAOGIAs.DeleteOnSubmit(bbg);
                    qltb.SubmitChanges();
                    LoadGridViewBangBaoGia();
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

        private void dtgvBangBaoGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbbMaPhanLoai.Enabled = false;
                txtTenBBG.Enabled = false;
                txtDonGia.Enabled = false;
                txtGhiChu.Enabled = false;

                txtMaBBG.Text = dtgvBangBaoGia.CurrentRow.Cells[0].Value.ToString();
                cbbMaPhanLoai.Text = dtgvBangBaoGia.CurrentRow.Cells[1].Value.ToString();
                txtTenBBG.Text = dtgvBangBaoGia.CurrentRow.Cells[2].Value.ToString();
                txtDonGia.Text = dtgvBangBaoGia.CurrentRow.Cells[3].Value.ToString();
                txtGhiChu.Text = dtgvBangBaoGia.CurrentRow.Cells[4].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Report.DanhMucGia_Report report = new Report.DanhMucGia_Report();
            ReportPrintTool rpt = new ReportPrintTool(report);
            report.CreateDocument(false);
            report.ShowPreviewDialog();
        }
    }
}