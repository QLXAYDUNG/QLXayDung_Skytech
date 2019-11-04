using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    
    class constructionItemBus
    {
        DAO.constructionItemDao constructionItemDao = new DAO.constructionItemDao();
        public bool isContructionIdtemGroup(Int64 contructionId)
        {
            var construction = constructionItemDao.isContructionIdtemGroup(contructionId);
          
            if (construction!=null)
            
                return true;
            
            else
            
                return false;
            

           
        }
        public object getContructionItemWithGroup(Int64 contructionId)
        {
            return constructionItemDao.getContructionItemWithGroup(contructionId);
        }

        public IEnumerable<Object> getContructionItemForSearchWithGroup(Int64 contructionId)
        {
            return constructionItemDao.getContructionItemForSearchWithGroup(contructionId);
        }

        public bool deleteConstructionItem(Int64 id)
        {
            return constructionItemDao.deleteConstructionItem(id);
        }
        public bool insertContstructionItem(DTO.ST_construction_item constractionItem)
        {
            return constructionItemDao.insertContstructionItem(constractionItem);
        }

        public bool updateContstructionItem(DTO.ST_construction_item constractionItem)
        {
            return constructionItemDao.updateContstructionItem(constractionItem);
        }
        public object getConstructionItem(Int64 constructionItemId)
        {
            return constructionItemDao.getConstructionItem(constructionItemId);
        }
        public object getAllIdNameContructionItem(Int64 contructionId)
        {
            return constructionItemDao.getAllIdNameContructionItem(contructionId);
        }
        public bool updateContstructionItemStatus(Int64 constractionItem, int status)
        {
            return constructionItemDao.updateContstructionItemStatus(constractionItem, status);
        }
        public bool isContructionStatus(Int64 contructionId)
        {
            var construction = constructionItemDao.isContructionStatus(contructionId);
            if ( construction != null )

                return true;

            else

                return false;
        }
    }
}
