using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class storehouseDao
    {

        DataClasses1DataContext db = new DataClasses1DataContext();
        public object getAllStorehouse()
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var storehouse = from t1 in db.ST_storehouses
                                 select new
                                 {
                                     t1.storehouse_id,
                                     t1.storehouse_id_custom,
                                     t1.storehouse_name,
                                     t1.storehouse_address,
                                 }
                                              ;
                return storehouse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object getStorehouse(Int64 storehouseId)
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var storehouse = (from t1 in db.ST_storehouses
                                  where t1.storehouse_id == storehouseId
                                  select new
                                  {
                                      t1.storehouse_id,
                                      t1.storehouse_id_custom,
                                      t1.storehouse_name,
                                      t1.storehouse_address,
                                  }).First();
                return storehouse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool deleteStorehouse(Int64 storehouseId)
        {
            try
            {
                var delete = db.ST_storehouses.Where(p => p.storehouse_id.Equals(storehouseId)).SingleOrDefault();

                db.ST_storehouses.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool insertStorehouse(DTO.ST_storehouse storehouse)
        {
            try
            {
                db.ST_storehouses.InsertOnSubmit(storehouse);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool updateStorehouse(DTO.ST_storehouse storehouse)
        {
             try
            {
            var updateStorehouse = db.ST_storehouses.Where(p => p.storehouse_id.Equals(storehouse.storehouse_id)).SingleOrDefault();

            updateStorehouse.storehouse_name = storehouse.storehouse_name;
            updateStorehouse.storehouse_address = storehouse.storehouse_address;
            db.SubmitChanges();
            return true;
            }
             catch (Exception)
             {
                 return false;
             }
        }

        
    }
}
