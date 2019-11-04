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
    public partial class frm_UpdateStorehouse : DevExpress.XtraEditors.XtraForm
    {
        public Int64 storehouseId;

        BUS.storehouseBus storehouseBus = new BUS.storehouseBus();
        public frm_UpdateStorehouse()
        {
            InitializeComponent();
        }
        private void loadStorehouse()
        {
            var storehouse = storehouseBus.getStorehouse(storehouseId);
            txt_StorehouseId.Text = storehouse.GetType().GetProperty("storehouse_id_custom").GetValue(storehouse, null).ToString();
            txt_storehouseName.Text = storehouse.GetType().GetProperty("storehouse_name").GetValue(storehouse, null).ToString();
            txt_Address.Text = storehouse.GetType().GetProperty("storehouse_address").GetValue(storehouse, null).ToString(); 
        }
                                    

        private void frm_UpdateStorehouse_Load(object sender, EventArgs e)
        {
            loadStorehouse();
        }
        private string checkNull()
        {
            if (txt_storehouseName.Text == "")
            {
                txt_storehouseName.Focus();
                return "Vui Lòng Nhập Tên Nhà Kho";
            }
            else if (txt_Address.Text == "")
            {
                txt_Address.Focus();
                return "Vui Lòng Nhập Địa Chỉ Nhà Kho";
            }
            else
            {
                return "true";
            }
        }
        #region update storehouse
        private bool updateStorehouse()
        {
            DTO.ST_storehouse newStorehouse = new DTO.ST_storehouse();
            newStorehouse.storehouse_id = storehouseId;
            newStorehouse.storehouse_name = txt_storehouseName.Text;
            newStorehouse.storehouse_address = txt_Address.Text;
            return storehouseBus.updateStorehouse(newStorehouse);
        }
        private void but_Add_Click(object sender, EventArgs e)
        {
            string check = checkNull();
            if (check == "true")
            {

                bool boolUpdateStorehouse = updateStorehouse();
                if (boolUpdateStorehouse == true)
                {
                    messeage.success("Cập Nhật Thành Công!");
                  
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
        #endregion

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}