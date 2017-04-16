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
    public partial class frmDanhMucThietBi : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucThietBi()
        {
            InitializeComponent();
           // dtgvtb = dtgvDSThietBi;
        }

        //public static DevExpress.XtraGrid.GridControl dtgvtb;

        public static bool tos;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                cbbMaModel.Enabled = true;
                txtSoSerial.Enabled = true;
                txtTenThietBi.Enabled = true;
                dtpNgayMua.Enabled = true;
                dtpNgayHetBH.Enabled = true;
                txtDienGiai.Enabled = true;

                txtDienGiai.Text = String.Empty;
                txtSoSerial.Text = String.Empty;
                txtTenThietBi.Text = String.Empty;


                btnThem.Text = "Lưu";
            }
            else
            {
                THIETBI thietbi = new THIETBI();
                thietbi.MATHIETBI = TangMa.ATTangMa2("TB", "THIETBI");
                thietbi.MAMODEL = cbbMaModel.Text;
                thietbi.SERIAL = txtSoSerial.Text;
                thietbi.TENTHIETBI = txtTenThietBi.Text;
                thietbi.NGAYMUA_SUACHUA = dtpNgayMua.Value;
                thietbi.NGAYKETTHUC = dtpNgayHetBH.Value;
                qltb.THIETBIs.InsertOnSubmit(thietbi);
                qltb.SubmitChanges();
                LoadGridViewThietBi();
                MessageBox.Show("Success");


                btnThem.Text = "Thêm";
                cbbMaModel.Enabled = false;
                txtSoSerial.Enabled = false;
                txtTenThietBi.Enabled = false;
                dtpNgayMua.Enabled = false;
                dtpNgayHetBH.Enabled = false;
                txtDienGiai.Enabled = false;


                txtDienGiai.Text = String.Empty;
                txtSoSerial.Text = String.Empty;
                txtTenThietBi.Text = String.Empty;
            }
        }

        public static string mtb = "";
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {

                cbbMaModel.Enabled = true;
                txtSoSerial.Enabled = true;
                txtTenThietBi.Enabled = true;
                dtpNgayMua.Enabled = true;
                dtpNgayHetBH.Enabled = true;
                txtDienGiai.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string matb = dtgvDSThietBi.CurrentRow.Cells[0].Value.ToString();
                THIETBI thietbi = qltb.THIETBIs.Where(t => t.MATHIETBI == matb).FirstOrDefault();
                thietbi.MAMODEL = cbbMaModel.Text;
                thietbi.SERIAL = txtSoSerial.Text;
                thietbi.TENTHIETBI = txtTenThietBi.Text;
                thietbi.NGAYMUA_SUACHUA = dtpNgayMua.Value;
                thietbi.NGAYKETTHUC = dtpNgayHetBH.Value;
                thietbi.GHICHUTHIETBI = txtDienGiai.Text;
                qltb.SubmitChanges();
                LoadGridViewThietBi();
                MessageBox.Show("Sửa thành công");
                

                btnSua.Text = "Sửa";
                cbbMaModel.Enabled = false;
                txtSoSerial.Enabled = false;
                txtTenThietBi.Enabled = false;
                dtpNgayMua.Enabled = false;
                dtpNgayHetBH.Enabled = false;
                txtDienGiai.Enabled = false;

                txtDienGiai.Text = String.Empty;
                txtSoSerial.Text = String.Empty;
                txtTenThietBi.Text = String.Empty;
            }
        }

        // load data thiet bi len gridview
        private void LoadGridViewThietBi()
        {
            var thietbi = from tb in qltb.THIETBIs
                          select new { tb.MATHIETBI, tb.MAMODEL, tb.SERIAL, tb.TENTHIETBI, tb.NGAYMUA_SUACHUA, tb.NGAYKETTHUC, tb.GHICHUTHIETBI };
            dtgvDSThietBi.DataSource = thietbi;
        }
        private void frmDanhMucThietBi_Load(object sender, EventArgs e)
        {
            cbbMaModel.Enabled = false;
            txtSoSerial.Enabled = false;
            txtTenThietBi.Enabled = false;
            dtpNgayMua.Enabled = false;
            dtpNgayHetBH.Enabled = false;
            txtDienGiai.Enabled = false;

            LoadGridViewThietBi();
            LoadcbbMaModel();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string mantb = dtgvDSThietBi.CurrentRow.Cells[0].Value.ToString();
                    THIETBI thietbi = qltb.THIETBIs.Where(t => t.MATHIETBI == mantb).FirstOrDefault();
                    qltb.THIETBIs.DeleteOnSubmit(thietbi);
                    qltb.SubmitChanges();
                    LoadGridViewThietBi();
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

        private void dtgvDSThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbbMaModel.Enabled = false;
                txtSoSerial.Enabled = false;
                txtTenThietBi.Enabled = false;
                dtpNgayMua.Enabled = false;
                dtpNgayHetBH.Enabled = false;
                txtDienGiai.Enabled = false;
                cbbMaModel.Text = dtgvDSThietBi.CurrentRow.Cells[1].Value.ToString();
                txtSoSerial.Text = dtgvDSThietBi.CurrentRow.Cells[2].Value.ToString();
                txtTenThietBi.Text = dtgvDSThietBi.CurrentRow.Cells[3].Value.ToString();
                dtpNgayMua.Text = dtgvDSThietBi.CurrentRow.Cells[4].Value.ToString();
                dtpNgayHetBH.Text = dtgvDSThietBi.CurrentRow.Cells[5].Value.ToString();
                txtDienGiai.Text = dtgvDSThietBi.CurrentRow.Cells[6].Value.ToString();
            }
            catch { }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadcbbMaModel()
        {
            cbbMaModel.DataSource = qltb.MODELs;
            cbbMaModel.DisplayMember = "MAMODEL";
            cbbMaModel.ValueMember = "MAMODEL";
        }
    }
}