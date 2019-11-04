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
    public partial class frm_EnterCouponSupplies : DevExpress.XtraEditors.XtraForm
    {
        public frm_EnterCouponSupplies( )
        {
            InitializeComponent( );
        }

        private void dongformEnterCouponSupplie(object sender, EventArgs e)
        {
            
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frm_AddNewEnterCouponSupplies f = new frm_AddNewEnterCouponSupplies( );
            //f.FormClosed += new FormClosedEventHandler(dongformEnterCouponSupplie);
            //f.ShowDialog( );
            //foreach ( Form childForm in MdiChildren )
            //{
            //    childForm.Close( );
            //}
            //frm_AddNewEnterCouponSupplies forms = new frm_AddNewEnterCouponSupplies( );
            
            //forms.show

            Form frm = kiemtraform(typeof(frm_AddNewEnterCouponSupplies));
            if ( frm == null )
            {
                frm_AddNewEnterCouponSupplies forms = new frm_AddNewEnterCouponSupplies( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }



        }

        private Form kiemtraform(Type ftype)
        {
            foreach ( Form f in this.MdiChildren )
            {
                if ( f.GetType( ) == ftype )
                {
                    return f;
                }
            }
            return null;
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_EditEnterCouponSupplies f = new frm_EditEnterCouponSupplies( );
            f.FormClosed += new FormClosedEventHandler(dongformEnterCouponSupplie);
            f.ShowDialog( );
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}