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
    public partial class frmThongTinNhaSanXuat : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmThongTinNhaSanXuat()
        {
            InitializeComponent();
        }
        TangMa tm = new TangMa();

        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (frmDanhMucNSX.tos == true)
            {
                NHASANXUAT nsx = new NHASANXUAT();
                //nsx.MANSX = txtMaNhaSanXuat.Text;
                nsx.MANSX = tm.ATTangMa3("NSX", "NHASANXUAT");
                nsx.TENNSX = txtTenNhaSanXuat.Text;
                nsx.GHICHUSX = txtDienGiai.Text;
                nsx.XOA = false;
                qltb.NHASANXUATs.InsertOnSubmit(nsx);
                qltb.SubmitChanges();
                MessageBox.Show("Success");
                loadDGVNSX();
                this.Close();
            }
            else
            {
                NHASANXUAT nsx = qltb.NHASANXUATs.Where(t => t.MANSX == frmDanhMucNSX.mnsx).FirstOrDefault();
                nsx.TENNSX = txtTenNhaSanXuat.Text;
                nsx.GHICHUSX= txtDienGiai.Text;
                qltb.SubmitChanges();
                MessageBox.Show("Sửa thành công");
                loadDGVNSX();
            }
        }
        void loadDGVNSX()
        {
            var nsx = from nsx1 in qltb.NHASANXUATs
                      select new { nsx1.MANSX, nsx1.TENNSX, nsx1.GHICHUSX };
            frmDanhMucNSX.dgvnsx.DataSource = nsx;
        }

        private void frmThongTinNhaSanXuat_Load(object sender, EventArgs e)
        {
            if (frmDanhMucNSX.tos == true)
            {
                btnLuu.Text = "Thêm";
                txtMaNhaSanXuat.Enabled = true;
            }
            else
            {
                btnLuu.Text = "Sửa";
                txtMaNhaSanXuat.Enabled = false;
                NHASANXUAT nsx = qltb.NHASANXUATs.Where(t => t.MANSX == frmDanhMucNSX.mnsx).FirstOrDefault();
                txtMaNhaSanXuat.Text = nsx.MANSX;
                txtTenNhaSanXuat.Text = nsx.TENNSX;
                txtDienGiai.Text = nsx.GHICHUSX;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}