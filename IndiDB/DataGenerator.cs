using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiDB
{
    public static class DataGenerator
    {
        public static void GenerateRecords(string dataFileName, string indexFileName, int recordsQuantity)
        {   
            using (var dataWriter = new BinaryWriter(File.Open(dataFileName, FileMode.Truncate)))
            {
                using (var indexWriter = new BinaryWriter(File.Open(indexFileName, FileMode.Truncate)))
                {
                    Random random = new Random();

                    for (int i = 0; i < recordsQuantity; i++)
                    {
                        Record record = new Record(i, i);

                        dataWriter.Write(record.Id);
                        dataWriter.Write(record.Value);

                        indexWriter.Write(record.Id);
                        indexWriter.Write(i);
                    }
                }
            }
        }
    }
}
