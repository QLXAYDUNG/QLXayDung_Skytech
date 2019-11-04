using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class supliesDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public IEnumerable<object> getAllSuplies_LoadSerach( )
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var suplies = from sup in db.ST_supplies
                              join ven in db.ST_vendors on sup.vendor_id equals ven.vendor_id
                              join unit in db.ST_units on sup.unit_id equals unit.unit_id
                              join group_sup in db.ST_group_supplies on sup.group_supplies_id equals group_sup.group_supplies_id

                              select new
                              {
                                  sup.supplies_id,
                                  sup.supplies_id_custom,
                                  sup.supplies_name,
                                  unit.unit_name,
                                  ven.vendor_name,
                                  group_sup.group_supplies_name,
                                  sup.supplies_entry_price,
                                  sup.supplies_commercial_price,
                                  
                              }
                                   ;

                return suplies;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public IEnumerable<object> getAllSuplies( )
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var suplies = from sup in db.ST_supplies
                              join ven in db.ST_vendors on sup.vendor_id equals ven.vendor_id
                              join unit in db.ST_units on sup.unit_id equals unit.unit_id
                              join group_sup in db.ST_group_supplies on sup.group_supplies_id equals group_sup.group_supplies_id

                              select new
                              {
                                  sup.supplies_id,
                                  sup.supplies_id_custom,
                                  sup.supplies_name,
                                  group_sup.group_supplies_name,
                                  unit.unit_name,
                                  ven.vendor_name,
                                  sup.supplies_entry_price,
                                  sup.supplies_commercial_price,
                                  sup.supplies_wholesale_price,
                                  sup.supplies_description
                              }
                                   ;

                return suplies;
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

        public bool insertSuplies(DTO.ST_supply supply)
        {
            try
            {
                db.ST_supplies.InsertOnSubmit(supply);
                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }

        }

        public object getSuplies(Int64 id)
        {
            db.Dispose( );
            db = new DataClasses1DataContext( );
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

            try{
                var suplies = db.ST_supplies.Where(p => p.supplies_id == id).First( );
                return suplies;
            }
            catch(Exception)
            {
                return null;
            }
            
        }

        public bool updateSuplies(DTO.ST_supply supp)
        {
            try
            {
                var updateSup = db.ST_supplies.Where(p => p.supplies_id.Equals(supp.supplies_id)).SingleOrDefault( );

                updateSup.supplies_name = supp.supplies_name;
                updateSup.group_supplies_id = supp.group_supplies_id;
                updateSup.vendor_id = supp.vendor_id;
                updateSup.unit_id = supp.unit_id;

                updateSup.supplies_commercial_price = supp.supplies_commercial_price;
                updateSup.supplies_entry_price = supp.supplies_entry_price;
                updateSup.supplies_wholesale_price = supp.supplies_wholesale_price;
                updateSup.supplies_survive_the_norm = supp.supplies_survive_the_norm;
                updateSup.supplies_description = supp.supplies_description;
                updateSup.supplies_image = supp.supplies_image;
                

                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteSuplies(Int64 id)
        {
            try
            {
                var delete = db.ST_supplies.Where(p => p.supplies_id.Equals(id)).SingleOrDefault( );

                db.ST_supplies.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Object> getAllSupliesInGroup(Int64 id)
        {  
            try
            {
                db.Dispose( );
                db = new DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var suplies = from b in db.ST_supplies
                               where b.group_supplies_id == id
                               select b;

                return suplies;
            }
            catch ( Exception )
            {
                return null;
            }
            
        }


    }
}
