using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class enterCouponBus
    {
        DAO.enterCouponDao enterCouponDao = new DAO.enterCouponDao();
        public object getAllEnterCoupon()
        {
            return enterCouponDao.getAllEnterCoupon();
        }
        public object getEnterCouponWithDayStar(DateTime dateStart)
        {
            return enterCouponDao.getEnterCouponWithDayStar(dateStart);
        }
        public object getEnterCouponWithDayStarDayEnd(DateTime dateStart, DateTime dateEnd)
        {
            return enterCouponDao.getEnterCouponWithDayStarDayEnd(dateStart, dateEnd);
        }
    }
}
