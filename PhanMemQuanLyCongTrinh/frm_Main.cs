using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.LookAndFeel;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static string Vitual_Username;
        public static Int64 Vitual_id = 0;
        public static string Vitual_Chinhanh;
        public static Int64 Vitual_Quyen;
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
        public frm_Main()
        {
            InitializeComponent();

            // The following line provides localization for the application's user interface.  
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("vi");

            // The following line provides localization for data formats.  
            System.Threading.Thread.CurrentThread.CurrentCulture =
                new System.Globalization.CultureInfo("vi-VN");  
        }

        private void btnUserInformation_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_UserInfo));
            if ( frm == null )
            {
                frm_UserInfo forms = new frm_UserInfo( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnRegistered_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_RegisterUser));
            if ( frm == null )
            {
                frm_RegisterUser forms = new frm_RegisterUser( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void btnCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Customer));
            if ( frm == null )
            {
                frm_Customer forms = new frm_Customer( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnCustomerGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Form frm = kiemtraform(typeof(frm_NewCustomerGroup));
            //if ( frm == null )
            //{
            //    frm_NewCustomerGroup forms = new frm_NewCustomerGroup( );
            //    forms.MdiParent = this;
            //    forms.Show( );
            //}
            //else
            //{
            //    frm.Activate( );
            //}
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_RePassword));
            if ( frm == null )
            {
                frm_RePassword forms = new frm_RePassword( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Employees));
            if ( frm == null )
            {
                frm_Employees forms = new frm_Employees( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Units));
            if ( frm == null )
            {
                frm_Units forms = new frm_Units( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnConstructors_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_BuildingContractor));
            if ( frm == null )
            {
                frm_BuildingContractor forms = new frm_BuildingContractor( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnVendor_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Vendor));
            if ( frm == null )
            {
                frm_Vendor forms = new frm_Vendor( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Supplies));
            if ( frm == null )
            {
                frm_Supplies forms = new frm_Supplies( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnStorehouses_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Storehouse));
            if ( frm == null )
            {
                frm_Storehouse forms = new frm_Storehouse( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnRevenueAndExpenditure_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_AccountingAccounts));
            if ( frm == null )
            {
                frm_AccountingAccounts forms = new frm_AccountingAccounts( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnEnterCouponSupplies_ItemClick(object sender, ItemClickEventArgs e)
        {
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

        private void btnListEnterCouponSupplies_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_EnterCouponSupplies));
            if ( frm == null )
            {
                frm_EnterCouponSupplies forms = new frm_EnterCouponSupplies( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnConstructions_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Constructions));
            if ( frm == null )
            {
                frm_Constructions forms = new frm_Constructions( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnSuppliesInWearHouse_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_StorehouseDetail));
            if ( frm == null )
            {
                frm_StorehouseDetail forms = new frm_StorehouseDetail( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnEmployeeConstructions_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Employees_Contruct));
            if ( frm == null )
            {
                frm_Employees_Contruct forms = new frm_Employees_Contruct( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnConstructionItems_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnProgressConstructionItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_progress));
            if ( frm == null )
            {
                frm_progress forms = new frm_progress( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnPlanConstructions_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        
        
    }
}