using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_StorehouseDetail : DevExpress.XtraEditors.XtraForm
    {
        BUS.storehouseBus storehouseBus = new BUS.storehouseBus();
        BUS.storehouseDetailBus storehouseDetailBus = new BUS.storehouseDetailBus();

        int index;
        public frm_StorehouseDetail()
        {
            InitializeComponent();
        }

        private void loadStorehouse()
        {
            grdc_Storehouse.DataSource = storehouseBus.getAllStorehouse();
        }

        private void frm_StorehouseDetail_Load(object sender, EventArgs e)
        {
            loadStorehouse();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void loadStorehouseDetail(Int64 StorehouseId)
        {
            grdc_StorehouseDetail.DataSource = storehouseDetailBus.getStorehouseDetailWithGroup(StorehouseId);
        }

        private void grdv_Storehouse_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;

            if (index >= 0)
            {
                Int64 StorehouseId =Convert.ToInt64(grdv_Storehouse.GetRowCellValue(index, "storehouse_id").ToString());
                loadStorehouseDetail(StorehouseId);
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdc_StorehouseDetail.DataSource = storehouseDetailBus.getAllStorehouseDetail();
        }
    }
}