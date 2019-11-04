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
    public partial class frm_EditDeparment : DevExpress.XtraEditors.XtraForm
    {
        BUS.deparmentBus depBus = new BUS.deparmentBus();
        
        public Int64 id = 0;

        public frm_EditDeparment( )
        {
            InitializeComponent( );
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_EditDeparment_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                loadDepartment( );
            }
            else
            {
                messeage.error("Có lỗi, hãy kiểm tra lại !");
            }
            
        }


        private void loadDepartment()
        {
            var department = depBus.getDepartment(id);

            if (department != null)
            {
                var propertyName = department.GetType( ).GetProperty("department_name").GetValue(department, null);
                var pro = (propertyName == null) ? "" : propertyName.ToString( );


                txt_deparment.Text = pro;
            }
            else
            {
                messeage.error("Có lỗi, hãy kiểm tra lại !");
            }

         
        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            bool bUpdate = depBus.update(txt_deparment.Text, id);

            if (bUpdate)
            {
                messeage.success("Cập nhật thành công !");
                this.Close();
            }
            else
            {
                messeage.error("Cập nhật thất bại !");
            }
        }
    }
}