using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class buildingContractorDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public object loadAllBuildingContractor()
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var buildingContractor = from t1 in db.ST_building_contractors 
                                         select new{
                                             t1.building_contractor_id,
                                             t1.building_contractor_id_custom,
                                             t1.building_contractor_name,
                                             t1.building_contractor_phone,
                                             t1.building_contractor_liabilities,
                                             t1.building_contractor_email,
                                             t1.building_contractor_address
                                         }
                                              ;
                return buildingContractor;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public object loadBuildingContractor(Int64 buildingContractorId)
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var buildingContractor = (from t1 in db.ST_building_contractors
                                         where t1.building_contractor_id == buildingContractorId
                                         select new
                                         {
                                             t1.building_contractor_id,
                                             t1.building_contractor_id_custom,
                                             t1.building_contractor_name,
                                             t1.building_contractor_phone,
                                             t1.building_contractor_liabilities,
                                             t1.building_contractor_email,
                                             t1.building_contractor_address,
                                             t1.building_contractor_date_of_birth,
                                             t1.building_contractor_bank_account_number,
                                             t1.building_contractor_tax_code,
                                             t1.building_contractor_description,
                                             t1.building_contractor_image
                                         }).First()
                                              ;
                return buildingContractor;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool deleteBuildingContractor(Int64 buildingContractorId)
        {
            try
            {
                var delete = db.ST_building_contractors.Where(p => p.building_contractor_id.Equals(buildingContractorId)).SingleOrDefault();

                db.ST_building_contractors.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insertBuildingContractor(DTO.ST_building_contractor buildingContractor)
        {
            try
            {
                db.ST_building_contractors.InsertOnSubmit(buildingContractor);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateBuildingContractor(DTO.ST_building_contractor buildingContractor)
        {
            try
            {
                
                var updateBuildingContractor = db.ST_building_contractors.Where(p => p.building_contractor_id.Equals(buildingContractor.building_contractor_id)).SingleOrDefault();
                updateBuildingContractor.building_contractor_name = buildingContractor.building_contractor_name;
                updateBuildingContractor.building_contractor_address = buildingContractor.building_contractor_address;
                updateBuildingContractor.building_contractor_phone = buildingContractor.building_contractor_phone;
                updateBuildingContractor.building_contractor_email = buildingContractor.building_contractor_email;
                updateBuildingContractor.building_contractor_bank_account_number = buildingContractor.building_contractor_bank_account_number;
                updateBuildingContractor.building_contractor_tax_code = buildingContractor.building_contractor_tax_code;
                updateBuildingContractor.building_contractor_description = buildingContractor.building_contractor_description;

                updateBuildingContractor.building_contractor_liabilities = buildingContractor.building_contractor_liabilities;


                updateBuildingContractor.building_contractor_date_of_birth = buildingContractor.building_contractor_date_of_birth;

                updateBuildingContractor.building_contractor_image = buildingContractor.building_contractor_image;
                
                
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
