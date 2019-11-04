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
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_AddNewUnit : DevExpress.XtraEditors.XtraForm
    {
        public frm_AddNewUnit( )
        {
            InitializeComponent( );
        }

        unitBus _unitBus = new unitBus();

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "")
            {
                messeage.error("Bạn chưa nhập tên đơn vị !");
            }
            else
            {
                ST_unit unit = new ST_unit()
                {
                    unit_name = txt_Name.Text
                };

                bool bInsert = _unitBus.insertVendor(unit);

                if (bInsert)
                {
                    messeage.success("Thêm mới thành công !");
                    this.Close();
                }
                else
                {
                    messeage.error("Không thể thêm mới!");
                }
            }
        }
    }
}