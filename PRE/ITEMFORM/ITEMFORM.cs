using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Jewellery_System.PRE.ITEMFORM
{
    public partial class ITEMFORM : Form
    {
        private int form_item_code;
        private string form_item_name;
        private int form_category_id;
        private string form_categories;
        private double form_amount;
        private DateTime form_item_date;
        private decimal form_item_weight;
        private int form_item_carat;
        private long shift_id;
        public string Status;
        public static ITEMFORM instance;

        BUS.itemform itemform;
        DAT.function_ fun = new DAT.function_();

        public ITEMFORM()
        {
            InitializeComponent();
            instance = this;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ITEMFORM_KeyDown);
        }

        public void Clear_Box()
        {
            try
            {
                itemform.BindItemDetaislFull(dataGridView1);
                txt_item_code.Text = "";
                txt_item_name.Text = "";
                txt_category_id.Text = "";
                txt_categories.Text = "";
                txt_item_amount.Text = "";
                txt_item_carat.Text = "";
                txt_item_weight.Text = "";
                btn_save.Text = "Save";
                txt_item_code.Focus();
            }
            catch { }
        }

        public bool Validation(string part)
        {
            if (btn_save.Text != "Save")
            {
                if (string.IsNullOrEmpty(this.txt_item_code.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.txt_item_code.Focus(); return false; }
            }
            if (part == "all")
            {
                if (string.IsNullOrEmpty(this.txt_item_name.Text.Trim()))
                { fun.validationMessge("Please Enter ItemName !"); this.txt_item_name.Focus(); return false; }//2 Itemname
                if (string.IsNullOrEmpty(this.txt_category_id.Text.Trim()))
                { fun.validationMessge("Please Enter Category ID !"); this.txt_category_id.Focus(); return false; }// 3  Cat ID         
                if (string.IsNullOrEmpty(this.txt_categories.Text.Trim()))
                { fun.validationMessge("Please Enter Categories !"); this.txt_categories.Focus(); return false; } //4    Catog       
                if (string.IsNullOrEmpty(this.txt_item_amount.Text.Trim()))
                { fun.validationMessge("Please Enter Amount !"); this.txt_item_amount.Focus(); return false; }//5 Amount
                if (string.IsNullOrEmpty(this.txt_item_weight.Text.Trim()))
                { fun.validationMessge("Please Enter Weight !"); this.txt_item_weight.Focus(); return false; }//7 Weight
                if (string.IsNullOrEmpty(this.txt_item_carat.Text.Trim()))
                { fun.validationMessge("Please Enter Carat !"); this.txt_item_carat.Focus(); return false; }//8 Carat
                else
                {
                    if (string.IsNullOrEmpty(txt_item_code.Text.Trim())) { this.form_item_code = 0; }
                    else { this.form_item_code = Convert.ToInt32(txt_item_code.Text); }
                    this.form_item_name = this.txt_item_name.Text.Trim();
                    this.form_category_id = Convert.ToInt32(this.txt_category_id.SelectedValue.ToString());
                    this.form_categories = this.txt_categories.Text.Trim();
                    this.form_amount = Convert.ToDouble(this.txt_item_amount.Text.Trim());
                    this.form_item_date = Convert.ToDateTime(DateTime.Now.ToString());
                    this.form_item_weight = Convert.ToDecimal(this.txt_item_weight.Text.Trim());
                    this.form_item_carat = Convert.ToInt32(this.txt_item_carat.Text.Trim());
                    this.shift_id = Convert.ToInt32(txt_shift_id.Text);
                }
            }

            return true;
        }
        public void BindCategory()
        {
            try
            {
                BUS.catogery1 cat = new BUS.catogery1();
                this.txt_category_id.DataSource = cat.Getcat1();
                this.txt_category_id.ValueMember = "id";
                this.txt_category_id.DisplayMember = "discription";
                cat = null;
            }
            catch 
            { 
            }
            
        
        }

        private void ITEMFORM_Load(object sender, EventArgs e)
        {
            try
            {
                itemform = new BUS.itemform();
                itemform.BindItemDetaislFull(dataGridView1);
                BindCategory();
            }
            catch
            {
 
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {


                if (Validation("all"))
                {
                    if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                    {

                        this.itemform = new BUS.itemform(form_item_code, form_item_name, form_category_id, form_categories, form_amount, form_item_date, form_item_weight, form_item_carat, shift_id);


                        if (btn_save.Text == "Save")
                        {

                            if (this.itemform.saveItem())
                            {
                                Clear_Box();

                            }
                            else
                            {}
                        }

                        else if (btn_save.Text == "Edit")
                        {
                            this.itemform.editItem();
                            Clear_Box();
                        }
                        else { fun.validationMessge("Something Wrong!"); }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                {
                    if (Validation("not"))
                    {
                        this.form_item_code = Convert.ToInt32(this.txt_item_code.Text);
                        this.itemform = new BUS.itemform(form_item_code);
                        if (this.itemform.deleteItem())
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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.txt_item_code.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txt_item_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txt_category_id.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.txt_item_amount.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.txt_categories.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                this.txt_item_weight.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                this.txt_item_carat.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void txt_category_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                form_category_id = Convert.ToInt32(txt_category_id.SelectedValue.ToString());
                ///  form_category_id = txt_category_id.SelectedValue;
                //MessageBox.Show(txt_category_id.SelectedValue.ToString());
            }
            catch
            { }
            
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            itemform = new BUS.itemform(this.txt_search.Text.Trim());
            itemform.BindItemyDetaisSearch(dataGridView1);
            if (txt_search.Text == "") { itemform.BindItemDetaislFull(dataGridView1); }
        }

        private void ITEMFORM_KeyDown(object sender, KeyEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }




    }
}
