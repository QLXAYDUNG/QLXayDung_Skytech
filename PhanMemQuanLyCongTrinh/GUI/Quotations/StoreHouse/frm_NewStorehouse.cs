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
    public partial class frm_NewStorehouse : DevExpress.XtraEditors.XtraForm
    {
        BUS.storehouseBus storehouseBus = new BUS.storehouseBus();
        public frm_NewStorehouse()
        {
            InitializeComponent();
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        #region insert storehouse
        private bool insertStorehouse()
        {
            DTO.ST_storehouse newStorehouse = new DTO.ST_storehouse();
            newStorehouse.storehouse_name = txt_storehouseName.Text;
            newStorehouse.storehouse_address = txt_Address.Text;
            return storehouseBus.insertStorehouse(newStorehouse);
        }

        private void but_Add_Click(object sender, EventArgs e)
        {
            string check = checkNull();
            if (check == "true")
            {

                bool boolInsertStorehouse = insertStorehouse();
                if (boolInsertStorehouse == true)
                {
                    messeage.success("Thêm Mới Thành Công!");
                    this.Close();
                }
                else
                {
                    messeage.error("Không Thể Thêm Mới!");
                }
            }
            else
            {
                messeage.error(check);
            }
        }
        #endregion

        private void frm_NewStorehouse_Load(object sender, EventArgs e)
        {

        }

    }
}