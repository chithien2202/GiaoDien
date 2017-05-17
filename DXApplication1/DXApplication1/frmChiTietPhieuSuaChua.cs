using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace DXApplication1
{
    public partial class frmChiTietPhieuSuaChua : RibbonForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmChiTietPhieuSuaChua()
        {
            InitializeComponent();
        }

        public void LoadCbbBangBaoGia()
        {
            cbbBangBaoGia.DataSource = qltb.BANGBAOGIAs;
            cbbBangBaoGia.DisplayMember = "TENBAOGIA";
            cbbBangBaoGia.ValueMember = "TENBAOGIA";
        }

        private void frmChiTietPhieuSuaChua_Load(object sender, EventArgs e)
        {
            LoadCbbBangBaoGia();
        }

        private void cbbBangBaoGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tien = (from pk in qltb.BANGBAOGIAs
                        where pk.TENBAOGIA == cbbBangBaoGia.SelectedValue.ToString()
                        select pk.DONGIA).FirstOrDefault();

            txtGiaThanh.Text = tien.ToString();
        }
    }
}
