using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.BUS
{
    class price : DAT.NewDataAccessLayer
    {
        private long  price_id;
        private double price_amount;
        private DateTime price_date;

        public long ID
        {
            get { return this.price_id; }
            set { this.price_id = value; }
        }
        public DateTime DATE
        {
            get { return this.price_date; }
            set { this.price_date = value; }
        }
        public double AMOUNT
        {
            get { return this.price_amount; }
            set { this.price_amount = value; }
        }

        public bool Saveprice()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[3];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int64);
                param[0].Value = price_id;
                param[1] = new MySqlParameter("@date0", MySqlDbType.DateTime);
                param[1].Value = price_date;
                param[2] = new MySqlParameter("@amount0", MySqlDbType.Double);
                param[2].Value = price_amount;
                param[2] = new MySqlParameter("@amount0", MySqlDbType.Double);
                param[2].Value = price_amount;

                if (OpenConnection())
                {
                    if (ExecuteCommand("priceSave", param))
                    {

                        ShowMessage("Data Saved Successfully", "Warning");
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



        public bool Editprice()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[3];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int64);
                param[0].Value = price_id;
                param[1] = new MySqlParameter("@date0", MySqlDbType.DateTime);
                param[1].Value = price_date;
                param[2] = new MySqlParameter("@amount0", MySqlDbType.Double);
                param[2].Value = price_amount;
                param[2] = new MySqlParameter("@amount0", MySqlDbType.Double);
                param[2].Value = price_amount;
                if (OpenConnection())
                {
                    if (ExecuteCommand("priceEdit", param))
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



        public bool Deleteprice()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int64);
                param[0].Value = price_id;
                if (OpenConnection())
                {
                    if (ExecuteCommand("priceDelete", param))
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

        public price(long priceid, DateTime pricedate, double priceamount)
        {
            this.price_id = priceid;
            this.price_date = pricedate;
            this.price_amount = priceamount;
        }

        public price(long priceid)
        {
            this.price_id = priceid;
        }
        public price()
        {
        }

        public DataTable Getprice()
        {
            comtable = null;


            if (OpenConnection())
            {
                comtable = SelectData("priceSelect", null);
                sqlconnection.Close();
            }

            return comtable;
        }
        public void BindPriceDetails(DataGridView dgv)
        {

            BindGrid(dgv, Getprice());
        }
        
        public DataTable GetPricebyID()
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@id0", MySqlDbType.Int64);
            param[0].Value = price_id;

            if (OpenConnection())
            {
                dt = SelectData("GetPricebyID", param);
                CloseConnection();
            }

            return dt;
        }

        public void BindPricebyID(DataGridView dgv)
        {

            BindGrid(dgv, GetPricebyID());
        }
    }
}
