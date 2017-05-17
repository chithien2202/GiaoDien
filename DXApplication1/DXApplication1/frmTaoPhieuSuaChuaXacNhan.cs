using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
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
    public partial class frmTaoPhieuSuaChuaXacNhan : RibbonForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmTaoPhieuSuaChuaXacNhan()
        {
            InitializeComponent();
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

        private void frmTaoPhieuSuaChuaXacNhan_Load(object sender, EventArgs e)
        {
            LoadGridViewPSC();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string mapsc = dtgvPhieuSuaChua.CurrentRow.Cells[0].Value.ToString();
            PHIEUSUACHUA psc = qltb.PHIEUSUACHUAs.Where(t => t.MAPSC == mapsc).FirstOrDefault();
            if (chkDaGiao.Checked)
            {
                psc.MANHANVIENTIEPNHAN = Program.mainForm.getUserName;
            }
            //qltb.PHIEUSUACHUAs.InsertOnSubmit(psc);
            qltb.SubmitChanges();
            LoadGridViewPSC();
            XtraMessageBox.Show("Xác nhận thành công", "Thông báo");
        }

        private void dtgvPhieuSuaChua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaPSC.Enabled = false;
                cbbNhanVienLap.Enabled = false;
                cbbNhanVienTiepNhan.Enabled = false;
                cbbMaPhieuTiepNhan.Enabled = false;
                dtpNgayBatDau.Enabled = false;
                cbbNguoiGoi.Enabled = false;
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
                txtGhiChu.Text = dtgvPhieuSuaChua.CurrentRow.Cells[5].Value.ToString();
                cbbNguoiGoi.Text = dtgvPhieuSuaChua.CurrentRow.Cells[6].Value.ToString();
                if (dtgvPhieuSuaChua.CurrentRow.Cells[7].Value.ToString() == "True")
                {
                    chkDongY.Checked = true;
                }
                else
                {
                    chkDongY.Checked = false;
                }
                txtGiaDuKien.Text = dtgvPhieuSuaChua.CurrentRow.Cells[8].Value.ToString();
                txtThongTinSuaChua.Text = dtgvPhieuSuaChua.CurrentRow.Cells[9].Value.ToString();
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
            }
            catch { }
        }
    }
}
