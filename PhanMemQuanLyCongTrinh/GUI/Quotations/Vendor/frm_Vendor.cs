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
    public partial class frm_Vendor : DevExpress.XtraEditors.XtraForm
    {
        BUS.vendorBus vendorBus = new vendorBus();

        int index;

        public frm_Vendor()
        {
            InitializeComponent();
        }
        void loadAllVenDor()
        {
            grdc_Vendor.DataSource = vendorBus.loadAllVendor();
        }
        private void frm_Vendor_Load(object sender, EventArgs e)
        {
            loadAllVenDor();
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadAllVenDor();
        }

        private void grdv_Vendor_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_Vendor.RowCount > 0)
            {
                Int64 vendorId = Convert.ToInt64(grdv_Vendor.GetRowCellValue(index, "vendor_id").ToString());
                string vendorName = grdv_Vendor.GetRowCellValue(index, "vendor_name").ToString();

                bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Nhà Cung Cấp '", vendorName);

                if (boolCheckDelete == true)
                {
                    bool boolDeleteBuildContractor = vendorBus.deleteVendor(vendorId);
                    if (boolDeleteBuildContractor == true)
                    {
                        messeage.success("Xóa Nhà Cung cấp Thành Công!");


                        loadAllVenDor();
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

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewVendor frm = new frm_NewVendor();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.Show();
        }
        private void dongform(object sender, EventArgs e)
        {
            loadAllVenDor();
            
        }
        

        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
           
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_Vendor.RowCount > 0)
            {
                frm_UpdateVendor frm = new frm_UpdateVendor();
                frm.FormClosed += new FormClosedEventHandler(dongform);
                frm.vendorId = Convert.ToInt64(grdv_Vendor.GetRowCellValue(index, "vendor_id").ToString());
                frm.Show();
            }
            else
            {
                messeage.error("Không Có Nhà Cung Cấp Để Chĩnh Sửa");
            }
           
        }
    }
}