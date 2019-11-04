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
    public partial class frm_UpdateConstructionItem : DevExpress.XtraEditors.XtraForm
    {

        public byte[] file;
        string fileName;

        public Int64 counstructionItemId { get; set; }
        BUS.constructionBus constructionBus = new BUS.constructionBus();
        BUS.constructionItemBus constructionItemBus = new BUS.constructionItemBus();
        BUS.buildingContractorBus buildingContractorBus = new BUS.buildingContractorBus();

        public frm_UpdateConstructionItem()
        {
            InitializeComponent();
        }
        private void loadConstructionItem()
        {
            var constructionItem = constructionItemBus.getConstructionItem(counstructionItemId);
            txt_ContructionItemId.Text = constructionItem.GetType().GetProperty("construction_item_custom").GetValue(constructionItem, null).ToString();
            txt_name.Text = constructionItem.GetType().GetProperty("construction_item_name").GetValue(constructionItem, null).ToString();
            lke_Constraction.EditValue = constructionItem.GetType().GetProperty("construction_id").GetValue(constructionItem, null).ToString();
            lke_buildingContractor.EditValue = constructionItem.GetType().GetProperty("building_contractor_id").GetValue(constructionItem, null).ToString();

            txt_ContractNumber.Text = constructionItem.GetType().GetProperty("construction_contract_number").GetValue(constructionItem, null).ToString();

            decimal money = Convert.ToDecimal(constructionItem.GetType().GetProperty("construction_item_total_price").GetValue(constructionItem, null).ToString());
            txt_Price.Text = money.ToString("0");


            txt_file.Text = constructionItem.GetType().GetProperty("construction_item_file_name").GetValue(constructionItem, null).ToString();

            var brimary = constructionItem.GetType().GetProperty("construction_item_image").GetValue(constructionItem, null);
            if (brimary != null)
            {
                byte[] array = (brimary as System.Data.Linq.Binary).ToArray();
                MemoryStream ms = new MemoryStream(array);
                pic_Logo.Image = Image.FromStream(ms);
            }




            var startDay = constructionItem.GetType().GetProperty("construction_item_date_start").GetValue(constructionItem, null);
            if (startDay != null)
            {


                date_Start.Text = startDay.ToString();
            }


            var endDay = constructionItem.GetType().GetProperty("construction_item_date_end").GetValue(constructionItem, null);
            if (endDay != null)
            {

                date_End.Text = endDay.ToString();
            }


            var guarantee = constructionItem.GetType().GetProperty("construction_item_date_end_guarantee").GetValue(constructionItem, null);
            if (guarantee != null)
            {

                date_Guarantee.Text = guarantee.ToString();
            }

            var fileNull = constructionItem.GetType().GetProperty("construction_item_file").GetValue(constructionItem, null);

            if (fileNull != null)
            {
                byte[] arr = (fileNull as System.Data.Linq.Binary).ToArray();
                file = arr;
                fileName = constructionItem.GetType().GetProperty("construction_item_file_name").GetValue(constructionItem, null).ToString();
            }
          

        }

        public void loadConstuction()
        {
            lke_Constraction.Properties.DisplayMember = "construction_name";
            lke_Constraction.Properties.ValueMember = "construction_id";
            lke_Constraction.Properties.DataSource = constructionBus.getAllContruction();
        }
        public void loadBuilding()
        {
            lke_buildingContractor.Properties.DisplayMember = "building_contractor_name";
            lke_buildingContractor.Properties.ValueMember = "building_contractor_id";
            lke_buildingContractor.Properties.DataSource = buildingContractorBus.loadAllBuildingContractor();
        }

        private void frm_UpdateConstructionItem_Load(object sender, EventArgs e)
        {
            loadConstructionItem();
            loadConstuction();
            loadBuilding();
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string checkNull()
        {
            if (txt_name.Text == "")
            {
                txt_name.Focus();
                return "Vui Lòng Nhập Tên Hạng Mục!";
            }
            else if (lke_Constraction.Text == lke_Constraction.Properties.NullText)
            {
                lke_Constraction.Focus();
                return "Vui Lòng Nhập Công Trình!";
            }
            else if (lke_buildingContractor.Text == "")
            {
                lke_buildingContractor.Focus();
                return "Vui Lòng Nhập Hạng Mục!";
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
            else if (file == null)
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
        private bool updateConstructionItem()
        {


            DTO.ST_construction_item newConstructionItem = new DTO.ST_construction_item();
            newConstructionItem.construction_item_id = counstructionItemId;
            newConstructionItem.construction_item_name = txt_name.Text;
            newConstructionItem.construction_id = Convert.ToInt64(lke_Constraction.EditValue);
            newConstructionItem.building_contractor_id = Convert.ToInt64(lke_buildingContractor.EditValue);
            newConstructionItem.construction_contract_number = txt_ContractNumber.Text;
            newConstructionItem.construction_item_total_price = Convert.ToDecimal(txt_Price.Text);



            if (file != null)
            {
                newConstructionItem.construction_item_file = file;
                newConstructionItem.construction_item_file_name = fileName;
            }
          


            if (date_Start.Text != "")
            {
                DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                dateStart.ToString("yy/MM/dd");
                newConstructionItem.construction_item_date_start = dateStart;
            }


            if (date_End.Text != "")
            {
                DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                dateEnd.ToString("yy/MM/dd");
                newConstructionItem.construction_item_date_end = dateEnd;
            }

            if (date_Guarantee.Text != "")
            {
                DateTime dateGuarantee = Convert.ToDateTime(date_Guarantee.Text);
                dateGuarantee.ToString("yy/MM/dd");
                newConstructionItem.construction_item_date_end_guarantee = dateGuarantee;
            }


            if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                newConstructionItem.construction_item_image = fileBinary;
            }


            return constructionItemBus.updateContstructionItem(newConstructionItem);

        }

        byte[] converImageToBirany(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {
            string checkNull1 = checkNull();
            if (checkNull1 == "true")
            {
                bool boolInsertConstruction = updateConstructionItem();
                if (boolInsertConstruction == true)
                {
                    messeage.success("Cập Nhật Thành Công!");
                    this.Close();
                }
                else
                {
                    messeage.error("Không Thể Cập Nhật!");
                }

            }
            else
            {
                messeage.error(checkNull1);
            }
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
                foreach (string fileName1 in openFileDialog.FileNames)
                {
                    txt_file.Text = fileName1;

                }
            }

            string filepath = txt_file.Text;
            fileName = Path.GetFileName(filepath);
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            file = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();

        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            string path = @"D:\" + fileName;
            File.WriteAllBytes(path, file);
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