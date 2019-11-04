using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    class vendorDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public object loadAllVendor()
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var vendor = from t1 in db.ST_vendors
                                         select new
                                         {
                                             t1.vendor_id,
                                             t1.vendor_id_custom,
                                             t1.vendor_name,
                                             t1.vendor_phone,
                                             t1.vendor_address,
                                             t1.vendor_bank_account_number
                                         }
                                              ;
                return vendor;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public object loadVendor(Int64 vendorId)
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
               
                var vendor = (from t1 in db.ST_vendors
                             where t1.vendor_id == vendorId
                             select new
                             {
                                 t1.vendor_id,
                                 t1.vendor_id_custom,
                                 t1.vendor_name,
                                 t1.vendor_phone,
                                 t1.vendor_address,
                                 t1.vendor_bank_account_number,
                                 t1.vendor_image,
                             }).First();
                return vendor;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool deleteVendor(Int64 VendorId)
        {
            try
            {
                var delete = db.ST_vendors.Where(p => p.vendor_id.Equals(VendorId)).SingleOrDefault();

                db.ST_vendors.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool insertVendor(DTO.ST_vendor vendor)
        {
            try
            {
                db.ST_vendors.InsertOnSubmit(vendor);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool updateVendor(DTO.ST_vendor vendor)
        {
            try
            {
                var updateVendor = db.ST_vendors.Where(p => p.vendor_id.Equals(vendor.vendor_id)).SingleOrDefault();

                updateVendor.vendor_name = vendor.vendor_name;
                updateVendor.vendor_address = vendor.vendor_address;
                updateVendor.vendor_phone = vendor.vendor_phone;

                updateVendor.vendor_bank_account_number = vendor.vendor_bank_account_number;
                updateVendor.vendor_image = vendor.vendor_image;
             
               


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
