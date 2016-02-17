using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms
{
    /// <summary>
    /// as opposed to quick find, we are not using a random number to mark whether things are connected
    /// the value of the array will contain the value of a things parent to indicate that they are connected
    /// in order to check whether tthings are connected, you compare the roots of each
    /// the overhead is finding the root of each child each time
    /// the trees could get too tall 
    /// </summary>
    public class QuickUnion
    {
         public int[] id;

        //start off by assigning each thing as its own parent
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
            //if somethign go orphaned, this would break;
            //if somehow something wasn't the parent of itself, this would break
            //if you started looking for 2 right away
            //2 would = id[2] so it would find 2 right away as its own root
            //if 1 is parent of 2 then you would look at 2 and see 1
            //then you would look at 1 and see 1 is the parent of itself so thats the root
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
