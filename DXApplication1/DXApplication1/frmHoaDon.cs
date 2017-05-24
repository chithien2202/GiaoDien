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
    public partial class frmHoaDon : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadCbbPSC();
        }

        public void LoadCbbPSC()
        {
            cbbMaPhieuSuaChua.DataSource = qltb.PHIEUSUACHUAs;
            cbbMaPhieuSuaChua.DisplayMember = "MAPSC";
            cbbMaPhieuSuaChua.ValueMember = "MAPSC";
        }

        private void cbbMaPhieuSuaChua_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tongtien = (from pk in qltb.PHIEUSUACHUAs
                        where pk.MAPSC == cbbMaPhieuSuaChua.SelectedValue.ToString()
                        select pk.TONGTIEN).FirstOrDefault();

            txtTongTien.Text = tongtien.ToString();
        }
    }
}