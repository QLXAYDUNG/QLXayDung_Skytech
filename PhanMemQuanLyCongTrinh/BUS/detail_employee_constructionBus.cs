using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DAO;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class detail_employee_constructionBus
    {
        detail_employee_constructionDao _em = new detail_employee_constructionDao( );
        public bool insert(ST_detail_employee_construction item)
        {
            return _em.insert(item);
        }

        public IEnumerable<Object> getAll( )
        {
            return _em.getAll();
        }

        public bool checkEmployeesContructItem(Int64 idContructItem)
        {
            return _em.checkEmployeesContructItem(idContructItem);
        }

        public IEnumerable<Object> getAll_ContrucItems( Int64 idContrucItem)
        {
            return _em.getAll_ContrucItems(idContrucItem);
        }

        public IEnumerable<Object> getAllEmployeeNotChecked(Int64 id)
        {
            return _em.getAllEmployeeNotChecked(id);
        }

        public bool deleteEmployee(Int64 id)
        {
            return _em.deleteEmployee(id);
        }
    }
}
