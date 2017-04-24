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
    public partial class frmMangHinh : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmMangHinh()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {

                txtTenMangHinh.Enabled = true;
                txtTenMangHinh.Text = String.Empty;

                btnThem.Text = "Lưu";
            }
            else
            {
                MANHINH mh = new MANHINH();
                mh.MaManHinh = TangMa.ATTangMa2("MH", "MANHINH");
                mh.TenManHinh = txtTenMangHinh.Text;


                qltb.MANHINHs.InsertOnSubmit(mh);
                qltb.SubmitChanges();
                XtraMessageBox.Show("Thêm thành công","Thông báo");
                LoadGridViewMangHinh();

                btnThem.Text = "Thêm";
                txtTenMangHinh.Enabled = false;


                txtTenMangHinh.Text = String.Empty;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {

                txtTenMangHinh.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string mamh = dtgvMangHinh.CurrentRow.Cells[0].Value.ToString();
                MANHINH mh = qltb.MANHINHs.Where(t => t.MaManHinh == mamh).FirstOrDefault();
                mh.TenManHinh = txtTenMangHinh.Text;

                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công","Thông báo");
                LoadGridViewMangHinh();

                btnSua.Text = "Sửa";
                txtTenMangHinh.Enabled = false;

                txtTenMangHinh.Text = String.Empty;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                string mamh = dtgvMangHinh.CurrentRow.Cells[0].Value.ToString();
                MANHINH mh = qltb.MANHINHs.Where(t => t.MaManHinh == mamh).FirstOrDefault();
                qltb.MANHINHs.DeleteOnSubmit(mh);
                qltb.SubmitChanges();
                XtraMessageBox.Show("Xóa thành công","Thông báo");
                LoadGridViewMangHinh();
            }

            if (dr == DialogResult.No)
            {
                this.Close();
            }
        }

        public void LoadGridViewMangHinh()
        {
            var manhinh = from mh in qltb.MANHINHs
                         select new { mh.MaManHinh, mh.TenManHinh };
            dtgvMangHinh.DataSource = manhinh;
        }

        private void dtgvMangHinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtTenMangHinh.Enabled = false;

                txtTenMangHinh.Text = dtgvMangHinh.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
        }

        private void frmMangHinh_Load(object sender, EventArgs e)
        {
            LoadGridViewMangHinh();
            txtTenMangHinh.Enabled = false;
        }
    }
}