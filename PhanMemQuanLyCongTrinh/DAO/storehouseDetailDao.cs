using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class storehouseDetailDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public bool changeIdParent(Int64 groupId)
        {
            try
            {
                var suppliesGroup = from t1 in db.ST_storehouses_details
                                    where t1.storehouse_id == groupId
                                    select new
                                    {
                                        t1.storehouses_detail_id,
                                        t1.supplies_id,
                                        t1.storehouse_detail_quantity,
                                    };
                var suppliesDefaut = from t1 in db.ST_storehouses_details
                                     where t1.storehouse_id == 1
                                     select new
                                     {
                                         t1.storehouses_detail_id,
                                         t1.supplies_id,
                                         t1.storehouse_detail_quantity,
                                     };


                foreach (var item1 in suppliesGroup)
                {
                    foreach (var item2 in suppliesDefaut)
                    {
                        if (item1.supplies_id == item2.supplies_id)
                        {

                            Int64 qualityitem1 = Convert.ToInt64(item1.storehouse_detail_quantity);
                            Int64 qualityitem2 = Convert.ToInt64(item2.storehouse_detail_quantity);
                            Int64 idDetail = Convert.ToInt64(item2.storehouses_detail_id);
                            Int64 total = qualityitem1 + qualityitem2;
                            bool boolCheckupdateQuality = updateQuality(total, idDetail);
                            bool boolCheckDelete = deleteStorehouseDetail(Convert.ToInt64(item1.storehouses_detail_id));

                        }
                    }
                    Int64 idDetailGroup = Convert.ToInt64(item1.storehouses_detail_id);

                    bool checkUpdate = updateGroup(idDetailGroup);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }


        public bool updateQuality(Int64 quality, Int64 storehousesId)
        {
            try
            {
                var update = db.ST_storehouses_details.Where(p => p.storehouses_detail_id == storehousesId).SingleOrDefault();
                update.storehouse_detail_quantity = quality;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteStorehouseDetail(Int64 storehouseDetailID)
        {
            try
            {
                var delete = db.ST_storehouses_details.Where(p => p.storehouses_detail_id == storehouseDetailID).SingleOrDefault();
                db.ST_storehouses_details.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateGroup(Int64 storehouseDetailID)
        {
            try
            {
                var update = db.ST_storehouses_details.Where(p => p.storehouses_detail_id == storehouseDetailID).SingleOrDefault();
                update.storehouse_id = 1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public object getAllStorehouseDetail()
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);


                var storehouseDetail = from t1 in db.ST_storehouses_details
                                       join t2 in db.ST_storehouses
                                       on t1.storehouse_id equals t2.storehouse_id
                                       join t3 in db.ST_supplies
                                            on t1.supplies_id equals t3.supplies_id
                                       select new
                                       {
                                           t1.storehouses_detail_id,
                                           t1.storehouse_detail_quantity,
                                           t2.storehouse_name,
                                           t3.supplies_name,
                                       };
                return storehouseDetail;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public object getStorehouseDetailWithGroup(Int64 storehouseId)
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);


                var storehouseDetail = from t1 in db.ST_storehouses_details
                                       join t2 in db.ST_storehouses
                                        on t1.storehouse_id equals t2.storehouse_id
                                       join t3 in db.ST_supplies
                                            on t1.supplies_id equals t3.supplies_id

                                  where t1.storehouse_id == storehouseId
                                  select new
                                  {
                                      t1.storehouses_detail_id,
                                      t1.storehouse_detail_quantity,
                                      t2.storehouse_name,
                                      t3.supplies_name,
                                  };
                return storehouseDetail;
            }
            catch (Exception)
            {
                return null;
            }
        }




        public object getAllStorehouseSuppliesWithGroup(Int64 storehouseId)
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var storehouseDetail = from t1 in db.ST_storehouses_details
                                       where t1.storehouse_id == storehouseId 
                                       select new
                                       {
                                           t1.storehouses_detail_id,
                                           t1.supplies_id,
                                           t1.storehouse_detail_quantity,
                                       };
                return storehouseDetail;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public object getAllStorehouseSuppliesWithDefaut()
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var storehouseDetail = from t1 in db.ST_storehouses_details
                                       where t1.storehouse_id == 1
                                       select new
                                       {
                                           t1.storehouses_detail_id,
                                           t1.supplies_id,
                                           t1.storehouse_detail_quantity,
                                       };

                
                return storehouseDetail;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object getStorehouseWithSupplies(Int64 storehouseID,Int64 suppliesId)
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var storehouseDetail = from t1 in db.ST_storehouses_details
                                        where t1.storehouse_id == storehouseID && t1.supplies_id==suppliesId
                                       select new
                                       {
                                           t1.storehouses_detail_id,
                                           t1.storehouse_detail_quantity,
                                       };
                return storehouseDetail;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
