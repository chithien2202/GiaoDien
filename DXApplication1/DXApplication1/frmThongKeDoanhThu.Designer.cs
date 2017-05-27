namespace DXApplication1
{
    partial class frmThongKeDoanhThu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKeDoanhThu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnTim = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dtpDen = new DevExpress.XtraEditors.DateEdit();
            this.dtpTu = new DevExpress.XtraEditors.DateEdit();
            this.dtgvThongKeDoanhThu = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDen.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTu.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSoLuong);
            this.panel1.Controls.Add(this.txtTongTien);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 460);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 40);
            this.panel1.TabIndex = 3;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(482, 12);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(170, 21);
            this.txtSoLuong.TabIndex = 3;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(735, 12);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(170, 21);
            this.txtTongTien.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(911, 11);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(29, 18);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "VND";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(354, 11);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(113, 18);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Tổng số hóa đơn";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(667, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tổng tiền";
            // 
            // btnTim
            // 
            this.btnTim.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Appearance.Options.UseFont = true;
            this.btnTim.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.Image")));
            this.btnTim.Location = new System.Drawing.Point(508, 29);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(55, 23);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(30, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(20, 16);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Từ ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(263, 31);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(23, 16);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Đến";
            // 
            // btnIn
            // 
            this.btnIn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.Location = new System.Drawing.Point(583, 29);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(55, 23);
            this.btnIn.TabIndex = 11;
            this.btnIn.Text = "In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(660, 29);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(55, 23);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dtpDen);
            this.groupControl1.Controls.Add(this.dtpTu);
            this.groupControl1.Controls.Add(this.btnHuy);
            this.groupControl1.Controls.Add(this.btnIn);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btnTim);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(970, 72);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Thông tin chung";
            // 
            // dtpDen
            // 
            this.dtpDen.EditValue = null;
            this.dtpDen.Location = new System.Drawing.Point(292, 30);
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDen.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDen.Size = new System.Drawing.Size(193, 20);
            this.dtpDen.TabIndex = 13;
            // 
            // dtpTu
            // 
            this.dtpTu.EditValue = null;
            this.dtpTu.Location = new System.Drawing.Point(56, 30);
            this.dtpTu.Name = "dtpTu";
            this.dtpTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTu.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTu.Size = new System.Drawing.Size(193, 20);
            this.dtpTu.TabIndex = 13;
            // 
            // dtgvThongKeDoanhThu
            // 
            this.dtgvThongKeDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvThongKeDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongKeDoanhThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dtgvThongKeDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvThongKeDoanhThu.Location = new System.Drawing.Point(0, 72);
            this.dtgvThongKeDoanhThu.Name = "dtgvThongKeDoanhThu";
            this.dtgvThongKeDoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvThongKeDoanhThu.Size = new System.Drawing.Size(970, 388);
            this.dtgvThongKeDoanhThu.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MAHOADON";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã hóa đơn";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MAKHACHHANG";
            this.dataGridViewTextBoxColumn2.HeaderText = "Mã khách hàng ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MAPSC";
            this.dataGridViewTextBoxColumn3.HeaderText = "Mã phiếu sửa chữa";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MANHANVIEN";
            this.dataGridViewTextBoxColumn4.HeaderText = "Mã nhân viên";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NGAYLAP";
            this.dataGridViewTextBoxColumn5.HeaderText = "Ngày lập";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TONGTIEN";
            this.dataGridViewTextBoxColumn6.HeaderText = "Tổng tiền";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // frmThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 500);
            this.Controls.Add(this.dtgvThongKeDoanhThu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKeDoanhThu";
            this.Text = "Thống kế doanh thu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDen.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTu.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeDoanhThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnTim;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox txtTongTien;
        private DevExpress.XtraEditors.DateEdit dtpDen;
        private DevExpress.XtraEditors.DateEdit dtpTu;
        private System.Windows.Forms.DataGridView dtgvThongKeDoanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TextBox txtSoLuong;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}