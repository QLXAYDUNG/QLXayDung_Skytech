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
using System.Threading;
using DevExpress.XtraEditors.Controls;
using System.Globalization;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_Supplies : DevExpress.XtraEditors.XtraForm
    {
        
        public frm_Supplies( )
        {
            InitializeComponent( );
        }

        public int index_group;
        public int index;

        group_suppliesBus _group = new group_suppliesBus();
        supliesBus _sup = new supliesBus();
        

        private void frm_Supplies_Load(object sender, EventArgs e)
        {
            LoadGroupSupplies( );

            LoadSupplies();
        }

        #region Load
        private void LoadGroupSupplies()
        {
            var datasource = _group.getAllGroup( );
            if ( datasource == null )
            {
                messeage.error("Không thể load dữ liệu");
            }
            else
            {
                grdc_group_supplies.DataSource = datasource;
            }
        }

        private void LoadSupplies()
        {
            var datasource = _sup.getAllSuplies();
            if ( datasource == null )
            {
                messeage.error("Không thể load dữ liệu");
            }
            else
            {
                grdc_Supplies.DataSource = datasource;
            }
        }

        private void dongformSupplies(object sender, EventArgs e)
        {
            LoadSupplies();
        }

        private void dongformGroup(object sender, EventArgs e)
        {
            LoadGroupSupplies( );
        }


        private void loadSuppliesWithGroup(Int64 id)
        {
            grdc_Supplies.DataSource = _sup.getAllSupliesInGroup(id);
        }
        #endregion Endload


        #region Event
        private void btn_AddGroup_supplies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddNewGroupSupplies f = new frm_AddNewGroupSupplies();
            f.FormClosed += new FormClosedEventHandler(dongformGroup);

            f.ShowDialog();
        }

        

        // xoa danh muc
        private void btn_DeleteGroup_supplies_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( grdv_group_supplies.RowCount > 0 )
            {
                Int64 id = Convert.ToInt64(grdv_group_supplies.GetRowCellValue(index_group, "group_supplies_id").ToString( ));
                var customerGroupName = grdv_group_supplies.GetRowCellValue(index_group, "group_supplies_name").ToString( );

                bool boolCheckDeleteGroup = messeage.info("Bạn Có Muốn Xóa Nhóm Vật Tư '", customerGroupName);

                if ( boolCheckDeleteGroup == true )
                {
                    // chuyen tat ca san pham co id dang xoa ve mac dinh
                    if ( id == 1)
                    {
                        messeage.info("Bạn không thể xóa Nhóm này!", "");
                    }
                    else
                    {
                        if ( _group.changeIdParent(id) )
                        {
                            bool boolDeleteCustomerGroup = _group.deleteGroupSupplie(id);

                            if ( boolDeleteCustomerGroup == true )
                            {

                                messeage.success("Xóa Nhóm Khách hàng Thành Công!");
                                LoadGroupSupplies( );

                            }
                            else
                            {
                                messeage.error("Xóa Nhóm Khách hàng Không Thành Công!");

                            }
                        }
                        else
                        {

                        }
                    }
                    }
                    


            }
            else
            {
                messeage.error("Không có Nhóm  Khách Hàng Để Xóa!!!");

            }
        }


        private void btn_EditGroup_supplies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( grdv_group_supplies.RowCount > 0 )
            {
                Int64 id = Convert.ToInt64(grdv_group_supplies.GetRowCellValue(index_group, "group_supplies_id").ToString( ));


                frm_UpdateGroupSupplies frm = new frm_UpdateGroupSupplies( );

                frm.id_group = id;
                frm.FormClosed += new FormClosedEventHandler(dongformGroup);

                //frm.id = id;
                frm.Show( );
            }
        }

        private void grdv_group_supplies_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index_group = e.FocusedRowHandle;

            Int64 GroupId = Int64.Parse(grdv_group_supplies.GetRowCellValue(index_group, "group_supplies_id").ToString( ));

            if ( GroupId != null)
            {
                loadSuppliesWithGroup(GroupId);
            }
            
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( grdv_Supplies.RowCount > 0 )
            {
                Int64 id = Convert.ToInt64(grdv_Supplies.GetRowCellValue(index, "supplies_id").ToString( ));
                

                if ( id == 0 )
                {
                    messeage.error("Bạn không thể xóa được!");
                }
                else
                {
                    var customerGroupName = grdv_Supplies.GetRowCellValue(index, "supplies_name").ToString( );
                    // kiem tra quyen admin thi khong duoc xoa - dang lam thu nghiem, cap nhat sau
                    if ( id == 1 )
                    {
                        messeage.error("Bạn không thể xóa !");
                    }
                    else
                    {
                        bool bMess = messeage.info("Bạn Có Muốn Xóa Mặt Hàng ", customerGroupName + " Này không !");

                        if ( bMess )
                        {
                            bool boolDeleteCustomer = _sup.deleteSuplies(id);
                            if ( boolDeleteCustomer == true )
                            {
                                messeage.success("Xóa Mặt Hàng Thành Công!");
                                LoadSupplies( );
                            }
                            else
                            {
                                messeage.error("Không thể xóa Mặt Hàng Này!");
                            }
                        }
                    }
                }
            }
        }

        // them moi vat tu
        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddNewSupplies frm = new frm_AddNewSupplies( );
            frm.FormClosed += new FormClosedEventHandler(dongformSupplies);
            frm.ShowDialog( );
        }


        // Chinh Sua Vat Tu
        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( grdv_Supplies.RowCount > 0 )
            {
                Int64 supplies_Id = Convert.ToInt64(grdv_Supplies.GetRowCellValue(index, "supplies_id").ToString( ));
                frm_UpdateSuppliescs frm = new frm_UpdateSuppliescs( );
                frm.FormClosed += new FormClosedEventHandler(dongformSupplies);
                frm.id_Suppliesc = supplies_Id;
                frm.Show( );
            }
            else
            {
                messeage.error("Không Có Khách Hàng Để Sửa");
            }
        }

        private void grdv_Supplies_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
        }

        #endregion EndEvent      

        

        

     
    }
}