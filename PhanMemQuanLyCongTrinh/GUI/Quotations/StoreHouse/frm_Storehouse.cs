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
    public partial class frm_Storehouse : DevExpress.XtraEditors.XtraForm
    {
        BUS.storehouseBus storehouseBus = new BUS.storehouseBus();
        int index;
        public frm_Storehouse()
        {
            InitializeComponent();
        }

        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void loadAllStorehouse()
        {
            grdc_Storehouse.DataSource = storehouseBus.getAllStorehouse();
        }

        private void frm_Storehouse_Load(object sender, EventArgs e)
        {
            loadAllStorehouse();
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadAllStorehouse();
        }

        private void grdv_Storehouse_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
        }
        #region delete Storehouse
        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_Storehouse.RowCount > 0)
            {
                Int64 storehouseId = Convert.ToInt64(grdv_Storehouse.GetRowCellValue(index, "storehouse_id").ToString());
                string storehouseName = grdv_Storehouse.GetRowCellValue(index, "storehouse_name").ToString();

                bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Nhà Cung Cấp '", storehouseName);

                if (boolCheckDelete == true)
                {
                    bool boolDeleteStorehouse = storehouseBus.deleteStorehouse(storehouseId);
                    if (boolDeleteStorehouse == true)
                    {
                        messeage.success("Xóa Nhà Kho Thành Công!");


                        loadAllStorehouse();
                    }
                    else
                    {
                        messeage.error("Xóa Nhà Cung Cấp Không Thất Bại!");

                    }
                }

            }
            else
            {
                messeage.error("Không Có gì Để Xóa!!");
            }
        }
        #endregion

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewStorehouse frm = new frm_NewStorehouse();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.Show();
        }
        private void dongform(object sender, EventArgs e)
        {
            loadAllStorehouse();

        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_Storehouse.RowCount > 0)
            {
                frm_UpdateStorehouse frm = new frm_UpdateStorehouse();
                frm.FormClosed += new FormClosedEventHandler(dongform);
                frm.storehouseId = Convert.ToInt64(grdv_Storehouse.GetRowCellValue(index, "storehouse_id").ToString());
                frm.Show();
            }
            else
            {
                messeage.error("Không Có Gì Để Chỉnh Sửa!");
            }
        }
    }
}