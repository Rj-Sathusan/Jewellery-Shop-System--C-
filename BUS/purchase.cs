using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Jewellery_System.BUS
{
    class purchase : DAT.NewDataAccessLayer
    {
        private int purchase_primary_key;
        private string purchase_customer_id;
        private string purchase_customer_name;
        private string purchase_item_name;
        private string purchase_item_code;
        private int purchase_carrot;
        private decimal purchase_weight;
        private double purchase_quantity;
        private decimal purchase_total_weight;
        private double purchase_unit_price;
        private double purchase_totel;
        private double purchase_discount;
        private double purchase_net_totel;
        private decimal purchase_making;
        private decimal purchase_wasting;
        private DateTime purchase_purchase_date;

        public string ITEM_CODE
        {
            get { return this.purchase_item_code; }
            set { this.purchase_item_code = value; }
        }
        public int PRIMARY_KEY
        {
            get { return this.purchase_primary_key; }
            set { this.purchase_primary_key = value; }
        }
        public string CUSTOMER_ID
        {
            get { return this.purchase_customer_id; }
            set { this.purchase_customer_id = value; }
        }
        public string CUSTOMER_NAME
        {
            get { return this.purchase_customer_name; }
            set { this.purchase_customer_name = value; }
        }
        public string ITEM_NAME
        {
            get { return this.purchase_item_name; }
            set { this.purchase_item_name = value; }
        }
        public int CARROT
        {
            get { return this.purchase_carrot; }
            set { this.purchase_carrot = value; }
        }
        public decimal WEIGHT
        {
            get { return this.purchase_weight; }
            set { this.purchase_weight = value; }
        }
        public double QUANTITY
        {
            get { return this.purchase_quantity; }
            set { this.purchase_quantity = value; }
        }
        public decimal TOTALWEIGHT
        {
            get { return this.purchase_total_weight; }
            set { this.purchase_total_weight = value; }
        }
        public double UNIT_PRICE
        {
            get { return this.purchase_unit_price; }
            set { this.purchase_unit_price = value; }
        }
        public double TOTEL
        {
            get { return this.purchase_totel; }
            set { this.purchase_totel = value; }
        }
        public double DISCOUNT
        {
            get { return this.purchase_discount; }
            set { this.purchase_discount = value; }
        }
        public double NET_TOTEL
        {
            get { return this.purchase_net_totel; }
            set { this.purchase_net_totel = value; }
        }
        public decimal MAKING
        {
            get { return this.purchase_making; }
            set { this.purchase_making = value; }
        }
        public decimal WASTING
        {
            get { return this.purchase_wasting; }
            set { this.purchase_wasting = value; }
        }
        public DateTime PURCHASE_DATE
        {
            get { return this.purchase_purchase_date; }
            set { this.purchase_purchase_date = value; }
        }

        public bool Savepurchase()
        {
            try
            {
                MySqlParameter[] param = new MySqlParameter[16];
                param[0] = new MySqlParameter("@primary_key0", MySqlDbType.Int32);
                param[0].Value = purchase_primary_key;
                param[1] = new MySqlParameter("@customer_id0", MySqlDbType.VarChar, 60);
                param[1].Value = purchase_customer_id;
                param[2] = new MySqlParameter("@customer_name0", MySqlDbType.VarChar, 60);
                param[2].Value = purchase_customer_name;
                param[3] = new MySqlParameter("@item_name0", MySqlDbType.VarChar, 60);
                param[3].Value = purchase_item_name;
                param[4] = new MySqlParameter("@carrot0", MySqlDbType.Int32);
                param[4].Value = purchase_carrot;
                param[5] = new MySqlParameter("@weight0", MySqlDbType.Decimal);
                param[5].Value = purchase_weight;
                param[6] = new MySqlParameter("@quantity0", MySqlDbType.Double);
                param[6].Value = purchase_quantity;
                param[7] = new MySqlParameter("@totalweight0", MySqlDbType.Double);
                param[7].Value = purchase_total_weight;
                param[8] = new MySqlParameter("@unit_price0", MySqlDbType.Double);
                param[8].Value = purchase_unit_price;
                param[9] = new MySqlParameter("@totel0", MySqlDbType.Double);
                param[9].Value = purchase_totel;
                param[10] = new MySqlParameter("@discount0", MySqlDbType.Double);
                param[10].Value = purchase_discount;
                param[11] = new MySqlParameter("@net_totel0", MySqlDbType.Double);
                param[11].Value = purchase_net_totel;
                param[12] = new MySqlParameter("@making0", MySqlDbType.Decimal);
                param[12].Value = purchase_making;
                param[13] = new MySqlParameter("@wasting0", MySqlDbType.Decimal);
                param[13].Value = purchase_wasting;
                param[14] = new MySqlParameter("@purchase_date0", MySqlDbType.DateTime);
                param[14].Value = purchase_purchase_date;
                param[15] = new MySqlParameter("@purchase_item_code0", MySqlDbType.Int32);
                param[15].Value = purchase_item_code;

                Console.WriteLine(purchase_item_code);
                if (OpenConnection())
                {
                    if (ExecuteCommand("purchaseSave", param))
                    {

                        CloseConnection();
                        param = null;

                        return true;
                    }
                    else
                    {

                        ShowMessage("Duplicate entry", "Error");
                        param = null;
                        return false;
                    }

                }
                else
                {
                    ShowMessage("Server Not Connected", "Error");

                    param = null;
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }

        }

        public bool Editpurchase()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[15];
                param[0] = new MySqlParameter("@primary_key0", MySqlDbType.Int32);
                param[0].Value = purchase_primary_key;
                param[1] = new MySqlParameter("@customer_id0", MySqlDbType.VarChar, 60);
                param[1].Value = purchase_customer_id;
                param[2] = new MySqlParameter("@customer_name0", MySqlDbType.VarChar, 60);
                param[2].Value = purchase_customer_name;
                param[3] = new MySqlParameter("@item_name0", MySqlDbType.VarChar, 60);
                param[3].Value = purchase_item_name;
                param[4] = new MySqlParameter("@carrot0", MySqlDbType.Int32);
                param[4].Value = purchase_carrot;
                param[5] = new MySqlParameter("@weight0", MySqlDbType.Decimal);
                param[5].Value = purchase_weight;
                param[6] = new MySqlParameter("@quantity0", MySqlDbType.Double);
                param[6].Value = purchase_quantity;
                param[7] = new MySqlParameter("@totalweight0", MySqlDbType.Double);
                param[7].Value = purchase_total_weight;
                param[8] = new MySqlParameter("@unit_price0", MySqlDbType.Double);
                param[8].Value = purchase_unit_price;
                param[9] = new MySqlParameter("@totel0", MySqlDbType.Double);
                param[9].Value = purchase_totel;
                param[10] = new MySqlParameter("@discount0", MySqlDbType.Double);
                param[10].Value = purchase_discount;
                param[11] = new MySqlParameter("@net_totel0", MySqlDbType.Double);
                param[11].Value = purchase_net_totel;
                param[12] = new MySqlParameter("@making0", MySqlDbType.Decimal);
                param[12].Value = purchase_making;
                param[13] = new MySqlParameter("@wasting0", MySqlDbType.Decimal);
                param[13].Value = purchase_wasting;
                param[14] = new MySqlParameter("@purchase_item_code0", MySqlDbType.Int32);
                param[14].Value = purchase_item_code;
                if (OpenConnection())
                {
                    if (ExecuteCommand(" purchaseEdit", param))
                    {

                        ShowMessage("Data Edited Successfully", "Warning");
                        CloseConnection();
                        param = null;

                        return true;
                    }
                    else
                    {

                        ShowMessage("Duplicate entry", "Error");
                        param = null;
                        return false;
                    }

                }
                else
                {
                    ShowMessage("Server Not Connected", "Error");

                    param = null;
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        public bool Deletepurchase()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@primary_key0", MySqlDbType.Int32);
                param[0].Value = purchase_primary_key;
                if (OpenConnection())
                {
                    if (ExecuteCommand(" purchaseDelete", param))
                    {

                        ShowMessage("Data Deleted Successfully", "Warning");
                        CloseConnection();
                        param = null;

                        return true;
                    }
                    else
                    {

                        ShowMessage("Duplicate entry", "Error");
                        param = null;
                        return false;
                    }

                }
                else
                {
                    ShowMessage("Server Not Connected", "Error");

                    param = null;
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        public purchase(int f_purchase_id,string purchase_item_code, string f_customer_id, string f_customer_name, string f_item_name, int f_purchase_carat, decimal f_purchase_weight, double f_purchase_quantity, decimal f_purchase_total_weight, double f_purchase_unit_price, double f_purchase_total_price, double f_purchase_discount,double f_purchase_net_total_price, decimal f_purchase_making, decimal f_purchase_wasting, DateTime f_purchase_date)
        {
            this.purchase_primary_key = f_purchase_id;
            this.purchase_customer_id = f_customer_id;
            this.purchase_customer_name = f_customer_name;
            this.purchase_item_name = f_item_name;
            this.purchase_carrot = f_purchase_carat;
            this.purchase_weight = f_purchase_weight;
            this.purchase_quantity = f_purchase_quantity;
            this.purchase_total_weight = f_purchase_total_weight;
            this.purchase_unit_price = f_purchase_unit_price;
            this.purchase_totel = f_purchase_total_price;
            this.purchase_discount = f_purchase_discount;
            this.purchase_net_totel = f_purchase_net_total_price;
            this.purchase_making = f_purchase_making;
            this.purchase_wasting = f_purchase_wasting;
            this.purchase_purchase_date = f_purchase_date;
            this.purchase_item_code = purchase_item_code;
        }

        public purchase(int f_purchase_id)
        {
            this.purchase_primary_key = f_purchase_id;
        }
          
        public purchase(string f_customer_name)
        {
            this.purchase_customer_name = f_customer_name;
        }
        public purchase()
        {
        }

        public DataTable GetpurcaseDetails()
        {
            comtable = null;


            if (OpenConnection())
            {
                comtable = SelectData("purcaseDetails", null);
                sqlconnection.Close();
            }

            return comtable;
        }

        public void BindpurcaseDetails(DataGridView dgv)
        {

            BindGrid(dgv, GetpurcaseDetails());
        }

        public DataTable GetPurchasebyName()
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@customer_name0", MySqlDbType.VarChar, 60);
            param[0].Value = purchase_customer_name;

            if (OpenConnection())
            {
                dt = SelectData("GetPurchasebyName", param);
                CloseConnection();
            }

            return dt;
        }

        public void BindPurchaseDetailsName(DataGridView dgv)
        {

            BindGrid(dgv, GetPurchasebyName());
        }
    }
}
