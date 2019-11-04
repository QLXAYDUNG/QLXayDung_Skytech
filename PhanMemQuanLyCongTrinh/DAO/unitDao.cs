using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class unitDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext( );

        public IEnumerable<object> getAllUnits( )
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var datasource = from t1 in db.ST_units
                             select t1;
                return datasource;
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

        public object getUnit(Int64 unitId)
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var unit = (from t1 in db.ST_units
                              where t1.unit_id == unitId
                              select t1).First( );
                return unit;
            }
            catch ( Exception )
            {
                return null;
            }
        }


        public bool deleteUnit(Int64 unitId)
        {
            try
            {
                var delete = db.ST_units.Where(p => p.unit_id.Equals(unitId)).SingleOrDefault( );

                db.ST_units.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insertUnit(DTO.ST_unit unit)
        {
            try
            {
                db.ST_units.InsertOnSubmit(unit);
                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }


        public bool updateUnit(DTO.ST_unit unit)
        {
            try
            {
                var updateVendor = db.ST_units.Where(p => p.unit_id.Equals(unit.unit_id)).SingleOrDefault( );

                updateVendor.unit_name = unit.unit_name;

                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }
    }
}
