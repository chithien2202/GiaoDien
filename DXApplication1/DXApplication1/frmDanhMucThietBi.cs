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
    public partial class frmDanhMucThietBi : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucThietBi()
        {
            InitializeComponent();
            dtgvtb = dtgvDSThietBi;
        }

        public static DevExpress.XtraGrid.GridControl dtgvtb;

        public static bool tos;
        private void btnThem_Click(object sender, EventArgs e)
        {
            tos = true;
            Form frm = new frmThongTinThietBi();
            frm.ShowDialog();
        }

        public static string mtb = "";
        private void btnSua_Click(object sender, EventArgs e)
        {
            tos = false;
            string mantb = dtgvDSThietBi.MainView.GetRow(gridView1.GetSelectedRows()[0]).ToString().Split(',')[0].Trim();
            mtb = mantb.Split(' ')[3].Trim();
            Form frm = new frmThongTinThietBi();
            frm.ShowDialog();
        }

        // load data thiet bi len gridview
        private void LoadGridViewThietBi()
        {
            var thietbi = from tb in qltb.THIETBIs
                          select new { tb.MATHIETBI, tb.MAMODEL, tb.SERIAL, tb.TENTHIETBI, tb.NGAYMUA_SUACHUA, tb.NGAYKETTHUC, tb.GHICHUTHIETBI };
            dtgvDSThietBi.DataSource = thietbi;
        }
        private void frmDanhMucThietBi_Load(object sender, EventArgs e)
        {
            LoadGridViewThietBi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string mantb = dtgvDSThietBi.MainView.GetRow(gridView1.GetSelectedRows()[0]).ToString().Split(',')[0].Trim();
                    string ma = mantb.Split(' ')[3].Trim();
                    THIETBI thietbi = qltb.THIETBIs.Where(t => t.MATHIETBI == ma).FirstOrDefault();
                    qltb.THIETBIs.DeleteOnSubmit(thietbi);
                    qltb.SubmitChanges();
                    MessageBox.Show("Delete Success!");
                    LoadGridViewThietBi();
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