namespace PhanMemQuanLyCongTrinh
{
    partial class frm_RegisterUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_RegisterUser));
            this.rdo_Gender = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.check_Status = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.btn_image = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_New = new DevExpress.XtraEditors.SimpleButton();
            this.pic_Logo = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Pass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_BankNumber = new DevExpress.XtraEditors.TextEdit();
            this.txt_Email = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Phone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Address = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_UserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.lue_deparment = new DevExpress.XtraEditors.LookUpEdit();
            this.btn_AddNewDerpament = new DevExpress.XtraEditors.SimpleButton();
            this.btn_AddNewRole = new DevExpress.XtraEditors.SimpleButton();
            this.dt_DateOfBirth = new DevExpress.XtraEditors.DateEdit();
            this.lue_role = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_Gender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_Status.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Pass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BankNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Phone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Address.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_deparment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_DateOfBirth.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_DateOfBirth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_role.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rdo_Gender
            // 
            this.rdo_Gender.Location = new System.Drawing.Point(235, 298);
            this.rdo_Gender.Name = "rdo_Gender";
            this.rdo_Gender.Properties.Columns = 2;
            this.rdo_Gender.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Nam"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Nữ")});
            this.rdo_Gender.Size = new System.Drawing.Size(147, 29);
            this.rdo_Gender.TabIndex = 270;
            this.rdo_Gender.SelectedIndexChanged += new System.EventHandler(this.rdo_Gender_SelectedIndexChanged);
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(87, 390);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(59, 16);
            this.labelControl12.TabIndex = 289;
            this.labelControl12.Text = "Trạng thái";
            // 
            // check_Status
            // 
            this.check_Status.Location = new System.Drawing.Point(235, 390);
            this.check_Status.Name = "check_Status";
            this.check_Status.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.check_Status.Properties.Appearance.Options.UseFont = true;
            this.check_Status.Properties.Caption = "";
            this.check_Status.Size = new System.Drawing.Size(75, 19);
            this.check_Status.TabIndex = 273;
            this.check_Status.CheckedChanged += new System.EventHandler(this.check_Status_CheckedChanged);
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(87, 366);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(36, 16);
            this.labelControl11.TabIndex = 288;
            this.labelControl11.Text = "Quyền";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(87, 182);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(55, 16);
            this.labelControl10.TabIndex = 287;
            this.labelControl10.Text = "Ngày sinh";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(89, 153);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(46, 16);
            this.labelControl9.TabIndex = 286;
            this.labelControl9.Text = "Chức vụ";
            // 
            // btn_image
            // 
            this.btn_image.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_image.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_image.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btn_image.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_image.Appearance.Options.UseBackColor = true;
            this.btn_image.Appearance.Options.UseFont = true;
            this.btn_image.Appearance.Options.UseForeColor = true;
            this.btn_image.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btn_image.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_image.ImageOptions.Image")));
            this.btn_image.Location = new System.Drawing.Point(957, 234);
            this.btn_image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_image.Name = "btn_image";
            this.btn_image.Size = new System.Drawing.Size(100, 23);
            this.btn_image.TabIndex = 274;
            this.btn_image.Text = "Hình ảnh";
            this.btn_image.Click += new System.EventHandler(this.btn_image_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Exit.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Exit.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Exit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_Exit.Appearance.Options.UseBackColor = true;
            this.btn_Exit.Appearance.Options.UseFont = true;
            this.btn_Exit.Appearance.Options.UseForeColor = true;
            this.btn_Exit.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btn_Exit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.ImageOptions.Image")));
            this.btn_Exit.Location = new System.Drawing.Point(651, 442);
            this.btn_Exit.LookAndFeel.SkinMaskColor = System.Drawing.Color.Gray;
            this.btn_Exit.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Black;
            this.btn_Exit.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn_Exit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(110, 36);
            this.btn_Exit.TabIndex = 276;
            this.btn_Exit.Text = "Đóng";
            this.btn_Exit.ToolTipTitle = "ESC";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_New
            // 
            this.btn_New.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_New.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_New.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btn_New.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_New.Appearance.Options.UseBackColor = true;
            this.btn_New.Appearance.Options.UseFont = true;
            this.btn_New.Appearance.Options.UseForeColor = true;
            this.btn_New.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btn_New.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_New.ImageOptions.Image")));
            this.btn_New.Location = new System.Drawing.Point(521, 442);
            this.btn_New.LookAndFeel.SkinMaskColor = System.Drawing.Color.RoyalBlue;
            this.btn_New.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_New.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn_New.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_New.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(110, 36);
            this.btn_New.TabIndex = 275;
            this.btn_New.Text = "Thêm mới";
            this.btn_New.ToolTipTitle = "Ctrl +S";
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // pic_Logo
            // 
            this.pic_Logo.Location = new System.Drawing.Point(912, 58);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_Logo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pic_Logo.Size = new System.Drawing.Size(176, 169);
            this.pic_Logo.TabIndex = 277;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(87, 91);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 16);
            this.labelControl7.TabIndex = 285;
            this.labelControl7.Text = "Mật khẩu";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(237, 115);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.txt_Name.Properties.Appearance.Options.UseFont = true;
            this.txt_Name.Size = new System.Drawing.Size(291, 22);
            this.txt_Name.TabIndex = 264;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(87, 61);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(86, 16);
            this.labelControl6.TabIndex = 284;
            this.labelControl6.Text = "Tên đăng nhập";
            // 
            // txt_Pass
            // 
            this.txt_Pass.Location = new System.Drawing.Point(237, 85);
            this.txt_Pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.txt_Pass.Properties.Appearance.Options.UseFont = true;
            this.txt_Pass.Properties.PasswordChar = '*';
            this.txt_Pass.Size = new System.Drawing.Size(291, 22);
            this.txt_Pass.TabIndex = 263;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(87, 334);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(120, 16);
            this.labelControl8.TabIndex = 282;
            this.labelControl8.Text = "Tài khoản ngân hàng";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(87, 304);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 16);
            this.labelControl1.TabIndex = 283;
            this.labelControl1.Text = "Giới tính";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(87, 274);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(31, 16);
            this.labelControl5.TabIndex = 281;
            this.labelControl5.Text = "Email";
            // 
            // txt_BankNumber
            // 
            this.txt_BankNumber.Location = new System.Drawing.Point(235, 334);
            this.txt_BankNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_BankNumber.Name = "txt_BankNumber";
            this.txt_BankNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.txt_BankNumber.Properties.Appearance.Options.UseFont = true;
            this.txt_BankNumber.Size = new System.Drawing.Size(291, 22);
            this.txt_BankNumber.TabIndex = 271;
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(235, 268);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.txt_Email.Properties.Appearance.Options.UseFont = true;
            this.txt_Email.Size = new System.Drawing.Size(291, 22);
            this.txt_Email.TabIndex = 269;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(87, 244);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 16);
            this.labelControl4.TabIndex = 280;
            this.labelControl4.Text = "Số điện thoại";
            // 
            // txt_Phone
            // 
            this.txt_Phone.Location = new System.Drawing.Point(235, 238);
            this.txt_Phone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.txt_Phone.Properties.Appearance.Options.UseFont = true;
            this.txt_Phone.Size = new System.Drawing.Size(291, 22);
            this.txt_Phone.TabIndex = 268;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(89, 214);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 16);
            this.labelControl3.TabIndex = 279;
            this.labelControl3.Text = "Địa chỉ";
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(235, 208);
            this.txt_Address.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.txt_Address.Properties.Appearance.Options.UseFont = true;
            this.txt_Address.Size = new System.Drawing.Size(454, 22);
            this.txt_Address.TabIndex = 267;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(89, 121);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 278;
            this.labelControl2.Text = "Họ và tên";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(237, 55);
            this.txt_UserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.txt_UserName.Properties.Appearance.Options.UseFont = true;
            this.txt_UserName.Size = new System.Drawing.Size(291, 22);
            this.txt_UserName.TabIndex = 262;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl13.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Appearance.Options.UseForeColor = true;
            this.labelControl13.Location = new System.Drawing.Point(534, 58);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(8, 16);
            this.labelControl13.TabIndex = 284;
            this.labelControl13.Text = "*";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl14.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Appearance.Options.UseForeColor = true;
            this.labelControl14.Location = new System.Drawing.Point(534, 88);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(8, 16);
            this.labelControl14.TabIndex = 284;
            this.labelControl14.Text = "*";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Appearance.Options.UseForeColor = true;
            this.labelControl15.Location = new System.Drawing.Point(534, 145);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(8, 16);
            this.labelControl15.TabIndex = 284;
            this.labelControl15.Text = "*";
            // 
            // lue_deparment
            // 
            this.lue_deparment.Location = new System.Drawing.Point(237, 144);
            this.lue_deparment.Name = "lue_deparment";
            this.lue_deparment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_deparment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("department_id", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("department_name", "Tên chức vụ")});
            this.lue_deparment.Properties.NullText = "Chọn";
            this.lue_deparment.Size = new System.Drawing.Size(289, 20);
            this.lue_deparment.TabIndex = 290;
            this.lue_deparment.EditValueChanged += new System.EventHandler(this.lue_deparment_EditValueChanged);
            // 
            // btn_AddNewDerpament
            // 
            this.btn_AddNewDerpament.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddNewDerpament.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddNewDerpament.ImageOptions.Image")));
            this.btn_AddNewDerpament.Location = new System.Drawing.Point(548, 140);
            this.btn_AddNewDerpament.Name = "btn_AddNewDerpament";
            this.btn_AddNewDerpament.Size = new System.Drawing.Size(25, 27);
            this.btn_AddNewDerpament.TabIndex = 291;
            this.btn_AddNewDerpament.Click += new System.EventHandler(this.btn_AddNewDerpament_Click);
            // 
            // btn_AddNewRole
            // 
            this.btn_AddNewRole.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddNewRole.ImageOptions.Image")));
            this.btn_AddNewRole.Location = new System.Drawing.Point(548, 361);
            this.btn_AddNewRole.Name = "btn_AddNewRole";
            this.btn_AddNewRole.Size = new System.Drawing.Size(25, 27);
            this.btn_AddNewRole.TabIndex = 291;
            this.btn_AddNewRole.Click += new System.EventHandler(this.btn_AddNewDerpament_Click);
            // 
            // dt_DateOfBirth
            // 
            this.dt_DateOfBirth.EditValue = null;
            this.dt_DateOfBirth.Location = new System.Drawing.Point(235, 177);
            this.dt_DateOfBirth.Name = "dt_DateOfBirth";
            this.dt_DateOfBirth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt_DateOfBirth.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt_DateOfBirth.Size = new System.Drawing.Size(291, 20);
            this.dt_DateOfBirth.TabIndex = 292;
            // 
            // lue_role
            // 
            this.lue_role.Location = new System.Drawing.Point(235, 365);
            this.lue_role.Name = "lue_role";
            this.lue_role.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_role.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("", "Tên quyền")});
            this.lue_role.Properties.NullText = "Chọn";
            this.lue_role.Size = new System.Drawing.Size(291, 20);
            this.lue_role.TabIndex = 290;
            this.lue_role.EditValueChanged += new System.EventHandler(this.lue_deparment_EditValueChanged);
            // 
            // frm_RegisterUser
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 563);
            this.Controls.Add(this.dt_DateOfBirth);
            this.Controls.Add(this.btn_AddNewRole);
            this.Controls.Add(this.btn_AddNewDerpament);
            this.Controls.Add(this.lue_role);
            this.Controls.Add(this.lue_deparment);
            this.Controls.Add(this.rdo_Gender);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.check_Status);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.btn_image);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.pic_Logo);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txt_Pass);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txt_BankNumber);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txt_Phone);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_UserName);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "frm_RegisterUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG KÝ TÀI KHOẢN";
            this.Load += new System.EventHandler(this.frm_RegisterUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdo_Gender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_Status.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Pass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BankNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Phone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Address.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_deparment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_DateOfBirth.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_DateOfBirth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_role.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup rdo_Gender;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.CheckEdit check_Status;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SimpleButton btn_image;
        private DevExpress.XtraEditors.SimpleButton btn_Exit;
        private DevExpress.XtraEditors.SimpleButton btn_New;
        private DevExpress.XtraEditors.PictureEdit pic_Logo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txt_Pass;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txt_BankNumber;
        private DevExpress.XtraEditors.TextEdit txt_Email;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_Phone;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_Address;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_UserName;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LookUpEdit lue_deparment;
        private DevExpress.XtraEditors.SimpleButton btn_AddNewDerpament;
        private DevExpress.XtraEditors.SimpleButton btn_AddNewRole;
        private DevExpress.XtraEditors.DateEdit dt_DateOfBirth;
        private DevExpress.XtraEditors.LookUpEdit lue_role;
    }
}