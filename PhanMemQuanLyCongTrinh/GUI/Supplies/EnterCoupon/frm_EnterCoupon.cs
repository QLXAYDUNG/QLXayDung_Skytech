using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_EnterCoupon : DevExpress.XtraEditors.XtraForm
    {
        BUS.enterCouponBus enterCouponBus = new BUS.enterCouponBus();
        public frm_EnterCoupon()
        {
            InitializeComponent();
        }

        private void loadAllEnterCoupon()
        {
            grdc_EnterCoupon.DataSource = enterCouponBus.getAllEnterCoupon();
        }
        private void frm_EnterCoupon_Load(object sender, EventArgs e)
        {
            loadAllEnterCoupon();
        }

        private void date_Start_EditValueChanged(object sender, EventArgs e)
        {
            if (date_Start.Text != "")
            {
                if (date_End.Text == "")
                {
                    DateTime date = Convert.ToDateTime(date_Start.Text);
                    grdc_EnterCoupon.DataSource = enterCouponBus.getEnterCouponWithDayStar(date);
                }
                else
                {
                    DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                    DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                    grdc_EnterCoupon.DataSource = enterCouponBus.getEnterCouponWithDayStarDayEnd(dateStart, dateEnd);
                }
            }
        }

        private void date_End_EditValueChanged(object sender, EventArgs e)
        {
            if (date_Start.Text != "" && date_End.Text != "")
            {
                DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                grdc_EnterCoupon.DataSource = enterCouponBus.getEnterCouponWithDayStarDayEnd(dateStart, dateEnd);
            }
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            date_End.Text = "";
            date_Start.Text = "";
            loadAllEnterCoupon();
        }

        

        
    }
}