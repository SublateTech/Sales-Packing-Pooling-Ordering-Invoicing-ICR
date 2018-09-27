using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Signature.Windows.Forms
{

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MaskedEdit))]
    [DesignerAttribute(typeof(MaskedEditDesigner))]
    public class TextEditor1 : Signature.Windows.Forms.VistaTextBox  
    {
        public TextEditor1()
        {
            this.BorderColor = Color.FromArgb(171, 173, 179);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!this.Multiline)
            {
                if (e.KeyChar == 0x0D)
                {
                    //base.OnKeyPress(e);
                    e.Handled = false;
                    return;
                }
            }
            base.OnKeyPress(e);
            return;
        }

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                return true;
            }
            
            if (!this.Multiline)
            {
                if (keyData == Keys.Enter || keyData == Keys.Down || keyData == Keys.Up)
                {
                    return true;
                }
            }
            else
            {
                base.ProcessCmdKey(ref msg, keyData);
                return false;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public new void Clear()
        {
            base.Text = "";
        }


    }
    [ToolboxItem(true)]
	[ToolboxBitmap(typeof(MaskedEdit))]
	[DesignerAttribute(typeof(MaskedEditDesigner))]
    public class MaskedEdit : Signature.Windows.Forms.VistaTextBox  
	{
        public MaskedEdit()
        {
            this.BorderColor = Color.FromArgb(171, 173, 179);
            BorderStyle = BorderStyle.FixedSingle;
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			
			if (e.KeyChar==0x0D)
			{	
				//base.OnKeyPress(e);
                e.Handled = false;
				return;
			}
	
			base.OnKeyPress(e);
			return;
		}

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                return true;
            }

               if (keyData == Keys.Enter || keyData == Keys.Down || keyData == Keys.Up)
                {
                    if (!this.Multiline)
                    {
              
                      return true;
                    }
                        else
                    {
                        base.ProcessCmdKey(ref msg, keyData);
                        return false;
                }
            }
            

            return base.ProcessCmdKey(ref msg, keyData);
        }
        /*
        public override string Text
        {
            get
            {
                // TODO:  Add MaskedEditNumeric.Text getter implementation
                return base.Text;
            }
            set
            {
                // TODO:  Add MaskedEditNumeric.Text setter implementation
                base.Text = value;
                base.OnLeave(null);
            }
        }*/
        public new void Clear()
        {
            base.Text = "";
        }
        
        
	}

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MaskedEdit))]
    [DesignerAttribute(typeof(MaskedEditDesigner))]
    public class TextBox : Signature.Windows.Forms.VistaTextBox  
    {
        public TextBox()
        {

            BorderStyle = BorderStyle.FixedSingle;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (e.KeyChar == 0x0D)
            {
                //base.OnKeyPress(e);
                e.Handled = false;
                return;
            }

            base.OnKeyPress(e);
            return;
        }

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter || keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Tab)
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        /*
        public override string Text
        {
            get
            {
                // TODO:  Add MaskedEditNumeric.Text getter implementation
                return base.Text;
            }
            set
            {
                // TODO:  Add MaskedEditNumeric.Text setter implementation
                base.Text = value;
                base.OnLeave(null);
            }
        }*/
        public new void Clear()
        {
            base.Text = "";
        }


    }

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MaskedEdit))]
    [DesignerAttribute(typeof(MaskedEditNumericDesigner))]
    public class MaskedEditNumeric : Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    {
        public MaskedEditNumeric()
        {
            this.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
        }
        
        public Double Number
        {
            get
            {
                if (this.Value.ToString() == "" || this.Value.ToString() == ".")
                    return Convert.ToDouble("0.00");
                else
                    return Convert.ToDouble(this.Value);

            }
          
        }

        
        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (e.KeyChar == 0x0D)
            {
                //base.OnKeyPress(e);
                e.Handled = false;
                return;
            }

            base.OnKeyPress(e);
            return;
        }

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter || keyData == Keys.Up || keyData == Keys.Down)
            {
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
        /*
        public override string Text
        {
            get
            {
                // TODO:  Add MaskedEditNumeric.Text getter implementation
                return base.Text;
            }
            set
            {
                // TODO:  Add MaskedEditNumeric.Text setter implementation
                base.Text = value;
                base.OnLeave(null);
            }
        }*/
        public void Clear()
        {
            base.Text = "";
        }
    }

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MaskedLabel))]
    [DesignerAttribute(typeof(MaskedLabelDesigner))]
    public class MaskedLabel : Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel
    {
        public MaskedLabel()
        {
            //   this.Leave += new System.EventHandler(this.TextEdit_Leave);	
        }
        // private void TextEdit_Leave(object sender, System.EventArgs e)
        // { }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (e.KeyChar == 0x0D)
            {
                //base.OnKeyPress(e);
                e.Handled = false;
                return;
            }

            base.OnKeyPress(e);
            return;
        }

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter)
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        /*
        public override string Text
        {
            get
            {
                // TODO:  Add MaskedEditNumeric.Text getter implementation
                return base.Text;
            }
            set
            {
                // TODO:  Add MaskedEditNumeric.Text setter implementation
                base.Text = value;
                base.OnLeave(null);
            }
        }*/
        public void Clear()
        {
            base.Text = "";
        }
    }

	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(MaskedEdit))]
	[DesignerAttribute(typeof(ComboBoxDesigner))]
	public class ComboBox :  Signature.Windows.Forms.VistaComboBox
	{
		public ComboBox()
		{
			
		}

        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (e.KeyChar == '\x0D')
            {
                // MessageBox.Show("Up");
                //base.OnKeyPress(e);
                e.Handled = false;
                return;
            }

            if (Char.IsLower(e.KeyChar))
                e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());

            base.OnKeyPress(e);
            return;
        }

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter || keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Tab || keyData == Keys.PageDown)
            {
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
			
		
		
	
	}

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MaskedEdit))]
    [DesignerAttribute(typeof(ComboBoxDesigner))]
    public class RichTextBox : System.Windows.Forms.RichTextBox
    {
        public RichTextBox()
        {

        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (e.KeyChar == '\x0D')
            {
                // MessageBox.Show("Up");
                //base.OnKeyPress(e);
                e.Handled = false;
                return;
            }

           // if (Char.IsLower(e.KeyChar))
           //     e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());

            base.OnKeyPress(e);
            return;
        }

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter || keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Tab || keyData == Keys.PageDown)
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }




    }

	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(MaskedEdit))]
	[DesignerAttribute(typeof(CalendarBoxDesigner))]
	public class CalendarBox :  Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
	{
		public CalendarBox()
		{
			
		}

        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (e.KeyChar == '\x0D')
            {
               // MessageBox.Show("Up");
                //base.OnKeyPress(e);
                e.Handled = false;
                return;
            }

            base.OnKeyPress(e);
            return;
        }

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter || keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Tab)
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
			
	
	}

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MaskedEdit))]
    [DesignerAttribute(typeof(ComboBoxDesigner))]
    public class UltraComboBox : Infragistics.Win.UltraWinEditors.UltraComboEditor
    {
        public UltraComboBox()
        {

        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            
            if (e.KeyChar == '\x0D')
            {
                // MessageBox.Show("Up");
                //base.OnKeyPress(e);
                e.Handled = false;
                return;
            }

            base.OnKeyPress(e);
            return;
        }

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter || keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Tab)
            {
                
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
    
    #region Old TexBox
    /*
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MaskedEdit))]
    [DesignerAttribute(typeof(MaskedEditDesigner))]
    public class TextBox1 : Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit 
    {
        System.Windows.Forms.CharacterCasing _CharacterCasing;
        Infragistics.Win.UltraWinMaskedEdit.EditAsType _EditAs;
     
        public TextBox1()
        {

            Appearance.ForeColorDisabled = Color.Black;
            Appearance.BackColorDisabled = Color.White;
            PromptChar = ' ';
            EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.String;
            InputMask = "";
            
        }
        
        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (e.KeyChar == 0x0D)
            {
                //base.OnKeyPress(e);
                e.Handled = false;
                return;
            }

            base.OnKeyPress(e);
            return;
        }

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter || keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Tab)
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        public override string Text
        {
            get
            {
                // TODO:  Add MaskedEditNumeric.Text getter implementation
                return base.Text;
            }
            set
            {
                // TODO:  Add MaskedEditNumeric.Text setter implementation
                base.Text = value;
                base.OnLeave(null);
            }
        }
        public void Clear()
        {
            base.Text = "";
        }
        
           public CharacterCasing CharacterCasing 
        {
            set { _CharacterCasing = value; }
        }

        public Boolean Multiline
        {
            set { ; }
        }
    }
    */
    #endregion
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MaskedEdit))]
    [DesignerAttribute(typeof(ComboBoxDesigner))]
    public class GroupBox : Infragistics.Win.Misc.UltraGroupBox //System.Windows.Forms.GroupBox //
    {
        public GroupBox()
        {
            ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP; //.Office2007;
            BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            Appearance.BackColor = Color.Transparent;
            Appearance.AlphaLevel = 95;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (e.KeyChar == '\x0D')
            {
                // MessageBox.Show("Up");
                //base.OnKeyPress(e);
                e.Handled = false;
                return;
            }

            base.OnKeyPress(e);
            return;
        }

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter || keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Tab)
            {

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public System.Windows.Forms.FlatStyle FlatStyle
        {
            get
            {
                return System.Windows.Forms.FlatStyle.System;
            }
            set
            {

            }
        }

    }

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MaskedEdit))]
    [DesignerAttribute(typeof(ComboBoxDesigner))]
    public class Button : Signature.Windows.Forms.GlassButton
    {
        public Button()
        {
            this.ForeColor = System.Drawing.Color.Black;
            this.BackColor = System.Drawing.SystemColors.Control; //.Color.LightSteelBlue;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (e.KeyChar == '\x0D')
            {
                // MessageBox.Show("Up");
                //base.OnKeyPress(e);
                e.Handled = false;
                return;
            }

            base.OnKeyPress(e);
            return;
        }

        //Process key strokes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter || keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Tab)
            {

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
