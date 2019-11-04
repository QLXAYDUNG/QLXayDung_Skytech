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
    public partial class frm_NewProgress : DevExpress.XtraEditors.XtraForm
    {

        BUS.constructionBus constructionBus = new BUS.constructionBus();
        BUS.constructionItemBus constructionItemBus = new BUS.constructionItemBus();
        BUS.progressBus progressBus = new BUS.progressBus();

        public frm_NewProgress()
        {
            InitializeComponent();
        }
        public void loadConstruction()
        {
            lke_Constraction.Properties.DisplayMember = "construction_name";
            lke_Constraction.Properties.ValueMember = "construction_id";
            lke_Constraction.Properties.DataSource = constructionBus.getAllContruction();
        }
        public void loadConstructionItem(Int64 id)
        {
            lke_ConstractionItem.Properties.DisplayMember = "construction_item_name";
            lke_ConstractionItem.Properties.ValueMember = "construction_item_id";
            lke_ConstractionItem.Properties.DataSource = constructionItemBus.getAllIdNameContructionItem(id);
        }

        private void frm_NewProgress_Load(object sender, EventArgs e)
        {
            loadConstruction();
        }

        private void lke_Constraction_EditValueChanged(object sender, EventArgs e)
        {
            loadConstructionItem(Convert.ToInt64( lke_Constraction.EditValue));
        }

        public string checkNull()
        {
            if (lke_Constraction.Text == lke_Constraction.Properties.NullText)
            {
                lke_Constraction.Focus();
                return "Vui Lòng Nhập Công Trình!";
            }
            else if (lke_ConstractionItem.Text == lke_ConstractionItem.Properties.NullText)
            {
                lke_ConstractionItem.Focus();
                return "Vui Lòng Nhập Hạng Mục!";
            }
            else if (date_Start.Text == "")
            {
                date_Start.Focus();
                return "Vui Lòng Nhập Ngày Lập!";
            }
            else if (txt_percent.Text == "" || Convert.ToInt32(txt_percent.Text) <= 0 || Convert.ToInt32(txt_percent.Text) >100)
            {
                txt_percent.Focus();
                return "Vui Lòng Nhập Phần Trăm Chính Xác!";
            }
            else if (pic_Logo.Image == null)
            {
                btn_Img.Focus();
                return "Vui Lòng Nhập Hình Ảnh Tiến Độ Công Trình!";
            }
            else
            {
                return "true";
            }
        }
        private bool insertProgress()
        {


            DTO.ST_progress_construction_item newProgress = new DTO.ST_progress_construction_item();
            newProgress.construction_item_id = Convert.ToInt64(lke_ConstractionItem.EditValue);
            newProgress.progress_construction_item_percent = Convert.ToInt32( txt_percent.Text);
            newProgress.progress_construction_item_date = Convert.ToDateTime(date_Start.Text);
            newProgress.progress_construction_item_description = txt_description.Text;
          

            if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                newProgress.progress_construction_item_image = fileBinary;
            }
            newProgress.employee_created = frm_Main.Vitual_id;
            


            return progressBus.insertProgress(newProgress);

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
                bool boolCheckUpdateStatus = false;
                    if (Convert.ToInt32(txt_percent.Text) > 0 && Convert.ToInt32(txt_percent.Text) < 100)
                    {
                        boolCheckUpdateStatus = constructionItemBus.updateContstructionItemStatus(Convert.ToInt64(lke_ConstractionItem.EditValue), 1);
                    }
                    else if (Convert.ToInt32(txt_percent.Text) == 100)
                        {
                            boolCheckUpdateStatus = constructionItemBus.updateContstructionItemStatus(Convert.ToInt64(lke_ConstractionItem.EditValue), 2);
                            bool boolCheckUpdateStatusCon = true;
                            if (constructionItemBus.isContructionStatus(Convert.ToInt64(lke_Constraction.EditValue)) == true)
                            {
                                boolCheckUpdateStatusCon = constructionBus.updateStatusContstruction(Convert.ToInt64(lke_Constraction.EditValue), 1);
                            }
                            else
                            {
                                boolCheckUpdateStatusCon = constructionBus.updateStatusContstruction(Convert.ToInt64(lke_Constraction.EditValue), 2);
                            }
                        }
                    
                    
                    

                    if (boolCheckUpdateStatus == true)
                    {
                        bool boolInsertConstruction = insertProgress();
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
                        messeage.error("Không Thể Thêm Mới!");
                    }
               

                }
                else
                {
                    messeage.error(checkNull1);
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