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
    public partial class frmThongTinLinhKien : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmThongTinLinhKien()
        {
            InitializeComponent();
        }
        //load cbb thiet bi
        private void LoadCbbThietBi()
        {
            cbbThietBi.DataSource = qltb.THIETBIs;
            cbbThietBi.DisplayMember = "TENTHIETBI";
            cbbThietBi.ValueMember = "MATHIETBI";
        }

        //viet code them linh kien
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (frmDanhMucLinhKien.tos == true)
            {
                LINHKIEN lk = new LINHKIEN();
                lk.MALINHKIEN = TangMa.ATTangMa2("LK", "LINHKIEN");
                lk.MATHIETBI = cbbThietBi.SelectedValue.ToString();
                lk.TENLINHKIEN = txtTenLinhKien.Text;
                lk.NGAYSX = dtpNgaySX.Value;
                lk.NGAYKETTHUC = dtpNgayHetBH.Value;
                lk.NGAYMUA_SUACHUA = dtpNgayMua.Value;
                lk.GHICHULINHKIEN = txtDienGiai.Text;
                qltb.LINHKIENs.InsertOnSubmit(lk);
                qltb.SubmitChanges();
                MessageBox.Show("Success");
                LoadLinhKien();
                this.Close();
            }
            else
            {
                LINHKIEN lk = qltb.LINHKIENs.Where(t => t.MALINHKIEN == frmDanhMucLinhKien.mlk).FirstOrDefault();
                lk.TENLINHKIEN = txtTenLinhKien.Text;
                lk.NGAYSX = dtpNgaySX.Value;
                lk.NGAYKETTHUC = dtpNgayHetBH.Value;
                lk.NGAYMUA_SUACHUA = dtpNgayMua.Value;
                lk.GHICHULINHKIEN = txtDienGiai.Text;
                qltb.SubmitChanges();
                MessageBox.Show("Sửa thành công");
                this.Close();
                LoadLinhKien();
            }
        }

        //load lai data cho gridview
        public void LoadLinhKien()
        {
            var linhkien = from lk in qltb.LINHKIENs
                           select new { lk.MALINHKIEN, lk.MATHIETBI, lk.TENLINHKIEN, lk.NGAYSX, lk.NGAYKETTHUC, lk.NGAYMUA_SUACHUA, lk.GHICHULINHKIEN };
            frmDanhMucLinhKien.dtgvlk.DataSource = linhkien;
        }

        private void frmThongTinLinhKien_Load(object sender, EventArgs e)
        {
            LoadCbbThietBi();
            if (frmDanhMucLinhKien.tos == true)
            {
                btnLuu.Text = "Thêm";
                txtMaLinhKien.Enabled = true;
            }
            else
            {
                btnLuu.Text = "Sửa";
                txtMaLinhKien.Enabled = false;
                cbbThietBi.Enabled = false;
                LINHKIEN lk = qltb.LINHKIENs.Where(t => t.MALINHKIEN == frmDanhMucLinhKien.mlk).FirstOrDefault();
                cbbThietBi.Text = lk.MATHIETBI;
                txtMaLinhKien.Text = lk.MALINHKIEN;
                txtTenLinhKien.Text = lk.TENLINHKIEN;
                dtpNgaySX.Text = lk.NGAYSX.ToString();
                dtpNgayHetBH.Text = lk.NGAYKETTHUC.ToString();
                dtpNgayMua.Text = lk.NGAYMUA_SUACHUA.ToString();
                txtDienGiai.Text = lk.GHICHULINHKIEN;
            }
        }

        //don gia chi nhap so
        private void txtTenLinhKien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}