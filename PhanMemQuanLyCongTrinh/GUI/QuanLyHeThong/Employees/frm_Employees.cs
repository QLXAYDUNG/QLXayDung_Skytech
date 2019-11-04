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
    public partial class frm_Employees : DevExpress.XtraEditors.XtraForm
    {
        userBus _user = new userBus();
        deparmentBus _dep = new deparmentBus();

        public int index;
        public int index_user;
        public Int64 user_id = 0;

        public Int64 user_id_delete = 0;

        public frm_Employees( )
        {
            InitializeComponent( );
        }

        

        #region Load
        private void LoadDepartment()
        {
            var datasource = _dep.listAll( );
            if (datasource == null)
            {
                messeage.error("Không thể load dữ liệu");
            }
            else
            {
                grdc_Department.DataSource = datasource;
            }
                       
        }

        private void LoadEmployee()
        {
            var datasource = _user.getAll();
            if ( datasource != null)
            {
                grdc_Employee.DataSource = datasource;
            }
            
        }

        private void dongformGroup(object sender, EventArgs e)
        {
            LoadDepartment( );
        }

        private void dongformEmployee(object sender, EventArgs e)
        {
            LoadEmployee( );
        }

        private void frm_Employees_Load(object sender, EventArgs e)
        {
            LoadDepartment( );
            LoadEmployee();
        }

        private void loadDepartmentWithGroup(Int64 id)
        {
            grdc_Employee.DataSource = _user.getAllUserByDepartment(id);
        }


        #endregion End Load

        
        #region Event
        private void btn_AddNewDepartment(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           frm_Newdepartment frm = new frm_Newdepartment();
           frm.FormClosed += new FormClosedEventHandler(dongformGroup);
           frm.Show( );
        }

        private void btn_EditDepartment(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( grdv_Department.RowCount > 0 )
            {
                Int64 id = Convert.ToInt64(grdv_Department.GetRowCellValue(index, "department_id").ToString( ));


                frm_EditDeparment frm = new frm_EditDeparment( );
                frm.FormClosed += new FormClosedEventHandler(dongformGroup);

                frm.id = id;
                frm.Show();
            }

            
        }

        private void btn_DeleteDepartmnent(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_Department.RowCount > 0)
            {
                Int64 id = Convert.ToInt64(grdv_Department.GetRowCellValue(index, "department_id").ToString( ));

                MessageBox.Show(id.ToString());
            }
            
            
        }

       
        #endregion End event

        private void grdv_Department_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;

            Int64 departmentGroupId = Int64.Parse(grdv_Department.GetRowCellValue(index, "department_id").ToString( ));

            loadDepartmentWithGroup(departmentGroupId);
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_RegisterUser f = new frm_RegisterUser();
            f.FormClosed += new FormClosedEventHandler(dongformEmployee);

            f.ShowDialog();
        }


        private void grdv_Employee_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index_user = e.FocusedRowHandle;
        }

        // Chinh Sua nhan vien
        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {          
            frm_NewCustomer frm = new frm_NewCustomer( );
            frm.FormClosed += new FormClosedEventHandler(dongformEmployee);
            user_id = Convert.ToInt64(grdv_Employee.GetRowCellValue(index_user, "employee_id").ToString( ));
   
            if ( user_id != 0 )
            {
                frm_UserInfo f = new frm_UserInfo( );
                f.user_id = user_id;
                f.ShowDialog( );
            }
            else
            {
                messeage.error("Không thể chỉnh sửa !");
            }

            
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        // Xoa Nhan vien
        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( grdv_Employee.RowCount > 0)
            {
                user_id_delete = Convert.ToInt64(grdv_Employee.GetRowCellValue(index_user, "employee_id").ToString( ));

                if ( user_id_delete == 0 )
                {
                    messeage.error("Bạn không thể xóa được!");
                }
                else
                {
                    var employeeUserName = grdv_Employee.GetRowCellValue(index_user, "employee_username").ToString( );

                    // kiem tra quyen admin thi khong duoc xoa - dang lam thu nghiem, cap nhat sau
                    if ( employeeUserName == "admin" || user_id_delete == frm_Main.Vitual_id )
                    {
                        messeage.error("Bạn không thể xóa !");
                    }
                    else
                    {
                        bool bMess = messeage.info("Bạn Có Muốn Xóa Khách Hàng ", employeeUserName + " này không !");

                        if ( bMess )
                        {
                            bool boolDeleteCustomer = _user.deleteUser(user_id_delete);
                            if ( boolDeleteCustomer == true )
                            {
                                messeage.success("Xóa Khách hàng Thành Công!");

                                // reset user id
                                user_id_delete = 0;
                                LoadEmployee( );
                            }
                            else
                            {
                                messeage.error("Không thể xóa khách hàng này!");
                            }
                        }
                    }
                }
            }
                                     
        }

        private void btn_DeleteDepartmnet_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        
    }
}