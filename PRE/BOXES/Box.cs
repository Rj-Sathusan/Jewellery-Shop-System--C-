using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.Boxes
{
    public partial class Box : Form
    {
        private String Boxid;
        private decimal Boxweight;

        BUS.box box;
        DataTable dt;
        DAT.function_ fun = new DAT.function_();
        public Box()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Box_KeyDown);
        }

        public void Progress_And_Clear()
        {
            try
            {
                pb_loading.Value = 0; pb_loading.Value = 100;
                boxidlbl.Text = "";
                weighttxt.Text = "";
                btn_save.Text = "Save";
                box.BindBoxDetails(dataGridView1);
            }
            catch { }
        }

        /*-----------------------------------------Get full chart------------------------------------*/
        private void Box_Load(object sender, EventArgs e)
        {
            try
            {
                box = new BUS.box();
                box.BindBoxDetails(dataGridView1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        /*-----------------------------------------SAVE-AND-EDIT-Process------------------------------------*/
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                {

                    if (Validation("all"))
                    {
                        this.box = new BUS.box(Boxid, Boxweight);

                        if (btn_save.Text == "Save")
                        { this.box.SaveBox(); }

                        else if (btn_save.Text == "Edit")
                        {
                            this.box.EditBox();
                        }
                        else { fun.validationMessge("Something Wrong!"); }
                        Progress_And_Clear();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        /*-----------------------------------------Delete Process------------------------------------*/
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                {
                    if (Validation("not"))
                    {
                        this.Boxid = this.boxidlbl.Text.Trim();
                        this.box = new Jewellery_System.BUS.box(Boxid);
                        if (this.box.DeleteBox())
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
                if (string.IsNullOrEmpty(this.boxidlbl.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.boxidlbl.Focus(); return false; }
            }

            if (part == "all")
            {
                
                if (string.IsNullOrEmpty(this.weighttxt.Text.Trim()))
                { fun.validationMessge("Please Enter Description !"); this.weighttxt.Focus(); return false; }

                else
                {
                    if (string.IsNullOrEmpty(boxidlbl.Text.Trim())) { this.Boxid = "0"; }
                    else { this.Boxid = this.boxidlbl.Text.Trim(); }
                    this.Boxweight = Convert.ToDecimal(weighttxt.Text);
                }

            }
            return true;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /*-----------------------------------------Grid double click------------------------------------*/
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.boxidlbl.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.weighttxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                btn_save.Text = "Edit"; weighttxt.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            box = new BUS.box(this.txt_search.Text.Trim());
            box.BindItemyDetaisSearch(dataGridView1);
            if (txt_search.Text==""){ box.BindBoxDetails(dataGridView1); }
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }

        private void Box_KeyDown(object sender, KeyEventArgs e)
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
