using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class frmThongTinModel : Form
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmThongTinModel()
        {
            InitializeComponent();
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

        private void frmThongTinModel_Load(object sender, EventArgs e)
        {
            LoadNhaSanXuat();
            LoadLoai();
            if (frmDanhMucModel.tos == true)
            {
                btnLuu.Text = "Thêm";
                txtMaModel.Enabled = true;
                cbbNhaSanXuat.Enabled = true;
            }
            else
            {
                btnLuu.Text = "Sửa";
                txtMaModel.Enabled = false;
                MODEL model = qltb.MODELs.Where(t => t.MAMODEL == frmDanhMucModel.mamd).FirstOrDefault();
                txtMaModel.Text = model.MAMODEL;
                txtTenModel.Text = model.TENMODEL;
                cbbLoai.Text = model.THUOC_LOAI;
                txtDienGiai.Text = model.GHICHUMODEL;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (frmDanhMucModel.tos == true)
            {
                MODEL model = new MODEL();
                model.MAMODEL = TangMa.ATTangMa2("MD", "MODEL");
                model.MANSX = cbbNhaSanXuat.SelectedValue.ToString();
                model.TENMODEL = txtTenModel.Text;
                model.THUOC_LOAI = cbbLoai.SelectedValue.ToString();
                model.GHICHUMODEL = txtDienGiai.Text;
                qltb.MODELs.InsertOnSubmit(model);
                qltb.SubmitChanges();
                MessageBox.Show("Success");
                LoadModel();
                this.Close();
            }
            else
            {
                string mamodel = frmDanhMucModel.dgvmodel.CurrentRow.Cells[0].Value.ToString();
                MODEL md = qltb.MODELs.Where(t => t.MAMODEL == mamodel).FirstOrDefault();
                //md.MAMODEL = txtMaModel.Text;
                //md.MANSX = cbbLoai.Text;
                md.THUOC_LOAI = cbbLoai.Text;
                md.GHICHUMODEL = txtDienGiai.Text;
                qltb.SubmitChanges();
                LoadModel();
            }
            
        }

        public void LoadModel()
        {
            var model = from md in qltb.MODELs
                        select new { md.MAMODEL, md.MANSX, md.TENMODEL, md.THUOC_LOAI, md.GHICHUMODEL };
            frmDanhMucModel.dgvmodel.DataSource = model;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
