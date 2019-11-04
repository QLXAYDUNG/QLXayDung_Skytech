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

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_NewConstructionItem : DevExpress.XtraEditors.XtraForm
    {
        BUS.constructionBus constructionBus = new BUS.constructionBus();
        BUS.constructionItemBus constructionItemBus = new BUS.constructionItemBus();
        BUS.buildingContractorBus buildingContractorBus = new buildingContractorBus();

        public frm_NewConstructionItem()
        {
            InitializeComponent();
        }
        public void loadConstruction()
        {
            lke_Constraction.Properties.DisplayMember = "construction_name";
            lke_Constraction.Properties.ValueMember = "construction_id";
            lke_Constraction.Properties.DataSource = constructionBus.getAllContruction();
        }
        public void loadBuildingContractor()
        {
            lke_buildingContractor.Properties.DisplayMember = "building_contractor_name";
            lke_buildingContractor.Properties.ValueMember = "building_contractor_id";
            lke_buildingContractor.Properties.DataSource = buildingContractorBus.loadAllBuildingContractor();
        }

        private void newConstructionItem_Load(object sender, EventArgs e)
        {
            loadConstruction();
            loadBuildingContractor();
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


        private bool insertConstruction()
        {


            DTO.ST_construction_item newConstructionItem = new DTO.ST_construction_item();
            newConstructionItem.construction_item_name = txt_name.Text;
            newConstructionItem.construction_id = Convert.ToInt64(lke_Constraction.EditValue);
            newConstructionItem.building_contractor_id = Convert.ToInt64(lke_buildingContractor.EditValue);
            newConstructionItem.construction_contract_number = txt_ContractNumber.Text;
            newConstructionItem.construction_item_total_price = Convert.ToDecimal(txt_Price.Text);
            string filepath = txt_file.Text;
            string filename = Path.GetFileName(filepath);
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();


            newConstructionItem.construction_item_file_name = filename;

            newConstructionItem.construction_item_file = bytes;
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
            newConstructionItem.construction_item_status = 0;
            newConstructionItem.employee_created = frm_Main.Vitual_id;



            return constructionItemBus.insertContstructionItem(newConstructionItem);

        }

        byte[] converImageToBirany(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
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

        private void btn_AddConstruction_Click(object sender, EventArgs e)
        {
            frm_NewConstructions frm = new frm_NewConstructions();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            
            frm.ShowDialog();
        }
        private void dongform(object sender, EventArgs e)
        {
            loadConstruction();
        }

        private void btn_AddBuildingContractor_Click(object sender, EventArgs e)
        {
            frm_NewBuildingContractor frm = new frm_NewBuildingContractor();
            frm.FormClosed += new FormClosedEventHandler(dongformBC);

            frm.ShowDialog();
        }
        private void dongformBC(object sender, EventArgs e)
        {
            loadBuildingContractor();
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

        
    }
}