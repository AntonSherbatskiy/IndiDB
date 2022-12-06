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

        public static int RecordsQuantity => BinaryQuery.RecordsQuantity;
        public int BlocksQuantity => (RecordsQuantity / RecordsInBlockQuantity);

        public const int BlockSizeInBytes = 800;
        public const int RecordsInBlockQuantity = 100;
        public const int MaxRecordQuantity = 10000;
        public const int UnsignedSpaceIndicator = -1;

        public bool AddRecord(DataRecord record)
        {
            if (RecordContains(record))
            {
                return false;
            }

            if (RecordsQuantity == 0)
            {
                GenerateIndexFileLayout("index.data");
            }

            using (var dataWriter = new BinaryWriter(File.Open(DataFileName, FileMode.Append)))
            {
                dataWriter.Write(record.Id);
                dataWriter.Write(record.Value);
            }

            int blockId = (int)Math.Floor((double)record.Id / 100);
            int startBytePosition = blockId * BlockSizeInBytes;

            InsertIndex(IndexFileName, record.Id, startBytePosition, blockId);
            
            return true;
        }

        public bool RemoveRecord(DataRecord record)
        {
            if (!RecordContains(record))
            {
                return false;
            }

            List<DataRecord> records = new List<DataRecord>();
            
            using (var dataWriter = new BinaryReader(File.Open(DataFileName, FileMode.Open)))
            {
                dataWriter.BaseStream.Position = BinaryQuery.GetRecordPosition(IndexFileName, record) * Record.ByteSize + Record.ByteSize;

                while (dataWriter.BaseStream.Position != dataWriter.BaseStream.Length)
                {
                    records.Add(new DataRecord(dataWriter.ReadInt32(), dataWriter.ReadInt32()));
                }
            }

            using (var stream = File.Open(DataFileName, FileMode.Open))
            {
                stream.Position = BinaryQuery.GetRecordPosition(IndexFileName, record) * Record.ByteSize;

                foreach (var item in records)
                {
                    stream.Write(BitConverter.GetBytes(item.Id));
                    stream.Write(BitConverter.GetBytes(item.Value));
                }

                stream.SetLength(stream.Length - Record.ByteSize);
            }

            RemoveIndex("index.data", record.Id);

            return true;

        }

        private void RemoveIndex(string fileName, int index)
        {
            int blockId = (int)Math.Floor((double)index / 100);
            int startBytePosition = blockId * BlockSizeInBytes;
            int position = -1;
            var indexBlock = BinaryQuery.GetIndexBlockByBlockId("index.data", blockId);

            foreach (var item in indexBlock.Where(item => item.Id == index))
            {
                position = item.Value;

                item.Id = UnsignedSpaceIndicator;
                item.Value = UnsignedSpaceIndicator;
            }

            indexBlock = indexBlock
                .OrderBy(item => item.Id)
                .ToList();

            SetBlock(indexBlock, startBytePosition);
            UpdateIndex(IndexFileName, position);
        }

        private void UpdateIndex(string indexFileName, int recordPosition)
        {
            using (var stream = File.Open(indexFileName, FileMode.Open))
            {
                
                while (stream.Position != stream.Length)
                {
                    byte[] intBuffer = new byte[sizeof(int)];


                    stream.Position += 4;
                    stream.Read(intBuffer, 0, sizeof(int));
                    stream.Position -= 8;

                    if (BitConverter.ToInt32(intBuffer) > recordPosition)
                    {
                        stream.Position += 4;

                        stream.Write(BitConverter.GetBytes(BitConverter.ToInt32(intBuffer) - 1));
                        stream.Position -= 8;
                    }

                    stream.Position += Record.ByteSize;
                }
            }
        }

        public void InsertIndex(string fileName, int index, long startBytePosition, int blockId)
        {
            var IndexBlock = BinaryQuery.GetIndexBlockByBlockId(fileName, blockId);

            for (int i = 0; i < IndexBlock.Count; i++)
            {
                if (IndexBlock[i].Value == UnsignedSpaceIndicator)
                {
                    IndexBlock[i].Id = index;
                    IndexBlock[i].Value = RecordsQuantity - 1;
                    break;
                }
            }

            IndexBlock = IndexBlock
                .OrderBy(item => item.Id)
                .ToList();

            

            SetBlock(IndexBlock, startBytePosition);
        }

        private void SetBlock(List<IndexRecord> indexRecordList, long byteStartPosition)
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

        public bool EditRecord(DataRecord record)
        {
            if (RecordContains(record))
            {
                long bytePosition = BinaryQuery.GetRecordPosition(IndexFileName, record);
                using (var dataStream = File.Open(DataFileName, FileMode.Open))
                {
                    dataStream.Position = (Record.ByteSize * bytePosition) + sizeof(int);
                    dataStream.Write(BitConverter.GetBytes(record.Value), 0, sizeof(int));
                }

                return true;
            }

            return false;
        }

        public bool RecordContains(DataRecord record)
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

        public static void GenerateIndexFileLayout(string fileName)
        {
            using (var indexWriter = new BinaryWriter(File.Open(fileName, FileMode.Truncate)))
            {
                for (int i = 0; i < MaxRecordQuantity; i++)
                {
                    indexWriter.Write(UnsignedSpaceIndicator);
                    indexWriter.Write(UnsignedSpaceIndicator);
                }
            }
        }
    }
}