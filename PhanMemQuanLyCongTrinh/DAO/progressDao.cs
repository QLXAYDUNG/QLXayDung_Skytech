using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class progressDao
    {

        DataClasses1DataContext db = new DataClasses1DataContext();

        public bool insertProgress(DTO.ST_progress_construction_item progress)
        {
            try
            {
                db.ST_progress_construction_items.InsertOnSubmit(progress);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public object getProgress(Int64 progressId)
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var progress = from t1 in db.ST_progress_construction_items
                               join t2 in db.ST_construction_items
                               on t1.construction_item_id equals t2.construction_item_id
                               join t3 in db.ST_constructions
                               on t2.construction_id equals t3.construction_id
                               where t1.progress_construction_item_id == progressId
                               
                               select new
                               {
                                   t1.progress_construction_item_id,
                                   t1.progress_construction_item_custom,
                                   t1.progress_construction_item_date,
                                   t1.progress_construction_item_description,
                                   t1.progress_construction_item_image,
                                   t1.progress_construction_item_percent,
                                   t2.construction_item_name,
                                   t3.construction_name,
                                   t2.construction_item_id,
                                   t3.construction_id
                               };
                return progress.First();
            }
            catch (Exception)
            {
                return null;
            }
        }



        public object getAllProgressWithConstruction(Int64 constructionId)
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var progress = from t1 in db.ST_progress_construction_items
                               join t2 in db.ST_construction_items
                               on t1.construction_item_id equals t2.construction_item_id
                               join t3 in db.ST_employees
                               on t1.employee_created equals t3.employee_id
                               where t2.construction_id == constructionId
                               orderby t1.progress_construction_item_date descending
                               select new {
                                   t1.progress_construction_item_id,
                                   t1.progress_construction_item_custom,
                                   t1.progress_construction_item_date,
                                   t1.progress_construction_item_description,
                                   t1.progress_construction_item_image,
                                   t1.progress_construction_item_percent,
                                   t2.construction_item_name,
                                   t3.employee_name
                               };
                return progress;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object getAllProgressWithConstructionItem(Int64 constructionItemId)
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var progress = from t1 in db.ST_progress_construction_items
                               join t2 in db.ST_construction_items
                               on t1.construction_item_id equals t2.construction_item_id
                               join t3 in db.ST_employees
                               on t1.employee_created equals t3.employee_id
                               where t1.construction_item_id == constructionItemId
                               orderby t1.progress_construction_item_date descending
                               select new
                               {
                                   t1.progress_construction_item_id,
                                   t1.progress_construction_item_custom,
                                   t1.progress_construction_item_date,
                                   t1.progress_construction_item_description,
                                   t1.progress_construction_item_image,
                                   t1.progress_construction_item_percent,
                                   t2.construction_item_name,
                                   t3.employee_name
                               };
                return progress;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object getAllProgress()
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var progress = from t1 in db.ST_progress_construction_items
                               join t2 in db.ST_construction_items
                               on t1.construction_item_id equals t2.construction_item_id
                               join t3 in db.ST_employees
                               on t1.employee_created equals t3.employee_id
                               orderby t1.progress_construction_item_date descending
                               select new
                               {
                                   t1.progress_construction_item_id,
                                   t1.progress_construction_item_custom,
                                   t1.progress_construction_item_date,
                                   t1.progress_construction_item_description,
                                   t1.progress_construction_item_image,
                                   t1.progress_construction_item_percent,
                                   t2.construction_item_name,
                                   t3.employee_name
                               };
                return progress;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool deleteProgress(Int64 storehouseId)
        {
            try
            {
                var delete = db.ST_progress_construction_items.Where(p => p.progress_construction_item_id.Equals(storehouseId)).SingleOrDefault();

                db.ST_progress_construction_items.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateProgress(DTO.ST_progress_construction_item progress)
        {
              try
            {
                var updateProgress = db.ST_progress_construction_items.Where(p => p.progress_construction_item_id.Equals(progress.progress_construction_item_id)).SingleOrDefault();
                updateProgress.progress_construction_item_percent = progress.progress_construction_item_percent;
                updateProgress.progress_construction_item_date = progress.progress_construction_item_date;
                updateProgress.progress_construction_item_description = progress.progress_construction_item_description;
                updateProgress.progress_construction_item_image = progress.progress_construction_item_image;
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
