using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class PaymentSlipDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext( );

        public IEnumerable<object> getAllPaymentSlips( )
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var datasource = from pm in db.ST_payment_slips
                                 select pm;
                return datasource;
            }
            catch ( Exception )
            {
                return null;
            }
            finally
            {
                dlg.Close( );
            }
        }

        public object getPaymentSlip(Int64 paymentId)
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var unit = (from t1 in db.ST_payment_slips
                            where t1.payment_slip_id == paymentId
                            select t1).First( );
                return unit;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public bool deletePaymentSlip(Int64 paymentId)
        {
            try
            {
                var delete = db.ST_payment_slips.Where(p => p.payment_slip_id.Equals(paymentId)).SingleOrDefault( );

                db.ST_payment_slips.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insertPaymentSlip(DTO.ST_payment_slip payment)
        {
            try
            {
                db.ST_payment_slips.InsertOnSubmit(payment);
                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }

        public bool updatePaymentSlip(DTO.ST_payment_slip pay)
        {
            try
            {
                var updateVendor = db.ST_payment_slips.Where(p => p.payment_slip_id.Equals(pay.payment_slip_id)).SingleOrDefault( );

                //updateVendor. = unit.unit_name;

                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }
    }
}
