using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using PhanMemQuanLyCongTrinh.BUS;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_NewVendor : DevExpress.XtraEditors.XtraForm
    {
        BUS.vendorBus vendorBus = new vendorBus();
        public frm_NewVendor()
        {
            InitializeComponent();
        }

        private string checkNull()
        {
            if (txt_VendorName.Text == "")
            {
                txt_VendorName.Focus();
                return "Vui Lòng Nhập Tên Nhà Cung Cấp";
            }
            else if (txt_Address.Text == "")
            {
                txt_Address.Focus();
                return "Vui Lòng Nhập Địa Chỉ Nhà Cung Cấp";
            }
            else if (txt_PhoneNumber.Text == "")
            {
                txt_PhoneNumber.Focus();
                return "Vui Lòng Nhập Số Điện Thoại Nhà Cung Cấp";
            }
            else
            {
                return "true";
            }
        }
        private bool insertVendor()
        {
            DTO.ST_vendor newVendor = new DTO.ST_vendor();
            newVendor.vendor_name = txt_VendorName.Text;
            newVendor.vendor_address = txt_Address.Text;
            newVendor.vendor_phone = txt_PhoneNumber.Text;

            newVendor.vendor_bank_account_number = txt_BankAccountNumber.Text;

 

            DateTime now = DateTime.Now;
            now.ToString("yyyy/MM/dd");
            newVendor.vendor_created_date = now;

            newVendor.vendor_status = true;

            if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                newVendor.vendor_image = fileBinary;
            }

            newVendor.employee_created = frm_Main.Vitual_id;

            return vendorBus.insertVendor(newVendor);
        }
       
        byte[] converImageToBirany(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
       
        private void frm_NewVendor_Load(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string check = checkNull();
            if (check == "true")
            {
                
                    bool boolInsertVendor = insertVendor();
                    if (boolInsertVendor == true)
                    {
                        messeage.success("Thêm Mới Thành Công!");
                        this.Close();
                    }
                    else
                    {
                        messeage.error("Không Thể Thêm Mới!");
                    }
            }
            else
            {
                messeage.error(check);
            }
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }

        private void btn_Img_Click(object sender, EventArgs e)
        {
            string filename;
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;
                    pic_Logo.Image = Image.FromFile(filename);
                }
            }
        }
    }
}