using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.CATEGORY1
{
    public partial class Catogery1 : Form
    {
        private int Catogery1id;
        private string Catogery1discription;

        BUS.catogery1 catogery1;
        DataTable dt;
        DAT.function_ fun = new DAT.function_();

        public Catogery1()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Catogery1_KeyDown);

        }

        public void Progress_And_Clear()
        {
            try
            {
                pb_loading.Value = 0; pb_loading.Value = 100;
                discriptiontxt.Text = "";
                categoryidlbl.Text = "";
                btn_save.Text = "Save"; discriptiontxt.Focus();
                catogery1.BindCategory2Details(dataGridView1);
            }
            catch { }
        }


        /*-----------------------------------------SAVE-AND-EDIT-Process------------------------------------*/
        private void btn_save_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                {

                    if (Validation("all"))
                    {
                        this.catogery1 = new BUS.catogery1(Catogery1id, Catogery1discription);

                        if (btn_save.Text == "Save")
                        { this.catogery1.SaveCatogery1(); }

                        else if (btn_save.Text == "Edit")
                        {
                            this.catogery1.EditCatogery1();
                        }
                        else { fun.validationMessge("Something Wrong!"); }
                        Progress_And_Clear();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        /*-----------------------------------------Delete Process------------------------------------*/
        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                {
                    if (Validation("not"))
                    {
                        this.Catogery1id = Convert.ToInt32(this.categoryidlbl.Text);
                        this.catogery1 = new Jewellery_System.BUS.catogery1(Catogery1id);
                        if (this.catogery1.DeleteCatogery1())
                        {
                            Progress_And_Clear();
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


        /*-----------------------------------------Validation Process------------------------------------*/
        public bool Validation(string part)
        {
            if (btn_save.Text != "Save")
            {
                if (string.IsNullOrEmpty(this.categoryidlbl.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.categoryidlbl.Focus(); return false; }       
            }
            if (part == "all")
            {
                if (string.IsNullOrEmpty(this.discriptiontxt.Text.Trim()))
                { fun.validationMessge("Please Enter Description !"); this.discriptiontxt.Focus(); return false; }

                else
                {
                    if (string.IsNullOrEmpty(categoryidlbl.Text.Trim())) { this.Catogery1id = 0; }
                    else { this.Catogery1id = Convert.ToInt32(categoryidlbl.Text); }
                    this.Catogery1discription = this.discriptiontxt.Text.Trim();
                }
            }

            return true;
        }



        /*-----------------------------------------Get full chart------------------------------------*/
        private void Catogery1_Load(object sender, EventArgs e)
        {
            try
            {
                catogery1 = new BUS.catogery1();
                catogery1.BindCategory2Details(dataGridView1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }


        /*-----------------------------------------Grid double click------------------------------------*/
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.categoryidlbl.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.discriptiontxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                btn_save.Text = "Edit"; discriptiontxt.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            catogery1 = new BUS.catogery1(this.txt_search.Text.Trim());
            catogery1.BindItemyDetaisSearch(dataGridView1);
            if (txt_search.Text == "") { catogery1.BindCategory2Details(dataGridView1); };
        }

        private void Catogery1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Handled)
            {
                if (e.KeyCode == Keys.F5)
                { Progress_And_Clear(); }

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

