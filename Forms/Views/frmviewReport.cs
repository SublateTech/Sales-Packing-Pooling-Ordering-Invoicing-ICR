using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
//using Signature.Reports;
using Signature.OSAS;

namespace Signature {

    public enum Report
    {

        summary_by_classes = 1,
        ranking_by_student = 2,
        summary_of_products_by_brochure = 3,
        detail_by_student_by_class = 4,
        detail_by_student = 5,
        prize_summary_by_student_by_class     = 6,
        summary_reps_sales   = 7,
        FinalBillTally   = 9,
        BoxInventory     = 8,
        DiscrepancyList = 10,
        PalletLabels =11,
        CustomerStatement = 12,
        DiscrepancyLetters = 13,
        POReceive = 14,
        PurchaseOrden = 15

    }


	
	/// <summary>
	/// Summary description for frmReport.
	/// </summary>
	public class frmViewReport : System.Windows.Forms.Form
	{
		
		
		internal System.Windows.Forms.Label txtTitle;
		internal System.Windows.Forms.Label Label21;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer cReport;

		public void SetReport(int nReport,  String sCompany, String sCustomerID, bool nView)
		{
			view_report(nReport,sCompany,sCustomerID, nView );
		}
		
		public ReportDocument oRpt=null;

		public String Selection="";

