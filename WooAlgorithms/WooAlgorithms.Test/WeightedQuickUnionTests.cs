using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WooAlgorithms.DynamicConnectivity;

namespace WooAlgorithms.Test
{
    [TestClass]
    public class WeightedQuickUnionTests
    {
        [TestMethod]
        public void PercolationWorks()
        {
            var p = new Percolation();

        }
        [TestMethod]
        public void Works()
        {
            var wqu = new WeightedQuickUnion(10);

            wqu.Union(4, 3);
            wqu.Union(3,8);
            wqu.Union(9, 4);

            wqu.Union(6, 5);
            wqu.Union(2, 1);
            wqu.Union(5,0);
            wqu.Union(7, 2);
            wqu.Union(6, 1);
            //wqu.Union(7, 3); this would connect everything

            Assert.IsTrue(wqu.Connected(4, 3));
            Assert.IsTrue(wqu.Connected(4, 8));
            Assert.IsTrue(wqu.Connected(4, 9));
            Assert.IsTrue(wqu.Connected(3, 3));
            Assert.IsTrue(wqu.Connected(3, 8));
            Assert.IsTrue(wqu.Connected(3, 9));
            Assert.IsTrue(wqu.Connected(8, 8));
            Assert.IsTrue(wqu.Connected(8, 9));

            Assert.IsFalse(wqu.Connected(4, 1));
            Assert.IsFalse(wqu.Connected(4, 7));
            Assert.IsFalse(wqu.Connected(4, 2));
            Assert.IsFalse(wqu.Connected(4, 5));
            Assert.IsFalse(wqu.Connected(4, 6));
            Assert.IsFalse(wqu.Connected(4, 0));
            Assert.IsFalse(wqu.Connected(8, 1));
            Assert.IsFalse(wqu.Connected(8, 7));
            Assert.IsFalse(wqu.Connected(8, 2));

            Assert.IsTrue(wqu.Connected(6, 0));
            Assert.IsTrue(wqu.Connected(6, 1));
            Assert.IsTrue(wqu.Connected(6, 2));
            Assert.IsTrue(wqu.Connected(6, 5));
            Assert.IsTrue(wqu.Connected(6, 7));
            Assert.IsTrue(wqu.Connected(2, 0));
            Assert.IsTrue(wqu.Connected(2, 1));




        }
    }
}
