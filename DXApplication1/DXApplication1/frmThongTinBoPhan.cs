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
    public partial class frmThongTinBoPhan : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmThongTinBoPhan()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (frmDanhMucBoPhan.tos == true)
            {
                BOPHAN bp = new BOPHAN();
                bp.MABOPHAN = TangMa.ATTangMa2("BP", "BOPHAN");
                bp.TENBOPHAN = txtTenBoPhan.Text;
                bp.DIENGIAI = txtDienGiai.Text;

                qltb.BOPHANs.InsertOnSubmit(bp);
                qltb.SubmitChanges();
                MessageBox.Show("Success");
                LoadBoPhan();
                this.Close();
            }
            else
            {
                BOPHAN nsx = qltb.BOPHANs.Where(t => t.MABOPHAN == frmDanhMucBoPhan.mbp).FirstOrDefault();
                nsx.TENBOPHAN = txtTenBoPhan.Text;
                nsx.DIENGIAI = txtDienGiai.Text;
                qltb.SubmitChanges();
                MessageBox.Show("Sửa thành công");
                this.Close();
                LoadBoPhan();
            }
        }

        //load lai data
        public void LoadBoPhan()
        {
            var bophan = from bp in qltb.BOPHANs
                        select new { bp.MABOPHAN, bp.TENBOPHAN, bp.DIENGIAI };
            frmDanhMucBoPhan.dtgvbp.DataSource = bophan;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongTinBoPhan_Load(object sender, EventArgs e)
        {
            if(frmDanhMucBoPhan.tos==true)
            {
                txtMaBoPhan.Enabled = true;
                btnLuu.Text = "Thêm";
            }
            else
            {
                txtMaBoPhan.Enabled = false;
                btnLuu.Text = "Sửa";
                BOPHAN bophan = qltb.BOPHANs.Where(t => t.MABOPHAN == frmDanhMucBoPhan.mbp).FirstOrDefault();
                txtMaBoPhan.Text = bophan.MABOPHAN;
                txtTenBoPhan.Text = bophan.TENBOPHAN;
                txtDienGiai.Text = bophan.DIENGIAI;
            }
        }
    }
}