namespace eBarSystemsSolution
{
    partial class eBarDataViewSystem
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
            this.dbGridView = new System.Windows.Forms.DataGridView();
            this.eBarSystemsDataSet = new eBarSystemsSolution.eBarSystemsDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPump = new System.Windows.Forms.ComboBox();
            this.btnSearchPump = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dTPicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtPickerUser = new System.Windows.Forms.DateTimePicker();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpSearchByDate = new System.Windows.Forms.GroupBox();
            this.btnSearchDate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dTPickerDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearchAllDate = new System.Windows.Forms.Button();
            this.btnSearchAllPump = new System.Windows.Forms.Button();
            this.btnSearchAllUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eBarSystemsDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpSearchByDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbGridView
            // 
            this.dbGridView.AllowUserToAddRows = false;
            this.dbGridView.AllowUserToDeleteRows = false;
            this.dbGridView.AllowUserToResizeColumns = false;
            this.dbGridView.AllowUserToResizeRows = false;
            this.dbGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridView.EnableHeadersVisualStyles = false;
            this.dbGridView.Location = new System.Drawing.Point(25, 26);
            this.dbGridView.Name = "dbGridView";
            this.dbGridView.ReadOnly = true;
            this.dbGridView.RowHeadersVisible = false;
            this.dbGridView.ShowEditingIcon = false;
            this.dbGridView.Size = new System.Drawing.Size(427, 464);
            this.dbGridView.TabIndex = 2;
            // 
            // eBarSystemsDataSet
            // 
            this.eBarSystemsDataSet.DataSetName = "eBarSystemsDataSet";
            this.eBarSystemsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchAllPump);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboPump);
            this.groupBox1.Controls.Add(this.btnSearchPump);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dTPicker);
            this.groupBox1.Location = new System.Drawing.Point(492, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 144);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Logs By Pump";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pump Number:";
            // 
            // cboPump
            // 
            this.cboPump.FormattingEnabled = true;
            this.cboPump.Location = new System.Drawing.Point(93, 31);
            this.cboPump.Name = "cboPump";
            this.cboPump.Size = new System.Drawing.Size(142, 21);
            this.cboPump.TabIndex = 3;
            // 
            // btnSearchPump
            // 
            this.btnSearchPump.Location = new System.Drawing.Point(160, 110);
            this.btnSearchPump.Name = "btnSearchPump";
            this.btnSearchPump.Size = new System.Drawing.Size(75, 23);
            this.btnSearchPump.TabIndex = 2;
            this.btnSearchPump.Text = "Search";
            this.btnSearchPump.UseVisualStyleBackColor = true;
            this.btnSearchPump.Click += new System.EventHandler(this.btnSearchPump_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Date:";
            // 
            // dTPicker
            // 
            this.dTPicker.Location = new System.Drawing.Point(93, 67);
            this.dTPicker.Name = "dTPicker";
            this.dTPicker.Size = new System.Drawing.Size(142, 20);
            this.dTPicker.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearchAllUser);
            this.groupBox2.Controls.Add(this.btnSearchUser);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtPickerUser);
            this.groupBox2.Controls.Add(this.cboUser);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(492, 346);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 144);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Logs by User";
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Location = new System.Drawing.Point(159, 110);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(75, 23);
            this.btnSearchUser.TabIndex = 4;
            this.btnSearchUser.Text = "Search";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Select Date:";
            // 
            // dtPickerUser
            // 
            this.dtPickerUser.Location = new System.Drawing.Point(93, 76);
            this.dtPickerUser.Name = "dtPickerUser";
            this.dtPickerUser.Size = new System.Drawing.Size(142, 20);
            this.dtPickerUser.TabIndex = 2;
            // 
            // cboUser
            // 
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(92, 31);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(142, 21);
            this.cboUser.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select User:";
            // 
            // grpSearchByDate
            // 
            this.grpSearchByDate.Controls.Add(this.btnSearchAllDate);
            this.grpSearchByDate.Controls.Add(this.btnSearchDate);
            this.grpSearchByDate.Controls.Add(this.label5);
            this.grpSearchByDate.Controls.Add(this.dTPickerDate);
            this.grpSearchByDate.Location = new System.Drawing.Point(492, 26);
            this.grpSearchByDate.Name = "grpSearchByDate";
            this.grpSearchByDate.Size = new System.Drawing.Size(250, 144);
            this.grpSearchByDate.TabIndex = 5;
            this.grpSearchByDate.TabStop = false;
            this.grpSearchByDate.Text = "Search Logs by Date";
            // 
            // btnSearchDate
            // 
            this.btnSearchDate.Location = new System.Drawing.Point(159, 105);
            this.btnSearchDate.Name = "btnSearchDate";
            this.btnSearchDate.Size = new System.Drawing.Size(75, 23);
            this.btnSearchDate.TabIndex = 2;
            this.btnSearchDate.Text = "Search";
            this.btnSearchDate.UseVisualStyleBackColor = true;
            this.btnSearchDate.Click += new System.EventHandler(this.btnSearchDate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Select Date:";
            // 
            // dTPickerDate
            // 
            this.dTPickerDate.Location = new System.Drawing.Point(92, 36);
            this.dTPickerDate.Name = "dTPickerDate";
            this.dTPickerDate.Size = new System.Drawing.Size(142, 20);
            this.dTPickerDate.TabIndex = 0;
            // 
            // btnSearchAllDate
            // 
            this.btnSearchAllDate.Location = new System.Drawing.Point(12, 105);
            this.btnSearchAllDate.Name = "btnSearchAllDate";
            this.btnSearchAllDate.Size = new System.Drawing.Size(103, 23);
            this.btnSearchAllDate.TabIndex = 3;
            this.btnSearchAllDate.Text = "View All Logs";
            this.btnSearchAllDate.UseVisualStyleBackColor = true;
            this.btnSearchAllDate.Click += new System.EventHandler(this.btnSearchAllDate_Click);
            // 
            // btnSearchAllPump
            // 
            this.btnSearchAllPump.Location = new System.Drawing.Point(15, 110);
            this.btnSearchAllPump.Name = "btnSearchAllPump";
            this.btnSearchAllPump.Size = new System.Drawing.Size(100, 23);
            this.btnSearchAllPump.TabIndex = 4;
            this.btnSearchAllPump.Text = "View All Logs";
            this.btnSearchAllPump.UseVisualStyleBackColor = true;
            this.btnSearchAllPump.Click += new System.EventHandler(this.btnSearchAllPump_Click);
            // 
            // btnSearchAllUser
            // 
            this.btnSearchAllUser.Location = new System.Drawing.Point(15, 110);
            this.btnSearchAllUser.Name = "btnSearchAllUser";
            this.btnSearchAllUser.Size = new System.Drawing.Size(100, 23);
            this.btnSearchAllUser.TabIndex = 5;
            this.btnSearchAllUser.Text = "View All Logs";
            this.btnSearchAllUser.UseVisualStyleBackColor = true;
            this.btnSearchAllUser.Click += new System.EventHandler(this.btnSearchAllUser_Click);
            // 
            // eBarDataViewSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 515);
            this.Controls.Add(this.grpSearchByDate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dbGridView);
            this.Name = "eBarDataViewSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eBar Systems - Data View System";
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eBarSystemsDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpSearchByDate.ResumeLayout(false);
            this.grpSearchByDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dbGridView;
        private eBarSystemsDataSet eBarSystemsDataSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dTPicker;
        private System.Windows.Forms.Button btnSearchPump;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPump;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtPickerUser;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpSearchByDate;
        private System.Windows.Forms.Button btnSearchDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dTPickerDate;
        private System.Windows.Forms.Button btnSearchAllPump;
        private System.Windows.Forms.Button btnSearchAllUser;
        private System.Windows.Forms.Button btnSearchAllDate;
    }
}