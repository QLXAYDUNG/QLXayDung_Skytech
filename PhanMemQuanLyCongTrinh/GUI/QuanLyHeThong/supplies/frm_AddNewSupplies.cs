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
    public partial class frm_AddNewSupplies : DevExpress.XtraEditors.XtraForm
    {
        public frm_AddNewSupplies( )
        {
            InitializeComponent( );
        }

        vendorBus _vender = new vendorBus();
        unitBus _unit = new unitBus();
        group_suppliesBus _group = new group_suppliesBus();
        supliesBus _sup = new supliesBus();

        private Int64 idGroup = 0;
        private Int64 idUnit = 0;
        private Int64 idVender = 0;
        private string linkImage = "";

       
        #region Load
        private void frm_AddNewSupplies_Load(object sender, EventArgs e)
        {
            loadUnit();
            loadVender();
            loadGroupSupplies();
        }

        private void loadUnit()
        {
            var getAllUnit = _unit.getAllUnits();
            lue_Units.Properties.DataSource = getAllUnit;
            lue_Units.Properties.ValueMember = "unit_id";
            lue_Units.Properties.DisplayMember = "unit_name";
        }

        private void loadVender()
        {
            var getAllVender = _vender.loadAllVendor();

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

        private void dongformUnit(object sender, EventArgs e)
        {
            loadUnit();
        }

        private void dongformVender(object sender, EventArgs e)
        {
            loadVender();
        }

        private void dongformGroupSupplies(object sender, EventArgs e)
        {
            loadGroupSupplies();
        }
        #endregion EndLoad

        #region Event

        // add New NCC
        private void btn_AddNewVender_Click(object sender, EventArgs e)
        {
            frm_NewVendor frm = new frm_NewVendor();
            frm.FormClosed += new FormClosedEventHandler(dongformVender);
            frm.ShowDialog();
        }
        // add New DVT
        private void btn_AddNewUnit_Click(object sender, EventArgs e)
        {
            frm_AddNewUnit frm = new frm_AddNewUnit( );
            frm.FormClosed += new FormClosedEventHandler(dongformUnit);
            frm.ShowDialog( );
        }

        private void btn_AddNewGroupSupplies_Click(object sender, EventArgs e)
        {
            frm_AddNewGroupSupplies frm = new frm_AddNewGroupSupplies( );
            frm.FormClosed += new FormClosedEventHandler(dongformGroupSupplies);
            frm.ShowDialog( );
        }

        private void lue_GroupSuplies_EditValueChanged(object sender, EventArgs e)
        {
            idGroup = (Int64) lue_GroupSuplies.EditValue;
        }

        private void lue_Units_EditValueChanged(object sender, EventArgs e)
        {
            idUnit = (Int64) lue_Units.EditValue;
        }

        private void lue_Vender_EditValueChanged(object sender, EventArgs e)
        {
            idVender = (Int64) lue_Vender.EditValue;
        }



        // Them Moi 
        private void btn_AddNew_Click(object sender, EventArgs e)
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
                    if (idUnit == 0)
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
                            if (txt_InPutPrice.Text == "")
                            {
                                messeage.error("Bạn chưa nhập Giá nhập !");
                            }
                            else
                            {
                                if (txt_OutPutPrice.Text == "")
                                {
                                    messeage.error("Bạn chưa nhập Giá bán !");
                                }
                                else
                                {
                                    if (txt_Ton.Text == "")
                                    {
                                        messeage.error("Bạn chưa số lượng Tồn kho !");
                                    }
                                    else
                                    {
                                        ST_supply sup = new ST_supply();

                                        sup.group_supplies_id = idGroup;
                                        sup.unit_id = idUnit;
                                        sup.vendor_id = idVender;
                                        sup.supplies_name = txt_Name.Text;
                                        sup.supplies_description = txt_Description.Text;
                                        sup.supplies_entry_price = Decimal.Parse(txt_InPutPrice.Text);
                                        sup.supplies_commercial_price = Decimal.Parse(txt_OutPutPrice.Text);
                                        sup.supplies_survive_the_norm = Int16.Parse(txt_Ton.Text);

                                        Decimal price_Giam = 0;
                                        if (txt_PriceGiam.Text == "")
                                        {
                                        price_Giam = 0;
                                        }
                                        else
                                        {
                                            price_Giam = Decimal.Parse(txt_PriceGiam.Text);
                                        }
                                        
                                        sup.supplies_wholesale_price = price_Giam;

                                        sup.employee_created = frm_Main.Vitual_id;

                                        if ( linkImage != "" )
                                        {
                                            sup.supplies_image = imageToByteArray(pic_Logo.Image);
                                        }


                                        bool bInsert = _sup.insertSuplies(sup);
                                       
                                       if (bInsert)
                                       {
                                            messeage.success("Thêm Mới Thành Công !");
                                            this.Close();
                                       }
                                       else
                                       {
                                        messeage.error("Không Thể Thêm Mới");
                                       }
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
        private void btn_Img_Click(object sender, EventArgs e)
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