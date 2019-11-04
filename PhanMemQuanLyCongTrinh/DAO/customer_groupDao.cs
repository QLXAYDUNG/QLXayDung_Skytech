using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class customer_groupDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext( );

        public IEnumerable<Object> getAllCustomer_Group( )
        {
            try
            {
                var data = from d in db.ST_customer_groups
                           select d;

                return data;
            }
            catch ( Exception ex )
            {
                return null;
            }
        }

        public Object getCustomer_Group(Int64 id)
        {
            try{
                var depament = from b in db.ST_customer_groups
                               where b.customer_group_id == id
                               select b;

                return depament;
            }
            catch(Exception)
            {
                return null;
            }
            
        }
    }
}
