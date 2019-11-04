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
    public partial class frm_BuildingContractor : DevExpress.XtraEditors.XtraForm
    {
        BUS.buildingContractorBus buildingContractorBus = new BUS.buildingContractorBus();
          
        int index;
        
        public frm_BuildingContractor()
        {
            InitializeComponent();
        }

        private void loadAllBuildingContractor()
        {
            grdc_BuidingContractor.DataSource = buildingContractorBus.loadAllBuildingContractor();
                
        }
        private void frm_BuildingContractor_Load(object sender, EventArgs e)
        {
            loadAllBuildingContractor();
        }

        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadAllBuildingContractor();
        }

        private void grdv_BuidingContractor_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
           
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                

                if (grdv_BuidingContractor.RowCount > 0)
                {
                    Int64 buildingContractorId = Convert.ToInt64( grdv_BuidingContractor.GetRowCellValue(index, "building_contractor_id").ToString());
                    string buildingContractorName = grdv_BuidingContractor.GetRowCellValue(index, "building_contractor_name").ToString();
                    

                    bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Thầu '", buildingContractorName);

                    if (boolCheckDelete == true)
                    {
                        bool boolDeleteBuildContractor = buildingContractorBus.deleteBuildingContractor(buildingContractorId);
                        if (boolDeleteBuildContractor == true)
                        {
                            messeage.success("Xóa Thầu Xây Dựng Thành Công!");

                            buildingContractorId = 0;

                            loadAllBuildingContractor();

                        }
                        else
                        {
                            messeage.error("Xóa Thầu Xây Dựng Không Thất Bại!");

                        }
                    }

                }
                else
                {
                    messeage.error("Không Có gì Để Xóa!!");
                }
            
            
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            frm_NewBuildingContractor frm = new frm_NewBuildingContractor();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.buildingContractorId = 0;
            frm.ShowDialog();
            
        }


        private void dongform(object sender, EventArgs e)
        {
            loadAllBuildingContractor();
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_BuidingContractor.RowCount > 0)
            {
                frm_NewBuildingContractor frm = new frm_NewBuildingContractor();
                frm.FormClosed += new FormClosedEventHandler(dongform);
                frm.buildingContractorId = Convert.ToInt64(grdv_BuidingContractor.GetRowCellValue(index, "building_contractor_id").ToString());
                frm.ShowDialog();
            }
            else
            {
                messeage.error("Không Có gì Để Sửa!!!");
            }
        }
    }
}