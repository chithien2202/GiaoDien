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

namespace DXApplication1
{
    public partial class frmDanhMucKhachHang : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmDanhMucKhachHang()
        {
            InitializeComponent();
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {

                txtTenKH.Enabled = true;
                txtDChi.Enabled = true;
                txtEmail.Enabled = true;
                txtSDT.Enabled = true;
                txtFax.Enabled = true;

                txtDienGiai.Enabled = true;

                btnThem.Text = "Lưu";
            }
            else
            {
                KHACHHANG khachhang = new KHACHHANG();
                khachhang.MAKHACHKHACH = TangMa.ATTangMa2("KH", "KHACHHANG");
                khachhang.TENKHACHHANG = txtTenKH.Text;
                khachhang.SDTKH = int.Parse(txtSDT.Text);
                khachhang.DIACHIKH = txtDChi.Text;
                khachhang.GHICHU = txtDienGiai.Text;
                khachhang.FAX = int.Parse(txtFax.Text);
                khachhang.EMAILKH = txtEmail.Text;
                qltb.KHACHHANGs.InsertOnSubmit(khachhang);
                qltb.SubmitChanges();
                MessageBox.Show("Success");
                LoadGridviewkhachhang();

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {

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
                kh.FAX = int.Parse(txtFax.Text);
                kh.EMAILKH = txtEmail.Text;
                qltb.SubmitChanges();
                MessageBox.Show("Sửa thành công");
                LoadGridviewkhachhang();

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
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                string makhachhang = dgtvKhachHang.CurrentRow.Cells[0].Value.ToString();
                KHACHHANG khachhang = qltb.KHACHHANGs.Where(t => t.MAKHACHKHACH == makhachhang).FirstOrDefault();
                qltb.KHACHHANGs.DeleteOnSubmit(khachhang);
                qltb.SubmitChanges();
                MessageBox.Show("Delete Success!");
                LoadGridviewkhachhang();
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
                txtFax.Text = dgtvKhachHang.CurrentRow.Cells[4].Value.ToString();
                txtEmail.Text = dgtvKhachHang.CurrentRow.Cells[5].Value.ToString();
                txtDienGiai.Text = dgtvKhachHang.CurrentRow.Cells[6].Value.ToString();

            }
            catch { }
        }
    }
}
