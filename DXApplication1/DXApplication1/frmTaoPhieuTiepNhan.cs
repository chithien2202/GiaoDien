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
    public partial class frmTaoPhieuTiepNhan : DevExpress.XtraEditors.XtraForm
    {
        QLTBDataContext qltb = new QLTBDataContext();
        TangMa tangma = new TangMa();
        PhieuTiepNhanService ptn = new PhieuTiepNhanService();
        public frmTaoPhieuTiepNhan()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {
        
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

            //string maptn = tangma.ThemMaPTN();
            bool flag = ptn.AddPhieuNhan(  
                tangma.ThemMaPTN(),
                cbbThietBi.SelectedValue.ToString(),
                Program.mainForm.getUserName,
                cbbKhachHang.SelectedValue.ToString(),
                DateTime.Parse(dtpNgayNhap.Value.ToString()),
                DateTime.Parse(dtpNgayHenTra.Value.ToString()),
                txtTinhTrangHuHong.Text,
                txtPhuKienDiCung.Text,
                false,
                txtGhiChu.Text
                );

            //if (flag)
            //{
            //    MessageBox.Show("df");
            //}
        }


        public void LoadCbbKhachHang()
        {
            cbbKhachHang.DataSource = qltb.KHACHHANGs;
            cbbKhachHang.DisplayMember = "TENKHACHHANG";
            cbbKhachHang.ValueMember = "MAKHACHKHACH";
        }

        public void LoadCbbThietBi()
        { 
            cbbThietBi.DataSource = qltb.THIETBIs;
            cbbThietBi.DisplayMember = "TENTHIETBI";
            cbbThietBi.ValueMember = "MATHIETBI";
        }

        private void frmTaoPhieuTiepNhan_Load(object sender, EventArgs e)
        {
            LoadCbbKhachHang();
            LoadCbbThietBi();
        }
    }
}