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
    public partial class frm_UpdateVendor : DevExpress.XtraEditors.XtraForm
    {
        BUS.vendorBus vendorBus = new BUS.vendorBus();

        public Int64 vendorId { get; set; }
        public frm_UpdateVendor()
        {
            InitializeComponent();
        }
        private void loadVendor()
        {
            var vendor = vendorBus.loadVendor(vendorId);
            txt_Address.Text = vendor.GetType().GetProperty("vendor_address").GetValue(vendor, null).ToString();
            txt_BankAccountNumber.Text = vendor.GetType().GetProperty("vendor_bank_account_number").GetValue(vendor, null).ToString();
            txt_PhoneNumber.Text = vendor.GetType().GetProperty("vendor_phone").GetValue(vendor, null).ToString();
            txt_VendorId.Text = vendor.GetType().GetProperty("vendor_id_custom").GetValue(vendor, null).ToString();
            txt_VendorName.Text = vendor.GetType().GetProperty("vendor_name").GetValue(vendor, null).ToString();
            
            var brimary = vendor.GetType().GetProperty("vendor_image").GetValue(vendor, null);
            if (brimary != null)
            {
                byte[] array = (brimary as System.Data.Linq.Binary).ToArray();
                MemoryStream ms = new MemoryStream(array);
                pic_Logo.Image = Image.FromStream(ms);
            }
        }
        private void frm_UpdateVendor_Load(object sender, EventArgs e)
        {
            loadVendor();
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
        byte[] converImageToBirany(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
        private bool updateVendor()
        {
            DTO.ST_vendor updateVendor = new DTO.ST_vendor();
            updateVendor.vendor_id = vendorId;
            updateVendor.vendor_name = txt_VendorName.Text;
            updateVendor.vendor_address = txt_Address.Text;
            updateVendor.vendor_phone = txt_PhoneNumber.Text;

            updateVendor.vendor_bank_account_number = txt_BankAccountNumber.Text;
            if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                updateVendor.vendor_image = fileBinary;
            }
            return vendorBus.updateVendor(updateVendor);
            

            
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string check = checkNull();
            if (check == "true")
            {

                bool boolUpdateVendor = updateVendor();
                if (boolUpdateVendor == true)
                {
                    messeage.success("Chỉnh SửaThành Công!");
                }
                else
                {
                    messeage.error("Không Thể Chỉnh Sửa!");
                }
            }
            else
            {
                messeage.error(check);
            }
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