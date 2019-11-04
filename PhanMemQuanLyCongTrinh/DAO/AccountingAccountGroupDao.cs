using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class accountingAccountGroupDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public object getAllAccountingAcountGroup()
        {
             try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var AccountingAcountGroup = from d in db.ST_income_and_expenditure_patterns select d;
                return AccountingAcountGroup;
             }
             catch(Exception)
             {
                 return null;
             }

        }
        public object getAccountingAcountGroup(Int64 AAGroupId)
        {
             try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
            var AccountingAcountGroup = from d in db.ST_income_and_expenditure_patterns where d.income_and_expenditure_pattern_id == AAGroupId select d;
            return AccountingAcountGroup.First();
            }
             catch (Exception)
             {
                 return null;
             }
        }

        public object getAccountingAcountGroupWithCustom(Int32 customId)
        {
            try
            {
                var AccountingAcountGroup = from d in db.ST_income_and_expenditure_patterns where d.income_and_expenditure_pattern_id_custom == customId select d;
                return AccountingAcountGroup.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool deleteAAG(Int64 AAGId)
        {
            try
            {
                var delete = db.ST_income_and_expenditure_patterns.Where(p => p.income_and_expenditure_pattern_id.Equals(AAGId)).SingleOrDefault();

                db.ST_income_and_expenditure_patterns.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool insertAAGroup(DTO.ST_income_and_expenditure_pattern AAgroup)
        {
            try
            {
                db.ST_income_and_expenditure_patterns.InsertOnSubmit(AAgroup);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool updateAAGroup(DTO.ST_income_and_expenditure_pattern updateAAGroup)
        {
            try
            {
                var updateVendor = db.ST_income_and_expenditure_patterns.Where(p => p.income_and_expenditure_pattern_id.Equals(updateAAGroup.income_and_expenditure_pattern_id)).SingleOrDefault();

                updateVendor.income_and_expenditure_pattern_id_custom = updateAAGroup.income_and_expenditure_pattern_id_custom;
                updateVendor.income_and_expenditure_pattern_name = updateAAGroup.income_and_expenditure_pattern_name;
              

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
