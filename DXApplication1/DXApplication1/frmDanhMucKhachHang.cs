﻿using System;
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

namespace DXApplication1
{
    public partial class frmDanhMucKhachHang : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
        public frmDanhMucKhachHang()
        {
            InitializeComponent();
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                txtTenKH.Enabled = true;
                txtDChi.Enabled = true;
                txtEmail.Enabled = true;
                txtSDT.Enabled = true;
                txtFax.Enabled = true;
                txtDienGiai.Enabled = true;

                txtDChi.Text = String.Empty;
                txtEmail.Text = String.Empty;
                txtFax.Text = String.Empty;
                txtSDT.Text = String.Empty;
                txtTenKH.Text = String.Empty;
                txtDienGiai.Text = String.Empty;

                btnThem.Text = "Lưu";
            }
            else
            {
                if (txtTenKH.Text == String.Empty || txtSDT.Text == String.Empty || txtDChi.Text==String.Empty)
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                }
                else
                {
                    KHACHHANG khachhang = new KHACHHANG();
                    //khachhang.MAKHACHKHACH = TangMa.ATTangMa2("KH", "KHACHHANG");
                    khachhang.MAKHACHKHACH = tangma.ThemMaKhachHang();
                    khachhang.TENKHACHHANG = txtTenKH.Text;
                    khachhang.SDTKH = int.Parse(txtSDT.Text);
                    khachhang.DIACHIKH = txtDChi.Text;
                    if (txtDienGiai.Text == null)
                    {
                        khachhang.GHICHU = txtDienGiai.Text = "";
                    }
                    else
                    {
                        khachhang.GHICHU = txtDienGiai.Text;
                    }
                    if (txtFax.Text == null || txtFax.Text == "") 
                    {
                        khachhang.FAX = null;
                    }
                    else
                    {
                        khachhang.FAX = int.Parse(txtFax.Text);
                    }
                    
                    khachhang.EMAILKH = txtEmail.Text;
                    qltb.KHACHHANGs.InsertOnSubmit(khachhang);
                    qltb.SubmitChanges();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo");
                    LoadGridviewkhachhang();

                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;

                    btnThem.Text = "Thêm";
                    txtTenKH.Enabled = false;
                    txtDChi.Enabled = false;
                    txtEmail.Enabled = false;
                    txtSDT.Enabled = false;
                    txtFax.Enabled = false;

                    txtDienGiai.Enabled = false;

                    txtTenKH.Text = String.Empty;
                    txtDienGiai.Text = String.Empty;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;

                txtTenKH.Enabled = true;
                txtDChi.Enabled = true;
                txtEmail.Enabled = true;
                txtSDT.Enabled = true;
                txtFax.Enabled = true;

                txtDienGiai.Enabled = true;

                btnSua.Text = "Lưu";
            }
            else
            {
                string makh = dgtvKhachHang.CurrentRow.Cells[0].Value.ToString();
                KHACHHANG kh = qltb.KHACHHANGs.Where(t => t.MAKHACHKHACH == makh).FirstOrDefault();
                kh.TENKHACHHANG = txtTenKH.Text;
                kh.SDTKH = int.Parse(txtSDT.Text);
                kh.DIACHIKH = txtDChi.Text;
                kh.GHICHU = txtDienGiai.Text;
                if (txtFax.Text == "" || txtFax.Text == null)
                {
                    kh.FAX = null;
                }
                else
                {
                    kh.FAX = int.Parse(txtFax.Text);
                }        
                kh.EMAILKH = txtEmail.Text;
                qltb.SubmitChanges();
                XtraMessageBox.Show("Sửa thành công","Thông báo");
                LoadGridviewkhachhang();

                btnThem.Enabled = true;
                btnXoa.Enabled = true;

                btnSua.Text = "Sửa";
                txtTenKH.Enabled = false;
                txtDChi.Enabled = false;
                txtEmail.Enabled = false;
                txtSDT.Enabled = false;
                txtFax.Enabled = false;

                txtDienGiai.Enabled = false;

                txtTenKH.Text = String.Empty;
                txtDienGiai.Text = String.Empty;
            }
        }
        public void LoadGridviewkhachhang()
        {
            var khachhang = from kh in qltb.KHACHHANGs
                            select new { kh.MAKHACHKHACH, kh.TENKHACHHANG, kh.DIACHIKH, kh.SDTKH, kh.FAX, kh.EMAILKH, kh.GHICHU };
            dgtvKhachHang.DataSource = khachhang;
        }

        private void frmDanhMucKhachHang_Load(object sender, EventArgs e)
        {
            LoadGridviewkhachhang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    string makhachhang = dgtvKhachHang.CurrentRow.Cells[0].Value.ToString();
                    KHACHHANG khachhang = qltb.KHACHHANGs.Where(t => t.MAKHACHKHACH == makhachhang).FirstOrDefault();
                    qltb.KHACHHANGs.DeleteOnSubmit(khachhang);
                    qltb.SubmitChanges();
                    XtraMessageBox.Show("Xóa thành công", "Thong báo");
                    LoadGridviewkhachhang();
                }
                catch
                {
                    XtraMessageBox.Show("Dữ liệu đang được sử dụng!", "Thông báo");
                }
            }

            if (dr == DialogResult.No)
            {
                this.Close();
            }

        }

        private void dgtvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtTenKH.Enabled = false;
                txtDChi.Enabled = false;
                txtEmail.Enabled = false;
                txtSDT.Enabled = false;
                txtFax.Enabled = false;
                txtDienGiai.Enabled = false;

                txtTenKH.Text = dgtvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtDChi.Text = dgtvKhachHang.CurrentRow.Cells[2].Value.ToString();
                txtSDT.Text = dgtvKhachHang.CurrentRow.Cells[3].Value.ToString(); 
                if(dgtvKhachHang.CurrentRow.Cells[4].Value == null)
                {
                    txtFax.Text = null;
                }
                else
                {
                    txtFax.Text = dgtvKhachHang.CurrentRow.Cells[4].Value.ToString();
                }
                txtEmail.Text = dgtvKhachHang.CurrentRow.Cells[5].Value.ToString();
                txtDienGiai.Text = dgtvKhachHang.CurrentRow.Cells[6].Value.ToString();

            }
            catch { }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Report.DanhMucKhachHang_Report report = new Report.DanhMucKhachHang_Report();
            ReportPrintTool rpt = new ReportPrintTool(report);
            report.CreateDocument(false);
            report.ShowPreviewDialog();
        }
    }
}
