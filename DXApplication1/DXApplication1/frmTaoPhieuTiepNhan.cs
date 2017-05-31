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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace DXApplication1
{
    public partial class frmTaoPhieuTiepNhan : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
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
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                dtpNgayNhap.Enabled = true;
                dtpNgayHenTra.Enabled = true;
                cbbKhachHang.Enabled = true;
                cbbThietBi.Enabled = true;
                txtPhuKienDiCung.Enabled = true;
                txtTinhTrangHuHong.Enabled = true;
                txtGhiChu.Enabled = true;
                chkDaNhan.Enabled = false;

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
                    PHIEUTIEPNHAN ptn = new PHIEUTIEPNHAN();
                    ptn.MAPHIEUTN = tangma.ThemMaPTN();
                    ptn.MATHIETBI = cbbThietBi.SelectedValue.ToString();
                    ptn.MANHANVIEN = Program.mainForm.getUserName;
                    ptn.MANHANVIENNHANMAY = null;
                    ptn.MAKHACHKHACH = cbbKhachHang.Text;
                    ptn.NGAYNHAN = dtpNgayNhap.Value;
                    ptn.NGAYHENTRA = dtpNgayHenTra.Value;
                    ptn.TINHHINHHUHONG = txtTinhTrangHuHong.Text;
                    ptn.PHUKIENKEMTHEO = txtPhuKienDiCung.Text;
                    ptn.HINHTHUC = null;
                    ptn.GHICHUPTN = txtGhiChu.Text;
                    qltb.PHIEUTIEPNHANs.InsertOnSubmit(ptn);
                    qltb.SubmitChanges();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");
                    LoadGridViewPTN();

                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
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

            dtpNgayNhap.Enabled = false;
            dtpNgayHenTra.Enabled = false;
            cbbKhachHang.Enabled = false;
            cbbThietBi.Enabled = false;
            txtPhuKienDiCung.Enabled = false;
            txtTinhTrangHuHong.Enabled = false;
            txtGhiChu.Enabled = false;
            chkDaNhan.Enabled = false;
        }

        private void LoadGridViewPTN()
        {
            var phieutiepnhan = from ptn in qltb.PHIEUTIEPNHANs
                          select new { ptn.MAPHIEUTN, ptn.MATHIETBI, ptn.MANHANVIEN, ptn.MANHANVIENNHANMAY, ptn.MAKHACHKHACH, ptn.NGAYNHAN,
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
                btnThem.Enabled = false;
                btnXoa.Enabled = false;

                dtpNgayNhap.Enabled = true;
                dtpNgayHenTra.Enabled = true;
                cbbKhachHang.Enabled = true;
                cbbThietBi.Enabled = true;
                txtTinhTrangHuHong.Enabled = true;
                txtGhiChu.Enabled = true;
                txtPhuKienDiCung.Enabled = true;
                chkDaNhan.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string maptn = dtgvDSPTN.CurrentRow.Cells[0].Value.ToString();
                PHIEUTIEPNHAN ptn = qltb.PHIEUTIEPNHANs.Where(t => t.MAPHIEUTN == maptn).FirstOrDefault();
                ptn.NGAYNHAN = dtpNgayNhap.Value;
                ptn.NGAYHENTRA = dtpNgayHenTra.Value;
                if(chkDaNhan.Checked)
                {
                    ptn.MANHANVIENNHANMAY = Program.mainForm.getUserName;
                }
                ptn.PHUKIENKEMTHEO = txtPhuKienDiCung.Text;
                ptn.TINHHINHHUHONG = txtTinhTrangHuHong.Text;
                ptn.GHICHUPTN = txtGhiChu.Text;
                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công", "Thông báo");
                LoadGridViewPTN();

                btnThem.Enabled = true;
                btnXoa.Enabled = true;

                btnSua.Text = "Sửa";

                dtpNgayNhap.Enabled = false;
                dtpNgayHenTra.Enabled = false;
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
                dtpNgayNhap.Enabled = false;
                dtpNgayHenTra.Enabled = false;
                cbbKhachHang.Enabled = false;
                cbbThietBi.Enabled = false;
                txtPhuKienDiCung.Enabled = false;
                txtTinhTrangHuHong.Enabled = false;
                txtGhiChu.Enabled = false;
                chkDaNhan.Enabled = false;

                cbbThietBi.Text = dtgvDSPTN.CurrentRow.Cells[1].Value.ToString();
                dtpNgayNhap.Text = dtgvDSPTN.CurrentRow.Cells[5].Value.ToString();
                dtpNgayHenTra.Text = dtgvDSPTN.CurrentRow.Cells[6].Value.ToString();
                cbbKhachHang.Text = dtgvDSPTN.CurrentRow.Cells[4].Value.ToString();
                if (dtgvDSPTN.CurrentRow.Cells[8].Value == null || dtgvDSPTN.CurrentRow.Cells[8].Value.ToString() == "")
                {
                    txtPhuKienDiCung.Text = "";
                }
                else
                {
                    txtPhuKienDiCung.Text = dtgvDSPTN.CurrentRow.Cells[8].Value.ToString();
                }

                if (dtgvDSPTN.CurrentRow.Cells[7].Value == null || dtgvDSPTN.CurrentRow.Cells[7].Value.ToString() == "")
                {
                    txtTinhTrangHuHong.Text = "";
                }
                else
                {
                    txtTinhTrangHuHong.Text = dtgvDSPTN.CurrentRow.Cells[7].Value.ToString();
                }
                if (dtgvDSPTN.CurrentRow.Cells[10].Value == null || dtgvDSPTN.CurrentRow.Cells[10].Value.ToString() == "")
                {
                    txtGhiChu.Text = "";
                }
                else
                {
                    txtGhiChu.Text = dtgvDSPTN.CurrentRow.Cells[10].Value.ToString();
                }

                if (dtgvDSPTN.CurrentRow.Cells[3].Value == null || dtgvDSPTN.CurrentRow.Cells[3].Value.ToString() == "")
                {
                    chkDaNhan.Checked = false;
                }
                else
                {
                    chkDaNhan.Checked = true;
                }
            }
            catch { }
        }


        private void xuatExcel(DataGridView g, string duongDan, string tenTap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 20;
            obj.Visible = true;// mở excel lên
            for (int i = 1; i < g.Columns.Count + 1; i++) { obj.Cells[1, i] = g.Columns[i - 1].HeaderText; }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null) { obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString(); }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //xuatExcel(dtgvDSPTN., @"D:\", "Danh sach phieu tiep nhan");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}