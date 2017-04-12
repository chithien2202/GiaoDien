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
    public partial class frmThongTinNhomKhachHang : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmThongTinNhomKhachHang()
        {
            InitializeComponent();
        }

        private void frmThongTinNhomKhachHang_Load(object sender, EventArgs e)
        {
            if (frmDanhMucNhomKhachHang.tos == true)
            {
                btnLuu.Text = "Thêm";
                txtMaNhomKH.Enabled = true;
               
            }
            else
            {
                btnLuu.Text = "Sửa";
                txtMaNhomKH.Enabled = false;
                NHOMKHACHHANG nhomkh = qltb.NHOMKHACHHANGs.Where(t => t.MANHOMKH== frmDanhMucNhomKhachHang.manhommkh).FirstOrDefault();
                txtMaNhomKH.Text = nhomkh.MANHOMKH;
                txtTenNhomKH.Text = nhomkh.TENNHOMKH;

                txtDienGiai.Text = nhomkh.GHICHU;
                txtKhuyenMai.Text = nhomkh.KHUYENMAI.ToString();
                
            }
        }
        TangMa tm = new TangMa();
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (frmDanhMucNhomKhachHang.tos == true)
            {
                NHOMKHACHHANG nhomkh = new NHOMKHACHHANG();
                //Chỗ này có vấn đề xem lại dùm
                nhomkh.MANHOMKH= tm.ATTangMa3("NKH", "NHOMKHACHHANG");
             
                nhomkh.TENNHOMKH = txtTenNhomKH.Text;
                nhomkh.KHUYENMAI = int.Parse(txtKhuyenMai.Text);
                nhomkh.GHICHU = txtDienGiai.Text;

                qltb.NHOMKHACHHANGs.InsertOnSubmit(nhomkh);
                qltb.SubmitChanges();
                MessageBox.Show("Success");
                LoadNhomKH();
                this.Close();
            }
            else
            {
                string manhomkh = frmDanhMucNhomKhachHang.dgvnhomkhachhang.CurrentRow.Cells[0].Value.ToString();
                NHOMKHACHHANG md = qltb.NHOMKHACHHANGs.Where(t => t.MANHOMKH == manhomkh).FirstOrDefault();

               
                md.TENNHOMKH = txtTenNhomKH.Text;
                
                md.GHICHU = txtDienGiai.Text;
               
                md.KHUYENMAI= int.Parse(txtKhuyenMai.Text);
                

                qltb.SubmitChanges();
                LoadNhomKH();
            }
        }
        public void LoadNhomKH()
        {
            var nhomkh = from md in qltb.NHOMKHACHHANGs
                            select new { md.MANHOMKH, md.TENNHOMKH, md.KHUYENMAI, md.GHICHU };
            frmDanhMucNhomKhachHang.dgvnhomkhachhang.DataSource = nhomkh;
        }
    }
}