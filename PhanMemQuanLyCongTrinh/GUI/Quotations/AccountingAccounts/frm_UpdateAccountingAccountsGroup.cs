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
    public partial class frm_UpdateAccountingAccountsGroup : DevExpress.XtraEditors.XtraForm
    {
        public Int64 AAGroupId { get; set; }
        BUS.AccountingAccountGroupBus AAGroupBus = new BUS.AccountingAccountGroupBus();
        public frm_UpdateAccountingAccountsGroup()
        {
            InitializeComponent();
        }
        private void loadAAGroup()
        {
            var AAGroup = AAGroupBus.getAccountingAcountGroup(AAGroupId);
            txt_AAGroupId.Text = AAGroup.GetType().GetProperty("income_and_expenditure_pattern_id_custom").GetValue(AAGroup, null).ToString();
            txt_AAGroupName.Text = AAGroup.GetType().GetProperty("income_and_expenditure_pattern_name").GetValue(AAGroup, null).ToString();
        }
        private void frm_UpdateAccountingAccountsGroup_Load(object sender, EventArgs e)
        {
            loadAAGroup();
        }
        private string checkNull()
        {
            if (txt_AAGroupId.Text == "")
            {
                txt_AAGroupId.Focus();
                return "Vui Lòng Nhập Mã Tài Khoản Ngân Hàng";
            }
            else if (txt_AAGroupName.Text == "")
            {
                txt_AAGroupName.Focus();
                return "Vui Lòng Nhập Tên Tài Khoản Ngân Hàng";
            }
            else
            {
                return "true";
            }
        }

        private bool updateAAGroup()
        {
            DTO.ST_income_and_expenditure_pattern newAAGroup = new DTO.ST_income_and_expenditure_pattern();
            newAAGroup.income_and_expenditure_pattern_id = AAGroupId;
            newAAGroup.income_and_expenditure_pattern_id_custom = Convert.ToInt32(txt_AAGroupId.Text);
            newAAGroup.income_and_expenditure_pattern_name = txt_AAGroupName.Text;
            return AAGroupBus.updateAAGroup(newAAGroup);
        }

        private void but_Add_Click(object sender, EventArgs e)
        {
            string check = checkNull();
            if (check == "true")
            {

                bool boolUpdateAAGroup = updateAAGroup();
                if (boolUpdateAAGroup == true)
                {
                    messeage.success("Cập Nhật Thành Công!");
                    this.Close();
                }
                else
                {
                    messeage.error("Không Thể Cập Nhật!");
                }
            }
            else
            {
                messeage.error(check);
            }
        }
    }
}