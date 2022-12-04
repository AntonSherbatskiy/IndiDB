using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IndiDB
{
    public class Record
    {
        public Record(int id, int value)
        {
            Id = id;
            Value = value;
        }

        public int Id { get; private set; }
        public int Value { get; set; }
        public const int SizeInBytes = 8;

        public override string ToString() => $"Id: {Id}\tData: {Value}";
    }
}
