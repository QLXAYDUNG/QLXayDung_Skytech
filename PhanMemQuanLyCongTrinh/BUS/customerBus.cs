using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class customerBus
    {
        DAO.customerDao customerDao = new DAO.customerDao();
        public object getAllCustomer()
        {
            return customerDao.getAllCustomer();
        }
        public object getCustomer(Int64 id)
        {
            return customerDao.getCustomer(id);
        }
        public bool insertCustomer(DTO.ST_customer customer)
        {
            return customerDao.insertCustomer(customer);
        }
        public bool updateCustomer(DTO.ST_customer customer)
        {
            return customerDao.updateCustomer(customer);
        }
        public bool deleteCustomer(Int64 id)
        {
            return customerDao.deleteCustomer(id);
        }
        public object getCustomerWithGroup(Int64 customerGroupId)
        {
            return customerDao.getCustomerWithGroup(customerGroupId);
        }
        public bool changeIdParent(Int64 groupId)
        {
            return customerDao.changeIdParent(groupId);
        }
    }
}
