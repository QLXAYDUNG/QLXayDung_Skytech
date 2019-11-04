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
using System.IO;
using DevExpress.XtraEditors.Mask;
using System.Runtime.Serialization.Formatters.Binary;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_UserInfo : DevExpress.XtraEditors.XtraForm
    {
        public frm_UserInfo( )
        {
            InitializeComponent( );
        }

        // check neu chinh sua thong tin user
        public Int64 user_id = 0;
        private bool gender = false;
        private bool check = false;
        private Int64 idDeparment = 0;
        private string linkImage = "";


        userBus userBus = new userBus();
        deparmentBus deparmentBus = new deparmentBus();

        private void frm_UserInfo_Load(object sender, EventArgs e)
        {
            dt_DateOfBirth.Properties.Mask.MaskType = MaskType.DateTime;
            dt_DateOfBirth.Properties.Mask.EditMask = "dd-MM-yyyy";

            loadDeparment();
            LoadData();
        }

        #region Load
        private void loadDeparment( )
        {
            var data = deparmentBus.listAll( );

            lue_deparment.Properties.DataSource = data;
            lue_deparment.Properties.ValueMember = "department_id";
            lue_deparment.Properties.DisplayMember = "department_name";
        }
        public void LoadData()
        {
            if (user_id == 0)
            {
                Int64 id = frm_Main.Vitual_id;

                loadUser(id);
            }
            else
            {
                // admin cap nhat user
                loadUser(user_id);
            }
            
            
        }

        public void loadUser(Int64 id)
        {
            var user = userBus.getUserByID(id);

            var Name = user.GetType( ).GetProperty("employee_name").GetValue(user, null);
            txt_Name.Text = (Name == null) ? "" : Name.ToString( );

            var UserName = user.GetType( ).GetProperty("employee_username").GetValue(user, null);
            txt_UserName.Text = (UserName == null) ? "" : UserName.ToString( );

            var Pass = user.GetType( ).GetProperty("employee_password").GetValue(user, null);
            txt_Pass.Text = (Pass == null) ? "" : Pass.ToString( );

            var employee_address = user.GetType( ).GetProperty("employee_address").GetValue(user, null);
            txt_Address.Text = (employee_address == null) ? "" : employee_address.ToString( );

            var employee_email = user.GetType( ).GetProperty("employee_email").GetValue(user, null);
            txt_Email.Text = (employee_email == null) ? "" : employee_email.ToString( );

            var employee_phone = user.GetType( ).GetProperty("employee_phone").GetValue(user, null);
            txt_Phone.Text = (employee_phone == null) ? "" : employee_phone.ToString( );

            var employee_date_of_birth = user.GetType( ).GetProperty("employee_date_of_birth").GetValue(user, null);
            dt_DateOfBirth.Text = (employee_date_of_birth == null) ? "" : employee_date_of_birth.ToString( );

            var employee_gender = user.GetType( ).GetProperty("employee_gender").GetValue(user, null);
            rdo_Gender.EditValue = (employee_gender == null) ? "" : employee_gender;

            var employee_bank_account_number = user.GetType( ).GetProperty("employee_bank_account_number").GetValue(user, null);
            txt_BankNumber.Text = (employee_bank_account_number == null) ? "" : employee_bank_account_number.ToString( );

            var department_id = user.GetType( ).GetProperty("department_id").GetValue(user, null);
            var departmentID = (department_id == null) ? "" : department_id.ToString( );
            lue_deparment.ItemIndex = Int32.Parse(departmentID) - 1;

            var employee_status = user.GetType( ).GetProperty("employee_status").GetValue(user, null);
            check_Status.EditValue = (employee_status == null) ? "" : employee_status;


            //hien thi hinh anh
            var employee_image = user.GetType( ).GetProperty("employee_image").GetValue(user, null);
            if ( employee_image != null )
            {
                var brimary = employee_image;
                byte[] array = (brimary as System.Data.Linq.Binary).ToArray( );
                MemoryStream ms = new MemoryStream(array);

                pic_Logo.Image = Image.FromStream(ms);
            }



            // set gia tri mat dinh
            var selectedGender = user.GetType( ).GetProperty("employee_gender").GetValue(user, null);
            selectedGender = (selectedGender == null) ? "0" : selectedGender.ToString( );

            gender = bool.Parse(selectedGender.ToString( ));
            check = bool.Parse(employee_status.ToString( ));
            idDeparment = Int64.Parse(departmentID.ToString( ));
        }

        #endregion End load

        #region Event
            private void lue_deparment_EditValueChanged(object sender, EventArgs e)
            {
                object obj = lue_deparment.EditValue;
                string text = lue_deparment.Text;

                idDeparment = Int64.Parse(obj.ToString( ));
            }

            private void rdo_Gender_EditValueChanged(object sender, EventArgs e)
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

            private void btn_Update_Click(object sender, EventArgs e)
            {
                Int64 idUser = 0;
                if (user_id == 0)
                {
                    idUser = frm_Main.Vitual_id;
                }
                else
                {
                    idUser = user_id;
                }

                var user = userBus.getUserByID(idUser);

                var _username = txt_UserName.Text;
                var _password = txt_Pass.Text;
                var _name = txt_Name.Text;
                var _add = txt_Address.Text;
                var _phone = txt_Phone.Text;
                var _email = txt_Email.Text;
                var _bank = txt_BankNumber.Text;



                var _gender = gender;
                var _status = check;
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
                            employee_gender = gender,
                            department_id = idDeparment,
  
                                                      
                        };

                        if ( dt_DateOfBirth.Text != "" )
                        {
                            var dateS = Convert.ToDateTime(dt_DateOfBirth.Text).ToString("dd-MM-yyyy hh:mm:ss");
                            var dateT = Convert.ToDateTime(dateS);
                            employee.employee_date_of_birth = dateT;
                        }

                        if (linkImage != "")
                        {
                            employee.employee_image = imageToByteArray(pic_Logo.Image);
                        }



                        var id = userBus.updateUser(employee, idUser);
                        if (id)
                        {  
                            messeage.success("Cập nhật thành công !");
                        }
                        else
                        {
                            messeage.error("Cập nhật thất bại !");
                            //reset
                        }
                    }
                }
            }
            }
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
        #endregion End Event

        

        //ảnh -> byte[]
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream( );
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray( );
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter( );
            using ( var ms = new MemoryStream( ) )
            {
                bf.Serialize(ms, obj);
                return ms.ToArray( );
            }
        }

        private void btn_image_Click_1(object sender, EventArgs e)
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

        private void btn_Deparment_Click(object sender, EventArgs e)
        {
            frm_Newdepartment f = new frm_Newdepartment( );
            f.ShowDialog( );
        }

     

        

  
    }
}