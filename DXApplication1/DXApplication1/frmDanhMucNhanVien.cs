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
    public partial class frmDanhMucNhanVien : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucNhanVien()
        {
            InitializeComponent();
            dgvnhanvien = dtgvnhanvien;
        }
        public static DataGridView dgvnhanvien;

        public static bool tos;
        public static string manv = "";
        private void btnThem_Click(object sender, EventArgs e)
        {
            tos = true;
            Form frm = new frmThongTinNhanVien();
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tos = false;
            string manhanvien = dtgvnhanvien.CurrentRow.Cells[0].Value.ToString();

            manv= manhanvien.Trim();
            Form frm = new frmThongTinNhanVien();
            frm.ShowDialog();
        }
        public void LoadGridviewnhanvien()
        {
            var nhanvien = from md in qltb.NHANVIENs
                            select new { md.MANHANVIEN, md.MABOPHAN, md.TENNHANVIEN, md.DIACHINV, md.EMAILNV, md.LUONG, md.GHICHU, md.SDTNV };
            dtgvnhanvien.DataSource = nhanvien;
        }

        private void frmDanhMucNhanVien_Load(object sender, EventArgs e)
        {
            LoadGridviewnhanvien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                string manhanvien = dtgvnhanvien.CurrentRow.Cells[0].Value.ToString();
                NHANVIEN nhanvien = qltb.NHANVIENs.Where(t => t.MANHANVIEN == manhanvien).FirstOrDefault();
                qltb.NHANVIENs.DeleteOnSubmit(nhanvien);
                qltb.SubmitChanges();
                MessageBox.Show("Xóa thành công!");
                LoadGridviewnhanvien();
            }

            if (dr == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}