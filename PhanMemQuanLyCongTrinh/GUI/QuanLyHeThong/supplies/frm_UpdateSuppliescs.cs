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
using System.IO;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_UpdateSuppliescs : DevExpress.XtraEditors.XtraForm
    {
        public frm_UpdateSuppliescs( )
        {
            InitializeComponent( );
        }

        vendorBus _vender = new vendorBus( );
        unitBus _unit = new unitBus( );
        group_suppliesBus _group = new group_suppliesBus( );
        supliesBus _sup = new supliesBus( );

        private Int64 idGroup = 0;
        private Int64 idUnit = 0;
        private Int64 idVender = 0;
        private string linkImage = "";

        public Int64 id_Suppliesc = 0;

        private void frm_UpdateSuppliescs_Load(object sender, EventArgs e)
        {

            if ( id_Suppliesc != 0 )
            {
                loadUnit( );
                loadVender( );
                loadGroupSupplies( );

                loadSuppliescs( );
            }
            else
            {
                messeage.error("Có lỗi, hãy kiểm tra lại !");
            }
        }

        #region Load

        private void loadUnit( )
        {
            var getAllUnit = _unit.getAllUnits( );
            lue_Units.Properties.DataSource = getAllUnit;
            lue_Units.Properties.ValueMember = "unit_id";
            lue_Units.Properties.DisplayMember = "unit_name";
        }

        private void loadVender( )
        {
            var getAllVender = _vender.loadAllVendor( );

            lue_Vender.Properties.DataSource = getAllVender;
            lue_Vender.Properties.ValueMember = "vendor_id";
            lue_Vender.Properties.DisplayMember = "vendor_name";
        }

        private void loadGroupSupplies( )
        {
            var getAllloadGroupSupplies = _group.getAllGroup( );

            lue_GroupSuplies.Properties.DataSource = getAllloadGroupSupplies;
            lue_GroupSuplies.Properties.ValueMember = "group_supplies_id";
            lue_GroupSuplies.Properties.DisplayMember = "group_supplies_name";
        }
        private void loadSuppliescs()
        {
            var getSupplies = _sup.getSuplies(id_Suppliesc);

            if ( getSupplies != null )
            {
                var property_supplies_name = getSupplies.GetType( ).GetProperty("supplies_name").GetValue(getSupplies, null);
                var supplies_name = (property_supplies_name == null) ? "" : property_supplies_name.ToString( );

                var property_unit_id = getSupplies.GetType( ).GetProperty("unit_id").GetValue(getSupplies, null);
                var unit_id = (property_unit_id == null) ? "" : property_unit_id.ToString( );


                var property_group_supplies_id = getSupplies.GetType( ).GetProperty("group_supplies_id").GetValue(getSupplies, null);
                var group_supplies_id = (property_group_supplies_id == null) ? "" : property_group_supplies_id.ToString( );

                var property_vendor_id = getSupplies.GetType( ).GetProperty("vendor_id").GetValue(getSupplies, null);
                var vendor_id = (property_vendor_id == null) ? "" : property_vendor_id.ToString( );

                var property_supplies_description = getSupplies.GetType( ).GetProperty("supplies_description").GetValue(getSupplies, null);
                var supplies_description = (property_supplies_description == null) ? "" : property_supplies_description.ToString( );

                var property_supplies_entry_price = getSupplies.GetType( ).GetProperty("supplies_entry_price").GetValue(getSupplies, null);
                var supplies_entry_price = (property_supplies_entry_price == null) ? "" : property_supplies_entry_price.ToString( );

                var property_supplies_wholesale_price = getSupplies.GetType( ).GetProperty("supplies_wholesale_price").GetValue(getSupplies, null);
                var supplies_wholesale_price = (property_supplies_wholesale_price == null) ? "" : property_supplies_wholesale_price.ToString( );


                var property_supplies_commercial_price = getSupplies.GetType( ).GetProperty("supplies_commercial_price").GetValue(getSupplies, null);
                var supplies_commercial_price = (property_supplies_commercial_price == null) ? "" : property_supplies_commercial_price.ToString( );

                var property_supplies_survive_the_norm = getSupplies.GetType( ).GetProperty("supplies_survive_the_norm").GetValue(getSupplies, null);
                var supplies_survive_the_norm = (property_supplies_survive_the_norm == null) ? "" : property_supplies_survive_the_norm.ToString( );


                // Do du lieu vao
                txt_Name.Text = supplies_name;
                lue_Units.ItemIndex = int.Parse(unit_id) - 1;
                lue_Vender.ItemIndex = int.Parse(vendor_id) - 1;
                lue_GroupSuplies.ItemIndex = int.Parse(group_supplies_id) - 1;

                txt_Description.Text = supplies_description;
                txt_InPutPrice.Text = supplies_entry_price;
                txt_OutPutPrice.Text = supplies_commercial_price;
                txt_PriceGiam.Text = supplies_wholesale_price;
                txt_Ton.Text = supplies_survive_the_norm;

                idGroup = Int64.Parse(idGroup.ToString()) ;
                idUnit = Int64.Parse(group_supplies_id);
                idVender = Int64.Parse(vendor_id);
            }
            else
            {
                messeage.error("Có lỗi, hãy kiểm tra lại !");
            }
        }
        private void dongformUnit(object sender, EventArgs e)
        {
            loadUnit( );
        }

        private void dongformVender(object sender, EventArgs e)
        {
            loadVender( );
        }

        private void dongformGroupSupplies(object sender, EventArgs e)
        {
            loadGroupSupplies( );
        }
        #endregion EndLoad

        #region Event
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if ( txt_Name.Text == "" )
            {
                messeage.error("Bạn chưa nhập Tên Vật Tư !");
            }
            else
            {
                if ( idGroup == 0 )
                {
                    messeage.error("Bạn chưa chọn Nhóm Vật Tư !");
                }
                else
                {
                    if ( idUnit == 0 )
                    {
                        messeage.error("Bạn chưa chọn Đơn Vị Vật Tư !");
                    }
                    else
                    {
                        if ( idVender == 0 )
                        {
                            messeage.error("Bạn chưa chọn Nhà Cung Cấp !");
                        }
                        else
                        {
                            if ( txt_InPutPrice.Text == "" )
                            {
                                messeage.error("Bạn chưa nhập Giá nhập !");
                            }
                            else
                            {
                                if ( txt_OutPutPrice.Text == "" )
                                {
                                    messeage.error("Bạn chưa nhập Giá bán !");
                                }
                                else
                                {
                                    if ( txt_Ton.Text == "" )
                                    {
                                        messeage.error("Bạn chưa số lượng Tồn kho !");
                                    }
                                    else
                                    {

                                        ST_supply sup = new ST_supply( );

                                        sup.supplies_id = id_Suppliesc;
                                        sup.group_supplies_id = Int64.Parse(lue_GroupSuplies.EditValue.ToString( )); ; ;
                                        sup.unit_id = Int64.Parse(lue_Units.EditValue.ToString());
                                        sup.vendor_id = Int64.Parse(lue_Vender.EditValue.ToString( )); ;
                                        sup.supplies_name = txt_Name.Text;
                                        sup.supplies_description = txt_Description.Text;
                                        sup.supplies_entry_price = Decimal.Parse(txt_InPutPrice.Text);
                                        sup.supplies_commercial_price = Decimal.Parse(txt_OutPutPrice.Text);
                                        sup.supplies_survive_the_norm = Int16.Parse(txt_Ton.Text);

                                        Decimal price_Giam = 0;
                                        if ( txt_PriceGiam.Text == "" )
                                        {
                                            price_Giam = 0;
                                        }
                                        else
                                        {
                                            price_Giam = Decimal.Parse(txt_PriceGiam.Text);
                                        }

                                        sup.supplies_wholesale_price = price_Giam;


                                        if ( linkImage != "" )
                                        {
                                            sup.supplies_image = imageToByteArray(pic_Logo.Image);
                                        }


                                        bool bUpdate = _sup.updateSuplies(sup);

                                        if ( bUpdate )
                                        {
                                            messeage.success("Cập Nhật Thành Công !");
                                        }
                                        else
                                        {
                                            messeage.error("Không Thể Cập Nhật");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btn_AddNewGroupSupplies_Click(object sender, EventArgs e)
        {
            frm_AddNewGroupSupplies frm = new frm_AddNewGroupSupplies( );
            frm.FormClosed += new FormClosedEventHandler(dongformGroupSupplies);
            frm.ShowDialog( );
        }

        //byte[] -> ảnh
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        //ảnh -> byte[]
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream( );
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray( );
        }

        private void btn_AddNewUnit_Click(object sender, EventArgs e)
        {
            frm_AddNewUnit frm = new frm_AddNewUnit( );
            frm.FormClosed += new FormClosedEventHandler(dongformUnit);
            frm.ShowDialog( );
        }

        private void btn_AddNewVender_Click(object sender, EventArgs e)
        {
            frm_NewVendor frm = new frm_NewVendor( );
            frm.FormClosed += new FormClosedEventHandler(dongformVender);
            frm.ShowDialog( );
        }

        private void lue_GroupSuplies_EditValueChanged(object sender, EventArgs e)
        {
            idGroup = Int64.Parse( lue_GroupSuplies.EditValue.ToString());
        }

        private void lue_Units_EditValueChanged(object sender, EventArgs e)
        {
            idUnit = Int64.Parse(lue_Units.EditValue.ToString());
        }

        private void lue_Vender_EditValueChanged(object sender, EventArgs e)
        {
            idVender = Int64.Parse(lue_Vender.EditValue.ToString());
        }

        private void btn_Img_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog( );
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";

            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if ( openFile.ShowDialog( ) == DialogResult.OK )
            {
                linkImage = openFile.FileName;
                pic_Logo.Image = Image.FromFile(linkImage);

            }
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close( );
        }

        #endregion EndEvent

        

        

        
       
    }
}