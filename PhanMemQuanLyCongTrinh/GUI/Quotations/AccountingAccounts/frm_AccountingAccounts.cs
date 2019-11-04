using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhanMemQuanLyCongTrinh.BUS;
namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_AccountingAccounts : DevExpress.XtraEditors.XtraForm
    {
        BUS.AccountingAccountGroupBus AAGBus = new BUS.AccountingAccountGroupBus();
        
        int indexAAGroup;
        public frm_AccountingAccounts()
        {
            InitializeComponent();
        }
        private void loadAcountingAcountGroup()
        {
            grdc_AcountingAcountGroup.DataSource = AAGBus.getAllAccountingAcountGroup();
        }

        private void frm_AccountingAccounts_Load(object sender, EventArgs e)
        {
            loadAcountingAcountGroup();
        }

        private void loadAllAcountingAcount()
        {
 
        }
        private void loadAcountingAcount(Int64 AAGroupId)
        {
            
        }


        private void grdv_AcountingAcountGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            indexAAGroup = e.FocusedRowHandle;
            if (indexAAGroup >= 0)
            {
                Int64 AAGroupId = Convert.ToInt64(grdv_AcountingAcountGroup.GetRowCellValue(indexAAGroup, "income_and_expenditure_pattern_id").ToString());
                loadAcountingAcount(AAGroupId);
            }
        }


        private void btn_DeleteAcountiongAcountGroup_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_AcountingAcountGroup.RowCount > 0)
            {
                Int64 AAGroupId = Convert.ToInt64(grdv_AcountingAcountGroup.GetRowCellValue(indexAAGroup, "income_and_expenditure_pattern_id").ToString());

                var AAGroupName = grdv_AcountingAcountGroup.GetRowCellValue(indexAAGroup, "income_and_expenditure_pattern_name").ToString();

                bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Nhóm Tài Khoản '", AAGroupName);

                if (boolCheckDelete == true)
                {
                    bool boolDeleteCustomer = AAGBus.deleteAAG(AAGroupId);
                    if (boolDeleteCustomer == true)
                    {
                        messeage.success("Xóa Khách hàng Thành Công!");
                        
                        loadAcountingAcountGroup();
                    }
                    else
                    {
                        messeage.error("Xóa Khách hàng Không Thành Công!");

                    }
                }
            }
            else
            {
                messeage.error("Không Có Gì Để Xóa");
            }
        }

        private void btn_AddAcountiongAcountGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewAccountingAccountsGroup frm = new frm_NewAccountingAccountsGroup();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.Show();
        }


        private void dongform(object sender, EventArgs e)
        {
            loadAcountingAcountGroup();

        }

        private void btn_EditAcountiongAcountGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_AcountingAcountGroup.RowCount > 0)
            {
                frm_UpdateAccountingAccountsGroup frm = new frm_UpdateAccountingAccountsGroup();
                frm.FormClosed += new FormClosedEventHandler(dongform);
                frm.AAGroupId = Convert.ToInt64(grdv_AcountingAcountGroup.GetRowCellValue(indexAAGroup, "income_and_expenditure_pattern_id").ToString());
                frm.Show();
            }
            else
            {
                messeage.error("Không Có Gì Để Chỉnh Sửa!");
            }
        }
    }
}