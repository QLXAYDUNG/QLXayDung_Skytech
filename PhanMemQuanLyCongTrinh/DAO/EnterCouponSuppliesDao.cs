using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class EnterCouponSuppliesDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext( );

        public IEnumerable<object> getAllEnterCouponSupplies( )
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var datasource = from pm in db.ST_enter_coupon_supplies
                                 select pm;
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

        public object getEnterCouponSupplies(Int64 id)
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var unit = (from t1 in db.ST_enter_coupon_supplies
                            where t1.enter_coupon_supplies_id == id
                            select t1).First( );
                return unit;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public bool deleteEnterCouponSupplies(Int64 id)
        {
            try
            {
                var delete = db.ST_enter_coupon_supplies.Where(p => p.enter_coupon_supplies_id.Equals(id)).SingleOrDefault( );

                db.ST_enter_coupon_supplies.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insertEnterCouponSupplies(DTO.ST_enter_coupon_supply enter)
        {
            try
            {
                db.ST_enter_coupon_supplies.InsertOnSubmit(enter);
                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }

        public bool updateEnterCouponSupplies(DTO.ST_enter_coupon_supply enter)
        {
            try
            {
                var updateVendor = db.ST_enter_coupon_supplies.Where(p => p.enter_coupon_supplies_id.Equals(enter.enter_coupon_supplies_id)).SingleOrDefault( );

                //updateVendor. = unit.unit_name;

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
