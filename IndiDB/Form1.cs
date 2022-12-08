using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using IndiDB.Binary;
using IndiDB.ExceptionHandle;
using IndiDB.FileRecord;

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
        public BinaryController BinaryController { get; private set; } = new BinaryController("main.data", "index.data");

        private void clearAllDataButton_Click(object sender, EventArgs e)
        {
            MainTable.Clear();
            EditorTable.Clear();

            databaseGrid.Refresh();
            databaseEditorGrid.Refresh();
        }

        private void getRecordByIdButton_Click(object sender, EventArgs e)
        {
            if (BinaryController.RecordsQuantity == 0)
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in EditorTable.Rows)
            {
                if (row[0] is not DBNull)
                {
                    ExceptionHandler.CheckValidFormat(() =>
                    {
                        BinaryController.RemoveRecord(Convert.ToInt32(row[0]));
                    });
                }
            }
        }

        private void clearFileButton_Click(object sender, EventArgs e)
        {
            BinaryController.ClearAllData();
        }

        private void generateRandomDataButton_Click(object sender, EventArgs e)
        {
            GenerateDataForm dataForm = new GenerateDataForm();
            dataForm.ShowDialog();

            DataGenerator.GenerateRecords("main.data", "index.data", (int)dataForm.numericUpDown1.Value);
        }

        private void getAllRecordsButton_Click(object sender, EventArgs e)
        {
            MainTable.Clear();

            var data = BinaryQuery.GetAllData("main.data").Cast<DataRecord>();

            foreach (var item in data)
            {
                MainTable.Rows.Add(item.Id, item.Value);
            }

            databaseGrid.DataSource = MainTable;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (EditorTable.Rows.Count == 0)
            {
                MessageBox.Show("No data to add. Please, Enter Id and value into columns.", "Empty table", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ExceptionHandler.CheckValidFormat(() =>
                {
                    foreach (DataRow row in EditorTable.Rows)
                    {
                        if (row[0].ToString() != string.Empty
                        && row[1].ToString() != string.Empty)
                        {
                            var record = new DataRecord(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]));

                            if (BinaryController.RecordContains(record.Id))
                            {
                                MessageBox.Show($"Record with id: {record.Id} is already exists.", "main.data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;
                            }

                            BinaryController.AddRecord(record);
                        }
                    }
                });
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in EditorTable.Rows)
            {
                if (row[0] is not DBNull && row[1] is not DBNull)
                {
                    ExceptionHandler.CheckValidFormat(() =>
                    {
                        BinaryController.EditRecord(new DataRecord(Convert.ToInt32(row[0]), Convert.ToInt32(row[1])));
                    });
                }
            }
        }
    }
}