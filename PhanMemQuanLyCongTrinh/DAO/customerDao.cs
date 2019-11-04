using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class customerDao
    {
        DataClasses1DataContext db = new DTO.DataClasses1DataContext();

        public object getAllCustomer()
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var customer = from t1 in db.ST_customers
                               join t2 in db.ST_customer_groups
                               on t1.customer_group_id equals t2.customer_group_id
                               select new {
                                   t1.customer_id,
                                   t1.customer_id_custom,
                                   t1.customer_name,
                                   t1.custome_phone,
                                   t1.customer_address,
                                   t1.customer_email,
                                   t1.customer_liabilities,
                                   t2.customer_group_name
                               }
                                   ;
                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object getCustomer(Int64 id)
        {
            db.Dispose();
            db = new DataClasses1DataContext();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
            var customer = db.ST_customers.Where(p => p.customer_id == id).First();
            return customer;
        }

        public object getCustomerWithGroup(Int64 customerGroupId)
        {
            try
            {
                db.Dispose();
                db = new DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var customer = from t1 in db.ST_customers
                               join t2 in db.ST_customer_groups
                               on t1.customer_group_id equals t2.customer_group_id
                               where t1.customer_group_id == customerGroupId
                               select new
                               {
                                   t1.customer_id,
                                   t1.customer_id_custom,
                                   t1.customer_name,
                                   t1.custome_bank_account_number,
                                   t1.custome_phone,
                                   t1.customer_address,
                                   t1.customer_email,
                                   t1.customer_liabilities,
                                   t1.customer_image,
                                   t2.customer_group_name,
                                   t2.customer_group_id
                               }
                                   ;
                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool insertCustomer(DTO.ST_customer customer)
        {
            try
            {
                db.ST_customers.InsertOnSubmit(customer);
                db.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        public bool updateCustomer(DTO.ST_customer customer)
        {
            try
            {
                var updateCustomer = db.ST_customers.Where(p => p.customer_id.Equals(customer.customer_id)).SingleOrDefault();

                updateCustomer.customer_name = customer.customer_name;
                updateCustomer.custome_bank_account_number = customer.custome_bank_account_number;
                updateCustomer.custome_date_of_birth = customer.custome_date_of_birth;
                updateCustomer.custome_gender = customer.custome_gender;
                updateCustomer.custome_phone = customer.custome_phone;
                updateCustomer.custome_tax_code = customer.custome_tax_code;
                updateCustomer.customer_address = customer.customer_address;
                updateCustomer.customer_created_date = customer.customer_created_date;
                updateCustomer.customer_description = customer.customer_description;
                updateCustomer.customer_email = customer.customer_email;
                updateCustomer.customer_liabilities = customer.customer_liabilities;
                updateCustomer.employee_created = customer.employee_created;
                updateCustomer.customer_group_id = customer.customer_group_id;
                updateCustomer.customer_image = customer.customer_image;
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

        public bool changeIdParent(Int64 groupId)
        {
            try
            {
                var datasource = from u in db.ST_customers
                                 where u.customer_group_id == groupId
                                 select u;

                if (datasource != null)
                {
                    foreach (var item in datasource)
                    {
                        item.customer_group_id = 1;
                    }
                    db.SubmitChanges();
                    return true;
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
