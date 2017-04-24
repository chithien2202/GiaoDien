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
    public partial class frmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        private void nHOMNGUOIDUNGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nHOMNGUOIDUNGBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLTBDataSet);

        }

        private void nHOMNGUOIDUNGBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.nHOMNGUOIDUNGBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLTBDataSet);

        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTBDataSet.PHANQUYEN' table. You can move, or remove it, as needed.
            this.pHANQUYENTableAdapter.Fill(this.qLTBDataSet.PHANQUYEN);
            // TODO: This line of code loads data into the 'qLTBDataSet.MANHINH' table. You can move, or remove it, as needed.
            this.mANHINHTableAdapter.Fill(this.qLTBDataSet.MANHINH);
            // TODO: This line of code loads data into the 'qLTBDataSet.NHOMNGUOIDUNG' table. You can move, or remove it, as needed.
            this.nHOMNGUOIDUNGTableAdapter.Fill(this.qLTBDataSet.NHOMNGUOIDUNG);

        }

        public void LoadDataCondition()
        {
            this.getPhanQuyenTableAdapter.Fill(this.qLTBDataSet.GetPhanQuyen, nHOMNGUOIDUNGDataGridView.CurrentRow.Cells[0].Value.ToString());
        }

        private void nHOMNGUOIDUNGDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            LoadDataCondition();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string _nhomnguoidung = nHOMNGUOIDUNGDataGridView.CurrentRow.Cells[0].Value.ToString().Trim();
            foreach(DataGridViewRow item in getPhanQuyenDataGridView.Rows)
            {
                try
                {
                    var phanquyen = getPhanQuyenTableAdapter.KiemTraKhoaChinhPhanQuyen(_nhomnguoidung, item.Cells[0].Value.ToString().Trim());
                    if(phanquyen.Rows.Count>0||phanquyen.Rows.Count.Equals(1))
                    {
                        pHANQUYENTableAdapter.UpdateQuery((bool)(item.Cells[2].Value), _nhomnguoidung, item.Cells[0].Value.ToString());
                    }
                    else
                    {
                        try
                        {
                            pHANQUYENTableAdapter.Insert(_nhomnguoidung, item.Cells[0].Value.ToString().Trim(), (bool)(item.Cells[2].Value));
                        }
                        catch
                        {
                            pHANQUYENTableAdapter.Insert(_nhomnguoidung, item.Cells[0].Value.ToString().Trim(), false);
                        }
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Không thành công","Thông báo");
                    break;
                }
            }
            XtraMessageBox.Show("Thành công","Thông báo");
        }
    }
}