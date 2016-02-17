using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms
{
    public class WeightedQuickUnion
    {
         public int[] id;
        public int[] sz;

         public WeightedQuickUnion(int n)
        {
            id = new int[n];
            sz = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
                sz[i] = 1;
            }
        }
         int Root(int i)
         {
            while (i != id[i])
            {
                id[i] = id[id[i]];
                i = id[i];
            }
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
            if (i == j) return;
            if (sz[i] < sz[j])
            {
                id[i] = j;
                sz[j] += sz[i];
            }
            else {
                id[j] = i;
                sz[i] += sz[j];
            }
           
        }
    }
}
