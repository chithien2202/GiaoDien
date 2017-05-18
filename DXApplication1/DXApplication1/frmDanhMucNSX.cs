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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;

namespace DXApplication1
{
    public partial class frmDanhMucNSX : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
        public frmDanhMucNSX()
        {
            InitializeComponent();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                txtTenNhaSanXuat.Enabled = true;
                txtDienGiai.Enabled = true;

                txtTenNhaSanXuat.Text = String.Empty;
                txtDienGiai.Text = String.Empty;

                btnThem.Text = "Lưu";
            }
            else
            {
                if (txtTenNhaSanXuat.Text == String.Empty)
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    NHASANXUAT nhasanxuat = new NHASANXUAT();
                    //nhasanxuat.MANSX = TangMa.ATTangMa3("NSX", "NHASANXUAT");
                    nhasanxuat.MANSX = tangma.ThemMaNSX();
                    nhasanxuat.TENNSX = txtTenNhaSanXuat.Text;
                    if (txtDienGiai.Text == null)
                    {
                        nhasanxuat.GHICHUSX = txtDienGiai.Text = "";
                    }
                    else
                    {
                        nhasanxuat.GHICHUSX = txtDienGiai.Text;
                    }
                    qltb.NHASANXUATs.InsertOnSubmit(nhasanxuat);
                    qltb.SubmitChanges();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");
                    LoadGridViewNSX();

                    btnThem.Text = "Thêm";
                    txtTenNhaSanXuat.Enabled = false;
                    txtDienGiai.Enabled = false;


                    txtTenNhaSanXuat.Text = String.Empty;
                    txtDienGiai.Text = String.Empty;
                }
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {

                txtTenNhaSanXuat.Enabled = true;
                txtDienGiai.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string mansx = dtgvNhaSanXuat.CurrentRow.Cells[0].Value.ToString();
                NHASANXUAT nsx = qltb.NHASANXUATs.Where(t => t.MANSX == mansx).FirstOrDefault();
                nsx.TENNSX = txtTenNhaSanXuat.Text;
                nsx.GHICHUSX = txtDienGiai.Text;
                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công","Thông báo");
                LoadGridViewNSX();

                btnSua.Text = "Sửa";
                txtTenNhaSanXuat.Enabled = false;
                txtDienGiai.Enabled = false;

                txtTenNhaSanXuat.Text = String.Empty;
                txtDienGiai.Text = String.Empty;
            }

        }

        void LoadGridViewNSX()
        {
            var nsx = from nsx1 in qltb.NHASANXUATs
                      select new { nsx1.MANSX, nsx1.TENNSX, nsx1.GHICHUSX };
            dtgvNhaSanXuat.DataSource = nsx;
        }
        private void frmDanhMucNSX_Load(object sender, EventArgs e)
        {
            txtTenNhaSanXuat.Enabled = false;
            txtDienGiai.Enabled = false;
            LoadGridViewNSX();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string mansx = dtgvNhaSanXuat.CurrentRow.Cells[0].Value.ToString();
                    NHASANXUAT nsx = qltb.NHASANXUATs.Where(t => t.MANSX == mansx).FirstOrDefault();
                    qltb.NHASANXUATs.DeleteOnSubmit(nsx);
                    qltb.SubmitChanges();
                    LoadGridViewNSX();
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvNhaSanXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtTenNhaSanXuat.Enabled = false;
                txtDienGiai.Enabled = false;
                txtTenNhaSanXuat.Text = dtgvNhaSanXuat.CurrentRow.Cells[1].Value.ToString();
                txtDienGiai.Text = dtgvNhaSanXuat.CurrentRow.Cells[2].Value.ToString();
            }
            catch { }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Report.DanhMucNSX_Report report = new Report.DanhMucNSX_Report();
            ReportPrintTool rpt = new ReportPrintTool(report);
            report.CreateDocument(false);
            report.ShowPreviewDialog();
        }
    }
}