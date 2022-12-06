﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IndiDB
{
    public static class DataGenerator
    {
        public static void GenerateRecords(string dataFileName, string indexFileName, int recordsQuantity)
        {
            BinaryComponent component = new BinaryComponent(dataFileName, indexFileName);
            var dataRecords = new DataRecord[recordsQuantity];
            Random random = new Random();

            for (int i = 0; i < recordsQuantity; i++)
            {
                dataRecords[i] = new DataRecord(i, random.Next(1001));
            }

            random.Shuffle(dataRecords);

            BinaryComponent.GenerateIndexFileLayout(indexFileName);
  
            using (var dataWriter = new BinaryWriter(File.Open(dataFileName, FileMode.Truncate)))
            {

                for (int i = 0; i < recordsQuantity; i++)
                {
                    dataWriter.Write(dataRecords[i].Id);
                    dataWriter.Write(dataRecords[i].Value);

                    int blockId = (int)Math.Floor((double)dataRecords[i].Id / 100);
                    int startBytePosition = blockId * BinaryComponent.BlockSizeInBytes;

                    var IndexBlock = BinaryQuery.GetIndexBlockByBlockId(indexFileName, blockId);

                    for (int j = 0; j < IndexBlock.Count; j++)
                    {
                        if (IndexBlock[j].Value == BinaryComponent.UnsignedSpaceIndicator)
                        {
                            IndexBlock[j].Id = dataRecords[i].Id;
                            IndexBlock[j].Value = i;
                            break;
                        }
                    }

                    IndexBlock = IndexBlock
                        .OrderBy(item => item.Id)
                        .ToList();

                    using (var stream = File.Open(indexFileName, FileMode.Open))
                    {
                        stream.Position = startBytePosition;

                        foreach (var item in IndexBlock)
                        {
                            stream.Write(BitConverter.GetBytes(item.Id), 0, sizeof(int));
                            stream.Write(BitConverter.GetBytes(item.Value), 0, sizeof(int));
                        }
                    }
                }
            }
        }
    }
}
