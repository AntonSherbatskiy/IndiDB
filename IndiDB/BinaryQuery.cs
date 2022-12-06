using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IndiDB
{
    public static class BinaryQuery
    {
        public static int RecordsQuantity => GetRecordsQuantity("main.data");

       
        public static int GetRecordPosition(string fileName, Record record)
        {
            List<IndexRecord> indexList = new List<IndexRecord>();

            using (var indexReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                indexList = GetIndexBlockByBlockId(fileName, (int)(record.Id / 100));
                IndexRecord? index = indexList.Find(index => index.Id == record.Id);

                return index is not null ? index.Value : -1;
            }
        }

        public static DataRecord? GetRecordById(string dataFileName, string indexFileName, int recordId)
        {
            var indexList = GetIndexBlockByBlockId(indexFileName, (int)Math.Floor((double)recordId / 100));
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

        public static List<IndiDB.Record> GetAllData(string fileName)
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

        public static List<DataRecord> GeDataBlockByBlockId(string fileName, int blockId)
        {
            List<DataRecord> recordList = new List<DataRecord>();

            using (var binaryReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                if (RecordsQuantity < 100)
                {
                    while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                    {
                        recordList.Add(new DataRecord(binaryReader.ReadInt32(), binaryReader.ReadInt32()));
                    }
                }
                else
                {
                    binaryReader.BaseStream.Position = blockId * BinaryComponent.BlockSizeInBytes;

                    for (int i = 0; i < 100; i++)
                    {
                        recordList.Add(new DataRecord(binaryReader.ReadInt32(), binaryReader.ReadInt32()));
                    }
                }
            }

            return recordList;
        }

        public static List<IndexRecord> GetIndexBlockByBlockId(string fileName, int blockId)
        {
            var recordList = new List<IndexRecord>();
            
            

            using (var binaryReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                binaryReader.BaseStream.Position = blockId * BinaryComponent.BlockSizeInBytes;

                for (int i = 0; i < 100; i++)
                {
                    recordList.Add(new IndexRecord(binaryReader.ReadInt32(), binaryReader.ReadInt32()));
                }
            }

            return recordList;
        }

        public static int GetBlockId(List<Record> block)
        {
            return (int)Math.Floor((double)block[0].Id / 100);
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
