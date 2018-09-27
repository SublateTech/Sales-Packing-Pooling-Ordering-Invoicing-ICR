using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Collections;
using System.Diagnostics; 

namespace Signature.Windows.Forms
{
	/// <summary>
	/// Provides a standard Winform ListView with editing capabilities.
	/// </summary>
	[DefaultEvent("ButtonClick"),DesignTimeVisible(true),ToolboxItem(true),]
	public class ListViewExEdit : System.ComponentModel.Component
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ListViewExEdit(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

		}

		public ListViewExEdit()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

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

        

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.textBox = new Signature.Windows.Forms.ListViewExEdit.TextBoxEx();
            this.button = new System.Windows.Forms.Button();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(17, 17);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 20);
            this.textBox.TabIndex = 0;
            this.textBox.Visible = false;
            this.textBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // button
            // 
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button.Location = new System.Drawing.Point(116, 17);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(30, 23);
            this.button.TabIndex = 0;
            this.button.Text = "...";
            this.button.Visible = false;
            this.button.Click += new System.EventHandler(this.buttonAction_Click);

		}
		#endregion

		#region public 

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The column settings collection")]
		public ColumnSettingsCollection ColumnSettings
		{
			get
			{
				return columnSettingsCollection;
			}
		}

		[Description("The listview this extender works with. If the listview is not set, the extender has no function.")]
		public ListView ListView
		{
			get 
			{
				return listView;
			}
			set 
			{
				// unhook from previous listview
				if (listView!=null) 
				{
					this.listView.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.listView_MouseDown);
					this.listView.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.listView_MouseUp);
					this.listView.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.listView_MouseMove);
					this.listView.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);

					this.listView.Controls.Remove(this.textBox);
					this.listView.Controls.Remove(this.button);
				}

				listView=value;

				// hookup events
				if (listView!=null) 
				{
					this.listView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDown);
					this.listView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_MouseUp);
					this.listView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView_MouseMove);
					this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);

					this.listView.Controls.Add(this.textBox);
					this.listView.Controls.Add(this.button);

				}
			}
		}



		[Browsable(false)]
		public int SelectedIndex 
		{
			get 
			{
				Debug.Assert(this.listView.SelectedIndices.Count<=1);
				return (this.listView.SelectedIndices.Count==1)?this.listView.SelectedIndices[0]:-1;
			}
		}

		private Cursor editableCursor=Cursors.Hand;
		private Signature.Windows.Forms.ListViewExEdit.TextBoxEx textBox;
		private System.Windows.Forms.Button button;
		private Cursor selectedCursor=Cursors.IBeam;

		[Description("The cursor that appears when the mouse passes over an editable column."), Category("Appearance")]
		public Cursor EditableCursor 
		{
			get 
			{
				return editableCursor;
			}
			set 
			{
				editableCursor=value;
			}
		}

		[Description("The cursor that appears when the mouse passes over an editable field."), Category("Appearance")]
		public Cursor SelectedCursor 
		{
			get 
			{
				return selectedCursor;
			}
			set 
			{
				selectedCursor=value;
			}
		}


		[Description("The embedded button that will show when the listbox is in editmode and DisplayButton is true")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Button Button 
		{
			get 
			{
				return this.button;
			}
		}

		[Description("The embedded textbox that will show when the listbox is in editmode")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public System.Windows.Forms.TextBox TextBox 
		{
			get 
			{
				return this.textBox;
			}
		}

		#endregion

		#region private

		private ColumnSettingsCollection columnSettingsCollection = new ColumnSettingsCollection();
		private ListView listView;
        internal const int DefaultButtonWidth = 25;
		internal const string DefaultButtonText="...";

		private bool HasButton(int index)  
		{
			if ((index >=0)&&(index<columnSettingsCollection.Count)) 
			{
				return columnSettingsCollection[index].HasButton;
			}
			return false;
		}

		private bool IsEditable(int index) 
		{
			if ((index >=0)&&(index<columnSettingsCollection.Count)) 
			{
				return columnSettingsCollection[index].IsEditable;
			}
			return false;
		}

		private int GetButtonWidth(int index) 
		{
			if ((index >=0)&&(index<columnSettingsCollection.Count)) 
			{
				return columnSettingsCollection[index].ButtonWidth;
			}
			return DefaultButtonWidth;
		}

		private string GetButtonText(int index) 
		{
			if ((index >=0)&&(index<columnSettingsCollection.Count)) 
			{
				return columnSettingsCollection[index].ButtonText;
			}
			return DefaultButtonText;
		}


		private void NextIndex(ref ItemIndices indices, bool previous) 
		{
			indices.SubItemIndex+=previous?-1:1;
			if (indices.SubItemIndex>=(this.listView.Items[indices.ItemIndex].SubItems.Count)) 
			{
				indices.SubItemIndex=0;
				indices.ItemIndex++;
			} 
			else if (indices.SubItemIndex<0) 
			{
				indices.SubItemIndex=this.listView.Items[indices.ItemIndex].SubItems.Count-1;
				indices.ItemIndex--;
			}
			if (indices.ItemIndex>=this.listView.Items.Count) indices.ItemIndex=0;
			if (indices.ItemIndex<0) indices.ItemIndex=this.listView.Items.Count-1;
		}



		private struct ItemIndices 
		{
			internal ItemIndices(int itemIndex, int subitemindex) 
			{
				this.ItemIndex=itemIndex;
				this.SubItemIndex=subitemindex;
			}
			internal int ItemIndex;
			internal int SubItemIndex;

			public override string ToString() 
			{
				return string.Format("[{0},{1}]",this.ItemIndex, this.SubItemIndex);
			}

			internal bool IsValid 
			{
				get 
				{
					return this.ItemIndex>=0;
				}
			}
		}


		private void StartEdit(ItemIndices indices)
		{
			// nothing to edit here
			if (!IsEditable(indices.SubItemIndex)) 
			{
				return;
			}

			Rectangle bounds=GetSubitemRectangle(indices.ItemIndex, indices.SubItemIndex);

			// take x from header if on first item (getsubitem returns bounds of whole item)
			if (indices.SubItemIndex==0) 
			{
				Rectangle header=GetHeaderRectangle(indices.SubItemIndex);
				bounds.X=header.X;
				bounds.Width=header.Width;
			} 

			// don't edit if textbox overlaps listview
			if (!this.listView.ClientRectangle.Contains(bounds)) return;

			if (HasButton(indices.SubItemIndex))
			{
				// make room for the button
				bounds.Width-=GetButtonWidth(indices.SubItemIndex);
			}

			this.textBox.Bounds = bounds;
			this.textBox.Text = this.listView.Items[indices.ItemIndex].SubItems[indices.SubItemIndex].Text;
			this.textBox.Modified=false;
			this.textBox.Tag=indices;
			this.textBox.SelectionStart=this.textBox.Text.Length;

			if (HasButton(indices.SubItemIndex))
			{
				this.button.Location=new Point(this.textBox.Left+this.textBox.Width, this.textBox.Top);
				this.button.Height=this.textBox.Height;
				this.button.Width=GetButtonWidth(indices.SubItemIndex);
				this.button.Text=GetButtonText(indices.SubItemIndex);
				this.button.Tag=indices;
			}
		}

		#endregion

		#region interop stuff

		private Rectangle GetSubitemRectangle(int itemIndex, int subitemIndex) 
		{
			Win32.RECT rect = new Win32.RECT();
			rect.top = subitemIndex;
			rect.left = (int)Win32.LVIR.BOUNDS;
			int intSendMessage = Win32.User32.SendMessage(this.listView.Handle, Win32.LVM.GETSUBITEMRECT, itemIndex, ref rect);

			return new Rectangle(rect.left, rect.top,rect.right-rect.left, rect.bottom-rect.top);
		}

		private Rectangle GetHeaderRectangle(int index)
		{
			Win32.RECT rect = new Win32.RECT();
			int intSendMessage = Win32.User32.SendMessage(Win32.User32.GetDlgItem(this.listView.Handle, 0), Win32.HDM.GETITEMRECT , index, ref rect);
			return new Rectangle(rect.left, rect.top, rect.right-rect.left, rect.bottom-rect.top);
		}

		private ItemIndices GetSubitemIndexAt(int x, int y) 
		{
			Win32.LVHITTESTINFO hti=new Win32.LVHITTESTINFO();
			hti.pt.x=x;
			hti.pt.y=y;
			hti.flags=Win32.LVHT.ONITEM;

			int res=Win32.User32.SendMessage(this.listView.Handle, Win32.LVM.SUBITEMHITTEST, 0, ref hti);

			return new ItemIndices(hti.iItem, hti.iSubItem);
		}

		#endregion

		#region delegate stuff
		public class ButtonClickedEventArgs : System.EventArgs
		{
			public ButtonClickedEventArgs(string text, int rowIndex, int colIndex) 
			{
				this.Text=text;
				this.RowIndex=rowIndex;
				this.ColIndex=colIndex;
			}
			public readonly string Text;
			public readonly int RowIndex;
			public readonly int ColIndex;
		}

		public delegate void ButtonClickedEventHandler(object sender, ButtonClickedEventArgs e);


		[Description("Occurs when the embedded button is clicked."), Category("Action")]
		public event ButtonClickedEventHandler ButtonClick;

		protected virtual void OnButtonClick(ButtonClickedEventArgs e) 
		{
			if (ButtonClick!=null)
			{
				ButtonClick(this, e);
			}
		}

		public class ModifiedChangedEventArgs : System.EventArgs
		{
			public ModifiedChangedEventArgs(string text, int rowIndex, int colIndex) 
			{
				this.Text=text;
				this.RowIndex=rowIndex;
				this.ColIndex=colIndex;
			}
			public readonly string Text;
			public readonly int RowIndex;
			public readonly int ColIndex;
		}

		public delegate void ModifiedChangedEventHandler(object sender, ModifiedChangedEventArgs e);

		[Description("Event fired when the value of the embedded textbox is changed."), Category("Property Changed")]
		public event ModifiedChangedEventHandler ModifiedChanged;

		protected virtual void OnModifiedChanged(ModifiedChangedEventArgs e) 
		{
			if (ModifiedChanged!=null) 
			{
				ModifiedChanged(this, e);
			}
		}

		//OnButtonClick(new ButtonClickedEventArgs(1, 2));

		[Description("Set text to listview")]
		public void SetFieldData(string text, int rowIndex, int colIndex)
		{
			if (this.textBox.Tag!=null)
			{
				ItemIndices indices=(ItemIndices)(this.textBox.Tag);
				if ((indices.ItemIndex==rowIndex)&&(indices.SubItemIndex==colIndex)) 
				{
					textBox.Text=text;
					OnModifiedChanged(new ModifiedChangedEventArgs(textBox.Text, indices.ItemIndex, indices.SubItemIndex));
					return;
				}
			}
			this.listView.Items[rowIndex].SubItems[colIndex].Text=text;
		}

		#endregion

		#region listview event handlers

		private void listView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ItemIndices indices=GetSubitemIndexAt(e.X, e.Y);
			if (!indices.IsValid) return;
				
			if (indices.ItemIndex!=this.SelectedIndex) return;

			if (this.textBox.Tag!=null) return;

			StartEdit(indices);
		}

		private void listView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (this.textBox.Tag!=null)
			{
				this.textBox.Visible = true;
				this.button.Visible=this.button.Tag!=null;
				this.textBox.BringToFront();
				this.textBox.Focus();
			}
		}

		private void listView_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ItemIndices indices=GetSubitemIndexAt(e.X, e.Y);
			if (indices.IsValid) 
			{
				if (IsEditable(indices.SubItemIndex)) 
				{
					Cursor.Current = (this.SelectedIndex==indices.ItemIndex)?selectedCursor:editableCursor;
				}
			}
		}

		private void listView_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) 
			{
				if (e.Alt||e.Control||e.Shift) return;

				// pick the first editable column
				for (int i=0; i<this.listView.Columns.Count;i++) 
				{
					if (IsEditable(i)) 
					{
						this.StartEdit(new ItemIndices(this.SelectedIndex, i));
						break;
					}
				}

				if (this.textBox.Tag!=null) 
				{
					this.textBox.Visible = true;
					this.button.Visible=this.button.Tag!=null;
					this.textBox.BringToFront();
					this.textBox.Focus();
				}
				e.Handled=true;
			}
		}


		#endregion

		#region textbox event handlers

		private void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) 
		{
			if (e.KeyCode == Keys.Escape) 
			{
				if (e.Alt||e.Control||e.Shift) return;

				this.button.Tag=this.textBox.Tag=null;
				textBox.Visible=false;
				button.Visible=false;
				this.listView.Focus();
				e.Handled=true;
			} 
			else if (e.KeyCode == Keys.Enter) 
			{
				if (e.Alt||e.Control||e.Shift) return;

				textBox.Visible=false;
				button.Visible=false;
				this.listView.Focus();
				e.Handled=true;
			}
			else if (e.KeyCode == Keys.Tab)
			{
				if (e.Alt||e.Control) return;

				if (this.textBox.Tag==null) return;

				// copy from textbox to listview
				ItemIndices indices=(ItemIndices)(this.textBox.Tag);
				this.listView.Items[indices.ItemIndex].SubItems[indices.SubItemIndex].Text=textBox.Text;
				if (textBox.Modified) OnModifiedChanged(new ModifiedChangedEventArgs(textBox.Text, indices.ItemIndex, indices.SubItemIndex));

				// advance to next editable field
				do 
				{
					NextIndex(ref indices, e.Shift);
				} while (!IsEditable(indices.SubItemIndex));

				StartEdit(indices);

				this.button.Visible=HasButton(indices.SubItemIndex);      // ==1);
			}
			else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) 
			{
            
                // copy from textbox to listview
				ItemIndices indices=(ItemIndices)(this.textBox.Tag);
				this.listView.Items[indices.ItemIndex].SubItems[indices.SubItemIndex].Text=textBox.Text;
				if (textBox.Modified) OnModifiedChanged(new ModifiedChangedEventArgs(textBox.Text, indices.ItemIndex, indices.SubItemIndex));

				// move editable field up or down
				indices.ItemIndex+=(e.KeyCode==Keys.Up)?-1:1;
				if (indices.ItemIndex>=this.listView.Items.Count) indices.ItemIndex=0;
				if (indices.ItemIndex<0) indices.ItemIndex=this.listView.Items.Count-1;

				StartEdit(indices);
			}
		}


		private void textBox_Leave(object sender, System.EventArgs e) 
		{
			if (this.textBox.Tag==null) return;
			  
			// don't hide editbox and button if focus is on button  
			if (button.Visible && button.Bounds.Contains(this.listView.PointToClient(Cursor.Position))) 
			{
				return;
			}

			ItemIndices indices=(ItemIndices)(this.textBox.Tag);
			this.listView.Items[indices.ItemIndex].SubItems[indices.SubItemIndex].Text=textBox.Text;
			if (textBox.Modified) OnModifiedChanged(new ModifiedChangedEventArgs(textBox.Text, indices.ItemIndex, indices.SubItemIndex));
			this.button.Visible=this.textBox.Visible=false;
			this.button.Tag=this.textBox.Tag=null;
		}

		#endregion

		#region button event handler

		private void buttonAction_Click(object sender, System.EventArgs e) 
		{
			if (((Control)sender).Tag==null) return;

			ItemIndices indices=(ItemIndices)(((Control)sender).Tag);

			OnButtonClick(new ButtonClickedEventArgs(textBox.Text, indices.ItemIndex, indices.SubItemIndex));
			textBox.Focus();
		}
		#endregion

		#region private classes

		private class TextBoxEx : System.Windows.Forms.TextBox
		{	
			#region overide from control
			protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
			{
				if ((keyData==Keys.Tab)||(keyData == (Keys.Shift|Keys.Tab)))
				{
					// grab Tab and Shift-Tab before the framework takes them
					this.OnKeyDown(new KeyEventArgs(keyData));
					return true;
				}
				else if (keyData==Keys.Escape) 
				{
					// grab escape key before framework takes it
					this.OnKeyDown(new KeyEventArgs(keyData));
					return true;
				} 
				else if (keyData==Keys.Enter) 
				{
					// grab enter before someone sounds the bell
					this.OnKeyDown(new KeyEventArgs(keyData));
					return true;
				}
				else 
				{
					// normal processing for all other keys
					return base.ProcessCmdKey (ref msg, keyData);
				}
			}
			#endregion
		}

		#endregion

        
	}

	#region class ColumnSettingsCollection
	public class ColumnSettingsCollection : CollectionBase
	{
		public virtual ColumnSetting Add(ColumnSetting value)
		{
			base.List.Add(value);
			return value;
		}

		public virtual void AddRange(ColumnSetting[] values)
		{
			foreach (ColumnSetting item in values) 
			{
				base.List. Add(item);
			}
		}

		public virtual void Remove(ColumnSetting value)
		{
			base.List.Remove(value);
		}

		public new void RemoveAt(int index)
		{
			if (index < base.List.Count)
			{
				Remove(this[index]);
			}
		}

		public virtual ColumnSetting Insert(int index, ColumnSetting value)
		{
			if (index >= List.Count) 
			{
				this.Add(value);
			}
			else
			{
				base.List.Insert(index, value);
			}
			return value;
		}

		public virtual bool Contains(ColumnSetting value)
		{
			return base.List.Contains(value);
		}

		public virtual ColumnSetting this[int index]
		{
			get
			{
				if (index < base.List.Count)
					return (base.List[index] as ColumnSetting);
				else
					return null;
			}
		}

		public virtual int IndexOf(ColumnSetting value)
		{
			return base.List.IndexOf(value);
		}
	}
	#endregion

	#region class ColumnSetting
	[DesignTimeVisible(false),ToolboxItem(false),]
	public class ColumnSetting : System.ComponentModel.Component
	{
		private bool isEditable=true;
		private bool hasButton=false;
		private int  buttonWidth=ListViewExEdit.DefaultButtonWidth;
		private string buttonText=ListViewExEdit.DefaultButtonText;
        Font _BackFont = new Font("Arial",22 );

		[Description("If true, column can be edited"), Category("Behavior"), DefaultValue(true)]
		public bool IsEditable
		{
			get 
			{
				return isEditable;
			}
			set 
			{
				isEditable=value;
			}
		}

		[Description("If true, column editable column has a button"), Category("Behavior"), DefaultValue(false)]
		public bool HasButton
		{
			get 
			{
				return hasButton;
			}
			set 
			{
				hasButton=value;
			}
		}

		[Description("Width for the button"), Category("Appearance"), DefaultValue(50)]
		public int ButtonWidth 
		{
			get 
			{
				return buttonWidth;
			}
			set 
			{
				buttonWidth=value;
			}
		}

		[Description("Text for the button"), Category("Appearance"), DefaultValue("...")]
		public string ButtonText
		{
			get 
			{
				return buttonText;
			}
			set 
			{
				buttonText=value;
			}
		}

        [Description("Background Color"), Category("Appearance"), DefaultValue("Arial")]
        public Font BackColor
        {
                set
                {
                    _BackFont = value;
                }
            get
                {
                    return _BackFont;
                }
            }
	}
	#endregion
}
