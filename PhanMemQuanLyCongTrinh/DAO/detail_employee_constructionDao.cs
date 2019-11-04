using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class detail_employee_constructionDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public bool insert(ST_detail_employee_construction item)
        {
            try
            {
                db.ST_detail_employee_constructions.InsertOnSubmit(item);
                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            } 
        }

        public IEnumerable<Object> getAll( )
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var employee_constructions = 
                              from detail in db.ST_detail_employee_constructions
                              join em in db.ST_employees on detail.employee_id equals em.employee_id
                              join c in db.ST_construction_items on detail.construction_item_id equals c.construction_item_id
                              join depart in db.ST_departments on em.department_id equals depart.department_id
                              where em.employee_status == true
                              select new
                              {
                                  em.employee_id,
                                  em.employee_id_custom,
                                  em.employee_name,
                                  em.employee_address,
                                  em.employee_date_of_birth,
                                  em.department_id,
                                  em.employee_phone,
                                  depart.department_price,
                                  c.construction_item_name,
                              };

                return employee_constructions;
            }
            catch ( Exception )
            {
                return null;
            }
            finally
            {
                dlg.Close( );
            }
        }

        public IEnumerable<Object> getAll_Contruct()
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var employee_constructions =
                              from detail in db.ST_detail_employee_constructions
                              join em in db.ST_employees on detail.employee_id equals em.employee_id
                              //join c in db.ST_construction_items on detail.construction_item_id equals c.construction_item_id
                              join dep in db.ST_departments on em.department_id equals dep.department_id
                              where em.employee_status == true
                              select new
                              {
                                  em.employee_id,
                                  em.employee_id_custom,
                                  em.employee_name,
                                  em.employee_address,
                                  em.employee_date_of_birth,
                                  dep.department_name,
                                  em.employee_phone,
                                  dep.department_price,
                                  //c.construction_item_name,
                              };

                return employee_constructions;
            }
            catch ( Exception )
            {
                return null;
            }
            finally
            {
                dlg.Close( );
            }
        }
        public IEnumerable<Object> getAll_ContrucItems(Int64 idContructItem)
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var employee_constructions =
                              from detail in db.ST_detail_employee_constructions
                              join em in db.ST_employees on detail.employee_id equals em.employee_id
                              //join c in db.ST_construction_items on detail.construction_item_id equals c.construction_item_id
                              join dep in db.ST_departments on em.department_id equals dep.department_id
                              where detail.construction_item_id == idContructItem &&  em.employee_status == true
                              select new
                              {
                                  em.employee_id,
                                  em.employee_id_custom,
                                  em.employee_name,
                                  em.employee_address,
                                  em.employee_date_of_birth,
                                  dep.department_name,
                                  em.employee_phone,
                                  dep.department_price,
                                  //c.construction_item_name,
                              };

                return employee_constructions;
            }
            catch ( Exception )
            {
                return null;
            }
            finally
            {
                dlg.Close( );
            }
        }

        public IEnumerable<Object> getAllEmployeeNotChecked(Int64 id)
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
            var datasource = from emp in db.ST_employees
                                join dep in db.ST_departments on emp.department_id equals dep.department_id
                             where !(from citem in db.ST_detail_employee_constructions
                             select citem.employee_id).Contains(emp.employee_id)
                             select new {
                                emp.employee_id, emp.employee_id_custom, emp.employee_name, emp.employee_address, emp.employee_date_of_birth, emp.employee_phone, dep.department_name, dep.department_price, emp.employee_status
                             };

            return datasource;
            }
            catch(Exception)
            {
                return null;
            }   
            finally
            {
                dlg.Close( );
            }
            
        }

        public bool checkEmployeesContructItem(Int64 idContructItem)
        {
            try{
                var items = from b in db.ST_detail_employee_constructions
                            where b.construction_item_id == idContructItem
                            select b.employee_id;

                if ( items.Any( ) )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
            
        }


        public bool deleteEmployee(Int64 id)
        {
            try
            {
                var delete = db.ST_detail_employee_constructions.Where(p => p.employee_id.Equals(id)).SingleOrDefault( );

                db.ST_detail_employee_constructions.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
