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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.recordByIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.getRecordByIdButton = new System.Windows.Forms.Button();
            this.blockIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.getBlockByIdButton = new System.Windows.Forms.Button();
            this.clearAllDataButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.databaseGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseEditorGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordByIdNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockIdNumericUpDown)).BeginInit();
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
            this.databaseGrid.Size = new System.Drawing.Size(691, 455);
            this.databaseGrid.TabIndex = 0;
            // 
            // getAllRecordsButton
            // 
            this.getAllRecordsButton.BackColor = System.Drawing.Color.PaleGreen;
            this.getAllRecordsButton.Location = new System.Drawing.Point(6, 26);
            this.getAllRecordsButton.Name = "getAllRecordsButton";
            this.getAllRecordsButton.Size = new System.Drawing.Size(430, 51);
            this.getAllRecordsButton.TabIndex = 1;
            this.getAllRecordsButton.Text = "Get all records";
            this.getAllRecordsButton.UseVisualStyleBackColor = false;
            this.getAllRecordsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Controls.Add(this.databaseEditorGrid);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.clearAllDataButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 505);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 193);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database editor";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.editButton.Click += new System.EventHandler(this.button1_Click_1);
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
            this.databaseEditorGrid.Size = new System.Drawing.Size(691, 110);
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
            this.addButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.databaseGrid);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(703, 487);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Main table";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.recordByIdNumericUpDown);
            this.groupBox3.Controls.Add(this.getRecordByIdButton);
            this.groupBox3.Controls.Add(this.blockIdNumericUpDown);
            this.groupBox3.Controls.Add(this.getBlockByIdButton);
            this.groupBox3.Controls.Add(this.getAllRecordsButton);
            this.groupBox3.Location = new System.Drawing.Point(721, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(442, 198);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Database queries";
            // 
            // recordByIdNumericUpDown
            // 
            this.recordByIdNumericUpDown.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recordByIdNumericUpDown.Location = new System.Drawing.Point(322, 140);
            this.recordByIdNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.recordByIdNumericUpDown.Name = "recordByIdNumericUpDown";
            this.recordByIdNumericUpDown.Size = new System.Drawing.Size(114, 47);
            this.recordByIdNumericUpDown.TabIndex = 6;
            // 
            // getRecordByIdButton
            // 
            this.getRecordByIdButton.BackColor = System.Drawing.Color.Moccasin;
            this.getRecordByIdButton.Location = new System.Drawing.Point(6, 140);
            this.getRecordByIdButton.Name = "getRecordByIdButton";
            this.getRecordByIdButton.Size = new System.Drawing.Size(310, 51);
            this.getRecordByIdButton.TabIndex = 5;
            this.getRecordByIdButton.Text = "Get record by id:";
            this.getRecordByIdButton.UseVisualStyleBackColor = false;
            this.getRecordByIdButton.Click += new System.EventHandler(this.getRecordByIdButton_Click);
            // 
            // blockIdNumericUpDown
            // 
            this.blockIdNumericUpDown.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.blockIdNumericUpDown.Location = new System.Drawing.Point(322, 85);
            this.blockIdNumericUpDown.Name = "blockIdNumericUpDown";
            this.blockIdNumericUpDown.Size = new System.Drawing.Size(114, 47);
            this.blockIdNumericUpDown.TabIndex = 4;
            // 
            // getBlockByIdButton
            // 
            this.getBlockByIdButton.BackColor = System.Drawing.Color.Moccasin;
            this.getBlockByIdButton.Location = new System.Drawing.Point(6, 83);
            this.getBlockByIdButton.Name = "getBlockByIdButton";
            this.getBlockByIdButton.Size = new System.Drawing.Size(310, 51);
            this.getBlockByIdButton.TabIndex = 3;
            this.getBlockByIdButton.Text = "Get block by block id:";
            this.getBlockByIdButton.UseVisualStyleBackColor = false;
            this.getBlockByIdButton.Click += new System.EventHandler(this.getBlockByIdButton_Click);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Location = new System.Drawing.Point(721, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(442, 143);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File control";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.PaleGreen;
            this.button4.Location = new System.Drawing.Point(6, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(430, 51);
            this.button4.TabIndex = 3;
            this.button4.Text = "Generate random data";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Salmon;
            this.button5.Location = new System.Drawing.Point(6, 83);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(430, 51);
            this.button5.TabIndex = 3;
            this.button5.Text = "Clear file";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1169, 706);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.databaseGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.databaseEditorGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordByIdNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockIdNumericUpDown)).EndInit();
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
        private Button button4;
        private Button button5;
        private NumericUpDown blockIdNumericUpDown;
        private Button getBlockByIdButton;
        private NumericUpDown recordByIdNumericUpDown;
        private Button getRecordByIdButton;
    }
}