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
using PhanMemQuanLyCongTrinh.DTO;
using DevExpress.XtraEditors.Mask;
using System.IO;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_RegisterUser : DevExpress.XtraEditors.XtraForm
    {
        deparmentBus deparmentBus = new deparmentBus();
        userBus userBus = new userBus();

        private bool gender = false;
        private bool check = false;
        private Int64 idDeparment = 0;
        private string linkImage = "";

        public frm_RegisterUser( )
        {
            InitializeComponent( );
        }

        #region Load
        private void Load_lue_deparment( )
        {
            var data = deparmentBus.listAll( );

            lue_deparment.Properties.DataSource = data;
            lue_deparment.Properties.ValueMember = "department_id";
            lue_deparment.Properties.DisplayMember = "department_name";
        }
        private void frm_RegisterUser_Load(object sender, EventArgs e)
        {
            Load_lue_deparment( );

            dt_DateOfBirth.Properties.Mask.MaskType = MaskType.DateTime  ;
            dt_DateOfBirth.Properties.Mask.EditMask = "dd-MM-yyyy"  ;
        }

        #endregion


        #region Event
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            var _username = txt_UserName.Text;
            var _password = txt_Pass.Text;
            var _name = txt_Name.Text;
            var _add = txt_Address.Text;
            var _phone = txt_Phone.Text;
            var _email = txt_Email.Text;
            var _bank = txt_BankNumber.Text;
            var _gender = gender;
            var _status = check;
                     
            
            //DateTime dt5 = date.ToDateTime( );


            if (idDeparment == 0)
            {
                messeage.error("Bạn chưa chọn chức vụ !");
            }
            else
            {
                //user name
                if (txt_UserName.Text == "")
                {
                    messeage.error("Bạn nhập tên đăng nhập !");
                }
                else
                {
                    //pass
                    if (txt_Pass.Text == "")
                    {
                        messeage.error("Bạn chưa nhập mật khẩu !");
                    }
                    else
                    {
                        
                        ST_employee employee = new ST_employee
                        {
                            employee_name = _name,
                            employee_username = _username,
                            employee_password = _password,
                            employee_address = _add,
                            employee_phone = _phone,
                            employee_email = _email,
                            employee_bank_account_number = _bank,
                            employee_status = _status,
                            employee_gender = _gender,
                            department_id = idDeparment,
                            employee_created_date = DateTime.Now                          
                        };

                        if ( dt_DateOfBirth.Text != "" )
                        {
                            var dateS = dt_DateOfBirth.Text;
                            var dateT = Convert.ToDateTime(dateS);
                            employee.employee_date_of_birth = dateT;
                        }

                        if (linkImage != "")
                        {
                            employee.employee_image = imageToByteArray(pic_Logo.Image);
                        }

                        

                        var id = userBus.insertUser(employee);
                        if (id > 0)
                        {  
                            messeage.success("Thêm mới thành công !");

                            resetForm();

                            //reset
                            linkImage = "";
                            gender = false;
                            check = false;
                            idDeparment = 0;
                        }
                        else
                        {
                            messeage.error("Thêm mới thất bại !");
                            //reset
                            linkImage = "";
                            gender = false;
                            check = false;
                            idDeparment = 0;
                        }
                    }
                }
            }
            
            
            

        }
        private void btn_AddNewDerpament_Click(object sender, EventArgs e)
        {
            frm_Newdepartment f = new frm_Newdepartment( );

            f.FormClosed += new FormClosedEventHandler(dongformGroup);

            f.ShowDialog( );

        }

        private void dongformGroup(object sender, EventArgs e)
        {
            Load_lue_deparment( );
        }

        

        private void rdo_Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup edit = sender as RadioGroup;
            var itemvalue = edit.Properties.Items[edit.SelectedIndex].Value;

            gender = bool.Parse(itemvalue.ToString( ));
        }

        private void check_Status_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            var itemvalue = edit.EditValue;
            check = bool.Parse(itemvalue.ToString( ));

        }

        private void lue_deparment_EditValueChanged(object sender, EventArgs e)
        {
            object obj = lue_deparment.EditValue;
            string text = lue_deparment.Text;

            idDeparment = Int64.Parse(obj.ToString( ));
        }

        private void resetForm()
        {
            txt_Address.Text = "";
            txt_BankNumber.Text = "";
            txt_Email.Text = "";
            txt_Name.Text = "";
            txt_Pass.Text = "";
            txt_Phone.Text = "";
            txt_UserName.Text = "";

            dt_DateOfBirth.EditValue = "";
            lue_deparment.ItemIndex = 0;
            pic_Logo.Image = null;
            lue_role.ItemIndex = 0;
            rdo_Gender.EditValue = false;
            check_Status.EditValue = false;
        }
        #endregion End Event

        

        private void btn_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog( );
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";

            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if ( openFile.ShowDialog( ) == DialogResult.OK )
            {
                linkImage = openFile.FileName;
                pic_Logo.Image = Image.FromFile(linkImage);
                
            }           
        }

        //ảnh -> byte[]
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream( );
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray( );
        }
        //byte[] -> ảnh
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        
        // su ly dang ky tai khoan
    


    }
}