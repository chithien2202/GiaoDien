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

namespace DXApplication1
{
    public partial class frmDanhMucNSX : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucNSX()
        {
            InitializeComponent();
            dgvnsx = dtgvNhaSanXuat;
            
        }
        public static DevExpress.XtraGrid.GridControl dgvnsx;


        public static bool tos;

        private void btnThem_Click(object sender, EventArgs e)
        {
            tos = true;
            Form frm = new frmThongTinNhaSanXuat();
            frm.ShowDialog();
            
        }

        public static string mnsx = "";
        private void btnSua_Click(object sender, EventArgs e)
        {
            tos = false;
            string mansx = dtgvNhaSanXuat.MainView.GetRow(gridView1.GetSelectedRows()[0]).ToString().Split(',')[0].Trim();
            mnsx = mansx.Split(' ')[3].Trim();
            Form frm = new frmThongTinNhaSanXuat();
            frm.ShowDialog();
            
        }

        void LoadGridViewNSX()
        {
            var nsx = from nsx1 in qltb.NHASANXUATs
                      select new { nsx1.MANSX, nsx1.TENNSX, nsx1.GHICHUSX };
            dtgvNhaSanXuat.DataSource = nsx;
        }
        private void frmDanhMucNSX_Load(object sender, EventArgs e)
        {
            LoadGridViewNSX();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string mansx = dtgvNhaSanXuat.MainView.GetRow(gridView1.GetSelectedRows()[0]).ToString().Split(',')[0].Trim();
                    string ma = mansx.Split(' ')[3].Trim();
                    NHASANXUAT nsx = qltb.NHASANXUATs.Where(t => t.MANSX == ma).FirstOrDefault();
                    qltb.NHASANXUATs.DeleteOnSubmit(nsx);
                    qltb.SubmitChanges();
                    MessageBox.Show("Delete Success!");
                    LoadGridViewNSX();
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}