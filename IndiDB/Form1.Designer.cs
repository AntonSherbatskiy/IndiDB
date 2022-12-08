namespace IndiDB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.databaseGrid = new System.Windows.Forms.DataGridView();
            this.getAllRecordsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.databaseEditorGrid = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.clearAllDataButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.recordByIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.getRecordByIdButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.generateRandomDataButton = new System.Windows.Forms.Button();
            this.clearFileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.databaseGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseEditorGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordByIdNumericUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // databaseGrid
            // 
            this.databaseGrid.AllowUserToAddRows = false;
            this.databaseGrid.AllowUserToDeleteRows = false;
            this.databaseGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.databaseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.databaseGrid.Location = new System.Drawing.Point(6, 26);
            this.databaseGrid.Name = "databaseGrid";
            this.databaseGrid.ReadOnly = true;
            this.databaseGrid.RowHeadersWidth = 50;
            this.databaseGrid.RowTemplate.Height = 29;
            this.databaseGrid.Size = new System.Drawing.Size(1199, 444);
            this.databaseGrid.TabIndex = 0;
            // 
            // getAllRecordsButton
            // 
            this.getAllRecordsButton.BackColor = System.Drawing.Color.PaleGreen;
            this.getAllRecordsButton.Location = new System.Drawing.Point(6, 26);
            this.getAllRecordsButton.Name = "getAllRecordsButton";
            this.getAllRecordsButton.Size = new System.Drawing.Size(478, 45);
            this.getAllRecordsButton.TabIndex = 1;
            this.getAllRecordsButton.Text = "Get all database records";
            this.getAllRecordsButton.UseVisualStyleBackColor = false;
            this.getAllRecordsButton.Click += new System.EventHandler(this.getAllRecordsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Controls.Add(this.databaseEditorGrid);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.clearAllDataButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 494);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 251);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database editor";
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Salmon;
            this.deleteButton.Location = new System.Drawing.Point(365, 26);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(173, 45);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.SkyBlue;
            this.editButton.Location = new System.Drawing.Point(180, 26);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(179, 45);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // databaseEditorGrid
            // 
            this.databaseEditorGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.databaseEditorGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.databaseEditorGrid.ColumnHeadersHeight = 29;
            this.databaseEditorGrid.Location = new System.Drawing.Point(6, 77);
            this.databaseEditorGrid.Name = "databaseEditorGrid";
            this.databaseEditorGrid.RowHeadersWidth = 51;
            this.databaseEditorGrid.RowTemplate.Height = 29;
            this.databaseEditorGrid.Size = new System.Drawing.Size(691, 168);
            this.databaseEditorGrid.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.PaleGreen;
            this.addButton.Location = new System.Drawing.Point(6, 26);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(168, 45);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // clearAllDataButton
            // 
            this.clearAllDataButton.BackColor = System.Drawing.Color.Salmon;
            this.clearAllDataButton.Location = new System.Drawing.Point(544, 26);
            this.clearAllDataButton.Name = "clearAllDataButton";
            this.clearAllDataButton.Size = new System.Drawing.Size(153, 45);
            this.clearAllDataButton.TabIndex = 2;
            this.clearAllDataButton.Text = "Clear dataView";
            this.clearAllDataButton.UseVisualStyleBackColor = false;
            this.clearAllDataButton.Click += new System.EventHandler(this.clearAllDataButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.databaseGrid);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1205, 476);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Main table";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.recordByIdNumericUpDown);
            this.groupBox3.Controls.Add(this.getRecordByIdButton);
            this.groupBox3.Controls.Add(this.getAllRecordsButton);
            this.groupBox3.Location = new System.Drawing.Point(727, 494);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(490, 128);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Database queries";
            // 
            // recordByIdNumericUpDown
            // 
            this.recordByIdNumericUpDown.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recordByIdNumericUpDown.Location = new System.Drawing.Point(370, 77);
            this.recordByIdNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.recordByIdNumericUpDown.Name = "recordByIdNumericUpDown";
            this.recordByIdNumericUpDown.Size = new System.Drawing.Size(114, 38);
            this.recordByIdNumericUpDown.TabIndex = 6;
            // 
            // getRecordByIdButton
            // 
            this.getRecordByIdButton.BackColor = System.Drawing.Color.Moccasin;
            this.getRecordByIdButton.Location = new System.Drawing.Point(6, 76);
            this.getRecordByIdButton.Name = "getRecordByIdButton";
            this.getRecordByIdButton.Size = new System.Drawing.Size(358, 45);
            this.getRecordByIdButton.TabIndex = 5;
            this.getRecordByIdButton.Text = "Get record by id:";
            this.getRecordByIdButton.UseVisualStyleBackColor = false;
            this.getRecordByIdButton.Click += new System.EventHandler(this.getRecordByIdButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.generateRandomDataButton);
            this.groupBox4.Controls.Add(this.clearFileButton);
            this.groupBox4.Location = new System.Drawing.Point(727, 621);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(490, 124);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File control";
            // 
            // generateRandomDataButton
            // 
            this.generateRandomDataButton.BackColor = System.Drawing.Color.PaleGreen;
            this.generateRandomDataButton.Location = new System.Drawing.Point(6, 26);
            this.generateRandomDataButton.Name = "generateRandomDataButton";
            this.generateRandomDataButton.Size = new System.Drawing.Size(478, 45);
            this.generateRandomDataButton.TabIndex = 3;
            this.generateRandomDataButton.Text = "Generate random data";
            this.generateRandomDataButton.UseVisualStyleBackColor = false;
            this.generateRandomDataButton.Click += new System.EventHandler(this.generateRandomDataButton_Click);
            // 
            // clearFileButton
            // 
            this.clearFileButton.BackColor = System.Drawing.Color.Salmon;
            this.clearFileButton.Location = new System.Drawing.Point(6, 73);
            this.clearFileButton.Name = "clearFileButton";
            this.clearFileButton.Size = new System.Drawing.Size(478, 45);
            this.clearFileButton.TabIndex = 3;
            this.clearFileButton.Text = "Clear file";
            this.clearFileButton.UseVisualStyleBackColor = false;
            this.clearFileButton.Click += new System.EventHandler(this.clearFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1229, 754);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.databaseGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.databaseEditorGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordByIdNumericUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView databaseGrid;
        private Button getAllRecordsButton;
        private GroupBox groupBox1;
        private Button addButton;
        private DataGridView databaseEditorGrid;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button clearAllDataButton;
        private Button deleteButton;
        private Button editButton;
        private GroupBox groupBox4;
        private Button generateRandomDataButton;
        private Button clearFileButton;
        private NumericUpDown recordByIdNumericUpDown;
        private Button getRecordByIdButton;
    }
}