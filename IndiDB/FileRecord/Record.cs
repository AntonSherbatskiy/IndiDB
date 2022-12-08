using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiDB.FileRecord
{
    public class Record
    {
        public Record(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public const int ByteSize = 8;
    }
}
