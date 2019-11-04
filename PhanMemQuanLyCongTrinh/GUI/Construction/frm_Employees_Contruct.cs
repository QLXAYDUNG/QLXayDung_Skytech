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
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_Employees_Contruct : DevExpress.XtraEditors.XtraForm
    {
        public frm_Employees_Contruct( )
        {
            InitializeComponent( );
        }

        Int64 id_contruct = 0;
        Int64 id_contruct_items = 0;
        constructionBus _contruct = new constructionBus( );
        constructionItemBus _contructItem = new constructionItemBus();
        detail_employee_constructionBus _detai = new detail_employee_constructionBus();

        #region Load

        private void frm_Employees_Contruct_Load(object sender, EventArgs e)
        {
            loadAllContruct( );
            loadAllEmployee();

            StyleDevxpressGridControl.styleGridControl(grdc_em, grdv_em);
            grdv_em.OptionsSelection.MultiSelect = true;
            grdv_em.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
        }

        // load contruct
        private void loadAllContruct( )
        {
            var datasour = _contruct.getAllContruction( );
            lue_Contruct.Properties.DataSource  = datasour;

            lue_Contruct.Properties.ValueMember = "construction_id";
            lue_Contruct.Properties.DisplayMember = "construction_name";
        }

        // load contruct Item
        private void loadConstruction_items(Int64 idContruct)
        {
            var datasour = _contructItem.getContructionItemForSearchWithGroup(idContruct);
            if ( datasour  != null)
            {
                lue_Contruct_items.Properties.DataSource = datasour;

                lue_Contruct_items.Properties.ValueMember = "construction_item_id";
                lue_Contruct_items.Properties.DisplayMember = "construction_item_name";
            }
            
        }

        // load Employee for Contruct Item
        private void loadEmployees(Int64 idContructItem)
        {
            var datasource = _detai.getAll_ContrucItems(idContructItem);
            if ( datasource != null)
            {
                grdc_em.DataSource = datasource;
            }
            
        }

        private void loadAllEmployee()
        {
            var datasource = _detai.getAll();
            grdc_em.DataSource = datasource;
        }

        // load lai form
        private void CloseForm(object sender, EventArgs e)
        {
            loadAllEmployee();
        }

        // load form idContruct
        private void CloseFormContructItem(object sender, EventArgs e)
        {
            loadEmployees(id_contruct_items);
        }

        private void dongformCon(object sender, EventArgs e)
        {
            loadAllContruct( );

        }

        private void dongformConItem(object sender, EventArgs e)
        {
            loadConstruction_items(id_contruct_items);

        }
        #endregion EndLoad

        #region Event

        private void btn_AddNewSuppelies_Click(object sender, EventArgs e)
        {
            frm_NewConstructions frm = new frm_NewConstructions( );
            frm.FormClosed += new FormClosedEventHandler(dongformCon);

            frm.ShowDialog( );
        }

        // Hang muc
        private void lue_Contruct_items_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            id_contruct_items = Convert.ToInt64(edit.EditValue);

            if ( id_contruct_items != 0 )
            {
                bool employeeContruct = _detai.checkEmployeesContructItem(id_contruct_items);

                if ( employeeContruct)
                {
                    loadEmployees(id_contruct);
                }
                else
                {
                    messeage.error("Bạn chưa có hạng mục của công trình, hãy thêm hạng mục !");
                    grdc_em.DataSource = null;
                }
            }
            else
            {
                messeage.error("Có lỗi, hãy kiểm tra lại !");
            }
        }


        // Cong Trinh
        private void lue_Contruct_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            var ID = Convert.ToInt64(edit.EditValue);

            id_contruct = Convert.ToInt64(edit.EditValue);


            if ( id_contruct != 0 )
            {
                bool bcheckContructItems = _contructItem.isContructionIdtemGroup(id_contruct);

                if ( bcheckContructItems )
                {
                    loadConstruction_items(id_contruct);
                }
                else
                {
                    messeage.error("Bạn chưa có hạng mục của công trình, hãy thêm hạng mục !");
                }
            }
            else
            {
                messeage.error("Có lỗi, hãy kiểm tra lại !");
            }

        }


        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddNewEmployeeContructItems frm = new frm_AddNewEmployeeContructItems();
            if ( id_contruct_items == 0)
            {
                frm.source = null;
            }
            else
            {
                var employeeNotCheked = _detai.getAllEmployeeNotChecked(id_contruct_items);
                frm.idContructItemms = id_contruct_items;
                frm.source = employeeNotCheked;
            }
            frm.FormClosed += new FormClosedEventHandler(CloseFormContructItem);
            frm.ShowDialog();
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadAllEmployee( );
        }
        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( id_contruct_items == 0 )
            {
                messeage.error("Bạn Chưa Chọn Hạng Mục, Công Trình !");
                return;
            }
            Int32[] selectedRowHandles = grdv_em.GetSelectedRows( );

            if ( selectedRowHandles.Length > 0 )
            {
                bool status = false;
                bool st = messeage.info("Bạn Có Muốn Xóa !", "");
                if ( st )
                {
                    for ( int i = 0; i < selectedRowHandles.Length; i++ )
                    {
                        object row = grdv_em.GetRow(selectedRowHandles[i]); //get a row, do something with it

                        var propertyName = row.GetType( ).GetProperty("employee_id").GetValue(row, null);
                        var pro = (propertyName == null) ? "" : propertyName.ToString( );
                        if ( _detai.deleteEmployee(Int64.Parse(pro.ToString( ))) )
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                }

                if ( status )
                {
                    messeage.success("Xóa Thành Công !");

                    loadEmployees(id_contruct_items);
                }
                else
                {
                    messeage.error("Xóa Thất Bại !");
                }


            }
            else
            {
                messeage.error("Xóa Thất Bại !");
            }





        }
        #endregion EndEvent

        private void btn_AddNew_Construction_items_Click(object sender, EventArgs e)
        {            
            frm_NewConstructionItem frm = new frm_NewConstructionItem( );
            frm.FormClosed += new FormClosedEventHandler(dongformConItem);

            frm.ShowDialog( );

        }

        
        

        

        

        

        

        


        

        
        

        
    }
}