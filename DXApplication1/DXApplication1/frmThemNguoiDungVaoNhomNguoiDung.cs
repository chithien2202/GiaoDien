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
    public partial class frmThemNguoiDungVaoNhomNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        public frmThemNguoiDungVaoNhomNguoiDung()
        {
            InitializeComponent();
        }

        private void frmThemNguoiDungVaoNhomNguoiDung_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTBDataSet.NGUOIDUNGNHOMNGDUNG' table. You can move, or remove it, as needed.
            this.nGUOIDUNGNHOMNGDUNGTableAdapter.Fill(this.qLTBDataSet.NGUOIDUNGNHOMNGDUNG);
            // TODO: This line of code loads data into the 'qLTBDataSet.NGUOIDUNG' table. You can move, or remove it, as needed.
            this.nGUOIDUNGTableAdapter.Fill(this.qLTBDataSet.NGUOIDUNG);
            // TODO: This line of code loads data into the 'qLTBDataSet.NHOMNGUOIDUNG' table. You can move, or remove it, as needed.
            this.nHOMNGUOIDUNGTableAdapter.Fill(this.qLTBDataSet.NHOMNGUOIDUNG);
            LoadComboByCondition();
        }

        public void LoadComboByCondition()
        {
            if (cbbNhomNguoiDung.SelectedValue != null)
                nGUOIDUNGTRONGNHOMTableAdapter.Fill(this.qLTBDataSet.NGUOIDUNGTRONGNHOM, cbbNhomNguoiDung.SelectedValue.ToString());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in nGUOIDUNGDataGridView.SelectedRows)
            {
                if (this.nGUOIDUNGTRONGNHOMTableAdapter.KiemTraKhoaChinh(item.Cells[0].Value.ToString().Trim(), cbbNhomNguoiDung.SelectedValue.ToString().Trim()).ToString() == string.Empty ||
                    this.nGUOIDUNGTRONGNHOMTableAdapter.KiemTraKhoaChinh(item.Cells[0].Value.ToString().Trim(), cbbNhomNguoiDung.SelectedValue.ToString().Trim()).Rows.Count == 1)
                {
                    XtraMessageBox.Show("Đã tồn tại","Thông báo");
                }
                else
                {
                    this.nGUOIDUNGNHOMNGDUNGTableAdapter.Insert(item.Cells[0].Value.ToString().Trim(), cbbNhomNguoiDung.SelectedValue.ToString().Trim(), string.Empty);
                    XtraMessageBox.Show("Thêm thành công","Thông báo");
                }
            }
            LoadComboByCondition();
        }

        private void cbbNhomNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboByCondition();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in nGUOIDUNGTRONGNHOMDataGridView.SelectedRows)
            {
                if(this.nGUOIDUNGNHOMNGDUNGTableAdapter.Delete(item.Cells[0].Value.ToString(), cbbNhomNguoiDung.SelectedValue.ToString(), item.Cells[2].Value.ToString())==1)
                {
                    XtraMessageBox.Show("Thành công","Thông báo");
                }
                else
                {
                    XtraMessageBox.Show("Thất bại","Thông báo");
                }
            }
            LoadComboByCondition();
        }
    }
}