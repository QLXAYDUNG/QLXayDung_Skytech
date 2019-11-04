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
    public partial class frm_Units : DevExpress.XtraEditors.XtraForm
    {

        public frm_Units( )
        {
            InitializeComponent( );
        }

        unitBus _unitBus = new unitBus( );
        int index;

        private void frm_Supplies_Load(object sender, EventArgs e)
        {
            loadGridViewUnits( );
        }

        #region Load
        private void loadGridViewUnits()
        {
            var datasource = _unitBus.getAllUnits();
            if (datasource != null)
            {
                grdc_unit.DataSource = datasource;
            }
            else
            {
                messeage.error("Không thể tải dữ liệu !");
            }
        }
        #endregion End load

        

        #region Event
        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddNewUnit frm = new frm_AddNewUnit( );
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.Show( );
        }

        private void dongform(object sender, EventArgs e)
        {
            loadGridViewUnits( );

        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( grdv_unit.RowCount > 0 )
            {
                Int64 unitId = Convert.ToInt64(grdv_unit.GetRowCellValue(index, "unit_id").ToString( ));
                string unitName = grdv_unit.GetRowCellValue(index, "unit_name").ToString( );

                bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Tên Đơn Vị Này '", unitName);

                if ( boolCheckDelete == true )
                {
                    bool boolDeleteBuildContractor = _unitBus.deleteVendor(unitId);
                    if ( boolDeleteBuildContractor == true )
                    {
                        messeage.success("Xóa Tên Đơn Vị Thành Công!");

                        loadGridViewUnits( );
                    }
                    else
                    {
                        messeage.error("Xóa Nhà Cung Cấp Không Thất Bại!");

                    }
                }

            }
            else
            {
                messeage.error("Không Có Gì Để Xóa!!");
            }
        }

        private void grdv_unit_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( grdv_unit.RowCount > 0 )
            {
                frm_Update_Unit frm = new frm_Update_Unit( );
                frm.FormClosed += new FormClosedEventHandler(dongform);
                frm.idUnit = Convert.ToInt64(grdv_unit.GetRowCellValue(index, "unit_id").ToString( ));
                frm.Show( );
            }
            else
            {
                messeage.error("Không Có Nhà Cung Cấp Để Chĩnh Sửa");
            }
        }
        #endregion EndEvent

        

        

    }
}