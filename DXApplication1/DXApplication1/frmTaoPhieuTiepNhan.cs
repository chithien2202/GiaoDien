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
using DevExpress.XtraTab;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace DXApplication1
{
    public partial class frmTaoPhieuTiepNhan : DevExpress.XtraEditors.XtraForm
    {
        HamLayNgay layngay = new HamLayNgay();
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
        public frmTaoPhieuTiepNhan()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {
        
        }
        //Ví dụ nè
        public void TrangThai()
        {
            //ngày bắt đầu
            var ngaybd = (from q in qltb.THIETBIs
                          where q.SERIAL == cbbThietBi.EditValue.ToString()
                          select q.NGAYMUA_SUACHUA).FirstOrDefault();

            var ngaykt = (from q in qltb.THIETBIs
                          where q.SERIAL == cbbThietBi.EditValue.ToString()
                          select q.NGAYKETTHUC).FirstOrDefault();

            if(DateTime.Now > ngaybd && DateTime.Now < ngaykt)
            {

            }


        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void timeEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                txtMaPTN.Enabled = false;
                dtpNgayNhap.Enabled = true;
                dtpNgayHenTra.Enabled = true;
                cbbKhachHang.Enabled = true;
                cbbThietBi.Enabled = true;
                txtPhuKienDiCung.Enabled = true;
                txtTinhTrangHuHong.Enabled = true;
                txtGhiChu.Enabled = true;
                chkDaNhan.Enabled = false;

                txtPhuKienDiCung.Text = String.Empty;
                txtGhiChu.Text = String.Empty;
                txtTinhTrangHuHong.Text= String.Empty;
                txtMaPTN.Text = String.Empty;


                btnThem.Text = "Lưu";
            }
            else
            {
                if (txtTinhTrangHuHong.Text == String.Empty || cbbThietBi.Text == String.Empty) 
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    PHIEUTIEPNHAN ptn = new PHIEUTIEPNHAN();
                    ptn.MAPHIEUTN = tangma.ThemMaPTN();
                    ptn.MATHIETBI = cbbThietBi.EditValue.ToString();
                    ptn.MANHANVIEN = Program.mainForm.getUserName;
                    ptn.MANHANVIENNHANMAY = null;
                    ptn.MAKHACHKHACH = cbbKhachHang.Text;
                    ptn.NGAYNHAN = dtpNgayNhap.Value;
                    ptn.NGAYHENTRA = dtpNgayHenTra.Value;
                    ptn.TINHHINHHUHONG = txtTinhTrangHuHong.Text;
                    ptn.PHUKIENKEMTHEO = txtPhuKienDiCung.Text;
                    //ptn.HINHTHUC = null;
                    var ngaybd = (from q in qltb.THIETBIs
                                  where q.MATHIETBI == cbbThietBi.EditValue.ToString()
                                  select q.NGAYMUA_SUACHUA).FirstOrDefault();

                    var ngaykt = (from q in qltb.THIETBIs
                                  where q.MATHIETBI == cbbThietBi.EditValue.ToString()
                                  select q.NGAYKETTHUC).FirstOrDefault();
              
                    if (DateTime.Now >= ngaybd && DateTime.Now <= ngaykt)
                    {
                        ptn.HINHTHUC = true;
                    }
                    if(DateTime.Now > ngaykt)
                    {
                        ptn.HINHTHUC = false;
                    }


                    ptn.GHICHUPTN = txtGhiChu.Text;
                    qltb.PHIEUTIEPNHANs.InsertOnSubmit(ptn);
                    qltb.SubmitChanges();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");
                    LoadGridViewPTN();

                    btnThem.Text = "Thêm";

                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
            }
        }


        public void LoadCbbKhachHang()
        {
            cbbKhachHang.Properties.DataSource = qltb.KHACHHANGs;
            cbbKhachHang.Properties.DisplayMember = "MAKHACHKHACH";
            cbbKhachHang.Properties.ValueMember = "MAKHACHKHACH";
        }

        public void LoadCbbThietBi()
        { 
            cbbThietBi.Properties.DataSource = qltb.THIETBIs;
            cbbThietBi.Properties.DisplayMember = "SERIAL";
            cbbThietBi.Properties.ValueMember = "MATHIETBI";
        }

        private void frmTaoPhieuTiepNhan_Load(object sender, EventArgs e)
        {
            LoadCbbKhachHang();
            LoadCbbThietBi();
            LoadGridViewPTN();

            txtMaPTN.Enabled = false;
            dtpNgayNhap.Enabled = false;
            dtpNgayHenTra.Enabled = false;
            cbbKhachHang.Enabled = false;
            cbbThietBi.Enabled = false;
            txtPhuKienDiCung.Enabled = false;
            txtTinhTrangHuHong.Enabled = false;
            txtGhiChu.Enabled = false;
            chkDaNhan.Enabled = false;
        }

        private void LoadGridViewPTN()
        {
            var phieutiepnhan = from ptn in qltb.PHIEUTIEPNHANs
                          select new { ptn.MAPHIEUTN, ptn.MATHIETBI, ptn.MANHANVIEN, ptn.MANHANVIENNHANMAY, ptn.MAKHACHKHACH, ptn.NGAYNHAN,
                              ptn.NGAYHENTRA, ptn.TINHHINHHUHONG, ptn.PHUKIENKEMTHEO, ptn.HINHTHUC, ptn.GHICHUPTN };
            dtgvDSPTN.DataSource = phieutiepnhan;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            XtraForm fff = new frmDanhMucKhachHang();
            fff.ShowDialog();
        }

        private void btnThemThietBi_Click(object sender, EventArgs e)
        {
            XtraForm fff = new frmDanhMucThietBi();
            fff.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        string maptn = dtgvDSPTN.CurrentRow.Cells[0].Value.ToString();
                        PHIEUTIEPNHAN ptn = qltb.PHIEUTIEPNHANs.Where(t => t.MAPHIEUTN == maptn).FirstOrDefault();
                        qltb.PHIEUTIEPNHANs.DeleteOnSubmit(ptn);
                        qltb.SubmitChanges();
                        XtraMessageBox.Show("Xóa thành công", "Thông báo");
                        LoadGridViewPTN();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;

                txtMaPTN.Enabled = false;
                dtpNgayNhap.Enabled = true;
                dtpNgayHenTra.Enabled = true;
                cbbKhachHang.Enabled = true;
                cbbThietBi.Enabled = true;
                txtTinhTrangHuHong.Enabled = true;
                txtGhiChu.Enabled = true;
                txtPhuKienDiCung.Enabled = true;
                chkDaNhan.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string maptn = dtgvDSPTN.CurrentRow.Cells[0].Value.ToString();
                PHIEUTIEPNHAN ptn = qltb.PHIEUTIEPNHANs.Where(t => t.MAPHIEUTN == maptn).FirstOrDefault();
                ptn.NGAYNHAN = dtpNgayNhap.Value;
                ptn.NGAYHENTRA = dtpNgayHenTra.Value;
                if(chkDaNhan.Checked)
                {
                    ptn.MANHANVIENNHANMAY = Program.mainForm.getUserName;
                }
                ptn.PHUKIENKEMTHEO = txtPhuKienDiCung.Text;
                ptn.TINHHINHHUHONG = txtTinhTrangHuHong.Text;
                ptn.GHICHUPTN = txtGhiChu.Text;
                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công", "Thông báo");
                LoadGridViewPTN();

                btnThem.Enabled = true;
                btnXoa.Enabled = true;

                btnSua.Text = "Sửa";

                txtMaPTN.Enabled = false;
                dtpNgayNhap.Enabled = false;
                dtpNgayHenTra.Enabled = false;
                cbbKhachHang.Enabled = false;
                cbbThietBi.Enabled = false;
                txtPhuKienDiCung.Enabled = false;
                txtTinhTrangHuHong.Enabled = false;
                txtGhiChu.Enabled = false;

                txtPhuKienDiCung.Text = String.Empty;
                txtTinhTrangHuHong.Text = String.Empty;
                txtGhiChu.Text = String.Empty;
            }
        }

        private void dtgvDSPTN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaPTN.Enabled = false;
                dtpNgayNhap.Enabled = false;
                dtpNgayHenTra.Enabled = false;
                cbbKhachHang.Enabled = false;
                cbbThietBi.Enabled = false;
                txtPhuKienDiCung.Enabled = false;
                txtTinhTrangHuHong.Enabled = false;
                txtGhiChu.Enabled = false;
                chkDaNhan.Enabled = false;

                txtMaPTN.Text = dtgvDSPTN.CurrentRow.Cells[0].Value.ToString();
                cbbThietBi.Text = dtgvDSPTN.CurrentRow.Cells[1].Value.ToString();
                dtpNgayNhap.Text = dtgvDSPTN.CurrentRow.Cells[5].Value.ToString();
                dtpNgayHenTra.Text = dtgvDSPTN.CurrentRow.Cells[6].Value.ToString();
                cbbKhachHang.Text = dtgvDSPTN.CurrentRow.Cells[4].Value.ToString();
                if (dtgvDSPTN.CurrentRow.Cells[8].Value == null || dtgvDSPTN.CurrentRow.Cells[8].Value.ToString() == "")
                {
                    txtPhuKienDiCung.Text = "";
                }
                else
                {
                    txtPhuKienDiCung.Text = dtgvDSPTN.CurrentRow.Cells[8].Value.ToString();
                }

                if (dtgvDSPTN.CurrentRow.Cells[7].Value == null || dtgvDSPTN.CurrentRow.Cells[7].Value.ToString() == "")
                {
                    txtTinhTrangHuHong.Text = "";
                }
                else
                {
                    txtTinhTrangHuHong.Text = dtgvDSPTN.CurrentRow.Cells[7].Value.ToString();
                }
                if (dtgvDSPTN.CurrentRow.Cells[10].Value == null || dtgvDSPTN.CurrentRow.Cells[10].Value.ToString() == "")
                {
                    txtGhiChu.Text = "";
                }
                else
                {
                    txtGhiChu.Text = dtgvDSPTN.CurrentRow.Cells[10].Value.ToString();
                }

                if (dtgvDSPTN.CurrentRow.Cells[3].Value == null || dtgvDSPTN.CurrentRow.Cells[3].Value.ToString() == "")
                {
                    chkDaNhan.Checked = false;
                }
                else
                {
                    chkDaNhan.Checked = true;
                }

                var serial = (from ma in qltb.THIETBIs
                                    where ma.MATHIETBI == dtgvDSPTN.CurrentRow.Cells[1].Value.ToString()
                                    select ma.SERIAL).FirstOrDefault();
                cbbThietBi.Text = serial;
            }
            catch { }
        }



        private void btnIn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-6V52PV4\SQLEXPRESS; Initial Catalog = QLTB; Integrated Security = True");
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from ReportPTN where MAPHIEUTN = '" + txtMaPTN.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            Report.PhieuTiepNhan_Report report = new Report.PhieuTiepNhan_Report();
            report.DataSource = dt;
            report.ShowPreviewDialog();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThietBi_Click(object sender, EventArgs e)
        {
            Form frm = new frmDanhMucThietBi();
            frm.ShowDialog();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            Form frm = new frmDanhMucKhachHang();
            frm.ShowDialog();
        }
    }
}