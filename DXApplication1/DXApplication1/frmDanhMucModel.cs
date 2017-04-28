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
        TangMa tangma = new TangMa();
        public frmDanhMucModel()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                cbbNhaSanXuat.Enabled = true;
                txtTenModel.Enabled = true;
                cbbLoai.Enabled = true;
                txtDienGiai.Enabled = true;

                txtTenModel.Text = String.Empty;
                txtDienGiai.Text = String.Empty;

                btnThem.Text = "Lưu";
            }
            else
            {
                if (txtTenModel.Text == String.Empty)
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    MODEL model = new MODEL();
                    //model.MAMODEL = TangMa.ATTangMa2("MD", "MODEL");
                    model.MAMODEL = tangma.ThemMaModel();
                    model.MANSX = cbbNhaSanXuat.SelectedValue.ToString();
                    model.TENMODEL = txtTenModel.Text;
                    model.THUOC_LOAI = cbbLoai.SelectedValue.ToString();
                    if (txtDienGiai.Text == null)
                    {
                        model.GHICHUMODEL = txtDienGiai.Text = "";
                    }
                    else
                    {
                        model.GHICHUMODEL = txtDienGiai.Text;
                    }
                    qltb.MODELs.InsertOnSubmit(model);
                    qltb.SubmitChanges();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");
                    LoadGridviewModel();

                    btnThem.Text = "Thêm";
                    cbbNhaSanXuat.Enabled = false;
                    txtTenModel.Enabled = false;
                    cbbLoai.Enabled = false;
                    txtDienGiai.Enabled = false;

                    txtTenModel.Text = String.Empty;
                    txtDienGiai.Text = String.Empty;
                }
            }
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
 
                cbbNhaSanXuat.Enabled = false;
                txtTenModel.Enabled = true;
                cbbLoai.Enabled = true;
                txtDienGiai.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string mamd = dtgvDSModel.CurrentRow.Cells[0].Value.ToString();
                MODEL md = qltb.MODELs.Where(t => t.MAMODEL ==mamd ).FirstOrDefault();
                md.TENMODEL = txtTenModel.Text;
                md.THUOC_LOAI = cbbLoai.Text;
                md.GHICHUMODEL = txtDienGiai.Text;
                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công","Thông báo");
                LoadGridviewModel();

                btnSua.Text = "Sửa";
                cbbNhaSanXuat.Enabled = false;
                txtTenModel.Enabled = false;
                cbbLoai.Enabled = false;
                txtDienGiai.Enabled = false;

                txtTenModel.Text = String.Empty;
                txtDienGiai.Text = String.Empty;
            }

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
            LoadNhaSanXuat();
            LoadLoai();

            cbbNhaSanXuat.Enabled = false;
            txtTenModel.Enabled = false;
            cbbLoai.Enabled = false;
            txtDienGiai.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                string mamodel = dtgvDSModel.CurrentRow.Cells[0].Value.ToString();
                MODEL model = qltb.MODELs.Where(t => t.MAMODEL == mamodel).FirstOrDefault();
                qltb.MODELs.DeleteOnSubmit(model);
                qltb.SubmitChanges();
                XtraMessageBox.Show("Xóa thành công","Thông báo");
                LoadGridviewModel();
            }

            if (dr == DialogResult.No)

            {
                this.Close();
            }

        }

        private void LoadNhaSanXuat()
        {
            cbbNhaSanXuat.DataSource = qltb.NHASANXUATs;
            cbbNhaSanXuat.DisplayMember = "TENNSX";
            cbbNhaSanXuat.ValueMember = "MANSX";
        }

        private void LoadLoai()
        {
            cbbLoai.DataSource = qltb.PHANLOAIs;
            cbbLoai.DisplayMember = "TENPHANLOAI";
            cbbLoai.ValueMember = "TENPHANLOAI";
        }

        private void dtgvDSModel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //String mamd = dtgvDSModel.CurrentRow.Cells[0].Value.ToString();
                //dtgvDSModel.DataSource = qltb.MODELs.Where(t => t.MAMODEL == mamd);
                cbbNhaSanXuat.Enabled = false;
                cbbLoai.Enabled = false;
                txtTenModel.Enabled = false;
                txtDienGiai.Enabled = false;
                cbbLoai.Text = dtgvDSModel.CurrentRow.Cells[3].Value.ToString();
                txtTenModel.Text = dtgvDSModel.CurrentRow.Cells[2].Value.ToString();
                txtDienGiai.Text = dtgvDSModel.CurrentRow.Cells[4].Value.ToString();
                cbbNhaSanXuat.Text = dtgvDSModel.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
        }
    }
}