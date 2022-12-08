using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndiDB.FileRecord;

namespace IndiDB
{
    public static class SearchingEngine
    {
        public static int Search(List<IndexRecord> indexList, int id)
        {
            int k = (int)Math.Log2(indexList.Count);
            int key = (int)Math.Pow(2, k);
            int temp = 0;
            int gamma = (int)Math.Pow(2, k);

            if (indexList[key].Id > id)
            {
                do
                {
                    if (indexList[key].Id > id)
                    {
                        key -= gamma / 2;
                    }
                    else
                    {
                        key += gamma / 2;
                    }

                    if (key < 0)
                    {
                        key = 0;
                    }
                    else if (key >= indexList.Count)
                    {
                        key = indexList.Count - 1;
                    }

                    if (indexList[key].Id == id)
                    {
                        return indexList[key].Value;
                    }

                    gamma = (int)Math.Pow(2, k - temp);
                    temp++;

                } while (gamma != 0);

                return -1;
            }
            else
            {
                int l = (int)Math.Log2(indexList.Count - Math.Pow(2, k));
                key = indexList.Count - (int)Math.Pow(2, l);
                gamma = (int)Math.Pow(2, l - temp);

                do
                {
                    if (indexList[key].Id > id)
                    {
                        key -= gamma / 2;
                    }
                    else
                    {
                        key += gamma / 2;
                    }

                    if (key < 0)
                    {
                        key = 0;
                    }
                    else if (key >= indexList.Count)
                    {
                        key = indexList.Count - 1;
                    }

                    if (indexList[key].Id == id)
                    {
                        return indexList[key].Value;
                    }

                    gamma = (int)Math.Pow(2, l - temp);
                    temp++;
                } while (gamma != 0);

                return -1;
            }
        }
    }
}
