using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Signature
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmTimerMessage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
        public Label Message;
        public Color MsgColor;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        
        

		public frmTimerMessage()
		{
			InitializeComponent();

		
		}

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Message = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.Message);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1190, 95);
            this.panel1.TabIndex = 0;
            // 
            // Message
            // 
            this.Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.ForeColor = System.Drawing.Color.Green;
            this.Message.Location = new System.Drawing.Point(3, 0);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(1187, 91);
            this.Message.TabIndex = 0;
            this.Message.Text = "WRONG SCHOOL";
            this.Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTimerMessage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1190, 95);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimerMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmTimerMessage_Paint);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		
        private void Form1_Load(object sender, EventArgs e)
        {
                myTimer.Tick += new EventHandler(TimerEventProcessor);

                // Sets the timer interval to 5 seconds.
                myTimer.Interval = (Int32)1000 / 2;
                
            myTimer.Start();            

        }
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
                myTimer.Stop();
                this.Close();
            
        }

        private void frmTimerMessage_Paint(object sender, PaintEventArgs e)
        {
            
            Message.ForeColor = MsgColor;
            
            
        }

        

	}
}
