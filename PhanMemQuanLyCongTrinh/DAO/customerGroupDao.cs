using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class customerGroupDao
    {
        DataClasses1DataContext db = new DTO.DataClasses1DataContext();

        public object getAllCustomerGroup()
        {
            db.Dispose();
            db = new DTO.DataClasses1DataContext();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
            return db.ST_customer_groups.ToList();
        }
        public object getCustomerGroup(Int64 idCustomerGroup)
        {
            db.Dispose();
            db = new DTO.DataClasses1DataContext();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
            return db.ST_customer_groups.Where(p => p.customer_group_id == idCustomerGroup).First();
        }
        public bool insertCustomerGroup(DTO.ST_customer_group customerGroup)
        {
            try
            {
                db.ST_customer_groups.InsertOnSubmit(customerGroup);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            db.ST_customer_groups.InsertOnSubmit(customerGroup);
            db.SubmitChanges();
        }


        public bool updateCustomerGroup(DTO.ST_customer_group customerGroup)
        {
            try
            {
                var updateCustomerGroup = db.ST_customer_groups.Where(p => p.customer_group_id.Equals(customerGroup.customer_group_id)).SingleOrDefault();
                updateCustomerGroup.customer_group_name = customerGroup.customer_group_name;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteCustomer(Int64 id)
        {
            try
            {
                var delete = db.ST_customers.Where(p => p.customer_id.Equals(id)).SingleOrDefault();

                db.ST_customers.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteCustomerGroup(Int64 idCustomerGroup)
        {
            var delete = db.ST_customer_groups.Where(p => p.customer_group_id.Equals(idCustomerGroup)).SingleOrDefault();

            db.ST_customer_groups.DeleteOnSubmit(delete);
            db.SubmitChanges();
            return true;
        }
    }
}
