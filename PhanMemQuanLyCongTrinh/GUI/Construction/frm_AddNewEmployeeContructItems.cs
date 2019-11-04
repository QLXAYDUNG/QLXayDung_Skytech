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
    public partial class frm_AddNewEmployeeContructItems : DevExpress.XtraEditors.XtraForm
    {
        public frm_AddNewEmployeeContructItems( )
        {
            InitializeComponent( );
        }

        userBus _user = new userBus();
        detail_employee_constructionBus _detail = new detail_employee_constructionBus();

        public IEnumerable<Object> source = null;
        public Int64 idContructItemms = 0;

        private void frm_AddNewEmployeeContructItems_Load(object sender, EventArgs e)
        {
            loadGridView();
            StyleDevxpressGridControl.styleGridControl(grdc_em, grdv_em);
            grdv_em.OptionsSelection.MultiSelect = true;
            grdv_em.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
        }

        #region Load
        private void loadGridView()
        {
            if (source != null)
            {
                var dataEmployeeChecked = source;
                grdc_em.DataSource = dataEmployeeChecked;
            } 
        }
        #endregion EndLoad

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = grdv_em.GetSelectedRows( );

            bool status = false;

            if ( selectedRowHandles.Length > 0)
            {
                for ( int i = 0; i < selectedRowHandles.Length; i++ )
                {
                    object row = grdv_em.GetRow(i); //get a row, do something with it

                    var propertyName = row.GetType( ).GetProperty("employee_id").GetValue(row, null);
                    var pro = (propertyName == null) ? "" : propertyName.ToString( );


                    if ( idContructItemms != 0 )
                    {
                        // them moi
                        ST_detail_employee_construction em = new ST_detail_employee_construction( );
                        em.employee_id = Int64.Parse(pro.ToString( ));
                        em.construction_item_id = idContructItemms;

                        if ( _detail.insert(em) )
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
                    messeage.success("Thêm Mới Thành Công !");
                    this.Close( );
                }
                else
                {
                    messeage.error("Thêm Mới Thất Bại !");
                    this.Close( );
                }
            }
            else
            {
                messeage.error("Bạn chưa chọn dữ liệu !");
            }
            
        }

 

        #region Event

        #endregion EndEvent
    }
}