using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
           
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
            XtraForm fff = new frm_background();
            TabCreating(this.xtraTabControl1, "Màng Hình Chính", fff);
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }
        public void TabCreating(XtraTabControl TabControl, string Text, Form Form)
        {
            int Index = KiemTraTonTai(TabControl, Text);
            if (Index >= 0)
            {
                TabControl.SelectedTabPage = TabControl.TabPages[Index];
                TabControl.SelectedTabPage.Text = Text;

            }
            else
            {
                XtraTabPage TabPage = new XtraTabPage { Text = Text };
                TabControl.TabPages.Add(TabPage);
                TabControl.SelectedTabPage = TabPage;

                Form.TopLevel = false;
                Form.Parent = TabPage;
                //  Form.MdiParent = this;
                Form.Show();
                Form.Dock = DockStyle.Fill;
            }
        }

        static int KiemTraTonTai(XtraTabControl TabControlName, string TabName)
        {
            int temp = -1;
            for (int i = 0; i < TabControlName.TabPages.Count; i++)
            {
                if (TabControlName.TabPages[i].Text == TabName)
                {
                    temp = i;
                    break;
                }
            }
            return temp;
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            XtraTabControl TabControl = (XtraTabControl)sender;
            

            int i = TabControl.SelectedTabPageIndex;
            TabControl.TabPages.RemoveAt(TabControl.SelectedTabPageIndex);
            TabControl.SelectedTabPageIndex = i - 1;
        }


        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = new frmDangNhap();
            this.Hide();
            frm.ShowDialog();
        }

        private void btnSaoLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = new frmSaoLuu();
            frm.ShowDialog();
        }

        private void btnKhoiPhuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = new frmPhucHoi();
            frm.ShowDialog();
        }

        private void btnNhomNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmNhomNguoiDung();
            TabCreating(this.xtraTabControl1, "Nhóm người dùng", fff);
        }

        private void btnThemNguoiDungVaoNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmThemNguoiDungVaoNhomNguoiDung();
            TabCreating(this.xtraTabControl1, "Thêm vào nhóm người dùng", fff);
        }

        private void btnMangHinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmMangHinh();
            TabCreating(this.xtraTabControl1, "Màng hình", fff);
        }

        private void btnPhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmPhanQuyen();
            TabCreating(this.xtraTabControl1, "Phân quyền", fff);
        }

        private void btnBoPhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmDanhMucBoPhan();
            TabCreating(this.xtraTabControl1, "Bộ phận", fff);
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmDanhMucNhanVien();
            TabCreating(this.xtraTabControl1, "Nhân viên", fff);
        }

        private void btnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmDanhMucKhachHang();
            TabCreating(this.xtraTabControl1, "khách hàng", fff);
        }



        private void btnNhaSanXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmDanhMucNSX();
            TabCreating(this.xtraTabControl1, "Nhà sản xuất", fff);
        }

        private void btnBangBaoGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmDanhMucGia();
            TabCreating(this.xtraTabControl1, "Bảng báo giá", fff);
        }

        private void btnLoaiGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmDanhMucPhanLoaiGia();
            TabCreating(this.xtraTabControl1, "Loại giá", fff);
        }

        private void btnThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmDanhMucThietBi();
            TabCreating(this.xtraTabControl1, "Thiết bị", fff);
        }

        private void btnLinhKien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmDanhMucLinhKien();
            TabCreating(this.xtraTabControl1, "Linh Kiện", fff);
        }

        private void btnModel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmDanhMucModel();
            TabCreating(this.xtraTabControl1, "Model", fff);
        }

        private void btnTiepNhanSuaChuaBaoHanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmTaoPhieuTiepNhan();
            TabCreating(this.xtraTabControl1, "Danh sách phiếu tiếp nhận", fff);
        }

        private void btnQuanLySuaChuaBaoHanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmTaoPhieuSuaChua();
            TabCreating(this.xtraTabControl1, "Danh sách phiếu sửa chữa", fff);
        }

        private void btnSuaChuaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = new frmSuaChua();
            TabCreating(this.xtraTabControl1, "Sửa chữa", frm);
        }

        private void btnHoaDonThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmHoaDon();
            TabCreating(this.xtraTabControl1, "Danh sách phiếu hóa đơn", fff);
        }

        private void btnTimKiemKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmTimkiemKhachHang();
            TabCreating(this.xtraTabControl1, "Tìm kiếm khách hàng", fff);
        }

        private void btnTimKiemTienDoSuaChua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmTimKiemTienDoSuaChua();
            TabCreating(this.xtraTabControl1, "Tìm kiếm tiến độ sửa chữa", fff);
        }

        private void btnLinhKienCuaTungThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmThongKeLinhKien();
            TabCreating(this.xtraTabControl1, "Thống kê linh kiện", fff);
        }

        private void btnThietBiNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmThongKeThietBi();
            TabCreating(this.xtraTabControl1, "Thống kê thiết bị", fff);
        }

        private void btnDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmThongKeDanhThu();
            TabCreating(this.xtraTabControl1, "Thống kê doanh thu", fff);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm fff = new frmNguoiDung();
            TabCreating(this.xtraTabControl1, "Người dùng", fff);
        }
    }
}
