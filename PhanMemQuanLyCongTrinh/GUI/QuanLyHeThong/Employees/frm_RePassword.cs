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
    public partial class frm_RePassword : DevExpress.XtraEditors.XtraForm
    {
        public frm_RePassword( )
        {
            InitializeComponent( );
        }

        userBus userBus = new userBus();

        private void frm_RePassword_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            var oldPass = txt_OldPass.Text;
            var NewPass = txt_OldPass.Text;
            var RePass = txt_ReNewPass.Text;

            if ( oldPass == "" )
            {
                messeage.error("Bạn chưa nhập mật khẩu cũ !");

            }
            else
            {
                var id = frm_Main.Vitual_id;
                var userPass = userBus.getUserByID(id);

                var pass = userPass.GetType( ).GetProperty("employee_password").GetValue(userPass, null);

                if ( NewPass == "" )
                {
                    messeage.error("Bạn chưa nhập mật khẩu mới !");
                }
                else
                {
                    if (RePass == "")
                    {
                        messeage.error("Bạn chưa nhập lại mật khẩu mới !");
                    }
                    else
                    {
                        if ( oldPass.ToString() == pass.ToString())
                        {
                            userBus.upatePass(RePass, id);
                            messeage.success("Cập nhật thành công !");              
                        }
                    }
                }

                
            }
        }


        
    }
}