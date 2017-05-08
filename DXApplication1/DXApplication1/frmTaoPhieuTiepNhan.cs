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
using DevExpress.XtraTab;

namespace DXApplication1
{
    public partial class frmTaoPhieuTiepNhan : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
        PhieuTiepNhanService ptn = new PhieuTiepNhanService();
        public frmTaoPhieuTiepNhan()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void timeEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                cbbKhachHang.Enabled = true;
                cbbThietBi.Enabled = true;
                txtPhuKienDiCung.Enabled = true;
                txtTinhTrangHuHong.Enabled = true;
                txtGhiChu.Enabled = true;

                txtPhuKienDiCung.Text = String.Empty;
                txtGhiChu.Text = String.Empty;
                txtTinhTrangHuHong.Text= String.Empty;


                btnThem.Text = "Lưu";
            }
            else
            {
                if (txtTinhTrangHuHong.Text == String.Empty)
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    //string maptn = tangma.ThemMaPTN();
                    bool flag = ptn.AddPhieuNhan(
                    tangma.ThemMaPTN(),
                    cbbThietBi.SelectedValue.ToString(),
                    Program.mainForm.getUserName,
                    cbbKhachHang.SelectedValue.ToString(),
                    DateTime.Parse(dtpNgayNhap.Value.ToString()),
                    DateTime.Parse(dtpNgayHenTra.Value.ToString()),
                    txtTinhTrangHuHong.Text,
                    txtPhuKienDiCung.Text,
                    false,
                    txtGhiChu.Text
                    );
                    LoadGridViewPTN();
                }
            }
        }


        public void LoadCbbKhachHang()
        {
            cbbKhachHang.DataSource = qltb.KHACHHANGs;
            cbbKhachHang.DisplayMember = "MAKHACHKHACH";
            cbbKhachHang.ValueMember = "MAKHACHKHACH";
        }

        public void LoadCbbThietBi()
        { 
            cbbThietBi.DataSource = qltb.THIETBIs;
            cbbThietBi.DisplayMember = "SERIAL";
            cbbThietBi.ValueMember = "MATHIETBI";
        }

        private void frmTaoPhieuTiepNhan_Load(object sender, EventArgs e)
        {
            LoadCbbKhachHang();
            LoadCbbThietBi();
            LoadGridViewPTN();
        }

        private void LoadGridViewPTN()
        {
            var phieutiepnhan = from ptn in qltb.PHIEUTIEPNHANs
                          select new { ptn.MAPHIEUTN, ptn.MATHIETBI, ptn.MANHANVIEN, ptn.MAKHACHKHACH, ptn.NGAYNHAN,
                              ptn.NGAYHENTRA, ptn.TINHHINHHUHONG, ptn.PHUKIENKEMTHEO, ptn.HINHTHUC, ptn.GHICHUPTN };
            dtgvDSPTN.DataSource = phieutiepnhan;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            XtraForm fff = new frmDanhMucKhachHang();
            fff.ShowDialog();
        }

        private void btnThemThietBi_Click(object sender, EventArgs e)
        {
            XtraForm fff = new frmDanhMucThietBi();
            fff.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                string maptn = dtgvDSPTN.CurrentRow.Cells[0].Value.ToString();
                PHIEUTIEPNHAN ptn = qltb.PHIEUTIEPNHANs.Where(t => t.MAPHIEUTN == maptn).FirstOrDefault();
                qltb.PHIEUTIEPNHANs.DeleteOnSubmit(ptn);
                qltb.SubmitChanges();
                XtraMessageBox.Show("Xóa thành công", "Thông báo");
                LoadGridViewPTN();
            }

            if (dr == DialogResult.No)

            {
                this.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {

                cbbKhachHang.Enabled = true;
                cbbThietBi.Enabled = true;
                txtTinhTrangHuHong.Enabled = true;
                txtGhiChu.Enabled = true;
                txtPhuKienDiCung.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string maptn = dtgvDSPTN.CurrentRow.Cells[0].Value.ToString();
                PHIEUTIEPNHAN ptn = qltb.PHIEUTIEPNHANs.Where(t => t.MAPHIEUTN == maptn).FirstOrDefault();
                ptn.NGAYNHAN = dtpNgayNhap.Value;
                ptn.NGAYHENTRA = dtpNgayHenTra.Value;
                ptn.PHUKIENKEMTHEO = txtPhuKienDiCung.Text;
                ptn.TINHHINHHUHONG = txtTinhTrangHuHong.Text;
                ptn.GHICHUPTN = txtGhiChu.Text;
                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công", "Thông báo");
                LoadGridViewPTN();

                btnSua.Text = "Sửa";
                cbbKhachHang.Enabled = false;
                cbbThietBi.Enabled = false;
                txtPhuKienDiCung.Enabled = false;
                txtTinhTrangHuHong.Enabled = false;
                txtGhiChu.Enabled = false;

                txtPhuKienDiCung.Text = String.Empty;
                txtTinhTrangHuHong.Text = String.Empty;
                txtGhiChu.Text = String.Empty;
            }
        }

        private void dtgvDSPTN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbbKhachHang.Enabled = false;
                cbbThietBi.Enabled = false;
                txtPhuKienDiCung.Enabled = false;
                txtTinhTrangHuHong.Enabled = false;
                txtGhiChu.Enabled = false;
                cbbThietBi.Text = dtgvDSPTN.CurrentRow.Cells[1].Value.ToString();
                dtpNgayNhap.Text = dtgvDSPTN.CurrentRow.Cells[4].Value.ToString();
                dtpNgayHenTra.Text = dtgvDSPTN.CurrentRow.Cells[5].Value.ToString();
                cbbKhachHang.Text = dtgvDSPTN.CurrentRow.Cells[3].Value.ToString();
                txtPhuKienDiCung.Text = dtgvDSPTN.CurrentRow.Cells[7].Value.ToString();
                txtTinhTrangHuHong.Text = dtgvDSPTN.CurrentRow.Cells[6].Value.ToString();
                txtGhiChu.Text = dtgvDSPTN.CurrentRow.Cells[9].Value.ToString();
            }
            catch { }
        }
    }
}