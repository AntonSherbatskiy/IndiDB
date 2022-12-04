using System.Data;
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
                        Record record = new Record(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]));

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

            var data = Component.GetAllData();

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
                Component.EditRecord(new Record(Convert.ToInt32(row[0]), Convert.ToInt32(row[1])));
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
                var block = Component.GetBlockByBlockId((int)blockIdNumericUpDown.Value);

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
            Record? record = Component.GetRecordById((int)recordByIdNumericUpDown.Value);

            if (record != null)
            {
                MainTable.Clear();

                MainTable.Rows.Add(record.Id, record.Value);
                databaseGrid.Refresh();
            }
            else
            {
                MessageBox.Show("This record does not exists.", "Empty record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}