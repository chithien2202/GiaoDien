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
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

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

        
        void loadKH()
        {
            var kh = from k in qltb.KHACHHANGs select k;
            cbbKhachHang.Properties.DataSource = kh;
            cbbKhachHang.Properties.DisplayMember = "TENKHACHHANG";
            cbbKhachHang.Properties.ValueMember = "MAKHACHKHACH";

        }
        
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            string mahd = txtMaHoaDon.Text;
            LoadGridViewHoaDon();
            btnSua.Enabled = false;
            //LoadCbbPSC();
            loadKH();
            //  cbbMaPhieuTiepNhan.Enabled = false;
            //dtpNgayLap.Enabled = false;
            //txtMaHoaDon.Enabled = false;
            //   txtKhachHang.Enabled = false;
            grbTTHD.Enabled = false;
         
            txtNhanVienLap.Enabled = false;
        }

        public void LoadCbbPSC()
        {
            //cbbMaPhieuTiepNhan.DataSource = qltb.PHIEUTIEPNHANs;
            //cbbMaPhieuTiepNhan.DisplayMember = "MAPHIEUTN";
            //cbbMaPhieuTiepNhan.ValueMember = "MAPHIEUTN";
        }

        private void cbbMaPhieuSuaChua_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var tongtien = (from pk in qltb.PHIEUSUACHUAs
            //            where pk.MAPSC == cbbMaPhieuTiepNhan.SelectedValue.ToString()
            //            select pk.TONGTIEN).FirstOrDefault();

          //  txtTongTien.Text = tongtien.ToString();
        }

        private void cbbMaPhieuSuaChua_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ////var kh = (from k in qltb.HOADONs where k.MAPSC == cbbMaPhieuSuaChua.SelectedValue.ToString() select new { k.MAKHACHHANG, k.KHACHHANG.TENKHACHHANG, k.PHIEUSUACHUA.TRANGTHAI,k.PHIEUSUACHUA.TONGTIEN }).FirstOrDefault();
            //var psc = (from p in qltb.PHIEUSUACHUAs where p.MAPHIEUTN == cbbMaPhieuTiepNhan.SelectedValue.ToString() select new {p.PHIEUTIEPNHAN.MAKHACHKHACH,p.PHIEUTIEPNHAN.KHACHHANG.TENKHACHHANG, p.TRANGTHAI,p.TONGTIEN }).FirstOrDefault();
            //lbMKH.Text = psc.MAKHACHKHACH;
            //txtKhachHang.Text = psc.TENKHACHHANG;
            //if(psc.TRANGTHAI.Value.ToString()=="True")
            //{
            //    txtTongTien.Text = "0";
            //}
            //else
            //{
            //    txtTongTien.Text = psc.TONGTIEN.ToString();
            //}
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnXoa.Enabled = false;
                btnSua.Enabled = false;

                dtgvPSC.Enabled = true;
                dtpNgayLap.Enabled = true;
                txtMaHoaDon.Enabled = false;
                cbbKhachHang.Enabled = true;
                txtNhanVienLap.Enabled = false;

                grbTTHD.Enabled = true;
                
                txtMaHoaDon.Text = String.Empty;
                txtNhanVienLap.Text = String.Empty;
                txtTongTien.Text = String.Empty;
                foreach(DataGridViewRow r in dtgvCTHD.Rows)
                {
                    dtgvCTHD.Rows.Remove(r);
                }
                btnThem.Text = "Lưu";
            }
            else
            {
                //if (cbbMaPhieuTiepNhan.Text == String.Empty || txtKhachHang.Text == String.Empty) 
                //{
                //    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                //}
                //else
                //{
                    //HOADON hd = new HOADON();
                    //hd.MAHOADON = tangma.ThemMaHoaDon();
                    //hd.MAKHACHHANG = lbMKH.Text;
                    //hd.MAPSC = cbbMaPhieuTiepNhan.Text;
                    //hd.MANHANVIEN = Program.mainForm.getUserName;
                    //hd.NGAYLAP = dtpNgayLap.Value;
                    //hd.TONGTIEN = decimal.Parse(txtTongTien.Text);
                    //qltb.HOADONs.InsertOnSubmit(hd);
                    //qltb.SubmitChanges();
                    //XtraMessageBox.Show("Thêm thành công", "Thông báo");
                    //LoadGridViewHoaDon();

                if(dtgvCTHD.Rows.Count<1)
                {
                    XtraMessageBox.Show("1 hóa đơn cần có ít nhất 1 chi tiết hóa đơn","Thông báo");
                    return;
                }
               

                List<string> lstmpsc = new List<string>();

                foreach (DataGridViewRow r in dtgvCTHD.Rows)
                {
                    int trung = 0;
                    foreach (string ma in lstmpsc)
                    {
                        if (r.Cells["PSC"].Value.ToString() == ma)
                        {
                            trung ++;
                            break;
                        }
                        
                    }
                    if(trung ==0)
                    {
                        lstmpsc.Add(r.Cells["PSC"].Value.ToString());
                    }
                    trung = 0;
                }


                foreach (string mapsc in lstmpsc)
                {
                    HOADON hd = new HOADON();
                    hd.MAHOADON = tangma.ThemMaHoaDon();
                    hd.MAKHACHHANG = cbbKhachHang.EditValue.ToString();
                    hd.MANHANVIEN = Program.mainForm.getUserName;
                    hd.NGAYLAP = dtpNgayLap.Value;
                    hd.TONGTIEN = 0;
                    hd.MAPSC = mapsc;
                    qltb.HOADONs.InsertOnSubmit(hd);
                    qltb.SubmitChanges();

                    foreach (DataGridViewRow r in dtgvCTHD.Rows)
                    {
                        if (r.Cells["PSC"].Value.ToString() == mapsc)
                        {
                            CHITIETHOADON ct = new CHITIETHOADON();
                            ct.MAHOADON = hd.MAHOADON;
                            ct.MALINHKIEN = r.Cells["MaLK"].Value.ToString();
                            ct.NGAYKETTHUCBH = DateTime.Parse(r.Cells["NgayKT"].Value.ToString());
                            ct.THANHTIEN = decimal.Parse(r.Cells["ThanhTien"].Value.ToString());
                            ct.GIATHANH = decimal.Parse(r.Cells["GiaThanh"].Value.ToString());
                            ct.TRANGTHAI = bool.Parse(r.Cells["BH"].Value.ToString());
                            qltb.CHITIETHOADONs.InsertOnSubmit(ct);
                            qltb.SubmitChanges();
                            HOADON hdcn = qltb.HOADONs.Where(x => x.MAHOADON == ct.MAHOADON).FirstOrDefault();
                            hdcn.TONGTIEN += ct.THANHTIEN;
                            qltb.SubmitChanges();
                        }
                    }
                }

                XtraMessageBox.Show("Tạo hóa đơn thành công","Thông báo");

                btnXoa.Enabled = true;
                    btnSua.Enabled = true;

                    btnThem.Text = "Thêm";

                    dtgvPSC.Enabled = false;
                    dtpNgayLap.Enabled = false;
                    txtMaHoaDon.Enabled = false;
                    cbbKhachHang.Enabled = false;
                    txtNhanVienLap.Enabled = false;

               //     cbbMaPhieuTiepNhan.Text = String.Empty;
                    txtMaHoaDon.Text = String.Empty;
                  //  txtKhachHang.Text = String.Empty;
                    txtNhanVienLap.Text = String.Empty;
                LoadGridViewHoaDon();
                //}
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
            // cbbMaPhieuTiepNhan.Text = dtgvDSHoaDon.CurrentRow.Cells[2].Value.ToString();

            var tenkhachhang = (from ma in qltb.KHACHHANGs
                              where ma.MAKHACHKHACH == dtgvDSHoaDon.CurrentRow.Cells[1].Value.ToString()
                              select ma.TENKHACHHANG).FirstOrDefault();
            cbbKhachHang.Text = tenkhachhang;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void loadcbbPTN()
        {
            var ptn = from p in qltb.PHIEUTIEPNHANs where p.MAKHACHKHACH== cbbKhachHang.EditValue.ToString() select p;
            cbbPTN.DataSource = ptn;
            cbbPTN.DisplayMember = "MAPHIEUTN";
            cbbPTN.ValueMember = "MAPHIEUTN";
        }
        private void cbbKhachHang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //loadcbbPTN();
            //psc();
        }
        void loaddtgvPSC()
        {
            var sc = (from s in qltb.PHIEUSUACHUAs where s.MAPHIEUTN == cbbPTN.SelectedValue.ToString() select s).FirstOrDefault();
            var ctsc = from c in qltb.CHITIETSUACHUAs where c.MAPSC == sc.MAPSC select new { c.MAPSC, c.MACTSC, c.MALINHKIEN, c.LINHKIEN.TENLINHKIEN, c.NGAYSUA };
            dtgvPSC.DataSource = ctsc;
            
        }
        private void cbbPTN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loaddtgvPSC();
        }

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            if(dtgvPSC.SelectedRows.Count>0)
            {
                DataGridViewRow ctsc = dtgvPSC.CurrentRow;
                var ctpsc = (from c in qltb.CHITIETSUACHUAs where c.MACTSC == ctsc.Cells["MaCTSC"].Value.ToString() select c).FirstOrDefault();
                DateTime ngs= DateTime.Parse(ctsc.Cells["NgaySua"].Value.ToString());
                DateTime ngaykt = ngs.AddMonths(3);
                string tt = "";
                if (ctpsc.TRANGTHAI == true)
                {
                    tt = "0";
                }
                else
                    tt = ctpsc.GIATHANH.ToString();
                dtgvCTHD.Rows.Add(ctsc.Cells["MLK"].Value.ToString(), ctsc.Cells["TenLK"].Value.ToString(),ngaykt.ToString(),tt,ctpsc.TRANGTHAI,ctpsc.GIATHANH, ctsc.Cells["MaPSC"].Value.ToString());

                Tong();
            }
        }

        void  Tong()
        {
            double tt = 0;
            foreach(DataGridViewRow r in dtgvCTHD.Rows)
            {
                tt += double.Parse(r.Cells["ThanhTien"].Value.ToString());
            }
            txtTongTien.Text=tt.ToString();
        }

        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {
            if(dtgvCTHD.SelectedRows.Count>0)
            {
                DialogResult d = XtraMessageBox.Show("Bạn có chắc muốn xóa?","Thông báo", MessageBoxButtons.OKCancel);
                if(d == DialogResult.OK)
                {
                    dtgvCTHD.Rows.Remove(dtgvCTHD.CurrentRow);
                    XtraMessageBox.Show("Đã xóa");
                    Tong();
                }
                
            }
        }

        void psc()
        {
           foreach(DataGridViewRow r in dtgvPSC.Rows)
            {
                PHIEUSUACHUA psc = qltb.PHIEUSUACHUAs.Where(x => x.MAPSC == r.Cells["MaPSC"].Value.ToString()).FirstOrDefault();
                var hds = from h in qltb.HOADONs select h;
                foreach (var hd in hds)
                {
                    if (psc.MAPSC == hd.MAPSC)
                    {
                        dtgvPSC.Rows.Remove(r);
                    }
                }
            }
        }

        private void dtgvPSC_Click(object sender, EventArgs e)
        {
            if(dtgvPSC.SelectedRows.Count>0)
            {
                PHIEUSUACHUA psc = qltb.PHIEUSUACHUAs.Where(x => x.MAPSC == dtgvPSC.CurrentRow.Cells["MaPSC"].Value.ToString()).FirstOrDefault();
                var hds = from h in qltb.HOADONs select h;
                foreach (var hd in hds)
                {
                    if(psc.MAPSC == hd.MAPSC)
                    {
                        btnThemCTHD.Enabled = false;
                        return;
                    }
                    else
                    {
                        btnThemCTHD.Enabled = true;
                    }
                }
            }
        }

        private void cbbKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            loadcbbPTN();
            psc();
        }

        private void dtgvDSHoaDon_Click(object sender, EventArgs e)
        {
            if (dtgvDSHoaDon.SelectedRows.Count > 0)
            {
                var chitiethoadon = from cthd in qltb.CHITIETHOADONs
                                    where cthd.MAHOADON == dtgvDSHoaDon.CurrentRow.Cells[0].Value.ToString()
                                    select new
                                    {
                                        cthd.MALINHKIEN,
                                        cthd.TRANGTHAI,
                                        cthd.GIATHANH,
                                        cthd.THANHTIEN
                                     };
                dtgvCTHD.DataSource = chitiethoadon;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-6V52PV4\SQLEXPRESS; Initial Catalog = QLTB; Integrated Security = True");
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from CHITIETHOADON where MAHOADON = '" + txtMaHoaDon.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            Report.HoaDon_Report report = new Report.HoaDon_Report();
            report.DataSource = dt;
            report.ShowPreviewDialog();


            //Report.HoaDon_Report report = new Report.HoaDon_Report();
            //ReportPrintTool rpt = new ReportPrintTool(report);
            //report.CreateDocument(false);
            //report.ShowPreviewDialog();
        }
    }
}