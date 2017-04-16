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
            
        }



        public static bool tos;

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                txtTenNhaSanXuat.Enabled = true;
                txtDienGiai.Enabled = true;

                btnThem.Text = "Lưu";
            }
            else
            {
                NHASANXUAT nhasanxuat = new NHASANXUAT();
                nhasanxuat.MANSX = TangMa.ATTangMa3("NSX", "NHASANXUAT");
                nhasanxuat.TENNSX = txtTenNhaSanXuat.Text;
                nhasanxuat.GHICHUSX = txtDienGiai.Text;
                qltb.NHASANXUATs.InsertOnSubmit(nhasanxuat);
                qltb.SubmitChanges();
                MessageBox.Show("Success");
                LoadGridViewNSX();

                btnThem.Text = "Thêm";
                txtTenNhaSanXuat.Enabled = false;
                txtDienGiai.Enabled = false;


                txtTenNhaSanXuat.Text = String.Empty;
                txtDienGiai.Text = String.Empty;
            }

        }

        public static string mnsx = "";
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {

                txtTenNhaSanXuat.Enabled = true;
                txtDienGiai.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string mansx = dtgvNhaSanXuat.CurrentRow.Cells[0].Value.ToString();
                NHASANXUAT nsx = qltb.NHASANXUATs.Where(t => t.MANSX == mansx).FirstOrDefault();
                nsx.TENNSX = txtTenNhaSanXuat.Text;
                nsx.GHICHUSX = txtDienGiai.Text;
                qltb.SubmitChanges();
                MessageBox.Show("Sửa thành công");
                LoadGridViewNSX();

                btnSua.Text = "Sửa";
                txtTenNhaSanXuat.Enabled = false;
                txtDienGiai.Enabled = false;

                txtTenNhaSanXuat.Text = String.Empty;
                txtDienGiai.Text = String.Empty;
            }

        }

        void LoadGridViewNSX()
        {
            var nsx = from nsx1 in qltb.NHASANXUATs
                      select new { nsx1.MANSX, nsx1.TENNSX, nsx1.GHICHUSX };
            dtgvNhaSanXuat.DataSource = nsx;
        }
        private void frmDanhMucNSX_Load(object sender, EventArgs e)
        {
            txtTenNhaSanXuat.Enabled = false;
            txtDienGiai.Enabled = false;
            LoadGridViewNSX();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string mansx = dtgvNhaSanXuat.CurrentRow.Cells[0].Value.ToString();
                    NHASANXUAT nsx = qltb.NHASANXUATs.Where(t => t.MANSX == mansx).FirstOrDefault();
                    qltb.NHASANXUATs.DeleteOnSubmit(nsx);
                    qltb.SubmitChanges();
                    LoadGridViewNSX();
                    MessageBox.Show("Delete Success!");
                    
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

        private void dtgvNhaSanXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenNhaSanXuat.Enabled = false;
            txtDienGiai.Enabled = false;
            txtTenNhaSanXuat.Text = dtgvNhaSanXuat.CurrentRow.Cells[1].Value.ToString();
            txtDienGiai.Text = dtgvNhaSanXuat.CurrentRow.Cells[2].Value.ToString();
        }
    }
}