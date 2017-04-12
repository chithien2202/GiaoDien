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
            dtgvbp = dtgvDSBoPhan;
        }
        public static DevExpress.XtraGrid.GridControl dtgvbp;

        public static bool tos;
        private void btnThem_Click(object sender, EventArgs e)
        {
            tos = true;
            Form frm=new frmThongTinBoPhan();
            frm.ShowDialog();
        }

        public static string mbp = "";
        private void btnSua_Click(object sender, EventArgs e)
        {
            tos = false;
            string mabp = dtgvDSBoPhan.MainView.GetRow(gridView1.GetSelectedRows()[0]).ToString().Split(',')[0].Trim();
            mbp = mabp.Split(' ')[3].Trim();
            Form frm = new frmThongTinBoPhan();
            frm.ShowDialog();
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
            LoadGridViewBoPhan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string mabp = dtgvDSBoPhan.MainView.GetRow(gridView1.GetSelectedRows()[0]).ToString().Split(',')[0].Trim();
                    string ma = mabp.Split(' ')[3].Trim();
                    BOPHAN bophan = qltb.BOPHANs.Where(t => t.MABOPHAN == ma).FirstOrDefault();
                    qltb.BOPHANs.DeleteOnSubmit(bophan);
                    qltb.SubmitChanges();
                    MessageBox.Show("Delete Success!");
                    LoadGridViewBoPhan();
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
    }
}