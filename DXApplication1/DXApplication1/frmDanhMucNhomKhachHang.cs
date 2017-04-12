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
    public partial class frmDanhMucNhomKhachHang : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucNhomKhachHang()
        {
            InitializeComponent();
            dgvnhomkhachhang = dtgvnhomkhachhang;
        }
        public static DataGridView dgvnhomkhachhang;
        
        public static bool tos;
        public static string manhommkh = "";
        private void btnThem_Click(object sender, EventArgs e)
        {
            tos = true;
            Form frm = new frmThongTinNhomKhachHang();
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tos = false;
            string manhomkh = dtgvnhomkhachhang.CurrentRow.Cells[0].Value.ToString();
            manhommkh = manhomkh.Trim();
            Form frm = new frmThongTinNhomKhachHang();
            frm.ShowDialog();
        }
        public void LoadGridviewnhomkh()
        {
            var nhomkh = from nkh in qltb.NHOMKHACHHANGs
                            select new { nkh.MANHOMKH, nkh.TENNHOMKH, nkh.KHUYENMAI, nkh.GHICHU };
            dtgvnhomkhachhang.DataSource = nhomkh;
        }

        private void frmDanhMucNhomKhachHang_Load(object sender, EventArgs e)
        {
            LoadGridviewnhomkh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                string manhomkh = dtgvnhomkhachhang.CurrentRow.Cells[0].Value.ToString();
                NHOMKHACHHANG nhomkh = qltb.NHOMKHACHHANGs.Where(t => t.MANHOMKH == manhomkh).FirstOrDefault();
                qltb.NHOMKHACHHANGs.DeleteOnSubmit(nhomkh);
                qltb.SubmitChanges();
                MessageBox.Show("Delete Success!");
                LoadGridviewnhomkh();
            }

            if (dr == DialogResult.No)
            {
                this.Close();
            }

        }
    }
}