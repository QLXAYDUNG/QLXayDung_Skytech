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
    public partial class frm_AddNewEnterCouponSupplies : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public frm_AddNewEnterCouponSupplies( )
        {
            InitializeComponent( );
        }

        supliesBus _sup = new supliesBus();
        private Int64 idSupplies = 0;

        List<Add_Supplies_And_Quantity> listObject = new List<Add_Supplies_And_Quantity>( );
        List<Int64> ListID = new List<Int64>();

        private void frm_AddNewEnterCouponSupplies_Load(object sender, EventArgs e)
        {
            LoadSearchLookUp();

            repositoryItem_quantity.EditValueChanged += new EventHandler(repositoryItemComboBox1_EditValueChanged);

            StyleDevxpressGridControl.styleGridControl(gridControl1, gridView1);
        }

        private void repositoryItemComboBox1_EditValueChanged(object sender, EventArgs e)
        {
            //The Current selected value in the dropdownlist  
            TextEdit t = sender as TextEdit;
            string editvalue =  t.EditValue.ToString();
            messeage.success(editvalue);

        }
  
        

        #region Load

        private void LoadSearchLookUp( )
        {
            slue_Supplies.Properties.DataSource = _sup.getAllSuplies_LoadSerach( );
            slue_Supplies.Properties.ValueMember = "supplies_id";
            slue_Supplies.Properties.DisplayMember = "supplies_name";
            slue_Supplies.Properties.ShowClearButton = false;
        }

        

        #endregion End Load

        #region Event
        private void slue_Supplies_EditValueChanged(object sender, EventArgs e)
        {
            try{
                idSupplies = Int64.Parse(slue_Supplies.EditValue.ToString( ));
                
                var totalRow = listObject.Count;

                if ( totalRow > 0 )
                {
                    // tim trong list co khong roi add vao
                    bool check = false;
                    foreach ( var item in listObject )
                    {
                        if ( item.id == idSupplies )
                        {
                            // update quantity len 1
                            item.quantity += 1;
                            check = true;
                            break;
                        }
                    }

                    if ( check == false )
                    {
                        Add_Supplies_And_Quantity item = new Add_Supplies_And_Quantity( );
                        item.id = idSupplies;
                        item.quantity = 1;

                        listObject.Add(item);


                        //ListID.Add(idSupplies);
                    }

                }
                else
                {
                    // add vao
                    Add_Supplies_And_Quantity item = new Add_Supplies_And_Quantity( );
                    item.id = idSupplies;
                    item.quantity = 1;

                    listObject.Add(item);
                    //ListID.Add(idSupplies);
                }



                // update GridView
                var datasource = from sup in db.ST_supplies
                                 join ven in db.ST_vendors on sup.vendor_id equals ven.vendor_id
                                 join unit in db.ST_units on sup.unit_id equals unit.unit_id
                                 join group_sup in db.ST_group_supplies on sup.group_supplies_id equals group_sup.group_supplies_id

                                 select new
                                 {
                                     sup.supplies_id,
                                     sup.supplies_id_custom,
                                     sup.supplies_name,
                                     unit.unit_name,
                                     group_sup.group_supplies_name,
                                     sup.supplies_wholesale_price,
                                     sup.supplies_entry_price,

                                 };
                
                
                DataTable table = new DataTable();

                table.Columns.Add("ID", typeof(string));
                table.Columns.Add("ID_custom", typeof(string));
                table.Columns.Add("supplies_name", typeof(string));
                table.Columns.Add("supplies_unit", typeof(string));
                table.Columns.Add("supplies_quantity", typeof(Int64));
                table.Columns.Add("supplies_price", typeof(Decimal));
                table.Columns.Add("supplies_wholesale_price", typeof(Decimal));
                table.Columns.Add("total", typeof(Decimal));

                var count = listObject.Count;
                foreach ( var item in listObject )
                {
                    foreach ( var itemList in datasource )
                    {
                        if ( item.id == itemList.supplies_id )
                        {
                            DataRow newRow = table.NewRow();
                            newRow["ID"] = itemList.supplies_id; // remove this line
                            newRow["ID_custom"] = itemList.supplies_id_custom; // remove this line
                            newRow["supplies_name"] = itemList.supplies_name;
                            newRow["supplies_unit"] = itemList.unit_name;
                            newRow["supplies_quantity"] = item.quantity;
                            newRow["supplies_price"] = itemList.supplies_entry_price;
                            newRow["supplies_wholesale_price"] = itemList.supplies_wholesale_price;
                            newRow["total"] = item.quantity * itemList.supplies_entry_price;

                            table.Rows.Add(newRow);

                            break;
                        }
                    }
                }
                gridControl1.DataSource = table;

                var total_price_supplies = double.Parse(gridView1.Columns["total"].SummaryItem.SummaryValue.ToString());
                StyleDevxpressGridControl.styleTextBoxVND(txt_total);
                txt_total.Text = total_price_supplies.ToString();
            }
            catch(Exception)
            {
                messeage.error("Có lỗi hãy kiểm tra lại !!");
            }
            
        }

        private void dongformSearch(object sender, EventArgs e)
        {
            LoadSearchLookUp( );
        }
        #endregion End Event

        private void btn_AddNewSuppelies_Click(object sender, EventArgs e)
        {
            frm_AddNewSupplies frm = new frm_AddNewSupplies();
            frm.FormClosed += new FormClosedEventHandler(dongformSearch);
            frm.ShowDialog();
        }

        private void txt_percent_discount_EditValueChanged(object sender, EventArgs e)
        {
            var total_price_supplies = double.Parse(gridView1.Columns["total"].SummaryItem.SummaryValue.ToString( ));
            var get_percent = Int32.Parse(txt_percent_discount.EditValue.ToString( ));
            var percent = 0;

            if ( get_percent != null || get_percent != 0 )
            {
                if ( get_percent >= 1 && get_percent <= 100 )
                {
                    percent = get_percent;
                }
                else
                {
                    percent = 0;
                }
            }
            
            txt_percent_discount.Text = percent.ToString();
            
            if (percent != 0)
            {
                txt_total_price.Text = ((percent * total_price_supplies)/100).ToString();
            }
            else
            {
                txt_total_price.Text = total_price_supplies.ToString( );
            }

        }

        private void txt_percent_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

       



    }
}