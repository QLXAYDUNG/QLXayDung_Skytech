using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class constructionBus
    {
        DAO.constructionDao constructionDao = new DAO.constructionDao();
        public object getAllContruction()
        {
            return constructionDao.getAllContruction();
        }
        public bool deleteContruction(Int64 id)
        {
            return constructionDao.deleteContruction(id);
        }

        public bool insertContstruction(DTO.ST_construction constraction)
        {
            return constructionDao.insertContstruction(constraction);
        }
        public object getContruction(Int64 constructionId)
        {
            return constructionDao.getContruction(constructionId);
        }
        public bool updateContstruction(DTO.ST_construction constraction)
        {
            return constructionDao.updateContstruction(constraction);
        }
        public bool updateStatusContstruction(Int64 constractionID, int status)
        {
            return constructionDao.updateStatusContstruction(constractionID, status);
        }
        
    }
}
