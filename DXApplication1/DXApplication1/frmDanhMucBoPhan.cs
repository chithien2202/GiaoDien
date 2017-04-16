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
    public partial class frmDanhMucBoPhan : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucBoPhan()
        {
            InitializeComponent();
            //dtgvbp = dtgvDSBoPhan;
        }
        //public static DevExpress.XtraGrid.GridControl dtgvbp;

        public static bool tos;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                txtTenBoPhan.Enabled = true;
                txtDienGiai.Enabled = true;

                btnThem.Text = "Lưu";
            }
            else
            {
                BOPHAN bophan = new BOPHAN();
                bophan.MABOPHAN = TangMa.ATTangMa2("BP", "BOPHAN");
                bophan.TENBOPHAN = txtTenBoPhan.Text;
                bophan.DIENGIAI = txtDienGiai.Text;
                qltb.BOPHANs.InsertOnSubmit(bophan);
                qltb.SubmitChanges();
                LoadGridViewBoPhan();
                MessageBox.Show("Success");
                

                btnThem.Text = "Thêm";
                txtTenBoPhan.Enabled = false;
                txtDienGiai.Enabled = false;


                txtTenBoPhan.Text = String.Empty;
                txtDienGiai.Text = String.Empty;
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
                MessageBox.Show("Sửa thành công");

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
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string mabp = dtgvDSBoPhan.CurrentRow.Cells[0].Value.ToString();
                    BOPHAN bophan = qltb.BOPHANs.Where(t => t.MABOPHAN == mabp).FirstOrDefault();
                    qltb.BOPHANs.DeleteOnSubmit(bophan);
                    qltb.SubmitChanges();
                    LoadGridViewBoPhan();
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
    }
}