using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IndiDB
{
    public class BinaryComponent
    {
        public BinaryComponent(string fileName, string indexFileName)
        {
            DataFileName = fileName;
            IndexFileName = indexFileName;
        }

        public string DataFileName { get; private set; }
        public string IndexFileName { get; private set; }
        
        public int RecordsQuantity => GetRecordsQuantity();
        public int BlocksQuantity => (RecordsQuantity / RecordsInBlockQuantity);

        public const int BlockSizeInBytes = 800;
        public const int RecordsInBlockQuantity = 100;

        public bool AddRecord(Record record)
        {
            if (RecordContains(record))
            {
                return false;
            }

            using (var dataWriter = new BinaryWriter(File.Open(DataFileName, FileMode.Open)))
            {
                dataWriter.BaseStream.Position = dataWriter.BaseStream.Length;

                dataWriter.Write(record.Id);
                dataWriter.Write(record.Value);
            }

            int blockId = (int)Math.Floor((double)record.Id / 100);
            int startBytePosition = blockId * BlockSizeInBytes;
            var IndexBlock = GetBlockByBlockId(blockId);

            IndexBlock.Add(new Record(record.Id, RecordsQuantity));
            IndexBlock = IndexBlock
                .OrderBy(item => item.Id)
                .ToList();

            SetBlock(IndexBlock, startBytePosition);

            return true;
        }

        public void SetBlock(List<Record> indexRecordList, long byteStartPosition)
        {
            using (var stream = File.Open(IndexFileName, FileMode.Open))
            {
                stream.Position = byteStartPosition;

                foreach (var item in indexRecordList)
                {
                    stream.Write(BitConverter.GetBytes(item.Id), 0, sizeof(int));
                    stream.Write(BitConverter.GetBytes(item.Value), 0, sizeof(int));
                }
            }
        }

        public int GetRecordPosition(Record record)
        {
            using (var indexReader = new BinaryReader(File.Open(DataFileName, FileMode.Open)))
            {
                while (indexReader.BaseStream.Position != indexReader.BaseStream.Length)
                {
                    int index = indexReader.ReadInt32();

                    if (index == record.Id)
                    {
                        return indexReader.ReadInt32();
                    }

                    indexReader.BaseStream.Position += sizeof(int);
                }
            }

            return -1;
        }

        public bool EditRecord(Record record)
        {
            if (RecordContains(record))
            {
                long bytePosition = GetRecordPosition(record);
                using (var dataStream = File.Open(DataFileName, FileMode.Open))
                {
                    dataStream.Position = (Record.SizeInBytes * bytePosition) + sizeof(int);
                    dataStream.Write(BitConverter.GetBytes(record.Value), 0, sizeof(int));
                }

                return true;
            }

            return false;
        }

        

        public Record? GetRecordById(int recordId)
        {
            using (var indexReader = new BinaryReader(File.Open(IndexFileName, FileMode.Open)))
            {
                while (indexReader.BaseStream.Position != indexReader.BaseStream.Length)
                {
                    int index = indexReader.ReadInt32();

                    if (index == recordId)
                    {
                        int recordPosition = indexReader.ReadInt32();

                        using (var dataReader = new BinaryReader(File.Open(DataFileName, FileMode.Open)))
                        {
                            dataReader.BaseStream.Position = recordPosition * Record.SizeInBytes;

                            return new Record(dataReader.ReadInt32(), dataReader.ReadInt32());
                        }
                    }

                    indexReader.BaseStream.Position += sizeof(int);
                }
            }

            return null;
        }

        public bool RecordContains(Record record)
        {
            using (var indexReader = new BinaryReader(File.Open(IndexFileName, FileMode.Open)))
            {
                while (indexReader.BaseStream.Position != indexReader.BaseStream.Length)
                {
                    int index = indexReader.ReadInt32();

                    if (index == record.Id)
                    {
                        return true;
                    }

                    indexReader.BaseStream.Position += sizeof(int);
                }
            }

            return false;
        }

        public List<Record> GetAllData()
        {
            List<Record> data = new List<Record>();

            using (var binaryReader = new BinaryReader(File.Open(IndexFileName, FileMode.Open)))
            {
                while (binaryReader.BaseStream.Position 
                    != binaryReader.BaseStream.Length)
                {
                    data.Add(new Record(binaryReader.ReadInt32(), binaryReader.ReadInt32()));
                }
            }

            return data;
        }

        public int GetBlockId(List<Record> block)
        {
            return (int)Math.Floor((double)block[0].Id / 100);
        }

        public List<Record> GetBlockByRecordId(int recordId)
        {
            return GetBlockByBlockId((int)Math.Floor((double)recordId / RecordsInBlockQuantity));
        }

        public List<Record> GetBlockByBlockId(int blockId)
        {
            List<Record> recordList = new List<Record>();

            using (var binaryReader = new BinaryReader(File.Open(DataFileName, FileMode.Open)))
            {
                if (RecordsQuantity < 100)
                {
                    while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                    {
                        recordList.Add(new Record(binaryReader.ReadInt32(), binaryReader.ReadInt32()));
                    }
                }
                else
                {
                    binaryReader.BaseStream.Position = blockId * BlockSizeInBytes;

                    for (int i = 0; i < 100; i++)
                    {
                        recordList.Add(new Record(binaryReader.ReadInt32(), binaryReader.ReadInt32()));
                    }
                }
            }

            return recordList;
        }

        public void ClearAllData()
        {
            using (var dataStream = File.Open(DataFileName, FileMode.Open))
            {
                using (var indexStream = File.Open(IndexFileName, FileMode.Open))
                {
                    dataStream.SetLength(0);
                    indexStream.SetLength(0);
                }
            }
        }

        public long GetFileBytesSize(string path)
        {
            return new FileInfo(path).Length;
        }

        private int GetRecordsQuantity()
        {
            return (int)new FileInfo(DataFileName).Length / Record.SizeInBytes;
        }
    }
}