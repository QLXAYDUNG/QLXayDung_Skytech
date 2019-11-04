using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class storehouseBus
    {
        DAO.storehouseDao storehouseDao = new DAO.storehouseDao();
        public object getAllStorehouse()
        {
            return storehouseDao.getAllStorehouse();
        }
        public bool deleteStorehouse(Int64 storehouseId)
        {
            return storehouseDao.deleteStorehouse(storehouseId);
        }
        public bool insertStorehouse(DTO.ST_storehouse storehouse)
        {
            return storehouseDao.insertStorehouse(storehouse);
        }
        public bool updateStorehouse(DTO.ST_storehouse storehouse)
        {
            return storehouseDao.updateStorehouse(storehouse); 
        }
        public object getStorehouse(Int64 storehouseId)
        {
            return storehouseDao.getStorehouse(storehouseId);
        }
    }
}
