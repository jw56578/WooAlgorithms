using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WooAlgorithms.Test
{
    [TestClass]
    public class GraphDepthFirstSearchTests
    {

        [TestMethod]
        public void BredthFirstSearchWorks()
        {
            Graph.Graph g = new Graph.Graph(9);
            g.AddEdge(0, 2);
            g.AddEdge(0, 1);
            g.AddEdge(0, 5);
            g.AddEdge(1,2);
            g.AddEdge(2,4);
            g.AddEdge(2,3);
            g.AddEdge(3,4);
            g.AddEdge(3,5);

            //create another path to 3 that is really long
            g.AddEdge(1, 6);
            g.AddEdge(6,7);
            g.AddEdge(7,8);
            g.AddEdge(8,3);

            Graph.BreadthFirstSearch dfs = new Graph.BreadthFirstSearch(g, 0);

            Assert.AreEqual(dfs.edgeTo[1], 0);
            Assert.AreEqual(dfs.edgeTo[2], 0);
            Assert.AreEqual(dfs.edgeTo[3], 2);
            Assert.AreEqual(dfs.edgeTo[4], 2);
            Assert.AreEqual(dfs.edgeTo[5], 0);

            //I have no idea how to implement distance to, the stupid course didn't explain it
            Assert.AreEqual(dfs.disTo[1], 1);
            Assert.AreEqual(dfs.disTo[2], 1);
            Assert.AreEqual(dfs.disTo[3], 2);
            Assert.AreEqual(dfs.disTo[4], 2);
            Assert.AreEqual(dfs.disTo[5], 1);


        }
        [TestMethod]
        public void DepthFirstSearchWorks()
        {
            Graph.Graph g = new Graph.Graph(7);
            g.AddEdge(0, 6);
            g.AddEdge(0, 2);
            g.AddEdge(0, 1);
            g.AddEdge(0, 5);
            g.AddEdge(6, 4);
            g.AddEdge(4, 5);
            g.AddEdge(4, 3);
            g.AddEdge(5,3);

            Graph.DepthFirstSearch dfs = new Graph.DepthFirstSearch(g,0);
            Assert.AreEqual(dfs.edgeTo[1], 0);
            Assert.AreEqual(dfs.edgeTo[2], 0);
            Assert.AreEqual(dfs.edgeTo[3], 5);
            Assert.AreEqual(dfs.edgeTo[4], 6);
            Assert.AreEqual(dfs.edgeTo[5], 4);
            Assert.AreEqual(dfs.edgeTo[6], 0);

            //so what the hell is the point of this
            //you know have a graph of how you get back to a location starting from any location
            //if you asked how to get from 5 to 0 you would just read through the edges
            //5 goes to 4, 4 goes to 6, 6 goes to 0
            //this is useful for solving mazes, you start at one point run the search and then you know how to get to the end point
            //this does not help with finding the shortest distance
            //if the maze had two ways to solve, you wouldn't know which way was shorter
        }
    }
}
