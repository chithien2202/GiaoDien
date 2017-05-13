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
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PHIEUSUACHUA psc = new PHIEUSUACHUA();
            psc.MAPSC = tangma.ThemMaPSC();
            psc.MANHANVIEN = Program.mainForm.getUserName;
            psc.MANHANVIENTIEPNHAN = null;
            psc.MAPHIEUTN = cbbMaPhieuTiepNhan.Text;
            psc.NGAYBATDAU = dtpNgayBatDau.Value;
            psc.GHICHUPSC = txtGhiChu.Text;
            psc.NGUOIGOI = cbbNgoiGoi.Text;
            if(chkDongY.Checked)
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
        }
    }
}