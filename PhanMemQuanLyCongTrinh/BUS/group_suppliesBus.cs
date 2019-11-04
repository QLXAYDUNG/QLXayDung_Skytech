using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DAO;


namespace PhanMemQuanLyCongTrinh.BUS
{
    public class group_suppliesBus
    {
        group_suppliesDao _groupDao = new group_suppliesDao();

        public IEnumerable<Object> getAllGroup()
        {
            return _groupDao.getAllGroupSupplies();
        }

        public bool insert(string name)
        {
            bool boolInsert = _groupDao.insertGroupSupplie(name);

            if ( boolInsert )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Object getGroupSupplies(Int64 id)
        {
            return _groupDao.getGroupSupplie(id);
        }

        public bool update(string name, Int64 id)
        {
            return _groupDao.updateGroupSupplie(name, id);
        }

        public bool deleteGroupSupplie(Int64 id)
        {
            return _groupDao.deleteGroupSupplie(id);
        }

        public bool changeIdParent(Int64 id)
        {
            return _groupDao.changeIdParent(id);
        }
    }
}
