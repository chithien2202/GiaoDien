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
    public partial class frmThongKeDoanhThu : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        HamLayNgay layngay = new HamLayNgay();
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tg = layngay.ngay();
            DateTime dt = Convert.ToDateTime(tg);
            var hd = from h in qltb.HOADONs where (h.NGAYLAP >= dtpTu.DateTime) && (h.NGAYLAP <= dtpDen.DateTime) select new { h.MAHOADON, h.MAKHACHHANG, h.MAPSC, h.MANHANVIEN, h.NGAYLAP, h.TONGTIEN };
            dtgvThongKeDoanhThu.DataSource = hd;

            var s = (from a in qltb.HOADONs where (a.NGAYLAP >= dtpTu.DateTime) && (a.NGAYLAP <= dtpDen.DateTime) select a).Count();
            int? tksl = (s == null) ? 0 : s;
            txtSoLuong.Text = tksl.ToString();

            var q = (from a in qltb.HOADONs where (a.NGAYLAP >= dtpTu.DateTime) && (a.NGAYLAP <= dtpDen.DateTime) select a).Sum(x => x.TONGTIEN);
            decimal? tktt = (q == null) ? 0 : q;
            txtTongTien.Text = tktt.ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }
    }
}