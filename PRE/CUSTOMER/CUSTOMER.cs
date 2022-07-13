using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.CUSTOMER
{
    public partial class CUSTOMER : Form
    {
        private string form_customer_id;
        private string form_customer_name;
        private string form_customer_address;
        private string form_customer_phoneno;
        private string form_customer_nicno;
        private string form_customer_type;
        public string Status;
        public static CUSTOMER instance;

        BUS.customer customer;
        DAT.function_ fun = new DAT.function_();
        
        public CUSTOMER()
        {
            InitializeComponent();
            instance = this;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CUSTOMER_KeyDown);
        }

        public void Clear_Box()
        {
            try
            {
                txt_customer_id.Visible = false;
                customer.BindCustomerDetails(dataGridView1);
                txt_customer_id.Text = "";
                txt_customer_name.Text = "";
                txt_customer_address.Text = "";
                txt_customer_phoneno.Text = "";
                txt_customer_nicno.Text = "";
                txt_customer_type.Text = "";
                btn_save.Text = "Save";
                txt_customer_name.Focus();
            }
            catch { }
        }

        public bool Validation(string part)
        {
            if (btn_save.Text != "Save")
            {
                if (string.IsNullOrEmpty(this.txt_customer_id.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.txt_customer_id.Focus(); return false; }
            }
            if (part == "all")
            {
                if (string.IsNullOrEmpty(this.txt_customer_name.Text.Trim()))
                { fun.validationMessge("Please Enter Name !"); this.txt_customer_name.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_customer_type.Text.Trim()))
                { fun.validationMessge("Please Select Type !"); this.txt_customer_type.Focus(); return false; }

                else
                {
                    if (string.IsNullOrEmpty(txt_customer_id.Text.Trim())) { this.form_customer_id = null; }
                    else { this.form_customer_id = this.txt_customer_id.Text.Trim(); }
                    this.form_customer_name = this.txt_customer_name.Text.Trim();
                    this.form_customer_address = this.txt_customer_address.Text.Trim();
                    this.form_customer_phoneno = this.txt_customer_phoneno.Text.Trim();
                    this.form_customer_nicno = this.txt_customer_nicno.Text.Trim();
                    this.form_customer_type = this.txt_customer_type.Text.Trim();
                }
            }
            return true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {


                if (Validation("all"))
                {
                    if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                    {

                        this.customer = new BUS.customer(form_customer_id, form_customer_name, form_customer_address, form_customer_phoneno, form_customer_nicno, form_customer_type);


                        if (btn_save.Text == "Save")
                        {

                            if (this.customer.Savecustomer())
                            {
                                pb_loading.Value = 0;
                                pb_loading.Value = 100;
                                Clear_Box();
                            }
                            else{}
                        }

                        else if (btn_save.Text == "Edit")
                        {
                            this.customer.Editcustomer();
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                {
                    if (Validation("not"))
                    {
                        this.form_customer_id = (this.txt_customer_id.Text);
                        this.customer = new BUS.customer(txt_customer_id.Text);
                        if (this.customer.Deletecustomer())
                        {
                            pb_loading.Value = 0;
                            pb_loading.Value = 100;
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

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txt_customer_id.Visible = true;
                this.txt_customer_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txt_customer_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txt_customer_address.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.txt_customer_phoneno.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.txt_customer_nicno.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.txt_customer_type.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                btn_save.Text = "Edit";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CUSTOMER_Load(object sender, EventArgs e)
        {
            customer = new BUS.customer();
            customer.BindCustomerDetails(dataGridView1);
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text == "") { customer.BindCustomerDetails(dataGridView1); }
            else
            {
                customer.tagsearch(txt_search.Text);
                customer.BindCustomeryDetaisSearch(dataGridView1);
            }
                
        }

        private void CUSTOMER_KeyDown(object sender, KeyEventArgs e)
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
