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
    public partial class frmNhomNguoiDung : DevExpress.XtraEditors.XtraForm
    {
      QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
   
        public frmNhomNguoiDung()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                txtTenNhom.Enabled = true;
                txtDienGiai.Enabled = true;

                btnThem.Text = "Lưu";
            }
            else
            {
                NHOMNGUOIDUNG nhomnd = new NHOMNGUOIDUNG();
                //nhomnd.MANHOM = TangMa.ATTangMa3("NND", "NHOMNGUOIDUNG");
                nhomnd.MANHOM = tangma.ThemMaNhomNguoiDung();
                nhomnd.TENNHOM = txtTenNhom.Text;
                if (txtDienGiai.Text == null)
                {
                    nhomnd.GHICHU = txtDienGiai.Text = "";
                }
                else
                {
                    nhomnd.GHICHU = txtDienGiai.Text;
                }

                qltb.NHOMNGUOIDUNGs.InsertOnSubmit(nhomnd);
                qltb.SubmitChanges();
                XtraMessageBox.Show("Thêm thành công","Thông báo");
                LoadGridviewnhomnguoidung();

                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                btnThem.Text = "Thêm";
                txtTenNhom.Enabled = false;


                txtDienGiai.Enabled = false;

                txtTenNhom.Text = String.Empty;
                txtDienGiai.Text = String.Empty;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;

                txtTenNhom.Enabled = true;
                txtDienGiai.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string manhom = dtgvnhomnguoidung.CurrentRow.Cells[0].Value.ToString();
                NHOMNGUOIDUNG nhom = qltb.NHOMNGUOIDUNGs.Where(t => t.MANHOM == manhom).FirstOrDefault();
                nhom.TENNHOM = txtTenNhom.Text;

                nhom.GHICHU = txtDienGiai.Text;

                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công","Thông báo");
                LoadGridviewnhomnguoidung();

                btnThem.Enabled = true;
                btnXoa.Enabled = true;

                btnSua.Text = "Sửa";
                txtTenNhom.Enabled = false;
                txtDienGiai.Enabled = false;

                txtTenNhom.Text = String.Empty;
                txtDienGiai.Text = String.Empty;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                string manhomnd = dtgvnhomnguoidung.CurrentRow.Cells[0].Value.ToString();
                NHOMNGUOIDUNG nhomnd = qltb.NHOMNGUOIDUNGs.Where(t => t.MANHOM == manhomnd).FirstOrDefault();
                qltb.NHOMNGUOIDUNGs.DeleteOnSubmit(nhomnd);
                qltb.SubmitChanges();
                XtraMessageBox.Show("Xóa thành công","Thông báo");
                LoadGridviewnhomnguoidung();
            }

            if (dr == DialogResult.No)
            {
                this.Close();
            }
        }

        public void LoadGridviewnhomnguoidung()
        {
            var nhomnd = from md in qltb.NHOMNGUOIDUNGs
                         select new { md.MANHOM, md.TENNHOM, md.GHICHU };
            dtgvnhomnguoidung.DataSource = nhomnd;
        }

        private void dtgvnhomnguoidung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtTenNhom.Enabled = false;
                txtDienGiai.Enabled = false;

                txtTenNhom.Text = dtgvnhomnguoidung.CurrentRow.Cells[1].Value.ToString();
                txtDienGiai.Text = dtgvnhomnguoidung.CurrentRow.Cells[2].Value.ToString();
            }
            catch { }
        }

        private void frmNhomNguoiDUng_Load(object sender, EventArgs e)
        {
            LoadGridviewnhomnguoidung();
            txtTenNhom.Enabled = false;
            txtDienGiai.Enabled = false;
        }
    }
}