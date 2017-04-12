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
using System.Windows;

namespace DXApplication1
{
    public partial class frmDanhMucModel : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucModel()
        {
            InitializeComponent();
            dgvmodel = dtgvDSModel;
        }
        public static DataGridView dgvmodel;

        public static bool tos;
        private void btnThem_Click(object sender, EventArgs e)
        {
            tos = true;
            Form frm = new frmThongTinModel();
            frm.ShowDialog();
        }

        public static string mamd = "";

        private void btnSua_Click(object sender, EventArgs e)
        {
            tos = false;
            string mamodel = dtgvDSModel.CurrentRow.Cells[0].Value.ToString();
            //MODEL md = qltb.MODELs.Where(t => t.MAMODEL == mamodel).FirstOrDefault();
            mamd = mamodel.Trim();
            Form frm = new frmThongTinModel();
            frm.ShowDialog();
        }

        public void LoadGridviewModel()
        {
            var model = from md in qltb.MODELs
                        select new { md.MAMODEL, md.MANSX, md.TENMODEL, md.THUOC_LOAI, md.GHICHUMODEL };
            dtgvDSModel.DataSource = model;
        }

        private void frmDanhMucModel_Load(object sender, EventArgs e)
        {
            LoadGridviewModel();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                string mamodel = dtgvDSModel.CurrentRow.Cells[0].Value.ToString();
                MODEL model = qltb.MODELs.Where(t => t.MAMODEL == mamodel).FirstOrDefault();
                qltb.MODELs.DeleteOnSubmit(model);
                qltb.SubmitChanges();
                MessageBox.Show("Delete Success!");
                LoadGridviewModel();
            }

            if (dr == DialogResult.No)

            {
                this.Close();
            }     
               
        }
    }
}