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
            LoadGridViewLinhKien();
        }
    }
}