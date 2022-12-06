using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace IndiDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            MainTable = new DataTable();
            EditorTable = new DataTable();

            MainTable.Columns.Add("Id");
            MainTable.Columns.Add("Value");

            EditorTable.Columns.Add("Id");
            EditorTable.Columns.Add("Value");

            databaseGrid.DataSource = MainTable;
            databaseEditorGrid.DataSource = EditorTable;
        }

        public DataTable MainTable { get; private set; }
        public DataTable EditorTable { get; private set; }
        public BinaryComponent Component { get; private set; } = new BinaryComponent("main.data", "index.data");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EditorTable.Rows.Count == 0)
            {
                MessageBox.Show("No data to add. Please, Enter Id and value into columns.", "Empty table", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (DataRow row in EditorTable.Rows)
                {
                    if (row[0].ToString() != string.Empty && row[1].ToString() != string.Empty)
                    {
                        var record = new DataRecord(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]));

                        if (Component.RecordContains(record))
                        {
                            MessageBox.Show($"Record with id: {record.Id} is already exists.", "main.data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                        Component.AddRecord(record);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainTable.Clear();

            var data = BinaryQuery.GetAllData("main.data").Cast<DataRecord>();

            foreach (var item in data)
            {
                MainTable.Rows.Add(item.Id, item.Value);
            }

            databaseGrid.DataSource = MainTable;
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (DataRow row in EditorTable.Rows)
            {
                if (row[0] is not DBNull && row[1] is not DBNull)
                {
                    Component.EditRecord(new DataRecord(Convert.ToInt32(row[0]), Convert.ToInt32(row[1])));
                }
            }
        }

        

        private void clearFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileStream = File.Open("main.data", FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Close();
        }

        private void clearAllDataButton_Click(object sender, EventArgs e)
        {
            MainTable.Clear();
            databaseGrid.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GenerateDataForm dataForm = new GenerateDataForm();
            dataForm.ShowDialog();

            DataGenerator.GenerateRecords("main.data", "index.data", (int)dataForm.numericUpDown1.Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Component.ClearAllData();
        }

        private void getBlockByIdButton_Click(object sender, EventArgs e)
        {
            try
            {
                var block = BinaryQuery.GeDataBlockByBlockId("main.data", (int)blockIdNumericUpDown.Value);

                if (block.Count == 0)
                {
                    MessageBox.Show("Empty file.", "main.data");
                }
                MainTable.Clear();

                foreach (var item in block)
                {
                    MainTable.Rows.Add(item.Id, item.Value);
                }

                databaseGrid.DataSource = MainTable;
            }
            catch (EndOfStreamException)
            {
                MessageBox.Show($"There are {Component.BlocksQuantity} blocks in file. Last block is {Component.BlocksQuantity - 1}", "Read block error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getRecordByIdButton_Click(object sender, EventArgs e)
        {
            if (BinaryComponent.RecordsQuantity == 0)
            {
                MessageBox.Show($"Empty file.", "main.data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRecord? record = BinaryQuery.GetRecordById("main.data", "index.data", (int)recordByIdNumericUpDown.Value);

            if (record == null)
            {
                MessageBox.Show($"Record with index {recordByIdNumericUpDown.Value} does not esists!", "main.data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MainTable.Clear();

            MainTable.Rows.Add(record.Id, record.Value);
            databaseGrid.Refresh();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            MainTable.Clear();

            var data = BinaryQuery.GetAllData("index.data").Cast<IndexRecord>();

            foreach (var item in data)
            {
                MainTable.Rows.Add(item.Id, item.Value);
            }

            databaseGrid.DataSource = MainTable;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in EditorTable.Rows)
            {
                if (row[0] is not DBNull)
                {
                    Component.RemoveRecord(new DataRecord(Convert.ToInt32(row[0]), Convert.ToInt32(row[1])));
                }
            }
        }
    }
}