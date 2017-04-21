namespace DXApplication1
{
    partial class frmPhanQuyen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanQuyen));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qLTBDataSet = new DXApplication1.QLTBDataSet();
            this.nHOMNGUOIDUNGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nHOMNGUOIDUNGTableAdapter = new DXApplication1.QLTBDataSetTableAdapters.NHOMNGUOIDUNGTableAdapter();
            this.tableAdapterManager = new DXApplication1.QLTBDataSetTableAdapters.TableAdapterManager();
            this.nHOMNGUOIDUNGDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mANHINHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mANHINHTableAdapter = new DXApplication1.QLTBDataSetTableAdapters.MANHINHTableAdapter();
            this.getPhanQuyenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getPhanQuyenTableAdapter = new DXApplication1.QLTBDataSetTableAdapters.GetPhanQuyenTableAdapter();
            this.getPhanQuyenDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pHANQUYENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pHANQUYENTableAdapter = new DXApplication1.QLTBDataSetTableAdapters.PHANQUYENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHOMNGUOIDUNGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHOMNGUOIDUNGDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mANHINHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getPhanQuyenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getPhanQuyenDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHANQUYENBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnLuu);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1120, 34);
            this.panelControl1.TabIndex = 8;
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLuu.Appearance.BackColor2 = System.Drawing.Color.Navy;
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLuu.Appearance.Options.UseBackColor = true;
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Appearance.Options.UseForeColor = true;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(15, 5);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(83, 23);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.TabStop = false;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(990, 132);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(8, 8);
            this.gridControl2.TabIndex = 10;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            // 
            // qLTBDataSet
            // 
            this.qLTBDataSet.DataSetName = "QLTBDataSet";
            this.qLTBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nHOMNGUOIDUNGBindingSource
            // 
            this.nHOMNGUOIDUNGBindingSource.DataMember = "NHOMNGUOIDUNG";
            this.nHOMNGUOIDUNGBindingSource.DataSource = this.qLTBDataSet;
            // 
            // nHOMNGUOIDUNGTableAdapter
            // 
            this.nHOMNGUOIDUNGTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGBAOGIATableAdapter = null;
            this.tableAdapterManager.BOPHANTableAdapter = null;
            this.tableAdapterManager.CHITIETHOADONTableAdapter = null;
            this.tableAdapterManager.CHITIETSUACHUATableAdapter = null;
            this.tableAdapterManager.HOADONTableAdapter = null;
            this.tableAdapterManager.KHACHHANGTableAdapter = null;
            this.tableAdapterManager.LINHKIENTableAdapter = null;
            this.tableAdapterManager.MANHINHTableAdapter = this.mANHINHTableAdapter;
            this.tableAdapterManager.MODELTableAdapter = null;
            this.tableAdapterManager.NGUOIDUNGNHOMNGDUNGTableAdapter = null;
            this.tableAdapterManager.NGUOIDUNGTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.NHASANXUATTableAdapter = null;
            this.tableAdapterManager.NHOMNGUOIDUNGTableAdapter = this.nHOMNGUOIDUNGTableAdapter;
            this.tableAdapterManager.PHANLOAITableAdapter = null;
            this.tableAdapterManager.PHANQUYENTableAdapter = this.pHANQUYENTableAdapter;
            this.tableAdapterManager.PHIEUSUACHUATableAdapter = null;
            this.tableAdapterManager.PHIEUTIEPNHANTableAdapter = null;
            this.tableAdapterManager.THIETBITableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DXApplication1.QLTBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nHOMNGUOIDUNGDataGridView
            // 
            this.nHOMNGUOIDUNGDataGridView.AllowUserToAddRows = false;
            this.nHOMNGUOIDUNGDataGridView.AutoGenerateColumns = false;
            this.nHOMNGUOIDUNGDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.nHOMNGUOIDUNGDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nHOMNGUOIDUNGDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.nHOMNGUOIDUNGDataGridView.DataSource = this.nHOMNGUOIDUNGBindingSource;
            this.nHOMNGUOIDUNGDataGridView.Location = new System.Drawing.Point(29, 87);
            this.nHOMNGUOIDUNGDataGridView.Name = "nHOMNGUOIDUNGDataGridView";
            this.nHOMNGUOIDUNGDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.nHOMNGUOIDUNGDataGridView.Size = new System.Drawing.Size(411, 283);
            this.nHOMNGUOIDUNGDataGridView.TabIndex = 11;
            this.nHOMNGUOIDUNGDataGridView.SelectionChanged += new System.EventHandler(this.nHOMNGUOIDUNGDataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MANHOM";
            this.dataGridViewTextBoxColumn1.HeaderText = "MANHOM";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TENNHOM";
            this.dataGridViewTextBoxColumn2.HeaderText = "TENNHOM";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "GHICHU";
            this.dataGridViewTextBoxColumn3.HeaderText = "GHICHU";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // mANHINHBindingSource
            // 
            this.mANHINHBindingSource.DataMember = "MANHINH";
            this.mANHINHBindingSource.DataSource = this.qLTBDataSet;
            // 
            // mANHINHTableAdapter
            // 
            this.mANHINHTableAdapter.ClearBeforeFill = true;
            // 
            // getPhanQuyenBindingSource
            // 
            this.getPhanQuyenBindingSource.DataMember = "GetPhanQuyen";
            this.getPhanQuyenBindingSource.DataSource = this.qLTBDataSet;
            // 
            // getPhanQuyenTableAdapter
            // 
            this.getPhanQuyenTableAdapter.ClearBeforeFill = true;
            // 
            // getPhanQuyenDataGridView
            // 
            this.getPhanQuyenDataGridView.AllowUserToAddRows = false;
            this.getPhanQuyenDataGridView.AutoGenerateColumns = false;
            this.getPhanQuyenDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.getPhanQuyenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.getPhanQuyenDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1});
            this.getPhanQuyenDataGridView.DataSource = this.getPhanQuyenBindingSource;
            this.getPhanQuyenDataGridView.Location = new System.Drawing.Point(517, 87);
            this.getPhanQuyenDataGridView.Name = "getPhanQuyenDataGridView";
            this.getPhanQuyenDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.getPhanQuyenDataGridView.Size = new System.Drawing.Size(457, 283);
            this.getPhanQuyenDataGridView.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MaManHinh";
            this.dataGridViewTextBoxColumn4.HeaderText = "MaManHinh";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TenManHinh";
            this.dataGridViewTextBoxColumn5.HeaderText = "TenManHinh";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "COQUYEN";
            this.dataGridViewCheckBoxColumn1.HeaderText = "COQUYEN";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // pHANQUYENBindingSource
            // 
            this.pHANQUYENBindingSource.DataMember = "PHANQUYEN";
            this.pHANQUYENBindingSource.DataSource = this.qLTBDataSet;
            // 
            // pHANQUYENTableAdapter
            // 
            this.pHANQUYENTableAdapter.ClearBeforeFill = true;
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 500);
            this.Controls.Add(this.getPhanQuyenDataGridView);
            this.Controls.Add(this.nHOMNGUOIDUNGDataGridView);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPhanQuyen";
            this.Text = "frmPhanQuyen";
            this.Load += new System.EventHandler(this.frmPhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHOMNGUOIDUNGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHOMNGUOIDUNGDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mANHINHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getPhanQuyenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getPhanQuyenDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHANQUYENBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private QLTBDataSet qLTBDataSet;
        private System.Windows.Forms.BindingSource nHOMNGUOIDUNGBindingSource;
        private QLTBDataSetTableAdapters.NHOMNGUOIDUNGTableAdapter nHOMNGUOIDUNGTableAdapter;
        private QLTBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private QLTBDataSetTableAdapters.MANHINHTableAdapter mANHINHTableAdapter;
        private System.Windows.Forms.DataGridView nHOMNGUOIDUNGDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource mANHINHBindingSource;
        private System.Windows.Forms.BindingSource getPhanQuyenBindingSource;
        private QLTBDataSetTableAdapters.GetPhanQuyenTableAdapter getPhanQuyenTableAdapter;
        private System.Windows.Forms.DataGridView getPhanQuyenDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private QLTBDataSetTableAdapters.PHANQUYENTableAdapter pHANQUYENTableAdapter;
        private System.Windows.Forms.BindingSource pHANQUYENBindingSource;
    }
}