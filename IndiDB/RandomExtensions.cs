using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiDB
{
    internal static class RandomExtensions
    {
        public static void Shuffle(this Random rng, DataRecord[] records)
        {
            int n = records.Length;

            while (n > 1)
            {
                int k = rng.Next(n--);
                (records[k], records[n]) = (records[n], records[k]);
            }
        }
    }
}
