using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
using PhanMemQuanLyCongTrinh.DAO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class EnterCouponSuppliesBus
    {
        EnterCouponSuppliesDao _enter = new EnterCouponSuppliesDao();

        public IEnumerable<object> getAllEnterCouponSupplies( )
        {
            return _enter.getAllEnterCouponSupplies();
        }

        public object getEnterCouponSupplies(Int64 id)
        {
            return _enter.getEnterCouponSupplies(id);
        }

        public bool deleteEnterCouponSupplies(Int64 id)
        {
            return _enter.deleteEnterCouponSupplies(id);
        }

        public bool insertEnterCouponSupplies(DTO.ST_enter_coupon_supply enter)
        {
            return _enter.insertEnterCouponSupplies(enter);
        }

        public bool updateEnterCouponSupplies(DTO.ST_enter_coupon_supply enter)
        {
            return _enter.updateEnterCouponSupplies(enter);
        }
    }
}
