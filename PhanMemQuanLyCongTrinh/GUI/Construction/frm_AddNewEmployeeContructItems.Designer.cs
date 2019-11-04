namespace PhanMemQuanLyCongTrinh
{
    partial class frm_AddNewEmployeeContructItems
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
            if ( disposing && (components != null) )
            {
                components.Dispose( );
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddNewEmployeeContructItems));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.but_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_AddNew = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tabPane2 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.grdc_em = new DevExpress.XtraGrid.GridControl();
            this.grdv_em = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.employee_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employee_id_custom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employee_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employee_address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employee_date_of_birth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.department_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employee_phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.department_price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employee_status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl8 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl6 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl7 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane2)).BeginInit();
            this.tabPane2.SuspendLayout();
            this.tabNavigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdc_em)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdv_em)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.but_Exit);
            this.panelControl1.Controls.Add(this.btn_AddNew);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1183, 70);
            this.panelControl1.TabIndex = 0;
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
            this.but_Exit.Location = new System.Drawing.Point(610, 17);
            this.but_Exit.LookAndFeel.SkinMaskColor = System.Drawing.Color.Gray;
            this.but_Exit.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Black;
            this.but_Exit.LookAndFeel.SkinName = "Office 2010 Black";
            this.but_Exit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.but_Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Exit.Name = "but_Exit";
            this.but_Exit.Size = new System.Drawing.Size(110, 36);
            this.but_Exit.TabIndex = 309;
            this.but_Exit.Text = "Đóng";
            this.but_Exit.ToolTipTitle = "ESC";
            this.but_Exit.Click += new System.EventHandler(this.but_Exit_Click);
            // 
            // btn_AddNew
            // 
            this.btn_AddNew.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_AddNew.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_AddNew.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btn_AddNew.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_AddNew.Appearance.Options.UseBackColor = true;
            this.btn_AddNew.Appearance.Options.UseFont = true;
            this.btn_AddNew.Appearance.Options.UseForeColor = true;
            this.btn_AddNew.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btn_AddNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddNew.ImageOptions.Image")));
            this.btn_AddNew.Location = new System.Drawing.Point(462, 17);
            this.btn_AddNew.LookAndFeel.SkinMaskColor = System.Drawing.Color.RoyalBlue;
            this.btn_AddNew.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_AddNew.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn_AddNew.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_AddNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_AddNew.Name = "btn_AddNew";
            this.btn_AddNew.Size = new System.Drawing.Size(110, 36);
            this.btn_AddNew.TabIndex = 308;
            this.btn_AddNew.Text = "Thêm mới";
            this.btn_AddNew.ToolTipTitle = "Ctrl +S";
            this.btn_AddNew.Click += new System.EventHandler(this.btn_AddNew_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tabPane2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 70);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1183, 541);
            this.panelControl2.TabIndex = 1;
            // 
            // tabPane2
            // 
            this.tabPane2.AllowCollapse = DevExpress.Utils.DefaultBoolean.Default;
            this.tabPane2.Controls.Add(this.tabNavigationPage2);
            this.tabPane2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane2.Location = new System.Drawing.Point(2, 2);
            this.tabPane2.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.tabPane2.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White;
            this.tabPane2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.tabPane2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabPane2.Name = "tabPane2";
            this.tabPane2.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage2});
            this.tabPane2.RegularSize = new System.Drawing.Size(1179, 537);
            this.tabPane2.SelectedPage = this.tabNavigationPage2;
            this.tabPane2.Size = new System.Drawing.Size(1179, 537);
            this.tabPane2.TabIndex = 14;
            this.tabPane2.Text = "tabPane2";
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Appearance.BackColor = System.Drawing.Color.Black;
            this.tabNavigationPage2.Appearance.Options.UseBackColor = true;
            this.tabNavigationPage2.Caption = "Danh sách nhân viên chưa có trong Hạng mục";
            this.tabNavigationPage2.Controls.Add(this.grdc_em);
            this.tabNavigationPage2.Controls.Add(this.barDockControl1);
            this.tabNavigationPage2.Controls.Add(this.barDockControl2);
            this.tabNavigationPage2.Controls.Add(this.barDockControl3);
            this.tabNavigationPage2.Controls.Add(this.barDockControl8);
            this.tabNavigationPage2.Controls.Add(this.barDockControl6);
            this.tabNavigationPage2.Controls.Add(this.barDockControl7);
            this.tabNavigationPage2.Controls.Add(this.barDockControl5);
            this.tabNavigationPage2.Controls.Add(this.barDockControl4);
            this.tabNavigationPage2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tabNavigationPage2.Margin = new System.Windows.Forms.Padding(100, 3, 100, 3);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(1179, 510);
            // 
            // grdc_em
            // 
            this.grdc_em.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdc_em.Location = new System.Drawing.Point(0, 0);
            this.grdc_em.MainView = this.grdv_em;
            this.grdc_em.Name = "grdc_em";
            this.grdc_em.Size = new System.Drawing.Size(1179, 510);
            this.grdc_em.TabIndex = 18;
            this.grdc_em.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdv_em});
            // 
            // grdv_em
            // 
            this.grdv_em.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdv_em.Appearance.Row.Options.UseFont = true;
            this.grdv_em.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdv_em.Appearance.TopNewRow.Options.UseFont = true;
            this.grdv_em.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.employee_id,
            this.employee_id_custom,
            this.employee_name,
            this.employee_address,
            this.employee_date_of_birth,
            this.department_name,
            this.employee_phone,
            this.department_price,
            this.employee_status});
            this.grdv_em.GridControl = this.grdc_em;
            this.grdv_em.Name = "grdv_em";
            this.grdv_em.OptionsBehavior.Editable = false;
            this.grdv_em.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdv_em.OptionsView.ShowGroupPanel = false;
            this.grdv_em.RowHeight = 30;
            this.grdv_em.ViewCaptionHeight = 0;
            // 
            // employee_id
            // 
            this.employee_id.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_id.AppearanceCell.Options.UseFont = true;
            this.employee_id.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_id.AppearanceHeader.Options.UseFont = true;
            this.employee_id.Caption = "ID_Em";
            this.employee_id.FieldName = "employee_id";
            this.employee_id.Name = "employee_id";
            this.employee_id.OptionsColumn.FixedWidth = true;
            // 
            // employee_id_custom
            // 
            this.employee_id_custom.Caption = "Mã";
            this.employee_id_custom.FieldName = "employee_id_custom";
            this.employee_id_custom.Name = "employee_id_custom";
            this.employee_id_custom.OptionsColumn.FixedWidth = true;
            this.employee_id_custom.Visible = true;
            this.employee_id_custom.VisibleIndex = 0;
            // 
            // employee_name
            // 
            this.employee_name.Caption = "Tên NV";
            this.employee_name.FieldName = "employee_name";
            this.employee_name.Name = "employee_name";
            this.employee_name.OptionsColumn.FixedWidth = true;
            this.employee_name.Visible = true;
            this.employee_name.VisibleIndex = 1;
            this.employee_name.Width = 120;
            // 
            // employee_address
            // 
            this.employee_address.Caption = "Địa Chỉ";
            this.employee_address.FieldName = "employee_address";
            this.employee_address.Name = "employee_address";
            this.employee_address.OptionsColumn.FixedWidth = true;
            this.employee_address.Visible = true;
            this.employee_address.VisibleIndex = 2;
            this.employee_address.Width = 150;
            // 
            // employee_date_of_birth
            // 
            this.employee_date_of_birth.Caption = "Ngày Sinh";
            this.employee_date_of_birth.DisplayFormat.FormatString = "dd/mm/yyy";
            this.employee_date_of_birth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.employee_date_of_birth.FieldName = "employee_date_of_birth";
            this.employee_date_of_birth.Name = "employee_date_of_birth";
            this.employee_date_of_birth.OptionsColumn.FixedWidth = true;
            this.employee_date_of_birth.Visible = true;
            this.employee_date_of_birth.VisibleIndex = 3;
            // 
            // department_name
            // 
            this.department_name.Caption = "Chức vụ";
            this.department_name.FieldName = "department_name";
            this.department_name.Name = "department_name";
            this.department_name.OptionsColumn.FixedWidth = true;
            this.department_name.Visible = true;
            this.department_name.VisibleIndex = 4;
            // 
            // employee_phone
            // 
            this.employee_phone.Caption = "SĐT";
            this.employee_phone.FieldName = "employee_phone";
            this.employee_phone.Name = "employee_phone";
            this.employee_phone.OptionsColumn.FixedWidth = true;
            this.employee_phone.Visible = true;
            this.employee_phone.VisibleIndex = 5;
            this.employee_phone.Width = 120;
            // 
            // department_price
            // 
            this.department_price.Caption = "Tiền Công/Ngày";
            this.department_price.FieldName = "department_price";
            this.department_price.Name = "department_price";
            this.department_price.OptionsColumn.FixedWidth = true;
            this.department_price.Visible = true;
            this.department_price.VisibleIndex = 6;
            // 
            // employee_status
            // 
            this.employee_status.Caption = "Tình Trạng";
            this.employee_status.FieldName = "employee_status";
            this.employee_status.Name = "employee_status";
            this.employee_status.OptionsColumn.FixedWidth = true;
            this.employee_status.Visible = true;
            this.employee_status.VisibleIndex = 7;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = null;
            this.barDockControl1.Size = new System.Drawing.Size(0, 510);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl2.Location = new System.Drawing.Point(1179, 0);
            this.barDockControl2.Manager = null;
            this.barDockControl2.Size = new System.Drawing.Size(0, 510);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl3.Location = new System.Drawing.Point(0, 510);
            this.barDockControl3.Manager = null;
            this.barDockControl3.Size = new System.Drawing.Size(1179, 0);
            // 
            // barDockControl8
            // 
            this.barDockControl8.CausesValidation = false;
            this.barDockControl8.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl8.Location = new System.Drawing.Point(0, 0);
            this.barDockControl8.Manager = null;
            this.barDockControl8.Size = new System.Drawing.Size(1179, 0);
            // 
            // barDockControl6
            // 
            this.barDockControl6.CausesValidation = false;
            this.barDockControl6.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl6.Location = new System.Drawing.Point(0, 0);
            this.barDockControl6.Manager = null;
            this.barDockControl6.Size = new System.Drawing.Size(0, 510);
            // 
            // barDockControl7
            // 
            this.barDockControl7.CausesValidation = false;
            this.barDockControl7.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl7.Location = new System.Drawing.Point(1179, 0);
            this.barDockControl7.Manager = null;
            this.barDockControl7.Size = new System.Drawing.Size(0, 510);
            // 
            // barDockControl5
            // 
            this.barDockControl5.CausesValidation = false;
            this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl5.Location = new System.Drawing.Point(0, 510);
            this.barDockControl5.Manager = null;
            this.barDockControl5.Size = new System.Drawing.Size(1179, 0);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl4.Location = new System.Drawing.Point(0, 0);
            this.barDockControl4.Manager = null;
            this.barDockControl4.Size = new System.Drawing.Size(1179, 0);
            // 
            // frm_AddNewEmployeeContructItems
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 611);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "frm_AddNewEmployeeContructItems";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM MỚI NHÂN VIÊN HẠNG MỤC CÔNG TRÌNH";
            this.Load += new System.EventHandler(this.frm_AddNewEmployeeContructItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane2)).EndInit();
            this.tabPane2.ResumeLayout(false);
            this.tabNavigationPage2.ResumeLayout(false);
            this.tabNavigationPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdc_em)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdv_em)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton but_Exit;
        private DevExpress.XtraEditors.SimpleButton btn_AddNew;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraBars.Navigation.TabPane tabPane2;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private DevExpress.XtraGrid.GridControl grdc_em;
        private DevExpress.XtraGrid.Views.Grid.GridView grdv_em;
        private DevExpress.XtraGrid.Columns.GridColumn employee_id;
        private DevExpress.XtraGrid.Columns.GridColumn employee_id_custom;
        private DevExpress.XtraGrid.Columns.GridColumn employee_name;
        private DevExpress.XtraGrid.Columns.GridColumn employee_address;
        private DevExpress.XtraGrid.Columns.GridColumn employee_date_of_birth;
        private DevExpress.XtraGrid.Columns.GridColumn department_name;
        private DevExpress.XtraGrid.Columns.GridColumn employee_phone;
        private DevExpress.XtraGrid.Columns.GridColumn department_price;
        private DevExpress.XtraGrid.Columns.GridColumn employee_status;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl8;
        private DevExpress.XtraBars.BarDockControl barDockControl6;
        private DevExpress.XtraBars.BarDockControl barDockControl7;
        private DevExpress.XtraBars.BarDockControl barDockControl5;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
    }
}