using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class frmThongTinNhomNguoiDung : Form
    {
        QLTBDataContext qltb = new QLTBDataContext();
        public frmThongTinNhomNguoiDung()
        {
            InitializeComponent();
        }

        private void frmThongTinNhomNguoiDung_Load(object sender, EventArgs e)
        {
            if (frmNhomNguoiDUng.tos == true)
            {
                btnLuu.Text = "Thêm";
                txtMaNhomND.Enabled = true;
                
            }
            else
            {
                btnLuu.Text = "Sửa";
                txtMaNhomND.Enabled = false;
                NHOMNGUOIDUNG nhomnd = qltb.NHOMNGUOIDUNGs.Where(t => t.MANHOM == frmNhomNguoiDUng.manhomnd).FirstOrDefault();
                txtMaNhomND.Text = nhomnd.MANHOM;
                txtTenNhomND.Text = nhomnd.TENNHOM;

                txtDienGiai.Text = nhomnd.GHICHU;
             
            }
        }
        TangMa tm = new TangMa();
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (frmNhomNguoiDUng.tos == true)
            {
                NHOMNGUOIDUNG nhomnd = new NHOMNGUOIDUNG();
                // Chổ này nữa 
                //nhomnd.MANHOM = tm.ATTangMa3("NND", "NHOMNGUOIDUNG");
                
                nhomnd.TENNHOM = txtTenNhomND.Text;

                nhomnd.GHICHU = txtDienGiai.Text;
               
                qltb.NHOMNGUOIDUNGs.InsertOnSubmit(nhomnd);
                qltb.SubmitChanges();
                MessageBox.Show("Success");
                Loadnhomnd();
                this.Close();
            }
            else
            {
                string manhomnd = frmNhomNguoiDUng.dgvnhomnd.CurrentRow.Cells[0].Value.ToString();
                NHOMNGUOIDUNG md = qltb.NHOMNGUOIDUNGs.Where(t => t.MANHOM == manhomnd).FirstOrDefault();

                
                md.TENNHOM= txtTenNhomND.Text;
               
                md.GHICHU = txtDienGiai.Text;
               

                qltb.SubmitChanges();
                Loadnhomnd();
            }
        }
        public void Loadnhomnd()
        {
            var nhomnd = from md in qltb.NHOMNGUOIDUNGs
                            select new { md.MANHOM, md.TENNHOM, md.GHICHU };
            frmNhomNguoiDUng.dgvnhomnd.DataSource = nhomnd;
        }
    }
}
