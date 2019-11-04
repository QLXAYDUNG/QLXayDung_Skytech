using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhanMemQuanLyCongTrinh.BUS;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_Login : DevExpress.XtraEditors.XtraForm
    {
        private userBus userBus = null;

        public frm_Login( )
        {
            InitializeComponent( );
            userBus = new userBus( );
        }

        
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if ( txt_UserName.Text == "" || txt_PassWord.Text == "" )
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Int64 IntCheckLogin = userBus.checkLogin(txt_UserName.Text, txt_PassWord.Text);

                if ( IntCheckLogin > 0)
                {                   
                    var user = userBus.getUserByID(IntCheckLogin);

                    // check quyen
                    var Quyen = user.GetType( ).GetProperty("permission_id").GetValue(user, null);
                    var Vitual_Quyen = (Quyen == null) ? 0 : Int64.Parse(Quyen.ToString( ));

                    frm_Main.Vitual_Username = txt_UserName.Text;
                    frm_Main.Vitual_Quyen = Vitual_Quyen;
                    frm_Main.Vitual_id = IntCheckLogin;

                    // tao form moi
                    frm_Main f = new frm_Main( );

                    

                    // an form hien tai                  
                    // show form
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide( );

                    f.ShowDialog( );
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                }

            }
        }


        private void CloseForm(Object sender, EventArgs args)
        {
            Application.Exit( );
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btn_Login;
        }
       
    }
}