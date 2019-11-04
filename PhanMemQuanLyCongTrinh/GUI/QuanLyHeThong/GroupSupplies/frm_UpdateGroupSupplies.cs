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
    public partial class frm_UpdateGroupSupplies : DevExpress.XtraEditors.XtraForm
    {
        public frm_UpdateGroupSupplies( )
        {
            InitializeComponent( );
        }
        public Int64 id_group = 0;

        group_suppliesBus _group = new group_suppliesBus();

        private void frm_UpdateGroupSupplies_Load(object sender, EventArgs e)
        {
            if ( id_group != 0 )
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
            var groupSupplies = _group.getGroupSupplies(id_group);

            if ( groupSupplies != null )
            {
                var propertyName = groupSupplies.GetType( ).GetProperty("group_supplies_name").GetValue(groupSupplies, null);
                var pro = (propertyName == null) ? "" : propertyName.ToString( );

                txt_name.Text = pro;
            }
            else
            {
                messeage.error("Có lỗi, hãy kiểm tra lại !");
            }
        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            bool bUpdate = _group.update(txt_name.Text, id_group);

            if ( bUpdate )
            {
                messeage.success("Cập nhật thành công !");
            }
            else
            {
                messeage.error("Cập nhật thất bại !");
            }
        }
    }
}