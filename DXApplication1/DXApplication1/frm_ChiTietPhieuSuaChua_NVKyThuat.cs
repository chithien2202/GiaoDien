using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace DXApplication1
{
    public partial class frm_ChiTietPhieuSuaChua_NVKyThuat : RibbonForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
        public frm_ChiTietPhieuSuaChua_NVKyThuat()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                cbbMaPSC.Enabled = true;
                txtGiaThanh.Enabled = true;
                cbbBangBaoGia.Enabled = true;
                dtpNgaySua.Enabled = true;
                dtpNgaySuaXong.Enabled = true;
                cbbMaLinhKien.Enabled = true;
                txtGhiChu.Enabled = true;
                chkBaoHanh.Enabled = true;
                cbbNhanVienSuaChua.Enabled = true;
                chkDaNhanThietBi.Enabled = false;

                cbbMaPSC.Text = String.Empty;
                txtGiaThanh.Text = String.Empty;
                cbbBangBaoGia.Text = String.Empty;
                cbbMaLinhKien.Text = String.Empty;
                txtGhiChu.Text = String.Empty;
                chkBaoHanh.Checked = false;
                chkDaNhanThietBi.Checked = false;

                btnThem.Text = "Lưu";
            }
            else
            {
                if (cbbNhanVienSuaChua.Text == String.Empty)
                {
                    XtraMessageBox.Show("Vui lòng nhập nhân viên sửa chữa", "Thông báo");
                }
                else
                {
                    CHITIETSUACHUA ctsc = new CHITIETSUACHUA();
                    ctsc.MACTSC = tangma.ThemMaCTPSC();
                    ctsc.MAPSC = cbbMaPSC.Text;
                    ctsc.MANHANVIENSUA = cbbNhanVienSuaChua.Text;
                    ctsc.MANHANVIENNHAN = null;
                    ctsc.GIATHANH = decimal.Parse(txtGiaThanh.Text);
                    ctsc.NGAYSUA = dtpNgaySua.Value;
                    ctsc.NGAYSUAXONG = dtpNgaySuaXong.Value;

                    if (chkBaoHanh.Checked)
                    {
                        ctsc.TRANGTHAI = true;
                    }
                    else
                    {
                        ctsc.TRANGTHAI = false;
                    }
                    ctsc.GHICHUCTSC = txtGhiChu.Text;
                    ctsc.MALINHKIEN = cbbMaLinhKien.Text;

                    qltb.CHITIETSUACHUAs.InsertOnSubmit(ctsc);
                    qltb.SubmitChanges();
                    LoadGridViewCTSC();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");

                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;

                    cbbMaPSC.Enabled = false;
                    txtGiaThanh.Enabled = false;
                    cbbBangBaoGia.Enabled = false;
                    dtpNgaySua.Enabled = false;
                    dtpNgaySuaXong.Enabled = false;
                    cbbMaLinhKien.Enabled = false;
                    txtGhiChu.Enabled = false;
                    chkBaoHanh.Enabled = false;
                    chkDaNhanThietBi.Enabled = false;
                }
            }
        }

        public void LoadGridViewCTSC()
        {
            var chitietsuachua = from ctsc in qltb.CHITIETSUACHUAs
                                 select new
                                 {
                                     ctsc.MACTSC,
                                     ctsc.MAPSC,
                                     ctsc.MANHANVIENSUA,
                                     ctsc.MANHANVIENNHAN,
                                     ctsc.STT,
                                     ctsc.GIATHANH,
                                     ctsc.NGAYSUA,
                                     ctsc.NGAYSUAXONG,
                                     ctsc.TRANGTHAI,
                                     ctsc.GHICHUCTSC,
                                     ctsc.MALINHKIEN
                                 };
            dtgvChiTietPSC.DataSource = chitietsuachua;
        }

        public void LoadCbbMaPSC()
        {
            cbbMaPSC.DataSource = qltb.PHIEUSUACHUAs;
            cbbMaPSC.DisplayMember = "MAPSC";
            cbbMaPSC.ValueMember = "MAPSC";
        }

        public void LoadCbbBangBaoGia()
        {
            cbbBangBaoGia.DataSource = qltb.BANGBAOGIAs;
            cbbBangBaoGia.DisplayMember = "TENBAOGIA";
            cbbBangBaoGia.ValueMember = "TENBAOGIA";
        }

        public void LoadCbbMaLinhKien()
        {
            cbbMaLinhKien.DataSource = qltb.LINHKIENs;
            cbbMaLinhKien.DisplayMember = "MALINHKIEN";
            cbbMaLinhKien.ValueMember = "MALINHKIEN";
        }

        public void LoadCbbNhanVienSua()
        {
            cbbNhanVienSuaChua.DataSource = qltb.NHANVIENs;
            cbbNhanVienSuaChua.DisplayMember = "MANHANVIEN";
            cbbNhanVienSuaChua.ValueMember = "MANHANVIEN";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;

                cbbMaPSC.Enabled = false;
                txtGiaThanh.Enabled = true;
                cbbBangBaoGia.Enabled = true;
                dtpNgaySua.Enabled = true;
                dtpNgaySuaXong.Enabled = true;
                cbbMaLinhKien.Enabled = true;
                txtGhiChu.Enabled = true;
                chkBaoHanh.Enabled = true;
                chkDaNhanThietBi.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string mactsc = dtgvChiTietPSC.CurrentRow.Cells[0].Value.ToString();
                CHITIETSUACHUA ctsc = qltb.CHITIETSUACHUAs.Where(t => t.MACTSC == mactsc).FirstOrDefault();
                ctsc.GIATHANH = decimal.Parse(txtGiaThanh.Text);
                ctsc.NGAYSUA = dtpNgaySua.Value;
                ctsc.NGAYSUAXONG = dtpNgaySuaXong.Value;
                if (chkDaNhanThietBi.Checked)
                {
                    ctsc.MANHANVIENNHAN = Program.mainForm.getUserName;
                }


                if (chkBaoHanh.Checked)
                {
                    ctsc.TRANGTHAI = true;
                }
                else
                {
                    ctsc.TRANGTHAI = false;
                }
                ctsc.GHICHUCTSC = txtGhiChu.Text;
                ctsc.MALINHKIEN = cbbMaLinhKien.Text;

                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công", "Thông báo");
                LoadGridViewCTSC();

                btnSua.Text = "Sửa";
                btnThem.Text = "Thêm";

                btnThem.Enabled = true;
                btnXoa.Enabled = true;

                cbbMaPSC.Enabled = false;
                txtGiaThanh.Enabled = false;
                cbbBangBaoGia.Enabled = false;
                dtpNgaySua.Enabled = false;
                dtpNgaySuaXong.Enabled = false;
                cbbMaLinhKien.Enabled = false;
                txtGhiChu.Enabled = false;
                chkBaoHanh.Enabled = false;
                chkDaNhanThietBi.Enabled = false;

                cbbMaPSC.Text = String.Empty;
                txtGiaThanh.Text = String.Empty;
                cbbBangBaoGia.Text = String.Empty;
                cbbMaLinhKien.Text = String.Empty;
                txtGhiChu.Text = String.Empty;
                chkBaoHanh.Checked = false;
                chkDaNhanThietBi.Checked = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    string mactsc = dtgvChiTietPSC.CurrentRow.Cells[0].Value.ToString();
                    CHITIETSUACHUA chitietsuachua = qltb.CHITIETSUACHUAs.Where(t => t.MACTSC == mactsc).FirstOrDefault();
                    qltb.CHITIETSUACHUAs.DeleteOnSubmit(chitietsuachua);
                    qltb.SubmitChanges();
                    XtraMessageBox.Show("Xóa thành công", "Thông báo");
                    LoadGridViewCTSC();
                }

                if (dr == DialogResult.No)
                {
                    this.Close();
                }
            }
            catch
            {
                XtraMessageBox.Show("Dữ liệu đang được sử dụng!", "Thông báo");
            }
        }

        private void dtgvChiTietPSC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbbMaPSC.Enabled = false;
                txtGiaThanh.Enabled = false;
                cbbBangBaoGia.Enabled = false;
                dtpNgaySua.Enabled = false;
                dtpNgaySuaXong.Enabled = false;
                cbbMaLinhKien.Enabled = false;
                txtGhiChu.Enabled = false;
                chkBaoHanh.Enabled = false;
                chkDaNhanThietBi.Enabled = false;

                cbbMaPSC.Text = dtgvChiTietPSC.CurrentRow.Cells[1].Value.ToString();
                txtGiaThanh.Text = dtgvChiTietPSC.CurrentRow.Cells[5].Value.ToString();
                dtpNgaySua.Text = dtgvChiTietPSC.CurrentRow.Cells[6].Value.ToString();
                dtpNgaySuaXong.Text = dtgvChiTietPSC.CurrentRow.Cells[7].Value.ToString();
                cbbMaLinhKien.Text = dtgvChiTietPSC.CurrentRow.Cells[10].Value.ToString();
                cbbNhanVienSuaChua.Text = dtgvChiTietPSC.CurrentRow.Cells[2].Value.ToString();
                if (dtgvChiTietPSC.CurrentRow.Cells[9].Value == null)
                {
                    txtGhiChu.Text = "";
                }
                else
                {
                    txtGhiChu.Text = dtgvChiTietPSC.CurrentRow.Cells[9].Value.ToString();
                }

                if (dtgvChiTietPSC.CurrentRow.Cells[8].Value.ToString() == "True")
                {
                    chkBaoHanh.Checked = true;
                }
                else
                {
                    chkBaoHanh.Checked = false;
                }

                if (dtgvChiTietPSC.CurrentRow.Cells[3].Value == null || dtgvChiTietPSC.CurrentRow.Cells[4].Value.ToString() == "")
                {
                    chkDaNhanThietBi.Checked = false;
                }
                else
                {
                    chkDaNhanThietBi.Checked = true;
                }
            }
            catch { }
        }

        private void cbbBangBaoGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tien = (from pk in qltb.BANGBAOGIAs
                        where pk.TENBAOGIA == cbbBangBaoGia.SelectedValue.ToString()
                        select pk.DONGIA).FirstOrDefault();

            txtGiaThanh.Text = tien.ToString();
        }

        private void ChiTietPhieuSuaChua_NVKyThuat_Load(object sender, EventArgs e)
        {
            LoadCbbMaPSC();
            LoadCbbBangBaoGia();
            LoadGridViewCTSC();
            LoadCbbNhanVienSua();
            LoadCbbMaLinhKien();
            LoadGridViewPSC();

            cbbMaPSC.Enabled = false;
            txtGiaThanh.Enabled = false;
            cbbBangBaoGia.Enabled = false;
            dtpNgaySua.Enabled = false;
            dtpNgaySuaXong.Enabled = false;
            cbbMaLinhKien.Enabled = false;
            txtGhiChu.Enabled = false;
            chkBaoHanh.Enabled = false;
            chkDaNhanThietBi.Enabled = false;
        }

        private void LoadGridViewPSC()
        {
            var phieusuachua = from psc in qltb.PHIEUSUACHUAs
                               select new
                               {
                                   psc.MAPSC,
                                   psc.MANHANVIEN,
                                   psc.MANHANVIENTIEPNHAN,
                                   psc.MAPHIEUTN,
                                   psc.NGAYBATDAU,
                                   psc.GHICHUPSC,
                                   psc.NGUOIGOI,
                                   psc.DONGY,
                                   psc.GIADUKIEN,
                                   psc.THONGTINSUACHUA,
                                   psc.TONGTIEN,
                                   psc.TRANGTHAI
                               };
            dtgvPhieuSuaChua.DataSource = phieusuachua;
        }

        private void dtgvPhieuSuaChua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbMaPSC.Enabled = false;
            txtGiaThanh.Enabled = false;
            cbbBangBaoGia.Enabled = false;
            dtpNgaySua.Enabled = false;
            dtpNgaySuaXong.Enabled = false;
            cbbMaLinhKien.Enabled = false;
            txtGhiChu.Enabled = false;
            chkBaoHanh.Enabled = false;
            chkDaNhanThietBi.Enabled = false;

            cbbMaPSC.Text = dtgvPhieuSuaChua.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
