namespace DXApplication1
{
    partial class frmThemNguoiDungVaoNhomNguoiDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemNguoiDungVaoNhomNguoiDung));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbbNhomNguoiDung = new System.Windows.Forms.ComboBox();
            this.nHOMNGUOIDUNGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLTBDataSet = new DXApplication1.QLTBDataSet();
            this.nGUOIDUNGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nGUOIDUNGTRONGNHOMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nHOMNGUOIDUNGTableAdapter = new DXApplication1.QLTBDataSetTableAdapters.NHOMNGUOIDUNGTableAdapter();
            this.nGUOIDUNGTableAdapter = new DXApplication1.QLTBDataSetTableAdapters.NGUOIDUNGTableAdapter();
            this.tableAdapterManager = new DXApplication1.QLTBDataSetTableAdapters.TableAdapterManager();
            this.nGUOIDUNGNHOMNGDUNGTableAdapter = new DXApplication1.QLTBDataSetTableAdapters.NGUOIDUNGNHOMNGDUNGTableAdapter();
            this.nGUOIDUNGTRONGNHOMTableAdapter = new DXApplication1.QLTBDataSetTableAdapters.NGUOIDUNGTRONGNHOMTableAdapter();
            this.nGUOIDUNGNHOMNGDUNGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.nGUOIDUNGDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nGUOIDUNGTRONGNHOMDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nHOMNGUOIDUNGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGUOIDUNGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGUOIDUNGTRONGNHOMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGUOIDUNGNHOMNGDUNGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGUOIDUNGDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGUOIDUNGTRONGNHOMDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(670, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(130, 19);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Nhóm người dùng";
            // 
            // cbbNhomNguoiDung
            // 
            this.cbbNhomNguoiDung.DataSource = this.nHOMNGUOIDUNGBindingSource;
            this.cbbNhomNguoiDung.DisplayMember = "TENNHOM";
            this.cbbNhomNguoiDung.FormattingEnabled = true;
            this.cbbNhomNguoiDung.Location = new System.Drawing.Point(816, 12);
            this.cbbNhomNguoiDung.Name = "cbbNhomNguoiDung";
            this.cbbNhomNguoiDung.Size = new System.Drawing.Size(121, 21);
            this.cbbNhomNguoiDung.TabIndex = 9;
            this.cbbNhomNguoiDung.ValueMember = "MANHOM";
            this.cbbNhomNguoiDung.SelectedIndexChanged += new System.EventHandler(this.cbbNhomNguoiDung_SelectedIndexChanged);
            // 
            // nHOMNGUOIDUNGBindingSource
            // 
            this.nHOMNGUOIDUNGBindingSource.DataMember = "NHOMNGUOIDUNG";
            this.nHOMNGUOIDUNGBindingSource.DataSource = this.qLTBDataSet;
            // 
            // qLTBDataSet
            // 
            this.qLTBDataSet.DataSetName = "QLTBDataSet";
            this.qLTBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nGUOIDUNGBindingSource
            // 
            this.nGUOIDUNGBindingSource.DataMember = "NGUOIDUNG";
            this.nGUOIDUNGBindingSource.DataSource = this.qLTBDataSet;
            // 
            // nGUOIDUNGTRONGNHOMBindingSource
            // 
            this.nGUOIDUNGTRONGNHOMBindingSource.DataMember = "NGUOIDUNGTRONGNHOM";
            this.nGUOIDUNGTRONGNHOMBindingSource.DataSource = this.qLTBDataSet;
            // 
            // nHOMNGUOIDUNGTableAdapter
            // 
            this.nHOMNGUOIDUNGTableAdapter.ClearBeforeFill = true;
            // 
            // nGUOIDUNGTableAdapter
            // 
            this.nGUOIDUNGTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.MANHINHTableAdapter = null;
            this.tableAdapterManager.MODELTableAdapter = null;
            this.tableAdapterManager.NGUOIDUNGNHOMNGDUNGTableAdapter = this.nGUOIDUNGNHOMNGDUNGTableAdapter;
            this.tableAdapterManager.NGUOIDUNGTableAdapter = this.nGUOIDUNGTableAdapter;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.NHASANXUATTableAdapter = null;
            this.tableAdapterManager.NHOMNGUOIDUNGTableAdapter = this.nHOMNGUOIDUNGTableAdapter;
            this.tableAdapterManager.PHANLOAITableAdapter = null;
            this.tableAdapterManager.PHANQUYENTableAdapter = null;
            this.tableAdapterManager.PHIEUSUACHUATableAdapter = null;
            this.tableAdapterManager.PHIEUTIEPNHANTableAdapter = null;
            this.tableAdapterManager.THIETBITableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DXApplication1.QLTBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nGUOIDUNGNHOMNGDUNGTableAdapter
            // 
            this.nGUOIDUNGNHOMNGDUNGTableAdapter.ClearBeforeFill = true;
            // 
            // nGUOIDUNGTRONGNHOMTableAdapter
            // 
            this.nGUOIDUNGTRONGNHOMTableAdapter.ClearBeforeFill = true;
            // 
            // nGUOIDUNGNHOMNGDUNGBindingSource
            // 
            this.nGUOIDUNGNHOMNGDUNGBindingSource.DataMember = "NGUOIDUNGNHOMNGDUNG";
            this.nGUOIDUNGNHOMNGDUNGBindingSource.DataSource = this.qLTBDataSet;
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem.Location = new System.Drawing.Point(523, 202);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(108, 38);
            this.btnThem.TabIndex = 11;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa.Location = new System.Drawing.Point(523, 270);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(108, 38);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // nGUOIDUNGDataGridView
            // 
            this.nGUOIDUNGDataGridView.AutoGenerateColumns = false;
            this.nGUOIDUNGDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.nGUOIDUNGDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nGUOIDUNGDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewCheckBoxColumn1});
            this.nGUOIDUNGDataGridView.DataSource = this.nGUOIDUNGBindingSource;
            this.nGUOIDUNGDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nGUOIDUNGDataGridView.Location = new System.Drawing.Point(0, 0);
            this.nGUOIDUNGDataGridView.Name = "nGUOIDUNGDataGridView";
            this.nGUOIDUNGDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.nGUOIDUNGDataGridView.Size = new System.Drawing.Size(451, 405);
            this.nGUOIDUNGDataGridView.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TENDANGNHAP";
            this.dataGridViewTextBoxColumn6.HeaderText = "TENDANGNHAP";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MATKHAU";
            this.dataGridViewTextBoxColumn7.HeaderText = "MATKHAU";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "HoatDong";
            this.dataGridViewCheckBoxColumn1.HeaderText = "HoatDong";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // nGUOIDUNGTRONGNHOMDataGridView
            // 
            this.nGUOIDUNGTRONGNHOMDataGridView.AutoGenerateColumns = false;
            this.nGUOIDUNGTRONGNHOMDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.nGUOIDUNGTRONGNHOMDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nGUOIDUNGTRONGNHOMDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn5});
            this.nGUOIDUNGTRONGNHOMDataGridView.DataSource = this.nGUOIDUNGTRONGNHOMBindingSource;
            this.nGUOIDUNGTRONGNHOMDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nGUOIDUNGTRONGNHOMDataGridView.Location = new System.Drawing.Point(0, 0);
            this.nGUOIDUNGTRONGNHOMDataGridView.Name = "nGUOIDUNGTRONGNHOMDataGridView";
            this.nGUOIDUNGTRONGNHOMDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.nGUOIDUNGTRONGNHOMDataGridView.Size = new System.Drawing.Size(451, 405);
            this.nGUOIDUNGTRONGNHOMDataGridView.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TENDANGNHAP";
            this.dataGridViewTextBoxColumn8.HeaderText = "TENDANGNHAP";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "MATKHAU";
            this.dataGridViewTextBoxColumn9.HeaderText = "MATKHAU";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "GHICHU";
            this.dataGridViewTextBoxColumn5.HeaderText = "GHICHU";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nGUOIDUNGDataGridView);
            this.panel1.Location = new System.Drawing.Point(30, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 405);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nGUOIDUNGTRONGNHOMDataGridView);
            this.panel2.Location = new System.Drawing.Point(670, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 405);
            this.panel2.TabIndex = 14;
            // 
            // frmThemNguoiDungVaoNhomNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 508);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbbNhomNguoiDung);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThemNguoiDungVaoNhomNguoiDung";
            this.Text = "frmThemNguoiDungVaoNhomNguoiDung";
            this.Load += new System.EventHandler(this.frmThemNguoiDungVaoNhomNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nHOMNGUOIDUNGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGUOIDUNGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGUOIDUNGTRONGNHOMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGUOIDUNGNHOMNGDUNGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGUOIDUNGDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGUOIDUNGTRONGNHOMDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;

        private System.Windows.Forms.ComboBox cbbNhomNguoiDung;
        private QLTBDataSet qLTBDataSet;
        private System.Windows.Forms.BindingSource nHOMNGUOIDUNGBindingSource;
        private QLTBDataSetTableAdapters.NHOMNGUOIDUNGTableAdapter nHOMNGUOIDUNGTableAdapter;
        private System.Windows.Forms.BindingSource nGUOIDUNGBindingSource;
        private QLTBDataSetTableAdapters.NGUOIDUNGTableAdapter nGUOIDUNGTableAdapter;
        private QLTBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource nGUOIDUNGTRONGNHOMBindingSource;
        private QLTBDataSetTableAdapters.NGUOIDUNGTRONGNHOMTableAdapter nGUOIDUNGTRONGNHOMTableAdapter;
        private QLTBDataSetTableAdapters.NGUOIDUNGNHOMNGDUNGTableAdapter nGUOIDUNGNHOMNGDUNGTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource nGUOIDUNGNHOMNGDUNGBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private System.Windows.Forms.DataGridView nGUOIDUNGDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridView nGUOIDUNGTRONGNHOMDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}