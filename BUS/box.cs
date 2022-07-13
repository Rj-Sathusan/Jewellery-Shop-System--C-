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
    class box : DAT.NewDataAccessLayer
    {
        private string Box_id;
        private decimal Box_weight;

        public string ID
        {
            get { return this.Box_id; }
            set { this.Box_id = value; }
        }
        public decimal WEIGHT
        {
            get { return this.Box_weight; }
            set { this.Box_weight = value; }
        }

        public bool SaveBox()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[2];
                param[0] = new MySqlParameter("@id0", MySqlDbType.VarChar, 100);
                param[0].Value = Box_id;
                param[1] = new MySqlParameter("@weight0", MySqlDbType.Decimal);
                param[1].Value = Box_weight;
                if (OpenConnection())
                {
                    if (ExecuteCommand("BoxSave", param))
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

        public bool EditBox()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[2];
                param[0] = new MySqlParameter("@id0", MySqlDbType.VarChar, 100);
                param[0].Value = Box_id;
                param[1] = new MySqlParameter("@weight0", MySqlDbType.Decimal);
                param[1].Value = Box_weight;
                if (OpenConnection())
                {
                    if (ExecuteCommand("BoxEdit", param))
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

        public bool DeleteBox()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@id0", MySqlDbType.VarChar, 100);
                param[0].Value = Box_id;
                if (OpenConnection())
                {
                    if (ExecuteCommand("BoxDelete", param))
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


        public box(String Boxid, decimal Boxweight)
        {
            this.Box_id = Boxid;
            this.Box_weight = Boxweight;
        }

        public box(String Boxid)
        {
            this.Box_id = Boxid;
        }



        public box()
        { }

        // ============================================ Get all details in Shop ==============================//////

        public DataTable Getbox()
        {
            comtable = null;


            if (OpenConnection())
            {
                comtable = SelectData("BoxSelect", null);
                sqlconnection.Close();
            }

            return comtable;
        }
        public void BindBoxDetails(DataGridView dgv)
        {

            BindGrid(dgv, Getbox());
        }

        public DataTable GetBoxbyID()
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@id0", MySqlDbType.VarChar, 10);
            param[0].Value = Box_id;

            if (OpenConnection())
            {
                dt = SelectData("BoxSelectbyID", param);
                CloseConnection();
            }

            return dt;
        }

        public void BindItemyDetaisSearch(DataGridView dgv)
        {

            BindGrid(dgv, GetBoxbyID());
        }


    }
}
