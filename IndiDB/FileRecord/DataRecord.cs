using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IndiDB.FileRecord
{
    public class DataRecord : Record
    {
        public DataRecord(int id, int value) : base(id)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}
