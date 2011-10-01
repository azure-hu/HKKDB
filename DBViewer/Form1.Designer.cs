namespace DBViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nevLabel;
            System.Windows.Forms.Label kepLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lapBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.lapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hkkDataSet = new DBViewer.hkkDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lapBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.nevComboBox = new System.Windows.Forms.ComboBox();
            this.kepPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lapTableAdapter = new DBViewer.hkkDataSetTableAdapters.lapTableAdapter();
            this.tableAdapterManager = new DBViewer.hkkDataSetTableAdapters.TableAdapterManager();
            nevLabel = new System.Windows.Forms.Label();
            kepLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lapBindingNavigator)).BeginInit();
            this.lapBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lapBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hkkDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kepPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nevLabel
            // 
            nevLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            nevLabel.AutoSize = true;
            nevLabel.Location = new System.Drawing.Point(12, 461);
            nevLabel.Name = "nevLabel";
            nevLabel.Size = new System.Drawing.Size(28, 13);
            nevLabel.TabIndex = 1;
            nevLabel.Text = "nev:";
            // 
            // kepLabel
            // 
            kepLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            kepLabel.AutoSize = true;
            kepLabel.Location = new System.Drawing.Point(12, 25);
            kepLabel.Name = "kepLabel";
            kepLabel.Size = new System.Drawing.Size(28, 13);
            kepLabel.TabIndex = 3;
            kepLabel.Text = "kep:";
            // 
            // lapBindingNavigator
            // 
            this.lapBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.lapBindingNavigator.BindingSource = this.lapBindingSource;
            this.lapBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.lapBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.lapBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.lapBindingNavigatorSaveItem});
            this.lapBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.lapBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.lapBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.lapBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.lapBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.lapBindingNavigator.Name = "lapBindingNavigator";
            this.lapBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.lapBindingNavigator.Size = new System.Drawing.Size(512, 25);
            this.lapBindingNavigator.TabIndex = 0;
            this.lapBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // lapBindingSource
            // 
            this.lapBindingSource.DataMember = "lap";
            this.lapBindingSource.DataSource = this.hkkDataSet;
            // 
            // hkkDataSet
            // 
            this.hkkDataSet.DataSetName = "hkkDataSet";
            this.hkkDataSet.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.hkkDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lapBindingNavigatorSaveItem
            // 
            this.lapBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lapBindingNavigatorSaveItem.Enabled = false;
            this.lapBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("lapBindingNavigatorSaveItem.Image")));
            this.lapBindingNavigatorSaveItem.Name = "lapBindingNavigatorSaveItem";
            this.lapBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.lapBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // nevComboBox
            // 
            this.nevComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nevComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.nevComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.nevComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lapBindingSource, "nev", true));
            this.nevComboBox.DataSource = this.lapBindingSource;
            this.nevComboBox.DisplayMember = "nev";
            this.nevComboBox.DropDownHeight = 80;
            this.nevComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nevComboBox.FormattingEnabled = true;
            this.nevComboBox.IntegralHeight = false;
            this.nevComboBox.Location = new System.Drawing.Point(46, 458);
            this.nevComboBox.Name = "nevComboBox";
            this.nevComboBox.Size = new System.Drawing.Size(442, 21);
            this.nevComboBox.TabIndex = 2;
            this.nevComboBox.ValueMember = "id";
            // 
            // kepPictureBox
            // 
            this.kepPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kepPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.lapBindingSource, "kep", true));
            this.kepPictureBox.Location = new System.Drawing.Point(122, 33);
            this.kepPictureBox.Name = "kepPictureBox";
            this.kepPictureBox.Size = new System.Drawing.Size(280, 388);
            this.kepPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kepPictureBox.TabIndex = 4;
            this.kepPictureBox.TabStop = false;
            this.kepPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.kepPictureBox_MouseClick);
            this.kepPictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.kepPictureBox_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "keres:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(46, 432);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(442, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(247, 432);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(241, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lapTableAdapter
            // 
            this.lapTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = DBViewer.hkkDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 483);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(nevLabel);
            this.Controls.Add(this.nevComboBox);
            this.Controls.Add(kepLabel);
            this.Controls.Add(this.kepPictureBox);
            this.Controls.Add(this.lapBindingNavigator);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lapBindingNavigator)).EndInit();
            this.lapBindingNavigator.ResumeLayout(false);
            this.lapBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lapBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hkkDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kepPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private hkkDataSet hkkDataSet;
        private System.Windows.Forms.BindingSource lapBindingSource;
        private hkkDataSetTableAdapters.lapTableAdapter lapTableAdapter;
        private hkkDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator lapBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton lapBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox nevComboBox;
        private System.Windows.Forms.PictureBox kepPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}

