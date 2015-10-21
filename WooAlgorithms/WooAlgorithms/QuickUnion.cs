using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms
{
    public class QuickUnion
    {
         public int[] id;

         public QuickUnion(int n)
        {
            id = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
            }
        }
         int Root(int i)
         {
             while (i != id[i]) i = id[i];
             return i;
         }
        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }
        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);
            id[i] = j;
        }
    }
}
