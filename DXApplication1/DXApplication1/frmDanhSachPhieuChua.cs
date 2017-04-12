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
    public partial class frmDanhSachPhieuChua : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachPhieuChua()
        {
            InitializeComponent();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Form frm =new frmGoiDienKhachHang();
            frm.ShowDialog();
        }
    }
}