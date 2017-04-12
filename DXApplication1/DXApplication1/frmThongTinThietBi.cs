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
    public partial class frmThongTinThietBi : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmThongTinThietBi()
        {
            InitializeComponent();
        }

        //load cbb ma model
        private void LoadcbbMaModel()
        {
            cbbMaModel.DataSource = qltb.MODELs;
            cbbMaModel.DisplayMember = "MAMODEL";
            cbbMaModel.ValueMember = "MAMODEL";
        }

        private void frmThongTinThietBi_Load(object sender, EventArgs e)
        {
            LoadcbbMaModel();
            if (frmDanhMucThietBi.tos == true)
            {
                cbbMaModel.Enabled = true;
                txtMaThietBi.Enabled = true;
                btnLuu.Text = "Thêm";
            }
            else
            {
                btnLuu.Text = "Sửa";
                txtMaThietBi.Enabled = false;
                cbbMaModel.Enabled = false;
                THIETBI tb = qltb.THIETBIs.Where(t => t.MATHIETBI == frmDanhMucThietBi.mtb).FirstOrDefault();
                cbbMaModel.Text = tb.MAMODEL;
                txtMaThietBi.Text = tb.MATHIETBI;
                txtSoSerial.Text = tb.SERIAL;
                txtTenThietBi.Text = tb.TENTHIETBI;
                dtpNgayMua.Text = tb.NGAYMUA_SUACHUA.ToString();
                dtpNgayHetBH.Text = tb.NGAYKETTHUC.ToString();
                txtDienGiai.Text = tb.GHICHUTHIETBI;
            }
        }

        //code them thiet bi
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (frmDanhMucThietBi.tos == true)
            {
                THIETBI tb = new THIETBI();
                tb.MATHIETBI = TangMa.ATTangMa2("TB", "THIETBI");
                tb.MAMODEL = cbbMaModel.SelectedValue.ToString();
                tb.SERIAL = txtSoSerial.Text;
                tb.TENTHIETBI = txtTenThietBi.Text;
                tb.NGAYMUA_SUACHUA = dtpNgayMua.Value;
                tb.NGAYKETTHUC = dtpNgayHetBH.Value;
                tb.GHICHUTHIETBI = txtDienGiai.Text;
                qltb.THIETBIs.InsertOnSubmit(tb);
                qltb.SubmitChanges();
                MessageBox.Show("Success");
                LoadThietBi();
                this.Close();
            }
            else
            {
                THIETBI tb = qltb.THIETBIs.Where(t => t.MATHIETBI == frmDanhMucThietBi.mtb).FirstOrDefault();
                tb.SERIAL = txtSoSerial.Text;
                tb.NGAYMUA_SUACHUA = dtpNgayMua.Value;
                tb.NGAYKETTHUC = dtpNgayHetBH.Value;
                tb.GHICHUTHIETBI = txtDienGiai.Text;
                qltb.SubmitChanges();
                MessageBox.Show("Sửa thành công");
                LoadThietBi();
                this.Close();
            }
        }

        //Load laij gridview thiet bi
        public void LoadThietBi()
        {
            var thietbi = from tb in qltb.THIETBIs
                     select new { tb.MATHIETBI, tb.MAMODEL, tb.SERIAL, tb.TENTHIETBI, tb.NGAYMUA_SUACHUA, tb.NGAYKETTHUC, tb.GHICHUTHIETBI };
            frmDanhMucThietBi.dtgvtb.DataSource = thietbi;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}