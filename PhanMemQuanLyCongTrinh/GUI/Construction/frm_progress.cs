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
    public partial class frm_progress : DevExpress.XtraEditors.XtraForm
    {

        int index;

        BUS.progressBus progressBus = new BUS.progressBus();

        BUS.constructionBus constructionBus = new BUS.constructionBus();
        BUS.constructionItemBus constructionItemBus = new BUS.constructionItemBus();
        public frm_progress()
        {
            InitializeComponent();
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewProgress frm = new frm_NewProgress();
            frm.FormClosed += new FormClosedEventHandler(dongform);
          
            frm.ShowDialog();
        }

        private void dongform(object sender, EventArgs e)
        {
            loadAllProgress();

        }
        public void loadAllProgress()
        {
            grdc_progress.DataSource = progressBus.getAllProgress();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void loadContruction()
        {
            lke_Contruct.Properties.DisplayMember = "construction_name";
            lke_Contruct.Properties.ValueMember = "construction_id";
            lke_Contruct.Properties.DataSource = constructionBus.getAllContruction();
        }
        private void frm_progress_Load(object sender, EventArgs e)
        {
            loadAllProgress();
            loadContruction();
        }

        private void loadContructionItem()
        {
            lke_Contruct_items.Properties.DisplayMember = "construction_item_name";
            lke_Contruct_items.Properties.ValueMember = "construction_item_id";
            lke_Contruct_items.Properties.DataSource = constructionItemBus.getAllIdNameContructionItem(Convert.ToInt64(lke_Contruct.EditValue));

        }

        public void loadProgressWithConstruction()
        {
            grdc_progress.DataSource = progressBus.getAllProgressWithConstruction(Convert.ToInt64(lke_Contruct.EditValue));
        }
        private void lke_Contruct_EditValueChanged(object sender, EventArgs e)
        {
            loadContructionItem();
            loadProgressWithConstruction();
        }

        private void btn_AddNewSuppelies_Click(object sender, EventArgs e)
        {

            frm_NewConstructions frm = new frm_NewConstructions();
            frm.FormClosed += new FormClosedEventHandler(dongformCon);

            frm.ShowDialog();
        }

        private void dongformCon(object sender, EventArgs e)
        {
            loadContruction();

        }

        private void btn_Construction_items_Click(object sender, EventArgs e)
        {
            frm_NewConstructionItem frm = new frm_NewConstructionItem();
            frm.FormClosed += new FormClosedEventHandler(dongformConItem);

            frm.ShowDialog();
        }

        private void dongformConItem(object sender, EventArgs e)
        {
            loadContructionItem();

        }
        public void loadProgressWithConstructionItem()
        {
            grdc_progress.DataSource = progressBus.getAllProgressWithConstructionItem(Convert.ToInt64(lke_Contruct_items.EditValue));
        }
        private void lke_Contruct_items_EditValueChanged(object sender, EventArgs e)
        {
            loadProgressWithConstructionItem();
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_progress.RowCount > 0)
            {
                Int64 id = Convert.ToInt64(grdv_progress.GetRowCellValue(index, "progress_construction_item_id").ToString());


                var name = grdv_progress.GetRowCellValue(index, "construction_item_name").ToString();

                
                    bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Tiến Độ Của Hạng Mục ", name);

                    if (boolCheckDelete == true)
                    {
                        bool boolDeleteCustomer = progressBus.deleteProgress(id);
                        if (boolDeleteCustomer == true)
                        {
                            messeage.success("Xóa Khách hàng Thành Công!");

                            loadAllProgress();
                        }
                        else
                        {
                            messeage.error("Xóa Khách hàng Không Thành Công!");

                        }
                    }
               

            }
            else
            {
                messeage.error("Không có  Khách Hàng Để Xóa!!!");

            }
        }

        private void grdv_progress_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_Updateprogress frm = new frm_Updateprogress();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.progressId = Convert.ToInt64(grdv_progress.GetRowCellValue(index, "progress_construction_item_id").ToString());
            frm.ShowDialog();
        }
    }
}