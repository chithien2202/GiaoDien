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
                          select new { psc.MAPSC, psc.MANHANVIEN, psc.MANHANVIENTIEPNHAN, psc.NGAYBATDAU, psc.GHICHUPSC, psc.NGUOIGOI,
                                        psc.DONGY, psc.GIADUKIEN, psc.THONGTINSUACHUA, psc.TONGTIEN, psc.TRANGTHAI };
            dtgvPhieuSuaChua.DataSource = phieusuachua;
        }

        private void frmTaoPhieuSuaChua_Load(object sender, EventArgs e)
        {
            LoadCbbPTN();
            LoadGridViewPSC();

            txtMaPSC.Enabled = false;
            cbbNhanVienLap.Enabled = false;
            cbbNhanVienTiepNhan.Enabled = false;
            cbbMaPhieuTiepNhan.Enabled = false;
            dtpNgayBatDau.Enabled = false;
            cbbNguoiGoi.Enabled = false;
            txtGiaDuKien.Enabled = false;
            txTongTien.Enabled = false;
            txtThongTinSuaChua.Enabled = false;
            chkTrangThai.Enabled = false;
            chkDongY.Enabled = false;
            txtGhiChu.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                txtMaPSC.Enabled = true;
                cbbNhanVienLap.Enabled = true;
                cbbNhanVienTiepNhan.Enabled = true;
                cbbMaPhieuTiepNhan.Enabled = true;
                dtpNgayBatDau.Enabled = true;
                cbbNguoiGoi.Enabled = true;
                txtGiaDuKien.Enabled = true;
                txTongTien.Enabled = true;
                txtThongTinSuaChua.Enabled = true;
                chkTrangThai.Enabled = true;
                chkDongY.Enabled = true;
                txtGhiChu.Enabled = true;

                btnThem.Text = "Lưu";
            }
            else
            {
                if (txtGiaDuKien.Text == String.Empty || txTongTien.Text == String.Empty || txtThongTinSuaChua.Text == String.Empty)
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
                    psc.NGUOIGOI = cbbNguoiGoi.Text;
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
                    psc.TONGTIEN = decimal.Parse(txTongTien.Text);
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


                    txtMaPSC.Enabled = false;
                    cbbNhanVienLap.Enabled = false;
                    cbbNhanVienTiepNhan.Enabled = false;
                    cbbMaPhieuTiepNhan.Enabled = false;
                    dtpNgayBatDau.Enabled = false;
                    cbbNguoiGoi.Enabled = false;
                    txtGiaDuKien.Enabled = false;
                    txTongTien.Enabled = false;
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
                txtGiaDuKien.Enabled = true;
                txTongTien.Enabled = true;
                txtThongTinSuaChua.Enabled = true;
                chkTrangThai.Enabled = true;
                chkDongY.Enabled = true;
                txtGhiChu.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string mapsc = dtgvPhieuSuaChua.CurrentRow.Cells[0].Value.ToString();
                PHIEUSUACHUA psc = qltb.PHIEUSUACHUAs.Where(t => t.MAPSC == mapsc).FirstOrDefault();
                psc.GIADUKIEN = decimal.Parse(txtGiaDuKien.Text);
                psc.TONGTIEN = decimal.Parse(txTongTien.Text);
                psc.THONGTINSUACHUA = txtThongTinSuaChua.Text;
                psc.GHICHUPSC = txtGhiChu.Text;
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

                btnSua.Text = "Sửa";
                btnThem.Text = "Thêm";
                txtGiaDuKien.Enabled = false;
                txTongTien.Enabled = false;
                txtThongTinSuaChua.Enabled = false;
                chkTrangThai.Enabled = false;
                chkDongY.Enabled = false;
                txtGhiChu.Enabled = false;

                txtGiaDuKien.Text = String.Empty;
                txTongTien.Text = String.Empty;
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
    }
}