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
    public partial class frm_Update_Unit : DevExpress.XtraEditors.XtraForm
    {
        public frm_Update_Unit( )
        {
            InitializeComponent( );
        }

        unitBus _unit = new unitBus( );

        public Int64 idUnit = 0;

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close( );
        }

        #region Load
        private void LoadData( )
        {
            if ( idUnit == 0 )
            {
                messeage.error("Không thể tải dữ liệu !");
            }
            else
            {
                var datasource = _unit.getUnits(idUnit);

                if ( datasource != null )
                {
                    var propertyName = datasource.GetType( ).GetProperty("unit_name").GetValue(datasource, null);
                    var unit_name = (propertyName == null) ? "" : propertyName.ToString( );

                    txt_Name.Text = unit_name;
                }
                else
                {
                    messeage.error("Không thể tải dữ liệu !");
                }
            }

        }

        private void frm_Update_Unit_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "")
            {
                messeage.error("Bạn Chưa Nhập Tên Đơn Vị !");
            }
            else{
                ST_unit unit = new ST_unit( )
                {
                    unit_name = txt_Name.Text,
                    unit_id = idUnit
                };

                bool bUpdate = _unit.updateUnit(unit);
                if ( bUpdate )
                {
                    messeage.success("Cập Nhật Thành Công !");
                }
                else
                {
                    messeage.error("Cập nhật thất bại !");
                }

            }
            
        }

        #endregion EndLoad

        

        
    }
}