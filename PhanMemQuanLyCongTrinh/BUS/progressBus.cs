using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class progressBus
    {
        DAO.progressDao progressDao = new DAO.progressDao();
        public bool insertProgress(DTO.ST_progress_construction_item progress)
        {
            return progressDao.insertProgress(progress);
        }
        public object getAllProgressWithConstruction(Int64 constructionId)
        {
            return progressDao.getAllProgressWithConstruction(constructionId);
        }
        public object getAllProgressWithConstructionItem(Int64 constructionItemId)
        {
            return progressDao.getAllProgressWithConstructionItem(constructionItemId);
        }
        public object getAllProgress()
        {
            return progressDao.getAllProgress();
        }

        public bool deleteProgress(Int64 storehouseId)
        {
            return progressDao.deleteProgress(storehouseId);
        }
        public object getProgress(Int64 progressId)
        {
            return progressDao.getProgress(progressId);
        }
        public bool updateProgress(DTO.ST_progress_construction_item progress)
        {
            return progressDao.updateProgress(progress);
        }
    }
}
