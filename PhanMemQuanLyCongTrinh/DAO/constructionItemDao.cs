using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class constructionItemDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public object isContructionIdtemGroup(Int64 contructionId)
        {
            try
            {
                var Contruction = from d in db.ST_construction_items where d.construction_id == contructionId select d;
                return Contruction.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object isContructionStatus(Int64 contructionId)
        {
            try
            {
                var Contruction = from d in db.ST_construction_items where d.construction_id == contructionId && d.construction_item_status != 2 select d;
                return Contruction.First( );
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public object getAllIdNameContructionItem(Int64 contructionId)
        {
            try
            {
                var Contruction = from d in db.ST_construction_items
                                  where d.construction_id == contructionId
                                  select new
                                  {
                                      d.construction_item_id,
                                      d.construction_item_name,
                                      d.construction_item_custom
                                  };
                return Contruction;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public object getContructionItemWithGroup(Int64 contructionId)
        {

            db.Dispose();
            db = new DataClasses1DataContext();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

            var customer = from t1 in db.ST_construction_items
                           join t2 in db.ST_constructions
                           on t1.construction_id equals t2.construction_id
                           join t3 in db.ST_building_contractors
                           on t1.building_contractor_id equals t3.building_contractor_id
                           where t1.construction_id == contructionId
                           select new
                           {
                               t1.construction_item_id,
                               t1.construction_item_custom,
                               t1.construction_item_name,
                               t2.construction_name,
                               t3.building_contractor_name,
                               t1.construction_item_total_price,
                               t1.construction_item_date_start,
                               t1.construction_item_date_end,
                               t1.construction_item_status,

                           }
                                  ;
            return customer;
        }

        public IEnumerable<Object> getContructionItemForSearchWithGroup(Int64 contructionId)
        {
            db.Dispose( );
            db = new DataClasses1DataContext( );
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

            var construction_item = from t1 in db.ST_construction_items
                           where t1.construction_id == contructionId
                           select new
                           {
                               t1.construction_item_id,
                               t1.construction_item_custom,
                               t1.construction_item_name,
                                t1.construction_item_status
                           };
            return construction_item;
        }


        public bool deleteConstructionItem(Int64 id)
        {
            try
            {
                var delete = db.ST_construction_items.Where(p => p.construction_item_id.Equals(id)).SingleOrDefault( );

                db.ST_construction_items.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public object getConstructionItem(Int64 id)
        {
            try
            {
                db.Dispose( );
                db = new DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var construction = from t1 in db.ST_construction_items
                                   join t2 in db.ST_constructions
                                   on t1.construction_id equals t2.construction_id
                                   join t3 in db.ST_building_contractors
                                   on t1.building_contractor_id equals t3.building_contractor_id
                                   where t1.construction_item_id == id
                                   select t1;
                return construction.First( );
            }
            catch ( Exception )
            {
                return null;
            }
        }








        public bool insertContstructionItem(DTO.ST_construction_item constractionItem)
        {
            try
            {
                db.ST_construction_items.InsertOnSubmit(constractionItem);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool updateContstructionItemStatus(Int64 constractionItem, int status)
        {
            try
            {
                var updateConstruction = db.ST_construction_items.Where(p => p.construction_item_id.Equals(constractionItem)).SingleOrDefault( );
                updateConstruction.construction_item_status = status;
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateContstructionItem(DTO.ST_construction_item constractionItem)
        {
            try
            {
                var updateConstruction = db.ST_construction_items.Where(p => p.construction_item_id.Equals(constractionItem.construction_item_id)).SingleOrDefault( );

                updateConstruction.construction_item_name = constractionItem.construction_item_name;
                updateConstruction.building_contractor_id = constractionItem.building_contractor_id;
                updateConstruction.construction_id = constractionItem.construction_id;
                updateConstruction.construction_contract_number = constractionItem.construction_contract_number;
                updateConstruction.construction_item_total_price = constractionItem.construction_item_total_price;

                updateConstruction.construction_item_file_name = constractionItem.construction_item_file_name;

                updateConstruction.construction_item_file = constractionItem.construction_item_file;


                updateConstruction.construction_item_date_start = constractionItem.construction_item_date_start;


                updateConstruction.construction_item_date_end = constractionItem.construction_item_date_end;


                updateConstruction.construction_item_date_end_guarantee = constractionItem.construction_item_date_end_guarantee;



                updateConstruction.construction_item_image = constractionItem.construction_item_image;


                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
