using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    
    public class unitBus
    {
        DAO.unitDao _unit = new DAO.unitDao();

        public object getAllUnits( )
        {
            return _unit.getAllUnits( );
        }
        public bool deleteVendor(Int64 unitId)
        {
            return _unit.deleteUnit(unitId);
        }

        public bool insertVendor(DTO.ST_unit unit)
        {
            return _unit.insertUnit(unit);
        }

        public object getUnits(Int64 unitId)
        {
            return _unit.getUnit(unitId);
        }

        public bool updateUnit(DTO.ST_unit unit)
        {
            return _unit.updateUnit(unit);
        }
    }
}
