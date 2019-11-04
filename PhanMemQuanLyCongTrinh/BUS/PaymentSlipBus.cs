using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
using PhanMemQuanLyCongTrinh.DAO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class PaymentSlipBus
    {
        PaymentSlipDao _pay = new PaymentSlipDao();

        public IEnumerable<object> getAllPaymentSlips( )
        {
            return _pay.getAllPaymentSlips();
        }

        public object getPaymentSlip(Int64 paymentId)
        {
            return _pay.getPaymentSlip(paymentId);
        }

        public bool deletePaymentSlip(Int64 paymentId)
        {
            return _pay.deletePaymentSlip(paymentId);
        }

        public bool insertPaymentSlip(DTO.ST_payment_slip payment)
        {
            return _pay.insertPaymentSlip(payment);
        }

        public bool updatePaymentSlip(DTO.ST_payment_slip pay)
        {
            return _pay.updatePaymentSlip(pay);
        }
    }
}