        public int Parameter_1 = 0;
        public String sParameter_1 = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

	
		public frmViewReport()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtTitle = new System.Windows.Forms.Label();
			this.Label21 = new System.Windows.Forms.Label();
			this.cReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// txtTitle
			// 
			this.txtTitle.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.txtTitle.Font = new System.Drawing.Font("Haettenschweiler", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.txtTitle.Location = new System.Drawing.Point(0, 0);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(832, 38);
			this.txtTitle.TabIndex = 169;
			this.txtTitle.Text = "         Report Viewer";
			this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Label21
			// 
			this.Label21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Label21.BackColor = System.Drawing.Color.Gray;
			this.Label21.Font = new System.Drawing.Font("Haettenschweiler", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Label21.Location = new System.Drawing.Point(0, 40);
			this.Label21.Name = "Label21";
			this.Label21.Size = new System.Drawing.Size(832, 28);
			this.Label21.TabIndex = 168;
			this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cReport
			// 
			this.cReport.ActiveViewIndex = -1;
			this.cReport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cReport.Location = new System.Drawing.Point(0, 0);
			this.cReport.Name = "cReport";
			this.cReport.ReportSource = null;
			this.cReport.Size = new System.Drawing.Size(832, 670);
			this.cReport.TabIndex = 170;
			// 
			// frmViewReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(832, 670);
			this.Controls.Add(this.cReport);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.Label21);
			this.Name = "frmViewReport";
			this.Text = "frmReport";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmReport_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void view_report(int nReport, String sCompany, String sCustomerID,bool nView)
		{
			DataSet ds1;
			Signature.Data.MySQL oMySql = new Signature.Data.MySQL() ; // Sql Open

			switch (nReport)
			{
				case 1:
					ds1 = oMySql.get_summary_by_classes(sCompany, sCustomerID);
					summary_by_classes oRpt2 = new summary_by_classes();
					oRpt2.SetDataSource(ds1);
					if (nView)
					{
						cReport.ReportSource = oRpt2;
						this.Text = "Summary by Classes";
						this.Show();
					}
					else
						oRpt2.PrintToPrinter(1,true,1,100);
					
					break;
				case 2:
					
					ds1 = oMySql.get_ranking_by_student(sCompany, sCustomerID,this.Selection);
					ranking_by_student oRpt1 = new ranking_by_student();
					oRpt1.SetDataSource(ds1);
					if (nView)
						{
						cReport.ReportSource = oRpt1;
						this.Text = "Ranking by Student";
						this.Show();
						}
					else
						oRpt1.PrintToPrinter(1,true,1,100);

					break;
			
				case 3:
					ds1 = oMySql.get_summary_of_products_by_brochure(sCompany, sCustomerID);
					summary_of_products_by_brochure oRpt3 = new summary_of_products_by_brochure();
					oRpt3.SetDataSource(ds1);
					if (nView)
					{
						cReport.ReportSource = oRpt3;
						this.Text = "Summary of Products by Brochure";
						this.Show();
					}
					else
						oRpt3.PrintToPrinter(1,true,1,100);
					break;
				case 4:
					ds1 = oMySql.get_detail_by_student_by_class(sCompany, sCustomerID);
					detail_by_student_by_class  oRpt4 = new detail_by_student_by_class();
					oRpt4.SetDataSource(ds1);
					if (nView)
					{
						cReport.ReportSource = oRpt4;
						this.Text = "Detail by Student by Class";
						this.Show();
					}
					else
						oRpt4.PrintToPrinter(1,true,1,100);
					break;
				case 5:
					ds1 = oMySql.get_detail_by_student(sCompany, sCustomerID);
					detail_by_student  oRpt5= new detail_by_student();
					oRpt5.SetDataSource(ds1);
					if (nView)
					{
						cReport.ReportSource = oRpt5;
						this.Text = "Order Detail by Student";
						this.Show();
					}
					else
						oRpt5.PrintToPrinter(1,true,1,100);
					break;
				case 6:
					ds1= oMySql.get_prize_summary_by_student_by_class(sCompany, sCustomerID);
					prize_summary_by_student_by_class oRpt6 = new prize_summary_by_student_by_class();
					oRpt6.SetDataSource(ds1);
					if (nView)
					{
						cReport.ReportSource = oRpt6;
						this.Text = "Prize Summary by Student by Class";
						this.Show();
					}
					else
						oRpt6.PrintToPrinter(1,true,1,100);
					break;
				case 7:
					ds1= oMySql.get_summary_reps_sales(sCompany);
                    if (ds1 == null)
                        MessageBox.Show("BAD");
                    summary_reps_sales oRpt7 = new summary_reps_sales();
					oRpt7.SetDataSource(ds1);
					//ds1.WriteXml("..\\Reports\\dataset14.xml", XmlWriteMode.WriteSchema);
					if (nView)
					{
						this.Text = "Summary Rep Sales";
						cReport.ReportSource = oRpt7;
						this.Show();
					}
					else
						oRpt7.PrintToPrinter(1,true,1,100);
					break;

                case 8:
                    {
                        ds1 = oMySql.GetDataSetGAProducByBox(sCompany, sCustomerID);
                        if (ds1 == null)
                            MessageBox.Show("Please check the database");
                         GAInventoryBox oRpt = new GAInventoryBox();
                        oRpt.SetDataSource(ds1);
                        ds1.WriteXml("dataset00.xml", XmlWriteMode.WriteSchema);
                        if (nView)
                        {
                            this.Text = "Box Inventory";
                            cReport.ReportSource = oRpt;
                            this.Show();
                        }
                        else
                            oRpt.PrintToPrinter(1, true, 1, 100);
                       
                       
                    }
                    break;
                case 9:
                    {
                        ds1 = oMySql.GetDataSetGAByBox(sCompany, sCustomerID);
                        if (ds1 == null)
                            MessageBox.Show("Please check the database");
                        FinalBillTally oRpt = new FinalBillTally ();
                        oRpt.SetDataSource(ds1);
                         ds1.WriteXml("dataset19.xml", XmlWriteMode.WriteSchema);
                        if (nView)
                        {
                            this.Text = "Final Bill Tally Sheet";
                            cReport.ReportSource = oRpt;
                            this.Show();
                        }
                        else
                            oRpt.PrintToPrinter(1, true, 1, 100);


                    }
                    break;
                case 10:
                    {
                        ds1 = oMySql.GetDiscrepancyLetters(sCompany, sCustomerID);
                        if (ds1 == null)
                            MessageBox.Show("Please check the database");
                        DiscrepancyList oRpt = new DiscrepancyList();
                        //ds1.WriteXml("dataset22.xml", XmlWriteMode.WriteSchema);
                        oRpt.SetDataSource(ds1);
                        
                        if (nView)
                        {
                            this.Text = "Discrepancy List";
                            cReport.ReportSource = oRpt;
                            this.Show();
                        }
                        else
                            oRpt.PrintToPrinter(1, true, 1, 100);
                        

                    }
                    break;
                case 11:
                    {
                        ds1 = oMySql.GetCustomerPallets(sCompany, sCustomerID,Parameter_1);
                        if (ds1 == null)
                            MessageBox.Show("Please check the database");
                        PalletLabels oRpt = new PalletLabels();
                       
                        //ds1.WriteXml("dataset25.xml", XmlWriteMode.WriteSchema);

                        /*ParameterField ParamField = new ParameterField();
                        ParameterDiscreteValue DiscreteVal = new ParameterDiscreteValue();

                        DiscreteVal.Value = "5";
                        ParamField.CurrentValues.Add(DiscreteVal);

                        //' Add the parameter to the parameter fields collection.
                        oRpt.ParameterFields.Add(ParamField);*/

                       /* ParameterFieldDefinitions crParameterFieldDefinitions;
                        ParameterFieldDefinition crParameterFieldDefinition;
                        ParameterDiscreteValue crParameterDiscreteValue;
                        ParameterValues crParameterValues;

                        crParameterFieldDefinitions = oRpt.DataDefinition.ParameterFields;
                        //Access the specified parameter from the collection
                        
                        
                        
                        crParameterFieldDefinition = crParameterFieldDefinitions["BoxNumber"];
                        crParameterValues = crParameterFieldDefinition.CurrentValues;
                        crParameterDiscreteValue = null;

                        crParameterDiscreteValue = new ParameterDiscreteValue();
                        crParameterDiscreteValue.Value = "3"; //2nd current value

                        //Add the second current value for the parameter field
                        crParameterValues.Add(crParameterDiscreteValue);

                        //All current parameter values must be applied for the parameter field.
                        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                        
                        oRpt.SetParameterValue(0,Parameter_1);
                        
                        */
 

                        oRpt.SetDataSource(ds1);

                        if (nView)
                        {
                            this.Text = "Pallet Labels";
                            cReport.ReportSource = oRpt;
                            this.Show();
                        }
                        else
                            oRpt.PrintToPrinter(1, true, 1, 100);


                    }
                    break;
                case 12:
                    {
                        ds1 = oMySql.GetCustomerStatement(sCompany, sCustomerID);
                        if (ds1 == null)
                            MessageBox.Show("Please check the database");
                        Statement oRpt = new Statement();
                        ds1.WriteXml("dataset26.xml", XmlWriteMode.WriteSchema);
                        oRpt.SetDataSource(ds1);

                        if (nView)
                        {
                            this.Text = "Statement";
                            cReport.ReportSource = oRpt;
                            this.Show();
                        }
                        else
                            oRpt.PrintToPrinter(1, true, 1, 100);


                    }
                    break;
                case 13:
                    {
                        ds1 = oMySql.GetDiscrepancyLetters(sCompany, sCustomerID);
                        if (ds1 == null)
                            MessageBox.Show("Please check the database");
                        DiscrepancyLetters oRpt = new DiscrepancyLetters();
                        //ds1.WriteXml("dataset27.xml", XmlWriteMode.WriteSchema);
                        oRpt.SetDataSource(ds1);

                        if (nView)
                        {
                            this.Text = "Discrepancy Letters";
                            cReport.ReportSource = oRpt;
                            this.Show();
                        }
                        else
                            oRpt.PrintToPrinter(1, true, 1, 100);


                    }
                    break;
                case 14:
                    {
                        ds1 = oMySql.GetPOReceive(sCompany,sParameter_1);
                        if (ds1 == null)
                            MessageBox.Show("Please check the database");
                        ds1.WriteXml("dataset29.xml", XmlWriteMode.WriteSchema);
                        POReceive oRpt = new POReceive();
                        
                        oRpt.SetDataSource(ds1);

                        if (nView)
                        {
                            this.Text = "PO Receive";
                            cReport.ReportSource = oRpt;
                            this.Show();
                        }
                        else
                            oRpt.PrintToPrinter(1, true, 1, 100);


                    }
                    break;
                case 15:
                    {
                        ds1 = oMySql.GetPOReceive(sCompany, sParameter_1);
                        if (ds1 == null)
                            MessageBox.Show("Please check the database");
                        ds1.WriteXml("dataset29.xml", XmlWriteMode.WriteSchema);
                        POReceive oRpt = new POReceive();

                        oRpt.SetDataSource(ds1);

                        if (nView)
                        {
                            this.Text = "PO Receive";
                            cReport.ReportSource = oRpt;
                            this.Show();
                        }
                        else
                            oRpt.PrintToPrinter(1, true, 1, 100);


                    }
                    break;

				default:
					break;

			}
			//oMySql.Close();


		}


		private void frmReport_Load(object sender, System.EventArgs e)
		{
			//String sCustomerID = "T0002";
			
			//view_report(1,"T07",sCustomerID);
			//view_report(2,"T07",sCustomerID);
			//view_report(3,"T07",sCustomerID);
			//view_report(4,"T07",sCustomerID);
			//view_report(5,"T07",sCustomerID);
			//view_report(6,"T07",sCustomerID);
			//return;

					
			//prize_summary_by_student_by_class oRpt_1;
			//DataSet ds1;

			//MySql oMySql = new MySql() ; // Sql Open
			
			
			//ds1 = oMySql.get_ranking_by_student();
			//ds1 = oMySql.get_summary_by_classes();
			//ds1 = oMySql.get_summary_of_products_by_brochure();
			//ds1 = oMySql.get_summary_by_student_by_class();
			//ds1 = oMySql.get_detail_by_student();
			//ds1= oMySql.get_prize_summary_by_student_by_class();
			
			//ds1.WriteXml("..\\Reports\\dataset12.xml", XmlWriteMode.WriteSchema);
			
			//oRpt = new ReportDocument();
			//oRpt.Load("c:\\Ten_Top\\ranking_by_student.rpt");
			//oRpt.Load("c:\\Ten_Top\\summary_by_classes.rpt");
			//oRpt.Load("c:\\Ten_Top\\summary_of_products_by_brochure.rpt");
			//oRpt.Load("c:\\Ten_Top\\summary_by_student_by_class.rpt");
			//oRpt.Load("c:\\Ten_Top\\detail_by_student_by_class.rpt");
			//oRpt.Load("c:\\Ten_Top\\prize_summary_by_student_by_class.rpt");
			
			//oRpt_1 = new prize_summary_by_student_by_class();
			//oRpt_1.SetDataSource(ds1);
			//cReport.ReportSource = oRpt;
			//cReport.ReportSource = oRpt_1;
			

			//oMySql.Close();

			/*		ReportDocument myReport = new ReportDocument();


					myReport.SetDataSource(ds1);
					if (b_title)
						myReport.SetParameterValue("title", sReport);
        
					myViewer.ReportSource = myReport;*/

			/*	customerReport = new Customer();
				DataSet dataSet;
				dataSet = DataSetConfiguration.CustomerDataSet;
				customerReport.SetDataSource(dataSet);
				crystalReportViewer.ReportSource = customerReport;
				*/


		}
	}
}
