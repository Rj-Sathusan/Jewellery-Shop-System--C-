using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.BOXITEMS
{
    public partial class BoxItems : Form
    {
        private int Primarykey;
        private string BoxItemsboxid;
        private int BoxItemsitem;
        DataTable dt;
        BUS.boxitems boxitems;
        DAT.function_ fun = new DAT.function_();

        public BoxItems()
        {
            InitializeComponent();
        }

    /*-----------------------------------------Clear and progress bar------------------------------------*/
        public void Progress_And_Clear()
        {
            try
            {
                pb_loading.Value = 0; pb_loading.Value = 100;
                itemtxt.Text = "";
                btn_save.Text = "Save";
                boxitems.BindBoxDetails(dataGridView1);
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToString(boxidtxt.SelectedValue.ToString());
                this.boxitems = new BUS.boxitems(BoxItemsboxid);
                fun.BindGrid(dataGridView1, dt);
                boxitems = new BUS.boxitems(this.boxidtxt.Text.Trim());
                boxitems.BindCategoryDetaislFull(dataGridView1);
                ///  form_category_id = txt_category_id.SelectedValue;
                MessageBox.Show(boxidtxt.SelectedValue.ToString());

            }
            catch
            { }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {


                if (Validation("all"))
                {
                    if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                    {

                        this.boxitems = new BUS.boxitems(Primarykey, BoxItemsboxid, BoxItemsitem);

                        if (btn_save.Text == "Save")
                        {

                            if (this.boxitems.SaveBoxItems())
                            {
                                Progress_And_Clear();
                            }
                            else
                            {

                            }


                        }

                        else if (btn_save.Text == "Edit")
                        {
                          this.boxitems.EditBoxItems();
                            
                        }
                        else { fun.validationMessge("Something Wrong!"); }
                        Progress_And_Clear();

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
                        this.boxitems = new BUS.boxitems(Primarykey);
                        if (this.boxitems.DeleteBoxItems())
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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*-----------------------------------------Validation Process------------------------------------*/
        public bool Validation(string part)
        {
            if (btn_save.Text != "Save")
            {
                if (string.IsNullOrEmpty(this.primarykeytxt.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.primarykeytxt.Focus(); return false; }       
            }

            if (part == "all")
            {
                if (string.IsNullOrEmpty(this.boxidtxt.Text.Trim()))
                { fun.validationMessge("Please Enter Box id"); this.boxidtxt.Focus(); return false; }
                if (string.IsNullOrEmpty(this.itemtxt.Text.Trim()))
                { fun.validationMessge("Please Enter Item name"); this.itemtxt.Focus(); return false; }

                else
                {
                    if (string.IsNullOrEmpty(primarykeytxt.Text.Trim())) { this.Primarykey = 0; }
                    else { this.Primarykey = Convert.ToInt32(primarykeytxt.Text); }
                    BoxItemsboxid = Convert.ToString(boxidtxt.SelectedValue.ToString());
                    BoxItemsitem = Convert.ToInt32(itemtxt.SelectedValue.ToString());

                }
            }
            return true;
        }

        private void BoxItems_Load(object sender, EventArgs e)
        {
            try
            {
                boxitems = new BUS.boxitems();
                boxitems.BindBoxDetails(dataGridView1);
                BindItemandBox();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.itemtxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.primarykeytxt.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.boxidtxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
               
                btn_save.Text = "Edit"; 
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        public void BindItemandBox()
        {
            try
            {
                BUS.itemform item = new BUS.itemform();
                BUS.box box = new BUS.box();
                this.itemtxt.DataSource = item.GetItem();
                this.itemtxt.ValueMember = "item_code";
                this.itemtxt.DisplayMember = "item_name";
                this.boxidtxt.DataSource = box.Getbox();
                this.boxidtxt.ValueMember = "id";
                this.boxidtxt.DisplayMember = "id";
                box = null;
                item = null;
            }
            catch
            {}
        }



        private void itemtxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BoxItemsitem = Convert.ToInt32(boxidtxt.SelectedValue.ToString());
                boxitems = new BUS.boxitems(this.boxidtxt.Text.Trim());
                boxitems.BindCategoryDetaislFull(dataGridView1);
                ///  form_category_id = txt_category_id.SelectedValue;
                MessageBox.Show(boxidtxt.SelectedValue.ToString());
            }
            catch
            { }
            
        }

        private void BoxItems_KeyDown(object sender, KeyEventArgs e)
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


        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }


    }
}
