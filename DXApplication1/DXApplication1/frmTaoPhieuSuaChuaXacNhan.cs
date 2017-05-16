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
    }
}
