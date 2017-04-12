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
    public partial class frmDanhMucLinhKien : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucLinhKien()
        {
            InitializeComponent();
            dtgvlk = dtgvDSLinhKien;
        }

        public static DevExpress.XtraGrid.GridControl dtgvlk;

        public static bool tos;
        private void btnThem_Click(object sender, EventArgs e)
        {
            tos = true;
            Form frm = new frmThongTinLinhKien();
            frm.ShowDialog();
        }

        public static string mlk = "";
        private void btnSua_Click(object sender, EventArgs e)
        {
            tos = false;
            string malk = dtgvDSLinhKien.MainView.GetRow(gridView1.GetSelectedRows()[0]).ToString().Split(',')[0].Trim();
            mlk = malk.Split(' ')[3].Trim();
            Form frm = new frmThongTinLinhKien();
            frm.ShowDialog();
        }

        private void LoadGridViewLinhKien()
        {
            var linhkien = from lk in qltb.LINHKIENs
                           select new { lk.MALINHKIEN, lk.MATHIETBI, lk.TENLINHKIEN, lk.NGAYSX, lk.NGAYKETTHUC, lk.NGAYMUA_SUACHUA, lk.DONGIA, lk.GHICHULINHKIEN };
            dtgvDSLinhKien.DataSource = linhkien;
        }

        private void frmDanhMucLinhKien_Load(object sender, EventArgs e)
        {
            LoadGridViewLinhKien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string malk = dtgvDSLinhKien.MainView.GetRow(gridView1.GetSelectedRows()[0]).ToString().Split(',')[0].Trim();
                    string ma = malk.Split(' ')[3].Trim();
                    LINHKIEN lk = qltb.LINHKIENs.Where(t => t.MALINHKIEN == ma).FirstOrDefault();
                    qltb.LINHKIENs.DeleteOnSubmit(lk);
                    qltb.SubmitChanges();
                    MessageBox.Show("Delete Success!");
                    LoadGridViewLinhKien();
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