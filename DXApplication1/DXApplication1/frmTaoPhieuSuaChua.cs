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
    public partial class frmTaoPhieuSuaChua : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
        public frmTaoPhieuSuaChua()
        {  
            InitializeComponent();
        } 
        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        public void LoadCbbPTN()
        {
            cbbMaPhieuTiepNhan.DataSource = qltb.PHIEUTIEPNHANs;
            cbbMaPhieuTiepNhan.DisplayMember = "MAPHIEUTN";
            cbbMaPhieuTiepNhan.ValueMember = "MAPHIEUTN";
        }

        public void LoadCbbNguoiGoi()
        {
            cbbMaPhieuTiepNhan.DataSource = qltb.NHANVIENs;
            cbbMaPhieuTiepNhan.DisplayMember = "MANHANVIEN";
            cbbMaPhieuTiepNhan.ValueMember = "MANHANVIEN";
        }

        private void LoadGridViewPSC()
        {
            var phieusuachua = from psc in qltb.PHIEUSUACHUAs
                          select new { psc.MAPSC, psc.MANHANVIEN, psc.MANHANVIENTIEPNHAN, psc.MAPHIEUTN,psc.NGAYBATDAU, psc.GHICHUPSC, psc.NGUOIGOI,
                                        psc.DONGY, psc.GIADUKIEN, psc.THONGTINSUACHUA, psc.TONGTIEN, psc.TRANGTHAI };
            dtgvPhieuSuaChua.DataSource = phieusuachua;
        }

        
        private void frmTaoPhieuSuaChua_Load(object sender, EventArgs e)
        {
            LoadCbbPTN();
            LoadGridViewPSC();

            btnTTKH.Enabled = false;
            txtMaPSC.Enabled = false;
            cbbNhanVienLap.Enabled = false;
            cbbNhanVienTiepNhan.Enabled = false;
            cbbMaPhieuTiepNhan.Enabled = false;
            dtpNgayBatDau.Enabled = false;
            chkDaGoi.Enabled = false;
            txtGiaDuKien.Enabled = false;
            txtTongTien.Enabled = false;
            txtThongTinSuaChua.Enabled = false;
            chkTrangThai.Enabled = false;
            chkDongY.Enabled = false;
            txtGhiChu.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                txtMaPSC.Enabled = false;
                cbbNhanVienLap.Enabled = false;
                cbbNhanVienTiepNhan.Enabled = false;
                cbbMaPhieuTiepNhan.Enabled = true;
                dtpNgayBatDau.Enabled = true;
                chkDaGoi.Enabled = true;
                txtGiaDuKien.Enabled = true;
                txtTongTien.Enabled = true;
                txtThongTinSuaChua.Enabled = true;
                chkTrangThai.Enabled = true;
                chkDongY.Enabled = true;
                txtGhiChu.Enabled = true;

                txtMaPSC.Text = String.Empty;
                cbbNhanVienLap.Text = String.Empty;
                cbbNhanVienTiepNhan.Text = String.Empty;
                cbbMaPhieuTiepNhan.Text = String.Empty;
                dtpNgayBatDau.Text = String.Empty;
                chkDaGoi.Checked = false;
                txtGiaDuKien.Text = String.Empty;
                txtTongTien.Text = String.Empty;
                txtThongTinSuaChua.Text = String.Empty;
                chkTrangThai.Checked = false;
                chkDongY.Checked = false;
                txtGhiChu.Text = String.Empty;

                btnThem.Text = "Lưu";
            }
            else
            {
                if (txtGiaDuKien.Text == String.Empty || txtTongTien.Text == String.Empty || txtThongTinSuaChua.Text == String.Empty)
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    PHIEUSUACHUA psc = new PHIEUSUACHUA();
                    psc.MAPSC = tangma.ThemMaPSC();
                    psc.MANHANVIEN = Program.mainForm.getUserName;
                    psc.MANHANVIENTIEPNHAN = null;
                    psc.MAPHIEUTN = cbbMaPhieuTiepNhan.Text;
                    psc.NGAYBATDAU = dtpNgayBatDau.Value;
                    psc.GHICHUPSC = txtGhiChu.Text;
                    if (chkDaGoi.Checked)
                    {
                        psc.NGUOIGOI = Program.mainForm.getUserName;
                    }
                    else
                    {
                        psc.NGUOIGOI = null;
                    }

                    if (chkDongY.Checked)
                    {
                        psc.DONGY = true;
                    }
                    else
                    {
                        psc.DONGY = false;
                    }
                    psc.GIADUKIEN = decimal.Parse(txtGiaDuKien.Text);
                    psc.THONGTINSUACHUA = txtThongTinSuaChua.Text;
                    psc.TONGTIEN = decimal.Parse(txtTongTien.Text);
                    if (chkTrangThai.Checked)
                    {
                        psc.TRANGTHAI = true;
                    }
                    else
                    {
                        psc.TRANGTHAI = false;
                    }
                    qltb.PHIEUSUACHUAs.InsertOnSubmit(psc);
                    qltb.SubmitChanges();
                    LoadGridViewPSC();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");

                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;

                    txtMaPSC.Enabled = false;
                    cbbNhanVienLap.Enabled = false;
                    cbbNhanVienTiepNhan.Enabled = false;
                    cbbMaPhieuTiepNhan.Enabled = false;
                    dtpNgayBatDau.Enabled = false;
                    chkDaGoi.Enabled = false;
                    txtGiaDuKien.Enabled = false;
                    txtTongTien.Enabled = false;
                    txtThongTinSuaChua.Enabled = false;
                    chkTrangThai.Enabled = false;
                    chkDongY.Enabled = false;
                    txtGhiChu.Enabled = false;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;

                txtGiaDuKien.Enabled = true;
                txtTongTien.Enabled = true;
                txtThongTinSuaChua.Enabled = true;
                chkTrangThai.Enabled = true;
                chkDongY.Enabled = true;
                txtGhiChu.Enabled = true;
                chkDaGoi.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string mapsc = dtgvPhieuSuaChua.CurrentRow.Cells[0].Value.ToString();
                PHIEUSUACHUA psc = qltb.PHIEUSUACHUAs.Where(t => t.MAPSC == mapsc).FirstOrDefault();
                psc.GIADUKIEN = decimal.Parse(txtGiaDuKien.Text);
                psc.TONGTIEN = decimal.Parse(txtTongTien.Text);
                psc.THONGTINSUACHUA = txtThongTinSuaChua.Text;
                psc.GHICHUPSC = txtGhiChu.Text;
                if (chkDaGoi.Checked)
                {
                    psc.NGUOIGOI = Program.mainForm.getUserName;
                }
                else
                {
                    psc.NGUOIGOI = null;
                }

                if (chkDongY.Checked)
                {
                    psc.DONGY = true;
                }
                else
                {
                    psc.DONGY = false;
                }

                if (chkTrangThai.Checked)
                {
                    psc.TRANGTHAI = true;
                }
                else
                {
                    psc.TRANGTHAI = false;
                }
                
                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công", "Thông báo");
                LoadGridViewPSC();

                btnThem.Enabled = true;
                btnXoa.Enabled = true;

                btnSua.Text = "Sửa";
                btnThem.Text = "Thêm";
                txtGiaDuKien.Enabled = false;
                txtTongTien.Enabled = false;
                txtThongTinSuaChua.Enabled = false;
                chkTrangThai.Enabled = false;
                chkDongY.Enabled = false;
                txtGhiChu.Enabled = false;
                chkDaGoi.Enabled = false;

                txtGiaDuKien.Text = String.Empty;
                txtTongTien.Text = String.Empty;
                txtThongTinSuaChua.Text = String.Empty;
                chkDongY.Checked = false;
                chkTrangThai.Checked = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                string mapsc = dtgvPhieuSuaChua.CurrentRow.Cells[0].Value.ToString();
                PHIEUSUACHUA phieusuachua = qltb.PHIEUSUACHUAs.Where(t => t.MAPSC == mapsc).FirstOrDefault();
                qltb.PHIEUSUACHUAs.DeleteOnSubmit(phieusuachua);
                qltb.SubmitChanges();
                XtraMessageBox.Show("Xóa thành công", "Thông báo");
                LoadGridViewPSC();
            }

            if (dr == DialogResult.No)
            {
                this.Close();
            }
        }

        private void dtgvPhieuSuaChua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        public static string mapsc = "";
        private void btnTTKH_Click(object sender, EventArgs e)
        {
            mapsc = txtMaPSC.Text;
            Form frm = new frmThongTinKH_Goi();
            frm.ShowDialog();
        }

        private void dtgvPhieuSuaChua_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnTTKH.Enabled = true;
                txtMaPSC.Enabled = false;
                cbbNhanVienLap.Enabled = false;
                cbbNhanVienTiepNhan.Enabled = false;
                cbbMaPhieuTiepNhan.Enabled = false;
                dtpNgayBatDau.Enabled = false;
                chkDaGoi.Enabled = false;
                txtGiaDuKien.Enabled = false;
                txtTongTien.Enabled = false;
                txtThongTinSuaChua.Enabled = false;
                chkTrangThai.Enabled = false;
                chkDongY.Enabled = false;
                txtGhiChu.Enabled = false;
                txtMaPSC.Text = dtgvPhieuSuaChua.CurrentRow.Cells[0].Value.ToString();
                cbbNhanVienLap.Text = dtgvPhieuSuaChua.CurrentRow.Cells[1].Value.ToString();

                cbbMaPhieuTiepNhan.Text = dtgvPhieuSuaChua.CurrentRow.Cells[3].Value.ToString();
                dtpNgayBatDau.Text = dtgvPhieuSuaChua.CurrentRow.Cells[4].Value.ToString();

                if (dtgvPhieuSuaChua.CurrentRow.Cells[7].Value.ToString() == "True")
                {
                    chkDongY.Checked = true;
                }
                else
                {
                    chkDongY.Checked = false;
                }
                txtGiaDuKien.Text = dtgvPhieuSuaChua.CurrentRow.Cells[8].Value.ToString();
                if (dtgvPhieuSuaChua.CurrentRow.Cells[9].Value == null || dtgvPhieuSuaChua.CurrentRow.Cells[9].Value.ToString() == "")
                {
                    txtThongTinSuaChua.Text = "";
                }
                else
                {
                    txtThongTinSuaChua.Text = dtgvPhieuSuaChua.CurrentRow.Cells[9].Value.ToString();
                }
                txtTongTien.Text = dtgvPhieuSuaChua.CurrentRow.Cells[10].Value.ToString();
                if (dtgvPhieuSuaChua.CurrentRow.Cells[11].Value.ToString() == "True")
                {
                    chkTrangThai.Checked = true;
                }
                else
                {
                    chkTrangThai.Checked = false;
                }

                if (dtgvPhieuSuaChua.CurrentRow.Cells[2].Value == null || dtgvPhieuSuaChua.CurrentRow.Cells[2].Value.ToString() == "")
                {
                    cbbNhanVienTiepNhan.Text = "";
                }
                else
                {
                    cbbNhanVienTiepNhan.Text = dtgvPhieuSuaChua.CurrentRow.Cells[2].Value.ToString();
                }
                if (dtgvPhieuSuaChua.CurrentRow.Cells[6].Value == null)
                {
                    chkDaGoi.Checked = false;
                }
                else
                {
                    chkDaGoi.Checked = true;
                }

                if (dtgvPhieuSuaChua.CurrentRow.Cells[5].Value == null || dtgvPhieuSuaChua.CurrentRow.Cells[5].Value.ToString() == "")
                {
                    txtGhiChu.Text = "";
                }
                else
                {
                    txtGhiChu.Text = dtgvPhieuSuaChua.CurrentRow.Cells[5].Value.ToString();
                }

            }
            catch { }
        }
    }
}