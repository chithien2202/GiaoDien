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
    public partial class frmDanhMucKhachHang : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucKhachHang()
        {
            InitializeComponent();
            dgvkhachang=dgtvKhachHang;
        }
        public static DataGridView dgvkhachang;

        public static bool tos;
        public static string makh = "";
        private void btnThem_Click(object sender, EventArgs e)
        {
            tos = true;
            Form frm = new frmThongTinKhachHang();
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tos = false;
            string makhachhang = dgtvKhachHang.CurrentRow.Cells[0].Value.ToString();

            makh = makhachhang.Trim();
            Form frm = new frmThongTinKhachHang();
            frm.ShowDialog();
        }
        public void LoadGridviewkhachhang()
        {
            var khachhang = from kh in qltb.KHACHHANGs
                            select new { kh.MAKHACHKHACH, kh.MANHOMKH, kh.TENKHACHHANG, kh.DIACHIKH, kh.EMAILKH, kh.FAX, kh.GHICHU, kh.SDTKH };
            dgtvKhachHang.DataSource = khachhang;
        }

        private void frmDanhMucKhachHang_Load(object sender, EventArgs e)
        {
            LoadGridviewkhachhang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                string makhachhang = dgtvKhachHang.CurrentRow.Cells[0].Value.ToString();
                KHACHHANG khachhang = qltb.KHACHHANGs.Where(t => t.MAKHACHKHACH == makhachhang).FirstOrDefault();
                qltb.KHACHHANGs.DeleteOnSubmit(khachhang);
                qltb.SubmitChanges();
                MessageBox.Show("Delete Success!");
                LoadGridviewkhachhang();
            }

            if (dr == DialogResult.No)
            {
                this.Close();
            }

        }
    }
}
