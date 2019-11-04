using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class AcountingAcountBus
    {
        DAO.acountingAcountDaocs acountAccountDao = new DAO.acountingAcountDaocs();
        public object getAllAcountingAcount()
        {
            return acountAccountDao.getAllAcountingAcount();
        }
        public object getAcountingAcount(Int64 AAId)
        {
            return acountAccountDao.getAcountingAcount(AAId);
        }
        public object getAcountingAcountWithGroup(Int64 AcountingAcountGroupId)
        {
            return acountAccountDao.getAcountingAcountWithGroup(AcountingAcountGroupId);
        }
        public bool insertAcountingAcount(DTO.ST_detail_income_and_expenditure_pattern AcountingAcount)
        {
            return acountAccountDao.insertAcountingAcount(AcountingAcount);
        }
        public bool updateAcountingAcount(DTO.ST_detail_income_and_expenditure_pattern AcountingAcount)
        {
            return acountAccountDao.updateAcountingAcount(AcountingAcount);
        }
        public bool deleteAcountingAccount(Int64 id)
        {
            return acountAccountDao.deleteAcountingAccount(id);
        }
        public bool IsAAIdCustom(Int32 customId)
        {
            if (acountAccountDao.getAccountingAcountWithCustom(customId) == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool changeIdParent(Int64 groupId)
        {
            return acountAccountDao.changeIdParent(groupId);
        }
    }
}
