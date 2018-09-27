using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.UPS.Tracking;

namespace Signature.Forms
{
	/// <summary>
	/// A test form for testing shipping information
	/// </summary>
	public class frmTracking : frmBase
	{
		
        #region declaration
        private Signature.Windows.Forms.TabControl shipperTabs;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TextBox txtSchDelivery;
		private System.Windows.Forms.TextBox txtStatus1;
		private System.Windows.Forms.TextBox txtType;
		private System.Windows.Forms.Label lbDelivery;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox txtTrackingNumber;
		private System.Windows.Forms.Button cmdTrack;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGrid dgTrackingInfo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        String LicenseNumber;
        String UserName;
        private Label lbTo;
        private TextBox txtWeight;
        private Label label12;
        private TextBox txtService;
        private Label label11;
        private TextBox txtReference;
        private Label lbReference;
        private TextBox txtBilledOn;
        private Label lbShippedSigned;
        private Label label4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtShippedFrom;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtShipTo;
#endregion
        String Password;
        Boolean IsAuto = false;

		public frmTracking(Boolean _IsAuto)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            IsAuto = _IsAuto;

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.shipperTabs = new Signature.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgTrackingInfo = new System.Windows.Forms.DataGrid();
            this.txtShipTo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtShippedFrom = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtService = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.lbReference = new System.Windows.Forms.Label();
            this.txtBilledOn = new System.Windows.Forms.TextBox();
            this.lbShippedSigned = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.txtSchDelivery = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lbDelivery = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTrackingNumber = new System.Windows.Forms.TextBox();
            this.cmdTrack = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStatus1 = new System.Windows.Forms.TextBox();
            this.shipperTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrackingInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippedFrom)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 708);
            this.txtStatus.Size = new System.Drawing.Size(584, 29);
            // 
            // shipperTabs
            // 
            this.shipperTabs.Controls.Add(this.tabPage1);
            this.shipperTabs.Controls.Add(this.tabPage2);
            this.shipperTabs.Controls.Add(this.tabPage3);
            this.shipperTabs.Controls.Add(this.tabPage4);
            this.shipperTabs.ItemSize = new System.Drawing.Size(0, 15);
            this.shipperTabs.Location = new System.Drawing.Point(8, 8);
            this.shipperTabs.Name = "shipperTabs";
            this.shipperTabs.SelectedIndex = 0;
            this.shipperTabs.Size = new System.Drawing.Size(564, 693);
            this.shipperTabs.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.dgTrackingInfo);
            this.tabPage1.Controls.Add(this.txtShipTo);
            this.tabPage1.Controls.Add(this.txtShippedFrom);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtWeight);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.txtService);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtReference);
            this.tabPage1.Controls.Add(this.lbReference);
            this.tabPage1.Controls.Add(this.txtBilledOn);
            this.tabPage1.Controls.Add(this.lbShippedSigned);
            this.tabPage1.Controls.Add(this.lbTo);
            this.tabPage1.Controls.Add(this.txtSchDelivery);
            this.tabPage1.Controls.Add(this.txtType);
            this.tabPage1.Controls.Add(this.lbDelivery);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtTrackingNumber);
            this.tabPage1.Controls.Add(this.cmdTrack);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 19);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(556, 670);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "UPS";
            // 
            // dgTrackingInfo
            // 
            this.dgTrackingInfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgTrackingInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgTrackingInfo.DataMember = "";
            this.dgTrackingInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgTrackingInfo.Location = new System.Drawing.Point(10, 362);
            this.dgTrackingInfo.Name = "dgTrackingInfo";
            this.dgTrackingInfo.Size = new System.Drawing.Size(533, 299);
            this.dgTrackingInfo.TabIndex = 8;
            // 
            // txtShipTo
            // 
            this.txtShipTo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtShipTo.Enabled = false;
            this.txtShipTo.Location = new System.Drawing.Point(203, 185);
            this.txtShipTo.Multiline = true;
            this.txtShipTo.Name = "txtShipTo";
            this.txtShipTo.Size = new System.Drawing.Size(262, 42);
            this.txtShipTo.TabIndex = 33;
            // 
            // txtShippedFrom
            // 
            this.txtShippedFrom.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtShippedFrom.Enabled = false;
            this.txtShippedFrom.Location = new System.Drawing.Point(203, 61);
            this.txtShippedFrom.Multiline = true;
            this.txtShippedFrom.Name = "txtShippedFrom";
            this.txtShippedFrom.Size = new System.Drawing.Size(262, 42);
            this.txtShippedFrom.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Shipped From:";
            // 
            // txtWeight
            // 
            this.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeight.Enabled = false;
            this.txtWeight.Location = new System.Drawing.Point(203, 308);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(106, 20);
            this.txtWeight.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 307);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Weight:";
            // 
            // txtService
            // 
            this.txtService.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtService.Enabled = false;
            this.txtService.Location = new System.Drawing.Point(203, 283);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(106, 20);
            this.txtService.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 283);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Service:";
            // 
            // txtReference
            // 
            this.txtReference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReference.Enabled = false;
            this.txtReference.Location = new System.Drawing.Point(203, 257);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(160, 20);
            this.txtReference.TabIndex = 25;
            // 
            // lbReference
            // 
            this.lbReference.AutoSize = true;
            this.lbReference.Location = new System.Drawing.Point(30, 257);
            this.lbReference.Name = "lbReference";
            this.lbReference.Size = new System.Drawing.Size(111, 13);
            this.lbReference.TabIndex = 24;
            this.lbReference.Text = "Reference Number(s):";
            // 
            // txtBilledOn
            // 
            this.txtBilledOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBilledOn.Enabled = false;
            this.txtBilledOn.Location = new System.Drawing.Point(203, 232);
            this.txtBilledOn.Name = "txtBilledOn";
            this.txtBilledOn.Size = new System.Drawing.Size(160, 20);
            this.txtBilledOn.TabIndex = 23;
            // 
            // lbShippedSigned
            // 
            this.lbShippedSigned.AutoSize = true;
            this.lbShippedSigned.Location = new System.Drawing.Point(30, 232);
            this.lbShippedSigned.Name = "lbShippedSigned";
            this.lbShippedSigned.Size = new System.Drawing.Size(96, 13);
            this.lbShippedSigned.TabIndex = 22;
            this.lbShippedSigned.Text = "Shipped/Billed On:";
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Location = new System.Drawing.Point(30, 185);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(65, 13);
            this.lbTo.TabIndex = 20;
            this.lbTo.Text = "Shipped To:";
            // 
            // txtSchDelivery
            // 
            this.txtSchDelivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSchDelivery.Enabled = false;
            this.txtSchDelivery.Location = new System.Drawing.Point(203, 159);
            this.txtSchDelivery.Name = "txtSchDelivery";
            this.txtSchDelivery.Size = new System.Drawing.Size(160, 20);
            this.txtSchDelivery.TabIndex = 19;
            // 
            // txtType
            // 
            this.txtType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtType.Enabled = false;
            this.txtType.Location = new System.Drawing.Point(203, 109);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(106, 20);
            this.txtType.TabIndex = 17;
            // 
            // lbDelivery
            // 
            this.lbDelivery.AutoSize = true;
            this.lbDelivery.Location = new System.Drawing.Point(30, 163);
            this.lbDelivery.Name = "lbDelivery";
            this.lbDelivery.Size = new System.Drawing.Size(102, 13);
            this.lbDelivery.TabIndex = 16;
            this.lbDelivery.Text = "Scheduled Delivery:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Type:";
            // 
            // txtTrackingNumber
            // 
            this.txtTrackingNumber.Location = new System.Drawing.Point(203, 21);
            this.txtTrackingNumber.Name = "txtTrackingNumber";
            this.txtTrackingNumber.Size = new System.Drawing.Size(160, 20);
            this.txtTrackingNumber.TabIndex = 11;
            // 
            // cmdTrack
            // 
            this.cmdTrack.Location = new System.Drawing.Point(393, 319);
            this.cmdTrack.Name = "cmdTrack";
            this.cmdTrack.Size = new System.Drawing.Size(72, 24);
            this.cmdTrack.TabIndex = 13;
            this.cmdTrack.Text = "Track";
            this.cmdTrack.Click += new System.EventHandler(this.cmdTrack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tracking Number:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 19);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(480, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FedEx";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Not Yet Supported";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 19);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(480, 557);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DHL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Not Yet Supported";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Location = new System.Drawing.Point(4, 19);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(480, 557);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "USPS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(87, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Not Yet Supported";
            // 
            // txtStatus1
            // 
            this.txtStatus1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus1.Enabled = false;
            this.txtStatus1.Location = new System.Drawing.Point(203, 134);
            this.txtStatus1.Name = "txtStatus1";
            this.txtStatus1.Size = new System.Drawing.Size(160, 20);
            this.txtStatus1.TabIndex = 18;
            // 
            // frmTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(584, 737);
            this.Controls.Add(this.shipperTabs);
            this.Name = "frmTracking";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Shipper Tracking Interface";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmTracking_Load);
            this.Shown += new System.EventHandler(this.frmTracking_Shown);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.shipperTabs, 0);
            this.shipperTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrackingInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippedFrom)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		

		public void cmdTrack_Click(object sender, System.EventArgs e)
		{
			AccessRequest ar;
			TrackingRequest tr;
			TrackingResponse trackResponse;

			tr = new TrackingRequest(txtTrackingNumber.Text, "1");
			ar = new AccessRequest(LicenseNumber, UserName, Password);

			trackResponse = tr.MakeRequest(ar);

            txtType.Text = "Package";




            if (trackResponse.MyResponse.ResponseStatusCode == 0)
            {
                MessageBox.Show("No Activity Information From UPS");
                this.Close();
                return;
            }

            if (trackResponse.MyShipment.MyPackage.Activity[0].Status.MyStatusType.Code == "X")
            {
                lbDelivery.Text = "Rescheduled Delivery:";
                txtSchDelivery.Text = trackResponse.MyShipment.MyPackage.RescheduledDeliveryDate.ToString();
                lbReference.Visible = false;
                txtReference.Visible = false;
                txtStatus1.Text = "Exception";
                txtShipTo.Text = trackResponse.MyShipment.MyShipTo.DestAddress.AddressLine1 + "\n" +
                                 trackResponse.MyShipment.MyShipTo.DestAddress.City + " " +
                                 trackResponse.MyShipment.MyShipTo.DestAddress.StateProvinceCode;
                txtBilledOn.Text = trackResponse.MyShipment.MyPackage.Activity[trackResponse.MyShipment.MyPackage.Activity.Length - 1].Timestamp.ToString();
                //Reference ?
                lbReference.Visible = true;
                txtReference.Enabled = false;
                txtReference.Visible = true;
                txtReference.Text = trackResponse.MyShipment.MyPackage.MyReferenceNumbers[trackResponse.MyShipment.MyPackage.MyReferenceNumbers.Length-1].Value.ToString();

            }
            else if (trackResponse.MyShipment.MyPackage.Activity[0].Status.MyStatusType.Code == "D")
            {
                lbShippedSigned.Text = "Signed By:";
                txtBilledOn.Text = trackResponse.MyShipment.MyPackage.Activity[0].Location.SignedFor;

                lbTo.Text = "Delivered To:";
                txtShipTo.Text = trackResponse.MyShipment.MyShipTo.DestAddress.AddressLine1 + "\n" +
                                 trackResponse.MyShipment.MyShipTo.DestAddress.City + " " +
                                 trackResponse.MyShipment.MyShipTo.DestAddress.StateProvinceCode;
                
                lbDelivery.Text = "Delivered On:";
                txtSchDelivery.Text = trackResponse.MyShipment.MyPackage.Activity[0].Timestamp.ToString();

                txtStatus1.Text = "Delivered";

            }
            else
            {

                if (trackResponse.MyShipment.MyPackage.Message != null)
                {
                    txtStatus1.Text = trackResponse.MyShipment.MyPackage.Message.Description + "-";
                }
                txtStatus1.Text += trackResponse.MyShipment.MyPackage.Activity[0].Status.MyStatusType.Description.ToLower();
               
                
                txtSchDelivery.Text = trackResponse.MyShipment.ScheduledDeliveryDate.ToString();
                try
                {
                    txtShipTo.Text = trackResponse.MyShipment.MyShipTo.DestAddress.AddressLine1 + "\n" +
                                     trackResponse.MyShipment.MyShipTo.DestAddress.City + " " +
                                     trackResponse.MyShipment.MyShipTo.DestAddress.StateProvinceCode;
                    txtBilledOn.Text = trackResponse.MyShipment.MyPackage.Activity[trackResponse.MyShipment.MyPackage.Activity.Length - 1].Timestamp.ToString();
                    //MessageBox.Show(trackResponse.MyShipment.MyPackage.Activity[trackResponse.MyShipment.MyPackage.Activity.Length - 1].Status.MyStatusType.Code);
                    txtReference.Text = trackResponse.MyShipment.MyReferenceNumbers[0].Value.ToString();
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
                    
                    lbReference.Visible = true;
                    txtReference.Enabled = false;
                    txtReference.Visible = true;
                    
                
            }
            try
                {
            txtShippedFrom.Text = trackResponse.MyShipment.MyShipper.SourceAddress.AddressLine1 + "\n" +
                                    trackResponse.MyShipment.MyShipper.SourceAddress.City + ", " +
                                    trackResponse.MyShipment.MyShipper.SourceAddress.StateProvinceCode + " " +
                                    trackResponse.MyShipment.MyShipper.SourceAddress.PostalCode;

            
            txtWeight.Text = trackResponse.MyShipment.MyPackage.PackageWeight.Weight.ToString() + " " + trackResponse.MyShipment.MyPackage.PackageWeight.MyUnitOfMeasurement.Code;
            txtService.Text = trackResponse.MyShipment.MyService.Description;
        }
        catch (Exception ex)
        {
            Console.Out.WriteLine(ex.Message);
        }
            
            
            dgTrackingInfo.DataSource = trackResponse.GetTrackingInfo();
		}

        private void frmTracking_Load(object sender, EventArgs e)
        {
            LicenseNumber = "4C1C73A0313E24AE";
            UserName = "amedinag";
            Password = "michelle";
            //txtTrackingNumber.Text = "1Z450X110345931230"; //"1Z1599220305223565";

            lbReference.Visible = false;
            txtReference.Visible = false;
        }

        private void frmTracking_Shown(object sender, EventArgs e)
        {
            if (IsAuto)
                cmdTrack_Click(null, null);
        }
	}
}
