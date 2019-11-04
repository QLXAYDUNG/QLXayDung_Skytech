using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class suppliesDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public IEnumerable<object> getAllSupplies( )
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                //var datasource = from t1 in db.ST_customers
                //               join t2 in db.ST_customer_groups
                //               on t1.customer_group_id equals t2.customer_group_id
                //               select new
                //               {
                //                   t1.customer_id,
                //                   t1.customer_id_custom,
                //                   t1.customer_name,
                //                   t1.custome_phone,
                //                   t1.customer_address,
                //                   t1.customer_email,
                //                   t1.customer_liabilities,
                //                   t2.customer_group_name
                //               }
                //                   ;
                var datasource = from sup in db.ST_supplies
                                 join u in db.ST_units on sup.unit_id equals u.unit_id
                                 join v in db.ST_vendors on sup.vendor_id equals v.vendor_id
                                 select new {
                                    
                                 };

                return datasource;
            }
            catch ( Exception )
            {
                return null;
            }
        }
    }
}
