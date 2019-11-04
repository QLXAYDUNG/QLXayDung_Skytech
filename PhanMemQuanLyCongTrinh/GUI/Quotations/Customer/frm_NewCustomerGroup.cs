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
    public partial class frm_NewCustomerGroup : DevExpress.XtraEditors.XtraForm
    {
        public Int64 customerGroupId { set; get; }
        BUS.customerGroupBus customerGroupBus;
        public frm_NewCustomerGroup()
        {
            InitializeComponent();
            customerGroupBus = new BUS.customerGroupBus();
        }
        public void loadCustomerGroup()
        {
            var dt = customerGroupBus.getCustomerGroup(customerGroupId);
            txt_CustomerGroupId.Text = dt.GetType().GetProperty("customer_group_id_custom").GetValue(dt, null).ToString();
            txt_CustomerGroupName.Text = dt.GetType().GetProperty("customer_group_name").GetValue(dt, null).ToString();
        }

        private void frm_NewCustomerGroup_Load(object sender, EventArgs e)
        {
            if (customerGroupId == 0)
            {
                lbl_CustomerGroupId.Visible = false;
                txt_CustomerGroupId.Visible = false;

                but_Update.Text = "Thêm mới";
            }
            else
            {
                but_Update.Text = "Cập nhật";
                txt_CustomerGroupId.Enabled = false;
                loadCustomerGroup();
            }
        }

        private string updateCustomerGroup()
        {
           DTO.ST_customer_group customerGroup = new DTO.ST_customer_group();
            customerGroup.customer_group_id= customerGroupId;
            customerGroup.customer_group_name = txt_CustomerGroupName.Text;
            bool boolUpdateCustomerGroup = customerGroupBus.updateCustomerGroup(customerGroup);
            if (boolUpdateCustomerGroup == true)
            {
                return "Chĩnh Sửa Thành Công!";
            }
            else
            {
                return "Không Thể Chỉnh Sửa!";
            }

        }

        private string insertCustomerGroup()
        {
            DTO.ST_customer_group customerGroup = new DTO.ST_customer_group();
            
            customerGroup.customer_group_name = txt_CustomerGroupName.Text;
            bool boolInsertCustomerGroup = customerGroupBus.insertCustomerGroup(customerGroup);
            if (boolInsertCustomerGroup == true)
            {
                return "Thêm Mới Thành Công!";
                this.Close();
            }
            else
            {
                return "Không Thể Thêm Mới!";
            }
        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            if (customerGroupId == 0)
            {
                messeage.success(insertCustomerGroup());
                
            }
            else
            {
                messeage.error(updateCustomerGroup());
                
            }
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_CustomerGroupName_Click(object sender, EventArgs e)
        {
           
        }

        private void lbl_CustomerGroupId_Click(object sender, EventArgs e)
        {

        }

       
    }
}