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
    public partial class frmThongKeThietBi : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        HamLayNgay layngay = new HamLayNgay();
        public frmThongKeThietBi()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tg = layngay.ngay();
            DateTime dt = Convert.ToDateTime(tg);
            var thietbi = from tb in qltb.THIETBIs where (tb.NGAYMUA_SUACHUA >= dtpTu.DateTime) && (tb.NGAYMUA_SUACHUA <= dtpDen.DateTime) select new { tb.MATHIETBI, tb.MAMODEL, tb.SERIAL, tb.TENTHIETBI, tb.NGAYMUA_SUACHUA, tb.NGAYKETTHUC, tb.GHICHUTHIETBI };
            dtgvDSThietBi.DataSource = thietbi;
            var q = (from a in qltb.THIETBIs where (a.NGAYMUA_SUACHUA >= dtpTu.DateTime) && (a.NGAYMUA_SUACHUA <= dtpDen.DateTime) select a).Count();
            int? tksl = (q == null) ? 0 : q;
            txtTongSo.Text = tksl.ToString();
        }
    }
}