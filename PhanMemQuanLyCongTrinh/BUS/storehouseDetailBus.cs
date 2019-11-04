using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class storehouseDetailBus
    {
        DAO.storehouseDetailDao store = new DAO.storehouseDetailDao();



        // khi xóa kho hàng thì chuyển tất cả hàng hóa vào kho mặc định
        public bool changeIdParent(Int64 groupId)
        {
            return store.changeIdParent(groupId);
        }

        public object getAllStorehouseDetail()
        {
            return store.getAllStorehouseDetail();
        }
        public object getStorehouseDetailWithGroup(Int64 storehouseId)
        {
            return store.getStorehouseDetailWithGroup(storehouseId);
        }

        
    }
}
