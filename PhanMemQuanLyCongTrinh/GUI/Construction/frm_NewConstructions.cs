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
    public partial class frm_NewConstructions : DevExpress.XtraEditors.XtraForm
    {
        BUS.constructionBus constructionBus = new BUS.constructionBus();
        BUS.customerBus customerBus = new BUS.customerBus();
        public frm_NewConstructions()
        {
            InitializeComponent();
        }
       
        OpenFileDialog open;

        public void loadCustomer()
        {
            lke_Customer.Properties.DisplayMember = "customer_name";
            lke_Customer.Properties.ValueMember = "customer_id";
            lke_Customer.Properties.DataSource = customerBus.getAllCustomer();      
        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "WORD files (*.docx)|*.docx";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    txt_file.Text = fileName;
                }
            }
        }

        public string checkNull()
        {
            if (txt_ConstructionName.Text == "")
            {
                txt_ConstructionName.Focus();
                return "Vui Lòng Nhập Tên Công Trình!";
            }
            else if (lke_Customer.Text == lke_Customer.Properties.NullText)
            {
                lke_Customer.Focus();
                return "Vui Lòng Nhập Khách Hàng!";
            }
            else if (txt_Address.Text == "")
            {
                txt_Address.Focus();
                return "Vui Lòng Nhập Địa Chỉ Khách Hàng!";
            }
            else if (txt_ContractNumber.Text == "")
            {
                txt_ContractNumber.Focus();
                return "Vui Lòng Nhập Số Hợp Đồng!";
            }
            else if (txt_Price.Text == "")
            {
                txt_Price.Focus();
                return "Vui Lòng Nhập Tiền Công Trình!";
            }
            else if (date_Start.Text == "")
            {
                date_Start.Focus();
                return "Vui Lòng Nhập Ngày Bắt Đầu!";
            }
            else if (date_End.Text == "")
            {
                txt_Price.Focus();
                return "Vui Lòng Nhập Ngày Kết Thúc!";
            }
            else if (txt_file.Text != "" && getFile() == null)
            {
                btn_OpenFile.Focus();
                return "File Bạn không Có!";
            }

            else
            {
                return "true";
            }
        }

        private byte[] getFile()
        {
            string filepath = txt_file.Text;
            string filename = Path.GetFileName(filepath);
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();
            return bytes;
        }


        byte[] converImageToBirany(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }


        private bool insertConstruction()
        {
           

            DTO.ST_construction newConstruction = new DTO.ST_construction();
            newConstruction.construction_name = txt_ConstructionName.Text;
            newConstruction.customer_id = Convert.ToInt64(lke_Customer.EditValue);
            newConstruction.construction_addresss = txt_Address.Text;
            newConstruction.construction_contract_number = txt_ContractNumber.Text;
            newConstruction.construction_total_price = Convert.ToDecimal(txt_Price.Text);
            string filepath = txt_file.Text;
            string filename = Path.GetFileName(filepath);
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();


            newConstruction.construction_file_name = filename;

            newConstruction.construction_file = bytes;
            if (date_Start.Text != "")
            {
                DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                dateStart.ToString("yy/MM/dd");
                newConstruction.construction_date_start = dateStart;
            }

            if (date_End.Text != "")
            {
                DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                dateEnd.ToString("yy/MM/dd");
                newConstruction.construction_date_end = dateEnd;
            }
            if (date_Guarantee.Text != "")
            {
                DateTime dateGuarantee = Convert.ToDateTime(date_Guarantee.Text);
                dateGuarantee.ToString("yy/MM/dd");
                newConstruction.construction_date_guarantee = dateGuarantee;
            }

             if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                newConstruction.construction_image = fileBinary;
            }
             newConstruction.construction_status = 0;
             newConstruction.employee_created = frm_Main.Vitual_id;



            return constructionBus.insertContstruction(newConstruction);

        }


        private void btn_Update_Click(object sender, EventArgs e)
        {
            string checkNull1 = checkNull();
            if (checkNull1 == "true")
            {
                bool boolInsertConstruction = insertConstruction();
                if (boolInsertConstruction == true)
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
                messeage.error(checkNull1);
            }
        }

        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            frm_NewCustomer frm = new frm_NewCustomer();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.customerId = 0;
            frm.ShowDialog();
        }
        private void dongform(object sender, EventArgs e)
        {
            loadCustomer();
        }

        private void frm_NewConstructions_Load(object sender, EventArgs e)
        {
            loadCustomer();
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

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Update_Click_1(object sender, EventArgs e)
        {
            string check = checkNull();
            if (check == "true")
            {

                bool boolInsertVendor = insertConstruction();
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
       
    }
}