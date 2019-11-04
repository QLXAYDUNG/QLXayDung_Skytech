using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DAO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class supliesBus
    {
        supliesDao _sup = new supliesDao();
        public bool insertSuplies(DTO.ST_supply supply)
        {
            return _sup.insertSuplies(supply);
        }

        public IEnumerable<object> getAllSuplies( )
        {
            return _sup.getAllSuplies();
        }

        public object getSuplies(Int64 id)
        {
            return _sup.getSuplies(id);
        }

        public bool updateSuplies(DTO.ST_supply supp)
        {
            return _sup.updateSuplies(supp);
        }

        public bool deleteSuplies(Int64 id)
        {
            return _sup.deleteSuplies(id);
        }

        public IEnumerable<Object> getAllSupliesInGroup(Int64 id)
        {
            return _sup.getAllSupliesInGroup(id);
        }

        public IEnumerable<object> getAllSuplies_LoadSerach( )
        {
            return _sup.getAllSuplies_LoadSerach();
        }
    }
}
