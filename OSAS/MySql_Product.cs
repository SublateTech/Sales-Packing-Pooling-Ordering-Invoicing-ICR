using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;


namespace OSAS
{
    /// <summary>
    /// Summary description for OSAS_Orders.
    /// </summary>
    public class MySql_Product : MySql
    {

        String CurProductID;
        String Name;
        String PPrice;

        public MySql_Product()
        {

            
        }

        public bool Find(String ProductID)
        {

            if (ProductID == "")
                return false;

            ProductID = ProductID.PadLeft(4, '0');

            //MessageBox.Show("Select * From Product Where ProductID='" + ProductID + "'");
            DataRow rProduct = this.GetDataRow("Select * From Product Where ProductID='" + ProductID + "'", "Product");
            

            if (rProduct == null)
            {

                this.Name = "No product found!";
                this.PPrice = "0.00";
                return false;
            }

            this.PPrice = rProduct["Price"].ToString();
            this.Name   = rProduct["Description"].ToString();
            this.CurProductID = ProductID;

            return true;
        }
        
        public string Description
        {
            get
            {
                return this.Name;
            }
            set
            {
                this.Name = value;
            }
        }
    
        public string Price
        {
            get
            {
                // TODO:  Add MaskedEditNumeric.Text getter implementation
                return this.PPrice;
            }
            set
            {
                this.PPrice = value;
            }
        }
    }
}
