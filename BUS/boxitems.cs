using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Jewellery_System.BUS
{
    class boxitems: DAT.NewDataAccessLayer
    {
        private int Primarykey;
        private string BoxItems_boxid;
        private int BoxItems_item;

        public string BOXID
        {
            get { return this.BoxItems_boxid;}
            set { this.BoxItems_boxid = value;}
        }

        public int PRIMARYKEY
        {
            get { return this.Primarykey; }
            set { this.Primarykey = value; }
        }

        public int ITEM
        {
            get { return this.BoxItems_item;}
            set { this.BoxItems_item = value;}
        }

        public bool SaveBoxItems()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[3];
                param[0] = new MySqlParameter("@boxid0", MySqlDbType.VarChar, 60);
                param[0].Value = BoxItems_boxid;
                param[1] = new MySqlParameter("@item0", MySqlDbType.Int32);
                param[1].Value = BoxItems_item;
                param[2] = new MySqlParameter("@primarykey0", MySqlDbType.Int32);
                param[2].Value = Primarykey;
                if (OpenConnection())
                {
                    if(ExecuteCommand("BoxItemsSave", param))
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


        public bool EditBoxItems()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[3];
                param[0] = new MySqlParameter("@boxid0", MySqlDbType.VarChar, 60);
                param[0].Value = BoxItems_boxid;
                param[1] = new MySqlParameter("@item0", MySqlDbType.Int32);
                param[1].Value = BoxItems_item;
                param[2] = new MySqlParameter("@primarykey0", MySqlDbType.Int32);
                param[2].Value = Primarykey;
                if (OpenConnection())
                {
                    if(ExecuteCommand("BoxItemsEdit", param))
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

        public bool DeleteBoxItems()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@primarykey0", MySqlDbType.Int32);
                param[0].Value = Primarykey;
                if (OpenConnection())
                {
                    if(ExecuteCommand("BoxItemsDelete", param))
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



        public boxitems(int Primarykey, string BoxItemsboxid, int BoxItemsitem)
        {
            this.Primarykey = Primarykey;
            this.BoxItems_boxid = BoxItemsboxid;
            this.BoxItems_item = BoxItemsitem;
        }

        public boxitems(int Primarykey)
        {
            this.Primarykey = Primarykey;
          
        }
        public boxitems(string BoxItemsboxid)
        {
            this.BoxItems_boxid = BoxItemsboxid;

        }

        public boxitems()
        {
        }


        public DataTable Getbox()
        {
            comtable = null;


            if (OpenConnection())
            {
                comtable = SelectData("BoxItemsSelect", null);
                sqlconnection.Close();
            }

            return comtable;
        }

        /*
        public DataTable Getforgrid(int id)
        {
            comtable = null;
            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@boxid0", MySqlDbType.VarChar, 60);
            param[0].Value = BoxItems_boxid;

            if (OpenConnection())
            {
                comtable = SelectData("BoxItemsGriddata", param);
                sqlconnection.Close();
            }

            return comtable;
        }
        */

        public DataTable Getbyid()
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@boxid0", MySqlDbType.VarChar, 50);
            param[0].Value = BoxItems_boxid;

            if (OpenConnection())
            {
                dt = SelectData("boxitemsbyboxid", param);
                CloseConnection();
            }

            return dt;
        }

        public void BindCategoryDetaislFull(DataGridView dgv)
        {

            BindGrid(dgv, Getbyid());
        }
        public void BindBoxDetails(DataGridView dgv)
        {

            BindGrid(dgv, Getbox());
        }

    }
}