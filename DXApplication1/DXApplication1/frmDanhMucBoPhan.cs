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
    public partial class frmDanhMucBoPhan : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
        public frmDanhMucBoPhan()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                txtTenBoPhan.Enabled = true;
                txtDienGiai.Enabled = true;
                txtTenBoPhan.Text = String.Empty;
                txtDienGiai.Text = String.Empty;

                btnThem.Text = "Lưu";
            }
            
            else
            {
                if (txtTenBoPhan.Text == String.Empty)
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin","Thông báo");
                }
                else
                {
                    BOPHAN bophan = new BOPHAN();
                    bophan.MABOPHAN = tangma.ThemMaBoPhan();
                    bophan.TENBOPHAN = txtTenBoPhan.Text;
                    if (txtDienGiai.Text == null)
                    {
                        bophan.DIENGIAI = txtDienGiai.Text = "";
                    }
                    else
                    {
                        bophan.DIENGIAI = txtDienGiai.Text;
                    }
                    qltb.BOPHANs.InsertOnSubmit(bophan);
                    qltb.SubmitChanges();
                    LoadGridViewBoPhan();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");


                    btnThem.Text = "Thêm";
                    txtTenBoPhan.Enabled = false;
                    txtDienGiai.Enabled = false;


                    txtTenBoPhan.Text = String.Empty;
                    txtDienGiai.Text = String.Empty;
                }
            }
        }

        public static string mbp = "";
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {

                txtTenBoPhan.Enabled = true;
                txtDienGiai.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string mabp = dtgvDSBoPhan.CurrentRow.Cells[0].Value.ToString();
                BOPHAN nsx = qltb.BOPHANs.Where(t => t.MABOPHAN == mabp).FirstOrDefault();
                nsx.TENBOPHAN = txtTenBoPhan.Text;
                nsx.DIENGIAI = txtDienGiai.Text;
                qltb.SubmitChanges();
                LoadGridViewBoPhan();
                XtraMessageBox.Show("Sửa thành công","Thông báo");

                btnSua.Text = "Sửa";
                txtTenBoPhan.Enabled = false;
                txtDienGiai.Enabled = false;

                txtTenBoPhan.Text = String.Empty;
                txtDienGiai.Text = String.Empty;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //load gridviewbophan
        private void LoadGridViewBoPhan()
        {
            var bophan = from bp in qltb.BOPHANs
                         select new { bp.MABOPHAN, bp.TENBOPHAN, bp.DIENGIAI };
            dtgvDSBoPhan.DataSource = bophan;
        }

        private void frmDanhMucBoPhan_Load(object sender, EventArgs e)
        {
            txtTenBoPhan.Enabled = false;
            txtDienGiai.Enabled = false;

            LoadGridViewBoPhan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string mabp = dtgvDSBoPhan.CurrentRow.Cells[0].Value.ToString();
                    BOPHAN bophan = qltb.BOPHANs.Where(t => t.MABOPHAN == mabp).FirstOrDefault();
                    qltb.BOPHANs.DeleteOnSubmit(bophan);
                    qltb.SubmitChanges();
                    LoadGridViewBoPhan();
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

        private void dtgvDSBoPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtTenBoPhan.Enabled = false;
                txtDienGiai.Enabled = false;
                txtTenBoPhan.Text = dtgvDSBoPhan.CurrentRow.Cells[1].Value.ToString();
                txtDienGiai.Text = dtgvDSBoPhan.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Report.DanhMucBoPhan_Report report = new Report.DanhMucBoPhan_Report();
            ReportPrintTool rpt = new ReportPrintTool(report);
            report.CreateDocument(false);
            report.ShowPreviewDialog();
        }
    }
}