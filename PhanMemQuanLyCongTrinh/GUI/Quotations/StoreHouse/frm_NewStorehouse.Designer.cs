namespace PhanMemQuanLyCongTrinh
{
    partial class frm_NewStorehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NewStorehouse));
            this.txt_Address = new DevExpress.XtraEditors.TextEdit();
            this.txt_storehouseName = new DevExpress.XtraEditors.TextEdit();
            this.lbl_CustomerGroupName = new DevExpress.XtraEditors.LabelControl();
            this.lbl_CustomerGroupId = new DevExpress.XtraEditors.LabelControl();
            this.but_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.but_Add = new DevExpress.XtraEditors.SimpleButton();
            this.lbl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Address.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_storehouseName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(199, 61);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Properties.Appearance.Options.UseFont = true;
            this.txt_Address.Size = new System.Drawing.Size(304, 22);
            this.txt_Address.TabIndex = 26;
            // 
            // txt_storehouseName
            // 
            this.txt_storehouseName.Location = new System.Drawing.Point(199, 24);
            this.txt_storehouseName.Name = "txt_storehouseName";
            this.txt_storehouseName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_storehouseName.Properties.Appearance.Options.UseFont = true;
            this.txt_storehouseName.Size = new System.Drawing.Size(304, 22);
            this.txt_storehouseName.TabIndex = 25;
            // 
            // lbl_CustomerGroupName
            // 
            this.lbl_CustomerGroupName.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CustomerGroupName.Appearance.Options.UseFont = true;
            this.lbl_CustomerGroupName.Location = new System.Drawing.Point(68, 64);
            this.lbl_CustomerGroupName.Name = "lbl_CustomerGroupName";
            this.lbl_CustomerGroupName.Size = new System.Drawing.Size(92, 16);
            this.lbl_CustomerGroupName.TabIndex = 24;
            this.lbl_CustomerGroupName.Text = "Địa Chỉ Nhà Kho";
            // 
            // lbl_CustomerGroupId
            // 
            this.lbl_CustomerGroupId.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CustomerGroupId.Appearance.Options.UseFont = true;
            this.lbl_CustomerGroupId.Location = new System.Drawing.Point(87, 27);
            this.lbl_CustomerGroupId.Name = "lbl_CustomerGroupId";
            this.lbl_CustomerGroupId.Size = new System.Drawing.Size(73, 16);
            this.lbl_CustomerGroupId.TabIndex = 23;
            this.lbl_CustomerGroupId.Text = "Tên Nhà Kho";
            // 
            // but_Exit
            // 
            this.but_Exit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.but_Exit.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.but_Exit.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.but_Exit.Appearance.ForeColor = System.Drawing.Color.White;
            this.but_Exit.Appearance.Options.UseBackColor = true;
            this.but_Exit.Appearance.Options.UseFont = true;
            this.but_Exit.Appearance.Options.UseForeColor = true;
            this.but_Exit.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.but_Exit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("but_Exit.ImageOptions.Image")));
            this.but_Exit.Location = new System.Drawing.Point(352, 112);
            this.but_Exit.LookAndFeel.SkinMaskColor = System.Drawing.Color.Gray;
            this.but_Exit.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Black;
            this.but_Exit.LookAndFeel.SkinName = "Office 2010 Black";
            this.but_Exit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.but_Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Exit.Name = "but_Exit";
            this.but_Exit.Size = new System.Drawing.Size(110, 36);
            this.but_Exit.TabIndex = 22;
            this.but_Exit.Text = "Đóng";
            this.but_Exit.ToolTipTitle = "ESC";
            this.but_Exit.Click += new System.EventHandler(this.but_Exit_Click);
            // 
            // but_Add
            // 
            this.but_Add.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.but_Add.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.but_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.but_Add.Appearance.ForeColor = System.Drawing.Color.White;
            this.but_Add.Appearance.Options.UseBackColor = true;
            this.but_Add.Appearance.Options.UseFont = true;
            this.but_Add.Appearance.Options.UseForeColor = true;
            this.but_Add.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.but_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("but_Add.ImageOptions.Image")));
            this.but_Add.Location = new System.Drawing.Point(198, 112);
            this.but_Add.LookAndFeel.SkinMaskColor = System.Drawing.Color.RoyalBlue;
            this.but_Add.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.but_Add.LookAndFeel.SkinName = "Office 2010 Black";
            this.but_Add.LookAndFeel.UseDefaultLookAndFeel = false;
            this.but_Add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Add.Name = "but_Add";
            this.but_Add.Size = new System.Drawing.Size(110, 36);
            this.but_Add.TabIndex = 21;
            this.but_Add.Text = "Thêm Mới";
            this.but_Add.ToolTipTitle = "Ctrl +S";
            this.but_Add.Click += new System.EventHandler(this.but_Add_Click);
            // 
            // lbl1
            // 
            this.lbl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.lbl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl1.Appearance.Options.UseFont = true;
            this.lbl1.Appearance.Options.UseForeColor = true;
            this.lbl1.Location = new System.Drawing.Point(509, 27);
            this.lbl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(8, 16);
            this.lbl1.TabIndex = 293;
            this.lbl1.Text = "*";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(509, 64);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(8, 16);
            this.labelControl1.TabIndex = 294;
            this.labelControl1.Text = "*";
            // 
            // frm_NewStorehouse
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 164);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.txt_storehouseName);
            this.Controls.Add(this.lbl_CustomerGroupName);
            this.Controls.Add(this.lbl_CustomerGroupId);
            this.Controls.Add(this.but_Exit);
            this.Controls.Add(this.but_Add);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frm_NewStorehouse";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM NHÀ KHO";
            this.Load += new System.EventHandler(this.frm_NewStorehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Address.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_storehouseName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_Address;
        private DevExpress.XtraEditors.TextEdit txt_storehouseName;
        private DevExpress.XtraEditors.LabelControl lbl_CustomerGroupName;
        private DevExpress.XtraEditors.LabelControl lbl_CustomerGroupId;
        private DevExpress.XtraEditors.SimpleButton but_Exit;
        private DevExpress.XtraEditors.SimpleButton but_Add;
        private DevExpress.XtraEditors.LabelControl lbl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}