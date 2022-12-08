using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IndiDB.FileRecord;

namespace IndiDB.Binary
{
    public static class BinaryQuery
    {
        public static int RecordsQuantity => GetRecordsQuantity("main.data");

        public static int GetRecordPosition(string fileName, int id)
        {
            List<IndexRecord> indexList = GetIndexBlock(fileName, id / 100);

            IndexRecord? index = indexList.Find(index => index.Id == id);
            return index is not null ? index.Value : -1;
        }

        public static DataRecord? GetRecordById(string dataFileName, string indexFileName, int recordId)
        {
            var indexList = GetIndexBlock(indexFileName, (int)Math.Floor((double)recordId / 100));
            int index = SearchingEngine.Search(indexList, recordId);

            if (index != -1)
            {
                using (var dataReader = new BinaryReader(File.Open(dataFileName, FileMode.Open)))
                {
                    dataReader.BaseStream.Position = index * Record.ByteSize;

                    return new DataRecord(dataReader.ReadInt32(), dataReader.ReadInt32());
                }
            }

            return null;
        }

        public static List<Record> GetAllData(string fileName)
        {
            if (fileName == "main.data")
            {
                List<Record> data = new List<Record>();

                using (var binaryReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    while (binaryReader.BaseStream.Position
                        != binaryReader.BaseStream.Length)
                    {
                        data.Add(new DataRecord(binaryReader.ReadInt32(), binaryReader.ReadInt32()));
                    }
                }

                return data;
            }
            else
            {
                var data = new List<Record>();

                using (var binaryReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    while (binaryReader.BaseStream.Position
                        != binaryReader.BaseStream.Length)
                    {
                        data.Add(new IndexRecord(binaryReader.ReadInt32(), binaryReader.ReadInt32()));
                    }
                }

                return data;
            }
        }

        public static List<IndexRecord> GetIndexBlock(string fileName, int blockId)
        {
            var recordList = new List<IndexRecord>();

            using (var binaryReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                binaryReader.BaseStream.Position = blockId * BinaryController.BlockSizeInBytes;

                for (int i = 0; i < 100; i++)
                {
                    recordList.Add(new IndexRecord(binaryReader.ReadInt32(), binaryReader.ReadInt32()));
                }
            }

            return recordList;
        }

        public static long GetFileBytesSize(string fileName)
        {
            return new FileInfo(fileName).Length;
        }

        public static int GetRecordsQuantity(string fileName)
        {
            return (int)new FileInfo(fileName).Length / Record.ByteSize;
        }
    }
}
