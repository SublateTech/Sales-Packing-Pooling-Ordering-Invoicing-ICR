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
    public partial class frmCommissionSalesReport : frmBase
    {
        Voicemail oVoicemail = new Voicemail(Global.CurrrentCompany);
        Rep oRep = new Rep(Global.CurrrentCompany);
        
        public frmCommissionSalesReport()
        {
            InitializeComponent();
        }

        private void txtRepID_KeyUp(object sender, KeyEventArgs e)
        {

            if (sender == txtRepID)
            {
                    if (e.KeyCode == Keys.F2)
                        {
                        
                            if (oVoicemail.View())
                            {
                                txtRepID.Text = oVoicemail.ID;
                                oRep.Find(oVoicemail.RepID);
                                lbRepName.Text = oRep.Name;
                                return;
                            }
                        }
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (txtRepID.Text.Trim() == "")
                                return;
                            
                            if (oVoicemail.Find(txtRepID.Text))
                            {   txtRepID.Text = oVoicemail.ID;
                                oRep.Find(oVoicemail.RepID);
                                lbRepName.Text = oRep.Name;
                                return;
                            }
                        }
                        
            }
            if (sender == txtRepID_2)
            {
                if (e.KeyCode == Keys.F2)
                {
                    if (oVoicemail.View())
                    {
                        txtRepID_2.Text = oVoicemail.ID;
                        oRep.Find(oVoicemail.RepID);
                        lbRepName_2.Text = oRep.Name;
                        return;
                    }
                    
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtRepID_2.Text.Trim() == "")
                        return;

                    if (oVoicemail.Find(txtRepID_2.Text))
                    {
                        txtRepID_2.Text = oVoicemail.ID;
                        oRep.Find(oVoicemail.RepID);
                        lbRepName_2.Text = oRep.Name;
                        return;
                    }
                }


            }

            if (e.KeyCode == Keys.PageDown)
               {
                    
                    if (!cbSummary.Checked)
                        oRep.PrintCommissionReport(txtRepID.Text, txtRepID_2.Text,"",false);
                    else
                        oRep.PrintCommissionSummaryReport(txtRepID.Text, txtRepID_2.Text);
               }
                
        }

    }
}