namespace DXApplication1
{
    partial class frmPhucHoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhucHoi));
            this.btnBrower = new DevExpress.XtraEditors.SimpleButton();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnPhucHoi = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrower
            // 
            this.btnBrower.Location = new System.Drawing.Point(436, 81);
            this.btnBrower.Name = "btnBrower";
            this.btnBrower.Size = new System.Drawing.Size(36, 23);
            this.btnBrower.TabIndex = 17;
            this.btnBrower.Text = "...";
            this.btnBrower.Click += new System.EventHandler(this.btnBrower_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(178, 82);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Properties.Appearance.Options.UseFont = true;
            this.txtLocation.Size = new System.Drawing.Size(252, 22);
            this.txtLocation.TabIndex = 16;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(374, 136);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(109, 38);
            this.simpleButton2.TabIndex = 15;
            this.simpleButton2.Text = "&Hủy";
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhucHoi.Appearance.Options.UseFont = true;
            this.btnPhucHoi.Image = ((System.Drawing.Image)(resources.GetObject("btnPhucHoi.Image")));
            this.btnPhucHoi.Location = new System.Drawing.Point(230, 136);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(105, 38);
            this.btnPhucHoi.TabIndex = 14;
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl2.Location = new System.Drawing.Point(145, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(235, 33);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Khôi phục dữ liệu";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(90, 84);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 18);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Đường dẫn :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmPhucHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 184);
            this.Controls.Add(this.btnBrower);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnPhucHoi);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmPhucHoi";
            this.Text = "Phục hồi dữ liệu";
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBrower;
        private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnPhucHoi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}