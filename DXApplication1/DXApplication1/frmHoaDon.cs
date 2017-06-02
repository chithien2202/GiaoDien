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
        TangMa tangma = new TangMa();
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadGridViewHoaDon();
            LoadCbbPSC();
            cbbMaPhieuSuaChua.Enabled = false;
            dtpNgayLap.Enabled = false;
            txtMaHoaDon.Enabled = false;
            txtKhachHang.Enabled = false;
            txtNhanVienLap.Enabled = false;
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
            //var kh = (from k in qltb.HOADONs where k.MAPSC == cbbMaPhieuSuaChua.SelectedValue.ToString() select new { k.MAKHACHHANG, k.KHACHHANG.TENKHACHHANG, k.PHIEUSUACHUA.TRANGTHAI,k.PHIEUSUACHUA.TONGTIEN }).FirstOrDefault();
            var psc = (from p in qltb.PHIEUSUACHUAs where p.MAPSC == cbbMaPhieuSuaChua.SelectedValue.ToString() select new {p.PHIEUTIEPNHAN.MAKHACHKHACH,p.PHIEUTIEPNHAN.KHACHHANG.TENKHACHHANG, p.TRANGTHAI,p.TONGTIEN }).FirstOrDefault();
            lbMKH.Text = psc.MAKHACHKHACH;
            txtKhachHang.Text = psc.TENKHACHHANG;
            if(psc.TRANGTHAI.Value.ToString()=="True")
            {
                txtTongTien.Text = "0";
            }
            else
            {
                txtTongTien.Text = psc.TONGTIEN.ToString();
            }
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnXoa.Enabled = false;
                btnSua.Enabled = false;

                cbbMaPhieuSuaChua.Enabled = true;
                dtpNgayLap.Enabled = true;
                txtMaHoaDon.Enabled = false;
                txtKhachHang.Enabled = false;
                txtNhanVienLap.Enabled = false;

                cbbMaPhieuSuaChua.Text = String.Empty;
                txtMaHoaDon.Text = String.Empty;
                txtKhachHang.Text = String.Empty;
                txtNhanVienLap.Text = String.Empty;

                btnThem.Text = "Lưu";
            }
            else
            {
                if (cbbMaPhieuSuaChua.Text == String.Empty || txtKhachHang.Text == String.Empty) 
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    HOADON hd = new HOADON();
                    hd.MAHOADON = tangma.ThemMaHoaDon();
                    hd.MAKHACHHANG = lbMKH.Text;
                    hd.MAPSC = cbbMaPhieuSuaChua.Text;
                    hd.MANHANVIEN = Program.mainForm.getUserName;
                    hd.NGAYLAP = dtpNgayLap.Value;
                    hd.TONGTIEN = decimal.Parse(txtTongTien.Text);
                    qltb.HOADONs.InsertOnSubmit(hd);
                    qltb.SubmitChanges();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");
                    LoadGridViewHoaDon();

                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;

                    btnThem.Text = "Thêm";

                    cbbMaPhieuSuaChua.Enabled = false;
                    dtpNgayLap.Enabled = false;
                    txtMaHoaDon.Enabled = false;
                    txtKhachHang.Enabled = false;
                    txtNhanVienLap.Enabled = false;

                    cbbMaPhieuSuaChua.Text = String.Empty;
                    txtMaHoaDon.Text = String.Empty;
                    txtKhachHang.Text = String.Empty;
                    txtNhanVienLap.Text = String.Empty;
                }
            }
        }



        public void LoadGridViewHoaDon()
        {
            var hoadon = from hd in qltb.HOADONs
                        select new { hd.MAHOADON, hd.MAKHACHHANG, hd.MAPSC, hd.MANHANVIEN, hd.NGAYLAP, hd.TONGTIEN };
            dtgvDSHoaDon.DataSource = hoadon;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)

            {
                try
                {
                    string mahoadon = dtgvDSHoaDon.CurrentRow.Cells[0].Value.ToString();
                    HOADON hoadon = qltb.HOADONs.Where(t => t.MAHOADON == mahoadon).FirstOrDefault();
                    qltb.HOADONs.DeleteOnSubmit(hoadon);
                    qltb.SubmitChanges();
                    XtraMessageBox.Show("Xóa thành công", "Thông báo");
                    LoadGridViewHoaDon();
                }
                catch
                {
                    XtraMessageBox.Show("Dữ liệu đang được sử dụng, không thể xóa!", "Thông báo");
                }
            }

            if (dr == DialogResult.No)

            {
                this.Close();
            }
        }

        private void dtgvDSHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHoaDon.Text = dtgvDSHoaDon.CurrentRow.Cells[0].Value.ToString();
            txtNhanVienLap.Text = dtgvDSHoaDon.CurrentRow.Cells[3].Value.ToString();
            dtpNgayLap.Text = dtgvDSHoaDon.CurrentRow.Cells[4].Value.ToString();
            txtTongTien.Text = dtgvDSHoaDon.CurrentRow.Cells[5].Value.ToString();
            cbbMaPhieuSuaChua.Text = dtgvDSHoaDon.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}