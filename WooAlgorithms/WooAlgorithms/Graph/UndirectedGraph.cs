using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms.Graph
{
    /// <summary>
    /// this is similiar to dynamic connectivity as being an object that is connected to another object
    /// 
    /// An extra consideration is when things are connected in many different paths. 
    /// What is the shortest path - how do you determine this
    /// 
    /// Cycle - is there a path from one vertex back to the same vertex
    /// 
    /// Euler tour - is there a cycle that uses each edge exactly once
    /// 
    /// Hamilton tour - is there a ccle that uses each vertex exactly once
    /// 
    ///like everything else we need to store things within an array where the index is equal to the id of some object
    ///a vertices will be an object with an number id
    ///the id will coorelate to an array index
    ///the index of the array will contain a list of the ids of the other vertices that its connected to
    ///this is called Adjacency List Graph
    ///
    /// 
    /// </summary>
    public abstract class Graph
    {
        //list could be replaced with Bag, google java bag
        protected List<int>[] adj;

        //I guess you need another array to hold the actual object
        protected Vertex[] vertex;

        //the count of all vertex
        public int V;

        public Graph(int v)
        {
            this.V = v;
            adj = new List<int>[v];
            vertex = new Vertex[v];
            v--;
            while (v >= 0) {
                //should there be another array to hold the actual object?
                var vert = new Vertex() { Id = v };
                vertex[v] = vert;
                adj[v] = new List<int>();
                v--;
            }

        }
        public abstract void AddEdge(int v, int w);



        public IEnumerable<int> Adj(int v) {
            foreach (var vert in adj[v])
            {
                yield return vert;
            }
        }
    }
    public class UndirectedGraph : Graph
    {
        public UndirectedGraph(int v):base(v)
        {

        }
        public override void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
        }
    }
}
