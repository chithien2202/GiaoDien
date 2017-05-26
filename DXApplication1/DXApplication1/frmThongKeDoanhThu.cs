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
        HamHT ht = new HamHT();
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tg = ht.ngay();
            DateTime dt = Convert.ToDateTime(tg);
            dtgvThongKeDoanhThu.DataSource = qltb.HOADONs.Where(x => x.NGAYLAP == dt).ToList();

            var a = qltb.HOADONs.Where(x => x.NGAYLAP == dt).Sum(x => x.TONGTIEN);// tinh tong tien nhap bán lẻ
            decimal? ttbl = (a == null) ? 0 : a;
            txtTongTien.Text = ttbl.ToString();
        }
    }
}