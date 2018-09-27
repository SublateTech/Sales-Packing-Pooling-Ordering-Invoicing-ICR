using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Signature.Windows.Forms
{
	/// <summary>
	/// Extends the <see cref="ListView"/> with DataBinding-ability.
	/// </summary>
	public class BoundListView : ListView
	{
		private ListChangedEventHandler listChangedHandler;
		private EventHandler positionChangedHandler;
		private object dataSource;
		private string dataMember;
		private CurrencyManager dataManager;
        private Int32 _ReadLimit=0;

		#region Properties
		#region DataSource
		/// <summary>
		/// Ruft die Datenquelle ab, für die Daten angezeigt werden sollen, oder legt diese fest.
		/// </summary>
		[TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
		[Category("Data")]
		[Description("Gibt die Datenquelle für das Control an.")]
		[DefaultValue(null)]
		public object DataSource
		{
			get
			{
				return this.dataSource;
			}
			set
			{
				if (this.dataSource != value)
				{
					this.dataSource = value;
					tryDataBinding();
				}
			}
		}

        /// <summary>
		/// Ruft die Datenquelle ab, für die Daten angezeigt werden sollen, oder legt diese fest.
		/// </summary>
        
        [Category("Data")]
        [Description("Limits row amount")]
        [DefaultValue(0)]
        public Int32 ReadLimit
        {
            get 
            {
                return _ReadLimit;
            }
            set
            {
                _ReadLimit =  value;
            }
        }
		#endregion

		#region DataMember
		/// <summary>
		/// Ruft die bestimmte Liste in DataSource ab, für die das Control 
		/// ein Datenblatt anzeigt, oder legt diese fest.
		/// </summary>
		[Category("Data")]
		[Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design",
			 "System.Drawing.Design.UITypeEditor, System.Drawing")]
		[Description("Gibt eine untergeordnete Liste von DataSource an, um sie anzuzeigen.")]
		[DefaultValue(null)]
		public string DataMember
		{
			get
			{
				return this.dataMember;
			}
			set
			{
				if (this.dataMember != value)
				{
					this.dataMember = value;
					tryDataBinding();
				}
			}
		}
		#endregion

		#region CurrencyManager
		/// <summary>
		/// Ruft den CurrencyManager der gebundenen Liste ab.
		/// </summary>
		protected CurrencyManager DataManager
		{
			get
			{
				return this.dataManager;
			}
		}
		#endregion
		#endregion
		
		/// <summary>
		/// Renew the Databinding. BindingContext is changed, if you change the Parent.
		/// </summary>
		protected override void OnBindingContextChanged(EventArgs e)
		{
			this.tryDataBinding();
			base.OnBindingContextChanged(e);
		}

        public BoundListView()
		{
			listChangedHandler = new ListChangedEventHandler(dataManager_ListChanged);
			positionChangedHandler = new EventHandler(dataManager_PositionChanged);

			this.View = System.Windows.Forms.View.Details;
			this.FullRowSelect = true;
			this.HideSelection = false;
			this.MultiSelect = false;
			this.LabelEdit = true;

			this.SelectedIndexChanged += new EventHandler(ListViewDataBinding_SelectedIndexChanged);
		}

		#region tryDataBinding
		/// <summary>
		/// Tries to get a new CurrencyManager for new DataBinding
		/// </summary>
		private void tryDataBinding()
		{
			if (this.DataSource == null ||
				base.BindingContext == null)
				return;

			CurrencyManager cm;
			try
			{
				cm = (CurrencyManager)base.BindingContext[this.DataSource, this.DataMember];
			}
			catch (System.ArgumentException)
			{
				// If no CurrencyManager was found
				return;
			}
			if (this.dataManager != cm)
			{
				// Unwire the old CurrencyManager
				if (this.dataManager != null)
				{
					this.dataManager.ListChanged -= listChangedHandler;
					this.dataManager.PositionChanged -= positionChangedHandler;
				}
				this.dataManager = cm;
				// Wire the new CurrencyManager
				if (this.dataManager != null)
				{
					this.dataManager.ListChanged += listChangedHandler;
					this.dataManager.PositionChanged += positionChangedHandler;
				}

				// Update metadata and data
				//-calculateColumns();
				DataBind();
			}
		}
		#endregion

		#region Item Methods
		/// <summary>
		/// Updates all Items.
		/// </summary>
		public void DataBind()
		{
			Int32 Limit = DataManager.Count;
            
            this.Items.Clear();
            if (ReadLimit > 0 && DataManager.Count > ReadLimit)
                Limit = ReadLimit;
            
			for (int i = 0; i < Limit; i++ )
			{
				addItem(i);
			}
		}
		
		/// <summary>
		/// Adds a new item.
		/// </summary>
		/// <param name="index">The index of the item.</param>
		private void addItem(int index)
		{
			ListViewItem item = getListViewItem(index);
			//item.Font =  new System.Drawing.Font("Arial",13);
            this.Items.Insert(index, item);
		}
		
		/// <summary>
		/// Updates the data of the item with the DataSource.
		/// </summary>
		/// <param name="index">The index of the item.</param>
		private void updateItem(int index)
		{
			if (index >= 0 &&
			    index < this.Items.Count)
			{
				ListViewItem item = getListViewItem(index);
				this.Items[index] = item;
			}
		}

		/// <summary>
		/// Returns a <see cref="ListViewItem"/> wich contains the row-data at given index.
		/// </summary>
		/// <param name="index">The index of the row.</param>
		/// <returns>A item wich contains the data.</returns>
		private ListViewItem getListViewItem(int index)
		{
			object row = DataManager.List[index];
			PropertyDescriptorCollection propColl = DataManager.GetItemProperties();
			ArrayList items = new ArrayList();
			
			// Fill value for each column
			foreach(ColumnHeader column in this.Columns)
			{
                PropertyDescriptor prop = null;
				prop = propColl.Find(column.Text, false);
				if (prop != null)
				{
					items.Add(prop.GetValue(row).ToString());
				}
			}
			return new ListViewItem((string[])items.ToArray(typeof(string)));
		}

		/// <summary>
		/// Delete the item at the given index.
		/// </summary>
		/// <param name="index">The index of the item.</param>
		private void deleteItem(int index)
		{
			if (index >= 0 &&
			    index < this.Items.Count)
				this.Items.RemoveAt(index);
		}
		
		/// <summary>
		/// Calculates the Colums of the <see cref="BoundListView"/>.
		/// </summary>
		private void calculateColumns1()
		{
            this.Columns.Clear();
			if (dataManager == null)
				return;
			foreach (PropertyDescriptor prop in DataManager.GetItemProperties())
			{
                
                if (DataManager.GetItemProperties().Find(prop.Name, false) != null)
                {
                    //MessageBox.Show(prop.Name + " " + "already exists");
                }
                
                ColumnHeader column = new ColumnHeader();
				column.Text = prop.Name;

				this.Columns.Add(column);
			}



		}
		#endregion
		
		#region Position changed from DataSource
		private void dataManager_PositionChanged(object sender, EventArgs e)
		{
			if (this.Items.Count > DataManager.Position)
			{
				this.Items[DataManager.Position].Selected = true;
				this.EnsureVisible(DataManager.Position);
			}
		}
		#endregion

		#region Item(s) changed from DataSource
		private void dataManager_ListChanged(object sender, ListChangedEventArgs e)
		{
			if (e.ListChangedType == ListChangedType.Reset ||
				e.ListChangedType == ListChangedType.ItemMoved)
			{
				// Update all data
				DataBind();
			}
			else if (e.ListChangedType == ListChangedType.ItemAdded)
			{
				// Add new Item
				addItem(e.NewIndex);
			}
			else if (e.ListChangedType == ListChangedType.ItemChanged)
			{
				// Change Item
				updateItem(e.NewIndex);
			}
			else if (e.ListChangedType == ListChangedType.ItemDeleted)
			{
				// Delete Item
				deleteItem(e.NewIndex);
			}
			else
			{
				// Update metadata and all data
				//-calculateColumns();
				DataBind();
			}
		}
		#endregion

		#region Position changed from ListView
		private void ListViewDataBinding_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.SelectedIndices.Count > 0 &&
					DataManager.Position != this.SelectedIndices[0])
					DataManager.Position = this.SelectedIndices[0];
			}
			catch
			{
				// Could appear, if you change the position while someone edits a row with invalid data.
			}
		}
		#endregion

		#region Item changed from ListView
		protected override void OnAfterLabelEdit(LabelEditEventArgs e)
		{
			base.OnAfterLabelEdit(e);
			if (e.Label == null)
			{
				// If you press ESC while editing.
				e.CancelEdit = true;
				return;
			}
			
			if (DataManager.List.Count > e.Item)
			{
				object row = DataManager.List[e.Item];
				// In a ListView you are only able to edit the first Column.
				PropertyDescriptor col = DataManager.GetItemProperties().Find(this.Columns[0].Text, false);
				try
				{
					if (row != null &&
						col != null)
						col.SetValue(row, e.Label);
					DataManager.EndCurrentEdit();
				}
				catch(Exception ex)
				{
					// If you try to enter strings in number-columns, too long strings or something
					// else wich is not allowed by the DataSource.
					MessageBox.Show("Edit failed:\r\n" + ex.Message, "Edit failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					dataManager.CancelCurrentEdit();
					e.CancelEdit = true;
				}
			}
		}
		#endregion

	}
}
