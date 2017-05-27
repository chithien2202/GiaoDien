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
    public partial class frmThongKeLinhKien : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        HamLayNgay layngay = new HamLayNgay();
        public frmThongKeLinhKien()
        {
            InitializeComponent();
        }

        private void LoadGridViewLinhKien()
        {
            var linhkien = from lk in qltb.LINHKIENs
                           select new { lk.MALINHKIEN, lk.MATHIETBI, lk.TENLINHKIEN, lk.NGAYSX, lk.NGAYKETTHUC, lk.NGAYMUA_SUACHUA, lk.GHICHULINHKIEN };
            dtgvDSLinhKien.DataSource = linhkien;
        }

        private void frmThongKeLinhKien_Load(object sender, EventArgs e)
        {
            //LoadGridViewLinhKien();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tg = layngay.ngay();
            DateTime dt = Convert.ToDateTime(tg);
            var linhkien = from lk in qltb.LINHKIENs where (lk.NGAYMUA_SUACHUA >= dtpTu.DateTime) && (lk.NGAYMUA_SUACHUA <= dtpDen.DateTime) select new { lk.MALINHKIEN, lk.MATHIETBI, lk.TENLINHKIEN, lk.NGAYSX, lk.NGAYKETTHUC, lk.NGAYMUA_SUACHUA, lk.GHICHULINHKIEN };
            dtgvDSLinhKien.DataSource = linhkien;
            var q = (from a in qltb.LINHKIENs where (a.NGAYMUA_SUACHUA >= dtpTu.DateTime) && (a.NGAYMUA_SUACHUA <= dtpDen.DateTime) select a).Count();// tinh tong tien
            int ? tksl = (q == null) ? 0 : q;
            txtTongSo.Text = tksl.ToString();
        }
    }
}