using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class customerGroupBus
    {
        DAO.customerGroupDao customerGroupDao = new DAO.customerGroupDao();
        public object getAllCustomerGroup()
        {
            return customerGroupDao.getAllCustomerGroup();
        }
        public object getCustomerGroup(Int64 idCustomerGroup)
        {
            return customerGroupDao.getCustomerGroup(idCustomerGroup);
        }
        public bool deleteCustomerGroup(Int64 idCustomerGroup)
        {
            return customerGroupDao.deleteCustomerGroup(idCustomerGroup);
        }
        public bool updateCustomerGroup(DTO.ST_customer_group customerGroup)
        {
            return customerGroupDao.updateCustomerGroup(customerGroup);
        }
        public bool insertCustomerGroup(DTO.ST_customer_group customerGroup)
        {
            return customerGroupDao.insertCustomerGroup(customerGroup);
        }
    }
}
