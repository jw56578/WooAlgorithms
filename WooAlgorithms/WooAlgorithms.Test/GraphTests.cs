﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace WooAlgorithms.Test
{
    [TestClass]
    public class GraphTests
    {
        public Graph.Graph StrongComponent()
        {
            Graph.Graph g = new Graph.DirectedGraph(13);
            g.AddEdge(4, 2);
            g.AddEdge(2,3);
            g.AddEdge(3,2);
            g.AddEdge(6,0);
            g.AddEdge(0,1);
            g.AddEdge(2,0);
            g.AddEdge(11,12);
            g.AddEdge(12,9);
            g.AddEdge(9,10);
            g.AddEdge(9,11);
            g.AddEdge(7,9);
            g.AddEdge(10,12);
            g.AddEdge(11,4);
            g.AddEdge(4,3);
            g.AddEdge(3,5);
            g.AddEdge(6,8);
            g.AddEdge(8,6);
            g.AddEdge(5, 4);
            g.AddEdge(0, 5);
            g.AddEdge(6, 4);
            g.AddEdge(6, 9);
            g.AddEdge(7, 6);
            return g;
        }
        [TestMethod]
        public void StrongComponentWorks()
        {
            var sc = new Graph.StrongComponents(StrongComponent());
            Assert.AreEqual(sc.id[0], 1);
            Assert.AreEqual(sc.id[1], 0);
            Assert.AreEqual(sc.id[2], 1);
            Assert.AreEqual(sc.id[3], 1);
            Assert.AreEqual(sc.id[4], 1);
            Assert.AreEqual(sc.id[5], 1);
            Assert.AreEqual(sc.id[6], 3);
            Assert.AreEqual(sc.id[7], 4);
            Assert.AreEqual(sc.id[8], 3);
            Assert.AreEqual(sc.id[9], 2);
            Assert.AreEqual(sc.id[10], 2);
            Assert.AreEqual(sc.id[11], 2);
            Assert.AreEqual(sc.id[12], 2);
        }
        [TestMethod]
        public void ReverseGraph()
        {
            var g = StrongComponent();
            g = g.Reverse();


        }
        [TestMethod]
        public void DepthFirstOrder()
        {
            Graph.Graph g = new Graph.DirectedGraph(7);
            g.AddEdge(0, 5);
            g.AddEdge(0, 2);
            g.AddEdge(0, 1);
            g.AddEdge(3, 6);
            g.AddEdge(3, 5);
            g.AddEdge(3, 4);
            g.AddEdge(5, 2);
            g.AddEdge(6, 4);
            g.AddEdge(6, 0);
            g.AddEdge(3, 2);
            g.AddEdge(1, 4);

            Graph.DepthFirstOrder dfs = new Graph.DepthFirstOrder(g);
            //4,1,2,5,0,6,3
            //this doesn't come out in the order of the lecture but it doesn't matter
            //it just has to be in in any order from bottom to top
            //this result actually makes more sense because 2 goes no where and it is at the top
            var postOrder = dfs.ReverseOrder().ToArray();
            Assert.AreEqual(postOrder[0], 3);
            Assert.AreEqual(postOrder[1], 6);
            Assert.AreEqual(postOrder[2], 0);
            Assert.AreEqual(postOrder[3], 1);
            Assert.AreEqual(postOrder[4], 4);
            Assert.AreEqual(postOrder[5], 5);
            Assert.AreEqual(postOrder[6], 2);

        }
        [TestMethod]
        public void DirectedBredthFirstSearchWorks()
        {
            Graph.Graph g = new Graph.DirectedGraph(9);
            g.AddEdge(0, 2);
            g.AddEdge(0, 1);
            g.AddEdge(2, 4);
            g.AddEdge(5, 0);
            g.AddEdge(1, 2);
            g.AddEdge(3, 2);
            g.AddEdge(4, 3);
            g.AddEdge(3, 5);
            g.AddEdge(3, 5);


            Graph.BreadthFirstSearch dfs = new Graph.BreadthFirstSearch(g, 0);

            Assert.AreEqual(dfs.edgeTo[1], 0);
            Assert.AreEqual(dfs.edgeTo[2], 0);
            Assert.AreEqual(dfs.edgeTo[3], 4);
            Assert.AreEqual(dfs.edgeTo[4], 2);
            Assert.AreEqual(dfs.edgeTo[5], 3);


            Assert.AreEqual(dfs.disTo[1], 1);
            Assert.AreEqual(dfs.disTo[2], 1);
            Assert.AreEqual(dfs.disTo[3], 3);
            Assert.AreEqual(dfs.disTo[4], 2);
            Assert.AreEqual(dfs.disTo[5], 4);


        }
        [TestMethod]
        public void ConnectdComponentsWorks()
        {
            Graph.Graph g = new Graph.UndirectedGraph(13);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(0, 5);
            g.AddEdge(0, 6);
            g.AddEdge(3, 4);
            g.AddEdge(3, 5);
            g.AddEdge(4, 6);
            g.AddEdge(4, 5);

            g.AddEdge(7, 8);

            g.AddEdge(9, 10);
            g.AddEdge(9, 11);
            g.AddEdge(9, 12);
            g.AddEdge(11, 12);

            Graph.ConnectedComponents cc = new Graph.ConnectedComponents(g);
            Assert.AreEqual(cc.id[0], 0);
            Assert.AreEqual(cc.id[1], 0);
            Assert.AreEqual(cc.id[2], 0);
            Assert.AreEqual(cc.id[3], 0);
            Assert.AreEqual(cc.id[4], 0);
            Assert.AreEqual(cc.id[5], 0);
            Assert.AreEqual(cc.id[6], 0);
            Assert.AreEqual(cc.id[7], 1);
            Assert.AreEqual(cc.id[8], 1);
            Assert.AreEqual(cc.id[9], 2);
            Assert.AreEqual(cc.id[10], 2);
            Assert.AreEqual(cc.id[11], 2);
            Assert.AreEqual(cc.id[12], 2);

            //so then you just look at the item that you care about and find out what its id is
            //then you find everything else that has the same id and do whatever
        }
        [TestMethod]
        public void BredthFirstSearchWorks()
        {
            Graph.Graph g = new Graph.UndirectedGraph(9);
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
            Graph.Graph g = new Graph.UndirectedGraph(7);
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
