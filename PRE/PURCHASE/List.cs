using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.PURCHASE
{
    public partial class List : Form
    {
        BUS.purchase customer = new BUS.purchase();
        BUS.purchase purchase;
        DAT.function_ fun = new DAT.function_();
        public static List instance;
        


        private int f_purchase_id;
        private string f_customer_id;
        private string f_customer_name;
        private string f_item_name;
        private int f_purchase_carat;
        private decimal f_purchase_weight;
        private double f_purchase_quantity;
        private decimal f_purchase_total_weight;
        private double f_purchase_unit_price;
        private double f_purchase_total_price;
        private double f_purchase_discount;
        private double f_purchase_net_total_price;
        private decimal f_purchase_making;
        private decimal f_purchase_wasting;
        private string f_item_code;
        private DateTime f_purchase_date;

        public List()
        {
            InitializeComponent();
            instance = this;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.List_KeyDown);
           
        }

        public bool Validation(string part)
        {
            if (btn_save.Text != "Save")
            {
                if (string.IsNullOrEmpty(this.txt_primary_key.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.txt_primary_key.Focus(); return false; }
            }

            if (part == "all")
            {
                if (string.IsNullOrEmpty(this.txt_customer_id.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.txt_customer_id.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_customer_name.Text.Trim()))
                { fun.validationMessge("Please Enter customer_name"); this.txt_customer_name.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_item_name.Text.Trim()))
                { fun.validationMessge("Please Enter item_name"); this.txt_item_name.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_carat.Text.Trim()))
                { fun.validationMessge("Please Enter carrot"); this.txt_carat.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_weight.Text.Trim()))
                { fun.validationMessge("Please Enter weight"); this.txt_weight.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_quantity.Text.Trim()))
                { fun.validationMessge("Please Enter quantity"); this.txt_quantity.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_total_weight.Text.Trim()))
                { fun.validationMessge("Please Enter Total Weight !"); this.txt_total_weight.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_unit_price.Text.Trim()))
                { fun.validationMessge("Please Enter unit_price"); this.txt_unit_price.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_total_price.Text.Trim()))
                { fun.validationMessge("Please Enter Total Weight !"); this.txt_total_price.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_discount.Text.Trim()))
                { fun.validationMessge("Please Enter discount"); this.txt_discount.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_net_total.Text.Trim()))
                { fun.validationMessge("Please Enter Net Total !"); this.txt_net_total.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_making.Text.Trim()))
                { fun.validationMessge("Please Enter Making"); this.txt_making.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_wasting.Text.Trim()))
                { fun.validationMessge("Please Enter Wasting"); this.txt_wasting.Focus(); return false; }

                else
                {
                    this.f_purchase_id = Convert.ToInt32(this.txt_primary_key.Text);
                    this.f_customer_id = this.txt_customer_id.Text.Trim();
                    this.f_customer_name = this.txt_customer_name.Text.Trim();
                    this.f_item_name = this.txt_item_name.Text.Trim();
                    this.f_purchase_carat = Convert.ToInt32(this.txt_carat.Text);
                    this.f_purchase_weight = Convert.ToDecimal(txt_weight.Text);
                    this.f_purchase_quantity = Convert.ToDouble(txt_quantity.Text);
                    this.f_purchase_total_weight = Convert.ToDecimal(txt_total_weight.Text);
                    this.f_purchase_unit_price = Convert.ToDouble(txt_unit_price.Text);
                    this.f_purchase_total_price = Convert.ToDouble(txt_total_price.Text);
                    this.f_purchase_discount = Convert.ToDouble(txt_discount.Text);
                    this.f_purchase_net_total_price = Convert.ToDouble(txt_net_total.Text);
                    this.f_purchase_making = Convert.ToDecimal(txt_making.Text);
                    this.f_purchase_wasting = Convert.ToDecimal(txt_wasting.Text);
                    this.f_purchase_date = Convert.ToDateTime(DateTime.Now.ToString());
                    this.f_item_code = txt_itemid.Text;
                }
            }
            return true;
        }

        public void Clear_Box()
        {
            try
            {
                txt_customer_id.Text = "";
                txt_customer_name.Text = "";
                txt_item_name.Text = "";
                txt_carat.Text = "";
                txt_weight.Text = "";
                txt_quantity.Text = "";
                txt_total_weight.Text = "";
                txt_unit_price.Text = "";
                txt_total_price.Text = "";
                txt_discount.Text = "";
                txt_net_total.Text = "";
                txt_making.Text = "";
                txt_wasting.Text = "";
                txt_customer_name.Focus();
                purchase.BindpurcaseDetails(dataGridView1);
            }
            catch { }
        }
      

     
        private void btn_save_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (Validation("all"))
                {
                    if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                    {

                        this.purchase = new BUS.purchase(f_purchase_id, f_item_code, f_customer_id, f_customer_name, f_item_name, f_purchase_carat, f_purchase_weight, f_purchase_quantity, f_purchase_total_weight, f_purchase_unit_price, f_purchase_total_price, f_purchase_discount, f_purchase_net_total_price, f_purchase_making, f_purchase_wasting, f_purchase_date);


                        if (btn_save.Text == "Save")
                        {

                            if (this.purchase.Savepurchase())
                            {
                                pb_loading.Value = 0;
                                pb_loading.Value = 100;
                                Clear_Box();

                            }
                            else
                            {

                            }
                        }

                        else if (btn_save.Text == "Edit")
                        {
                            this.purchase.Editpurchase();
                            pb_loading.Value = 0;
                            pb_loading.Value = 100;
                            Clear_Box();
                        }
                        else { fun.validationMessge("Something Wrong!"); }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void List_Load(object sender, EventArgs e)
        {
            try
            {
                purchase = new BUS.purchase();
                purchase.BindpurcaseDetails(dataGridView1);
            }
            catch
            {

            }
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                {
                    if (Validation("not"))
                    {
                        this.f_purchase_id = Convert.ToInt32(this.txt_primary_key.Text);
                        this.purchase = new BUS.purchase(f_purchase_id);
                        if (this.purchase.Deletepurchase())
                        {
                            Clear_Box();
                        }
                        else
                        {
                            fun.validationMessge("Something Wrong!");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_menu_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            PRE.PURCHASE.LOAD_CUSTOMER customerselect = new PRE.PURCHASE.LOAD_CUSTOMER();
            btn_search2.Focus(); PRE.PURCHASE.LOAD_CUSTOMER.instance.statues = "DB";
            customerselect.Show();
            
        }

        private void btn_search2_Click(object sender, EventArgs e)
        {
            PRE.PURCHASE.LOAD_ITEM Itemselect = new PRE.PURCHASE.LOAD_ITEM();
            txt_quantity.Focus(); PRE.PURCHASE.LOAD_ITEM.instance.statues = "DB";
            Itemselect.Show();
        }

        private void txt_weight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_total_weight.Text = Convert.ToString(Convert.ToDecimal(txt_weight.Text) * Convert.ToDecimal(txt_quantity.Text));
            }
            catch { txt_total_weight.Text = ""; }
        }

        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_total_weight.Text = Convert.ToString(Convert.ToDecimal(txt_weight.Text) * Convert.ToDecimal(txt_quantity.Text));
            }
            catch { txt_total_weight.Text = ""; }

            try
            {
                txt_total_price.Text = Convert.ToString(Convert.ToDecimal(txt_unit_price.Text) * Convert.ToDecimal(txt_quantity.Text));
            }
            catch { txt_total_price.Text = ""; }    
        }

        private void txt_unit_price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_total_price.Text = Convert.ToString(Convert.ToDecimal(txt_unit_price.Text) * Convert.ToDecimal(txt_quantity.Text));
            }
            catch { txt_total_price.Text = ""; }
        }

        private void txt_total_price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_net_total.Text = Convert.ToString(Convert.ToDecimal(txt_total_price.Text) - Convert.ToDecimal(txt_discount.Text));
            }
            catch { txt_net_total.Text = ""; }
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_net_total.Text = Convert.ToString(Convert.ToDecimal(txt_total_price.Text) - Convert.ToDecimal(txt_discount.Text));
            }
            catch { txt_net_total.Text = ""; }

        }

        

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                this.txt_primary_key.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txt_customer_id.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txt_customer_name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.txt_itemid.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.txt_item_name.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.txt_carat.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                this.txt_weight.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                this.txt_quantity.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                this.txt_total_weight.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                this.txt_unit_price.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                this.txt_total_price.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                this.txt_discount.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                this.txt_net_total.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                this.txt_making.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                this.txt_wasting.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                
                btn_save.Text = "Edit";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            purchase = new BUS.purchase(this.txt_search.Text.Trim());
            purchase.BindPurchaseDetailsName(dataGridView1);
            if (txt_search.Text == "") { purchase.BindpurcaseDetails(dataGridView1); }
        }

        private void List_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Handled)
            {
                if (e.KeyCode == Keys.F5)
                { Clear_Box(); }

                if (e.KeyCode == Keys.Delete)
                { btn_delete.PerformClick(); }

                if (e.KeyCode == Keys.Enter)
                { SendKeys.Send("{tab}"); e.Handled = e.SuppressKeyPress = true; }

                if (e.KeyCode == Keys.Escape)
                { this.Close(); }
            }
            e.Handled = true;
        }

        private void txt_wasting_TextChanged(object sender, EventArgs e)
        {
              try
            {
                if (radioButton4.Checked)
                {
                    f_purchase_wasting = Convert.ToDecimal((Convert.ToDecimal(txt_weight.Text) / 8) * Convert.ToDecimal(txt_wasting.Text));
                }
                else { f_purchase_wasting = Convert.ToDecimal(txt_wasting.Text); }
            }
            catch { }
        }

        private void radioButton4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton4.Checked)
                {
                    f_purchase_wasting = Convert.ToDecimal((Convert.ToDecimal(txt_weight.Text) / 8) * Convert.ToDecimal(txt_wasting.Text));
                }
                else { f_purchase_wasting = Convert.ToDecimal(txt_wasting.Text); }
            }
            catch { }
        }
    }
}
