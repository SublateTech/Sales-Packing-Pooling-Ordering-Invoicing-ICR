using System;
using System.Collections;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Signature.Classes;
using Signature.Data;


namespace Signature.Classes
{
    public class GA_Box 
    {
        private MySQL oMySql = Global.oMySql;
        
        // Properties
        public String ID;
        private String _Description;
        public String CompanyID;
        public String _KitID;


        //Methods

        public GA_Box(String CompanyID)
        {            
            this.CompanyID = CompanyID;
        } //Constructor

        public bool Find(String BoxID)
        {
            //Header

            DataRow rBox = this.oMySql.GetDataRow("Select * From ga_box Where ID='" + BoxID + "'", "box");

            if (rBox == null)
            {
                return false;
            }

            //this.Clear();

            //Header
            
            //this._CompanyID = rBox["CompanyID"].ToString();
            this._Description = rBox["Description"].ToString();

            //Items.Clear();

           /* //DataView tDetail = oMySql.GetDataView("Select ProductID, Description, Price  From Product  Where CompanyID=." + _CompanyID + "'", "TMP");
            foreach (DataRow Row in tDetail.Table.Rows)
            {
                Product _Item = new Product(_CompanyID);

                _Item.ID = Row["ProductID"].ToString();
                _Item.Price = (Double)Row["Price"];
                _Item.Description = Row["Description"].ToString();

                Items.Add(Row["ProductID"].ToString(), _Item);

            }*/

            return true;
        }
        public bool View()
        {
        	frmProductView oView = new frmProductView(this.CompanyID);
			oView.ShowDialog();
			if (oView.sSelectedID!="")
			{
				ID =  oView.sSelectedID;
                return true;
				
			}
            return false;
		
        }
        public void Save()
        {
        }
        public void Update()
        {
        }
        
        public String Description
        {
            get { return _Description; }
            set { _Description = value;  }
        }
        

        #region Classes & Enumerators
        public class _Items : Hashlist //, IList
        {
           /* Hash List Support */
            public new Product this[string Key]
            {
                get { return (Product)base[Key]; }

            }
            public new Product this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (Product)oTemp;
                }
            }

            // Expose the enumerator for the associative array.
            public new IEnumerator GetEnumerator()
            {
                return new ItemsEnumerator(this);
            }
        }
        public class ItemsEnumerator : IEnumerator
        {
            public ItemsEnumerator(_Items ar)
            {
                _ar = ar;
                _currIndex = -1;
            }
            public object Current
            {
                get
                {
                    return _ar.m_oValues[_ar.m_oKeys[_currIndex]];

                }
            }
            public bool MoveNext()
            {
                _currIndex++;
                if (_currIndex == _ar.Length)
                    return false;
                else
                    return true;
            }
            public void Reset()
            {
                _currIndex = -1;
            }

            // The index of the item this enumerator applies to.
            protected int _currIndex;
            // A reference to this enumerator's associative array.
            protected _Items _ar;


        }
        #endregion

    }

}
