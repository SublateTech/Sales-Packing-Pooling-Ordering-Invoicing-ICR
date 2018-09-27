using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;

namespace Signature.Forms
{
    public partial class frmBrochureProjected: frmBase
    {
        Brochure oBrochure;
        Brochure oBrochure_2;
        DataTable dtBrochures;

        public frmBrochureProjected()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oBrochure = new Brochure(base.CompanyID);
            oBrochure_2 = new Brochure(base.CompanyID);
            dtBrochures = oMySql.GetDataTable(String.Format("Select * from Brochure Where CompanyID='{0}'", this.CompanyID), "Brochures");
            
            Int32 nRow = 15;
            foreach (DataRow row in dtBrochures.Rows)
            {
                Label lBrochureID = new Label();
                lBrochureID.Text = row["BrochureID"].ToString();
                lBrochureID.Top = nRow;
                lBrochureID.Height = 25;
                lBrochureID.Width = 50;
                
                
                Label label = new Label();
                label.Text = row["Description"].ToString();
                label.Top = nRow;
                label.Left = lBrochureID.Left+lBrochureID.Width;
                label.Width = 350;
                label.Height = 25;
                

                CheckBox checkbox = new CheckBox();
                checkbox.Left = label.Left + label.Width;
                checkbox.Top = label.Top;
                checkbox.Checked = false;
                checkbox.Width = 15;
                checkbox.Name = row["BrochureID"].ToString();

                gbBrochures.Controls.Add(lBrochureID);
                gbBrochures.Controls.Add(label);
                gbBrochures.Controls.Add(checkbox);
                
                nRow += label.Height;
            }
        }
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            #region txtBrochureID
            if (sender == txtBrochureID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oBrochure.View())
                    {
                        
                        txtBrochureID.Text = oBrochure.ID;
                        txtDescription.Text = oBrochure.Description;
                    
                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtBrochureID.Text.Trim().Length == 0)
                    {
                        
                        txtBrochureID.Focus();
                    }

                    if (oBrochure.Find(txtBrochureID.Text))
                    {
                        
                        txtBrochureID.Text = oBrochure.ID;
                        txtDescription.Text = oBrochure.Description;
                    
                    }
                    



                }

            }
            #endregion
            #region txtBrochureID
            if (sender == txtBrochureID_2)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oBrochure_2.View())
                    {

                        txtBrochureID_2.Text = oBrochure_2.ID;
                        txtDescription_2.Text = oBrochure_2.Description;

                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtBrochureID_2.Text.Trim().Length == 0)
                    {

                        txtBrochureID_2.Focus();
                    }

                    if (oBrochure_2.Find(txtBrochureID_2.Text))
                    {

                        txtBrochureID_2.Text = oBrochure_2.ID;
                        txtDescription_2.Text = oBrochure_2.Description;

                    }
                }
            }
            #endregion
            #region txtUnitsProjected
            if (sender == txtUnitsProjected)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oBrochure.View())
                    {

                        txtUnitsProjected.Text = oBrochure.ID;
                       // txtDescription_2.Text = oBrochure.Description;


                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtUnitsProjected.Text.Trim().Length == 0)
                    {

                        txtUnitsProjected.Focus();
                    }

                    if (oBrochure.Find(txtUnitsProjected.Text))
                    {

                        txtUnitsProjected.Text = oBrochure.ID;
                        //txtDescription_2.Text = oBrochure.Description;


                    }




                }

            }
            #endregion

            #region Default Option
            //Default option
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    if (!e.Shift)
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Down:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Up:
                    this.SelectNextControl(this.ActiveControl, false, true, true, true);
                    break;
                case Keys.F8:
                    break;
                case Keys.F3:
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    if (txtUnitsProjected.Text.Trim() == "")
                        txtUnitsProjected.Text = "0";
                        oBrochure.PrintBrochureProjected(Convert.ToInt32(txtUnitsProjected.Text));
                    this.Dispose();
                    break;


                //case Keys.<some key>: 
                // ......; 
                // break; 
            }
            #endregion

        }

        private void bProcess_Click(object sender, EventArgs e)
        {
            
            List<string> Sql = new List<string>();
            foreach (Control control in gbBrochures.Controls)
            {
                
                if (control.GetType().ToString().Contains("CheckBox"))
                {
                    if (((CheckBox)control).Checked)
                        Sql.Add(control.Name);
                        
                }
            }
            if (Sql.Count >0)
            {
                
                if (txtUnitsProjected.Text.Trim() == "")
                    txtUnitsProjected.Text = "0";
                oBrochure.PrintBrochureProjected(Convert.ToInt32(txtUnitsProjected.Text), Sql);
                this.Dispose();
            }
//            MessageBox.Show(Sql);
        }

        private void bProcess_Click_1(object sender, EventArgs e)
        {
            String Sql = "";

            foreach (Control control in gbBrochures.Controls)
            {

                if (control.GetType().ToString().Contains("CheckBox"))
                {
                    if (((CheckBox)control).Checked)

                        if (Sql == "")
                            Sql += "BrochureID='" + control.Name + "'";
                        else
                            Sql += " Or BrochureID='" + control.Name + "'";
                }
            }
            if (Sql != "")
            {
                Sql = "And (" + Sql + ")";
                if (txtUnitsProjected.Text.Trim() == "")
                    txtUnitsProjected.Text = "0";
                oBrochure.PrintBrochureProjected(Convert.ToInt32(txtUnitsProjected.Text), Sql);
                this.Dispose();
            }
            //            MessageBox.Show(Sql);
        }

        
    }
}