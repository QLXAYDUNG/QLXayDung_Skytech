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
    public partial class frm_Updateprogress : DevExpress.XtraEditors.XtraForm
    {
        BUS.constructionBus constructionBus = new BUS.constructionBus();
        BUS.constructionItemBus constructionItemBus = new BUS.constructionItemBus();
        BUS.progressBus progressBus = new BUS.progressBus();

        public Int64 progressId { get; set; }
        Int64 contructionId;
        Int64 contructionItemId;
        public frm_Updateprogress()
        {
            InitializeComponent();
        }

        public void loadProgress()
        {
            var progress = progressBus.getProgress(progressId);
            txt_Construction.Text = progress.GetType().GetProperty("construction_name").GetValue(progress, null).ToString();
            txt_ConstructionIten.Text = progress.GetType().GetProperty("construction_item_name").GetValue(progress, null).ToString();
            txt_description.Text = progress.GetType().GetProperty("progress_construction_item_description").GetValue(progress, null).ToString();
            txt_percent.Text = progress.GetType().GetProperty("progress_construction_item_percent").GetValue(progress, null).ToString();

            date_Start.Text = progress.GetType().GetProperty("progress_construction_item_date").GetValue(progress, null).ToString();

            var brimary = progress.GetType().GetProperty("progress_construction_item_image").GetValue(progress, null);
            if (brimary != null)
            {
                byte[] array = (brimary as System.Data.Linq.Binary).ToArray();
                MemoryStream ms = new MemoryStream(array);
                pic_Logo.Image = Image.FromStream(ms);
            }
            contructionId =Convert.ToInt64( progress.GetType().GetProperty("construction_id").GetValue(progress, null));
            contructionItemId = Convert.ToInt64(progress.GetType().GetProperty("construction_item_id").GetValue(progress, null));

        }

        private void frm_Updateprogress_Load(object sender, EventArgs e)
        {
            loadProgress();
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string checkNull()
        { if (date_Start.Text == "")
            {
                date_Start.Focus();
                return "Vui Lòng Nhập Ngày Lập!";
            }
            else if (txt_percent.Text == "" || Convert.ToInt32(txt_percent.Text) <= 0 || Convert.ToInt32(txt_percent.Text) > 100)
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

        private bool updateProgress()
        {

            DTO.ST_progress_construction_item newProgress = new DTO.ST_progress_construction_item();

            newProgress.progress_construction_item_id = progressId;
            newProgress.progress_construction_item_percent = Convert.ToInt32(txt_percent.Text);
            newProgress.progress_construction_item_date = Convert.ToDateTime(date_Start.Text);
            newProgress.progress_construction_item_description = txt_description.Text;

            if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                newProgress.progress_construction_item_image = fileBinary;
            }
          

            return progressBus.updateProgress(newProgress);

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
                bool boolCheckUpdateStatus = false;
                if (Convert.ToInt32(txt_percent.Text) > 0 && Convert.ToInt32(txt_percent.Text) < 100)
                {
                    boolCheckUpdateStatus = constructionItemBus.updateContstructionItemStatus(contructionItemId, 1);
                }
                else if (Convert.ToInt32(txt_percent.Text) == 100)
                {
                    boolCheckUpdateStatus = constructionItemBus.updateContstructionItemStatus(contructionItemId, 2);
                    
                }

                bool boolCheckUpdateStatusCon = true;
                if (constructionItemBus.isContructionStatus(Convert.ToInt64(contructionId)) == true)
                {
                    boolCheckUpdateStatusCon = constructionBus.updateStatusContstruction(contructionId, 1);
                }
                else
                {
                    boolCheckUpdateStatusCon = constructionBus.updateStatusContstruction(contructionId, 2);
                }


                if (boolCheckUpdateStatus == true)
                {
                    bool boolUpdateProgress = updateProgress();
                    if (boolUpdateProgress == true)
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
                    messeage.error("Không Thể Cập Nhật!");
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