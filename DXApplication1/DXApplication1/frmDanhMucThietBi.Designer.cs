﻿namespace DXApplication1
{
    partial class frmDanhMucThietBi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucThietBi));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnTroGiup = new DevExpress.XtraEditors.SimpleButton();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dtgvDSThietBi = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MATHIETBI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAMODEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SERIAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENTHIETBI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYMUA_SUACHUA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYKETTHUC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GHICHU = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSThietBi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnDong);
            this.panelControl1.Controls.Add(this.btnTroGiup);
            this.panelControl1.Controls.Add(this.btnIn);
            this.panelControl1.Controls.Add(this.btnSua);
            this.panelControl1.Controls.Add(this.btnXoa);
            this.panelControl1.Controls.Add(this.btnThem);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(781, 34);
            this.panelControl1.TabIndex = 5;
            // 
            // btnDong
            // 
            this.btnDong.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDong.Appearance.BackColor2 = System.Drawing.Color.Navy;
            this.btnDong.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDong.Appearance.Options.UseBackColor = true;
            this.btnDong.Appearance.Options.UseFont = true;
            this.btnDong.Appearance.Options.UseForeColor = true;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(583, 5);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(95, 23);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "&Đóng (F10)";
            // 
            // btnTroGiup
            // 
            this.btnTroGiup.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnTroGiup.Appearance.BackColor2 = System.Drawing.Color.Navy;
            this.btnTroGiup.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTroGiup.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnTroGiup.Appearance.Options.UseBackColor = true;
            this.btnTroGiup.Appearance.Options.UseFont = true;
            this.btnTroGiup.Appearance.Options.UseForeColor = true;
            this.btnTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("btnTroGiup.Image")));
            this.btnTroGiup.Location = new System.Drawing.Point(437, 5);
            this.btnTroGiup.Name = "btnTroGiup";
            this.btnTroGiup.Size = new System.Drawing.Size(108, 23);
            this.btnTroGiup.TabIndex = 4;
            this.btnTroGiup.Text = "Trợ &giúp (F9)";
            // 
            // btnIn
            // 
            this.btnIn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnIn.Appearance.BackColor2 = System.Drawing.Color.Navy;
            this.btnIn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnIn.Appearance.Options.UseBackColor = true;
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Appearance.Options.UseForeColor = true;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.Location = new System.Drawing.Point(330, 5);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 3;
            this.btnIn.Text = "&In (F8)";
            // 
            // btnSua
            // 
            this.btnSua.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSua.Appearance.BackColor2 = System.Drawing.Color.Navy;
            this.btnSua.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSua.Appearance.Options.UseBackColor = true;
            this.btnSua.Appearance.Options.UseFont = true;
            this.btnSua.Appearance.Options.UseForeColor = true;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Location = new System.Drawing.Point(126, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(82, 23);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "&Sửa (F6)";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnXoa.Appearance.BackColor2 = System.Drawing.Color.Navy;
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnXoa.Appearance.Options.UseBackColor = true;
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Appearance.Options.UseForeColor = true;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(230, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "&Xóa (F7)";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThem.Appearance.BackColor2 = System.Drawing.Color.Navy;
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThem.Appearance.Options.UseBackColor = true;
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Appearance.Options.UseForeColor = true;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(15, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(83, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "&Thêm(F5)";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.dtgvDSThietBi);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 34);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(781, 416);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Danh sách thiết bị";
            // 
            // dtgvDSThietBi
            // 
            this.dtgvDSThietBi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvDSThietBi.Location = new System.Drawing.Point(2, 26);
            this.dtgvDSThietBi.MainView = this.gridView1;
            this.dtgvDSThietBi.Name = "dtgvDSThietBi";
            this.dtgvDSThietBi.Size = new System.Drawing.Size(777, 388);
            this.dtgvDSThietBi.TabIndex = 0;
            this.dtgvDSThietBi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MATHIETBI,
            this.MAMODEL,
            this.SERIAL,
            this.TENTHIETBI,
            this.NGAYMUA_SUACHUA,
            this.NGAYKETTHUC,
            this.GHICHU});
            this.gridView1.GridControl = this.dtgvDSThietBi;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // MATHIETBI
            // 
            this.MATHIETBI.Caption = "Mã thiết bị";
            this.MATHIETBI.FieldName = "MATHIETBI";
            this.MATHIETBI.Name = "MATHIETBI";
            this.MATHIETBI.Visible = true;
            this.MATHIETBI.VisibleIndex = 0;
            // 
            // MAMODEL
            // 
            this.MAMODEL.Caption = "Mã Model";
            this.MAMODEL.FieldName = "MAMODEL";
            this.MAMODEL.Name = "MAMODEL";
            this.MAMODEL.Visible = true;
            this.MAMODEL.VisibleIndex = 1;
            // 
            // SERIAL
            // 
            this.SERIAL.Caption = "Serial";
            this.SERIAL.FieldName = "SERIAL";
            this.SERIAL.Name = "SERIAL";
            this.SERIAL.Visible = true;
            this.SERIAL.VisibleIndex = 2;
            // 
            // TENTHIETBI
            // 
            this.TENTHIETBI.Caption = "Tên thiết bị";
            this.TENTHIETBI.FieldName = "TENTHIETBI";
            this.TENTHIETBI.Name = "TENTHIETBI";
            this.TENTHIETBI.Visible = true;
            this.TENTHIETBI.VisibleIndex = 3;
            // 
            // NGAYMUA_SUACHUA
            // 
            this.NGAYMUA_SUACHUA.Caption = "Ngày mua/sửa chữa";
            this.NGAYMUA_SUACHUA.FieldName = "NGAYMUA_SUACHUA";
            this.NGAYMUA_SUACHUA.Name = "NGAYMUA_SUACHUA";
            this.NGAYMUA_SUACHUA.Visible = true;
            this.NGAYMUA_SUACHUA.VisibleIndex = 4;
            // 
            // NGAYKETTHUC
            // 
            this.NGAYKETTHUC.Caption = "Ngày hết BH";
            this.NGAYKETTHUC.FieldName = "NGAYKETTHUC";
            this.NGAYKETTHUC.Name = "NGAYKETTHUC";
            this.NGAYKETTHUC.Visible = true;
            this.NGAYKETTHUC.VisibleIndex = 5;
            // 
            // GHICHU
            // 
            this.GHICHU.Caption = "Diễn giải";
            this.GHICHU.FieldName = "GHICHUTHIETBI";
            this.GHICHU.Name = "GHICHU";
            this.GHICHU.Visible = true;
            this.GHICHU.VisibleIndex = 6;
            // 
            // frmDanhMucThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 450);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDanhMucThietBi";
            this.Text = "frmDanhMucThietBi";
            this.Load += new System.EventHandler(this.frmDanhMucThietBi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSThietBi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnTroGiup;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dtgvDSThietBi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MATHIETBI;
        private DevExpress.XtraGrid.Columns.GridColumn TENTHIETBI;
        private DevExpress.XtraGrid.Columns.GridColumn SERIAL;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYMUA_SUACHUA;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYKETTHUC;
        private DevExpress.XtraGrid.Columns.GridColumn GHICHU;
        private DevExpress.XtraGrid.Columns.GridColumn MAMODEL;
    }
}