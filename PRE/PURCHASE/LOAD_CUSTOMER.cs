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
    public partial class LOAD_CUSTOMER : Form
    {
        public static PRE.PURCHASE.LOAD_CUSTOMER instance;
        public string statues;
        
        public LOAD_CUSTOMER()
        {
            instance = this;
            InitializeComponent();
        }

        BUS.customer customer;
        DAT.function_ fun = new DAT.function_();

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (statues=="nonDB")
            {
                PRE.PURCHASE.PURCHASE.instance.txt_customer_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                PRE.PURCHASE.PURCHASE.instance.txt_customer_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.Close();
            }
            else        
            {
                PRE.PURCHASE.List.instance.txt_customer_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                PRE.PURCHASE.List.instance.txt_customer_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.Close();
            }
        }

        private void LOAD_CUSTOMER_Load(object sender, EventArgs e)
        {
            customer = new BUS.customer();
            customer.BindCustomerDetails(dataGridView1);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            this.Hide();
            CUSTOMER.CUSTOMER customerform = new CUSTOMER.CUSTOMER();
            customerform.Show();
        }

        private void btn_add_new_customer_Click(object sender, EventArgs e)
        {
            this.Hide();
            PRE.PURCHASE.PURCHASE.ActiveForm.Hide();
            CUSTOMER.CUSTOMER customerform = new CUSTOMER.CUSTOMER();
            customerform.Show();
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
    }
}
