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
    public partial class frmNhomNguoiDUng : DevExpress.XtraEditors.XtraForm
    {
      QLTBDataContext qltb = new QLTBDataContext();
   
        public frmNhomNguoiDUng()
        {
            InitializeComponent();
            dgvnhomnd = dtgvnhomnguoidung;
        }
         public static DataGridView dgvnhomnd;

        public static bool tos;
        public static string manhomnd = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmNhomNguoiDUng_Load(object sender, EventArgs e)
        {
            LoadGridviewnhomnguoidung();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            tos = true;
            Form frm = new frmThongTinNhomNguoiDung();
            frm.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            tos = false;
            string manhomnd1 = dtgvnhomnguoidung.CurrentRow.Cells[0].Value.ToString();

            manhomnd = manhomnd1.Trim();
            Form frm = new frmThongTinNhomNguoiDung();
            frm.ShowDialog();
        }
        public void LoadGridviewnhomnguoidung()
        {
            var nhomnd = from md in qltb.NHOMNGUOIDUNGs
                            select new { md.MANHOM, md.TENNHOM, md.GHICHU };
            dtgvnhomnguoidung.DataSource = nhomnd;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                string manhomnd = dtgvnhomnguoidung.CurrentRow.Cells[0].Value.ToString();
                NHOMNGUOIDUNG nhomnd = qltb.NHOMNGUOIDUNGs.Where(t => t.MANHOM == manhomnd).FirstOrDefault();
                qltb.NHOMNGUOIDUNGs.DeleteOnSubmit(nhomnd);
                qltb.SubmitChanges();
                MessageBox.Show("Delete Success!");
                LoadGridviewnhomnguoidung();
            }

            if (dr == DialogResult.No)
            {
                this.Close();
            }
        }
        

     
    }
}