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

          //  txtTongTien.Text = tongtien.ToString();
        }

        private void cbbMaPhieuSuaChua_SelectionChangeCommitted(object sender, EventArgs e)
        {
           // var kh = (from k in qltb.HOADONs where k.MAPSC == cbbMaPhieuSuaChua.SelectedValue.ToString() select new { k.MAKHACHHANG, k.KHACHHANG.TENKHACHHANG, k.PHIEUSUACHUA.TRANGTHAI,k.PHIEUSUACHUA.TONGTIEN }).FirstOrDefault();
            var psc = (from p in qltb.PHIEUSUACHUAs where p.MAPSC == cbbMaPhieuSuaChua.SelectedValue.ToString() select new {p.PHIEUTIEPNHAN.MAKHACHKHACH,p.PHIEUTIEPNHAN.KHACHHANG.TENKHACHHANG, p.TRANGTHAI,p.TONGTIEN }).FirstOrDefault();
            lbMKH.Text = psc.MAKHACHKHACH;
            cbbKhachHang.Text = psc.TENKHACHHANG;
            if(psc.TRANGTHAI.Value.ToString()=="True")
            {
                txtTongTien.Text = "0";
            }
            else
            {
                txtTongTien.Text = psc.TONGTIEN.ToString();
            }
        }

        private void cbbKhachHang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbbKhachHang.Text + "   " + lbMKH.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }
    }
}