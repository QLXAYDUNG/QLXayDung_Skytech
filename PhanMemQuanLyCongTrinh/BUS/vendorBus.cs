using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    
    class vendorBus
    {
        DAO.vendorDao vendorDao = new DAO.vendorDao();

        public object loadAllVendor()
        {
            return vendorDao.loadAllVendor();
        }
        public bool deleteVendor(Int64 VendorId)
        {
            return vendorDao.deleteVendor(VendorId);
        }
        public bool insertVendor(DTO.ST_vendor vendor)
        {
            return vendorDao.insertVendor(vendor);
        }
        public object loadVendor(Int64 vendorId)
        {
            return vendorDao.loadVendor(vendorId);
        }
        public bool updateVendor(DTO.ST_vendor vendor)
        {
            return vendorDao.updateVendor(vendor);
        }
    }
}
