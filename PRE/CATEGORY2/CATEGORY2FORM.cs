using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.CATEGORY2
{
    public partial class CATEGORY2FORM : Form
    {
        private int form_id;
        private string form_description;
        private int form_days;
        private double form_amount;

       BUS.category2 category2;
       DAT.function_ fun = new DAT.function_();

        public CATEGORY2FORM()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CATEGORY2FORM_KeyDown);
        }

        public void Clear_Box()
        {
            try
            {
                txt_id.Visible = false;
                category2.BindCategoryDetaisl(dataGridView1);
                txt_id.Text = "";
                txt_description.Text = "";
                txt_days.Text = "";
                txt_amount.Text = "";
                btn_save.Text = "Save";
                txt_description.Focus();
            }
            catch { }
        }

        private void CATEGORY2FORM_Load(object sender, EventArgs e)
        {
            category2 = new BUS.category2();
            category2.BindCategoryDetaisl(dataGridView1);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                    if (Validation("all"))
                    {
                        if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                        {

                            this.category2 = new BUS.category2(form_id,form_description,form_days,form_amount);

                           
                            if (btn_save.Text == "Save")
                            {

                                if (this.category2.Saveshop())
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
                                this.category2.Editshop();
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
                        this.form_id = Convert.ToInt32(this.txt_id.Text);
                        this.category2 = new Jewellery_System.BUS.category2(form_id);
                        if (this.category2.Deleteshop())
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

        public bool Validation(string part)
        {
            if (btn_save.Text != "Save")
            {
                if (string.IsNullOrEmpty(this.txt_id.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.txt_id.Focus(); return false; }       
            }

            if (part == "all")
            {
                if (string.IsNullOrEmpty(this.txt_description.Text.Trim()))
                { fun.validationMessge("Please Enter Description !"); this.txt_description.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_days.Text.Trim()))
                { fun.validationMessge("Please Enter Days !"); this.txt_days.Focus(); return false; }
                if (string.IsNullOrEmpty(this.txt_amount.Text.Trim()))
                { fun.validationMessge("Please Enter Amount !"); this.txt_amount.Focus(); return false; }

                else
                {
                    if (string.IsNullOrEmpty(txt_id.Text.Trim())) { this.form_id = 0; }
                    else { this.form_id = Convert.ToInt32(txt_id.Text); }
                    this.form_description = this.txt_description.Text.Trim();
                    this.form_days = Convert.ToInt32(this.txt_days.Text.Trim());
                    this.form_amount = Convert.ToDouble(this.txt_amount.Text.Trim());

                }
            }
            return true;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txt_id.Visible = true;
                this.txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txt_description.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txt_days.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.txt_amount.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                btn_save.Text = "Edit"; txt_description.Focus();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Refresh();
            
        }

        private void btn_refresh_Enter(object sender, EventArgs e)
        {
            this.dataGridView1.Refresh();
        }

        private void txt_days_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_days.Text, "[^0-9]"))
            {
                MessageBox.Show("Days are not in Valid Format !");
                txt_days.Text = txt_days.Text.Remove(txt_days.Text.Length - 1);
            }
        }

        private void CATEGORY2FORM_Click(object sender, EventArgs e)
        {
            Clear_Box();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }

        private void txt_description_TextChanged(object sender, EventArgs e)
        {}

        private void CATEGORY2FORM_KeyDown(object sender, KeyEventArgs e)
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

        private void btn_menu_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }
    }
}
