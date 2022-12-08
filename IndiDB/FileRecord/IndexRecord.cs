using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiDB.FileRecord
{
    public class IndexRecord : Record
    {
        public IndexRecord(int id, int value) : base(id)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}
