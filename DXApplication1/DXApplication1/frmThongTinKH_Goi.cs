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
    public partial class frmThongTinKH_Goi : Form
    {
        
        public frmThongTinKH_Goi()
        {
            InitializeComponent();
        }
        QLTBDataContext qltb = new QLTBDataContext();
        private void frmThongTinKH_Goi_Load(object sender, EventArgs e)
        {
                var psc = (from p in qltb.PHIEUSUACHUAs where p.MAPSC == frmTaoPhieuSuaChua.mapsc select p).FirstOrDefault();
                txtMaPSC.Text = psc.MAPSC;
                txtMaKH.Text = psc.PHIEUTIEPNHAN.KHACHHANG.MAKHACHKHACH;
                txtTenKH.Text = psc.PHIEUTIEPNHAN.KHACHHANG.TENKHACHHANG;
                txtDChi.Text = psc.PHIEUTIEPNHAN.KHACHHANG.DIACHIKH;
                txtSDT.Text = psc.PHIEUTIEPNHAN.KHACHHANG.SDTKH.ToString();
                txtFax.Text = psc.PHIEUTIEPNHAN.KHACHHANG.FAX.ToString();
                txtEmail.Text = psc.PHIEUTIEPNHAN.KHACHHANG.EMAILKH;  
        }
    }
}
