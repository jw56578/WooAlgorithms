using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms.DynamicConnectivity
{
    /// <summary>
    /// This is the practice of determining if 2 objects on opposite sides of a grid are connected to each other
    /// imagine a crossword puzzle grid and treat it as a maze, is there a path of white squares going from one side of the grid to another
    /// even though you could present an object graph in any way you wanted, you woul have to maintain the model used as integers, so each object would just have to have 1 unique integer id
    /// dont' get confused by the grid model, because of course if grid cells are next to each other, they are connected
    /// the important concept is if they are closed or open, it doesn't matter that they are touching each other
    /// </summary>
    public class Percolation
    {
        Grid myGrid = null;
        WeightedQuickUnion weightedUnion = null;
        int VirtualTopId = 0;
        int VirtualBottomId = 0;
        int X = 0;
        int Y = 0;
        int Cells = 0;
        public Percolation():this(10,10)
        {
 
        }
        public Percolation(int x, int y)
        {
            myGrid = new Grid(x,y);
            Cells = x * y;
            weightedUnion = new WeightedQuickUnion(Cells + 2);
            VirtualTopId = Cells;
            VirtualBottomId = Cells + 1;
            X = x;
            Y = y;
        }
        public void Union(int p, int q)
        {
            UnionVirtualSites(p, q);
            weightedUnion.Union(p, q);
        }
        void UnionVirtualSites(int p, int q)
        {
            if (p < X)
                UnionTopRow(p);
            if (p >= Cells - X)
                UnionBottomRow(p);
            if (q < X)
                UnionTopRow(q);
            if (q >= Cells - X)
                UnionBottomRow(q);

        }
        void UnionTopRow(int id)
        {
            weightedUnion.Union(VirtualTopId, id);
        }
        void UnionBottomRow(int id)
        {
            weightedUnion.Union(VirtualBottomId, id);
        }
        //do we need to care about unioning???
        public void UnUnion()
        {

        }
        ///// <summary>
        /// if you were just going to test whether the top row is connected to the bottom row, this would be too slow because you would just be loooping through
        /// all the cells on the top and testing against the cells on the bottom
        /// instead just create 2 more quasi cells that reprsent the entire top and the entire bottom
        /// so i guess anyttime you did a union on any id that is on the top and bottom row, you would then also union the virtual sites
        /// </summary>
        void CreateVirtualSite()
        {

        }
        public Cell GetCell(int x, int y)
        {
            return myGrid.GetRow(x).Cells[y];
        }
        public bool IsPercolated()
        {
            //need to create the ids that represent the virtual site
            return weightedUnion.Connected(VirtualBottomId,VirtualTopId);
        }
    }

    public class Grid
    {
        List<Row> Rows = new List<Row>();
        public Row GetRow(int index)
        {
            return Rows[index];
        }
        public Grid(int x, int y)
        {
            int Id = 0;
            for (int i = 0; i < y; i++)
            {
                var r = new Row();
                for (int a = 0; a < x; a++)
                {
                    var c = new Cell();
                    c.Top = NullCell.Instance;
                    c.Bottom = NullCell.Instance;
                    c.Left = NullCell.Instance;
                    c.Right = NullCell.Instance;

                    if (i > 0)
                    {
                        c.Top = Rows[i - 1].Cells[a] ;
                        Rows[i - 1].Cells[a].Bottom = c;
                    }
                    if (a > 0)
                    {
                        c.Left = (r.Cells[a - 1]);
                        r.Cells[a - 1].Right = c;
                    }
                    c.Id = Id;
                    r.Cells.Add(c);
                    Id++;
                }
                Rows.Add(r);
            }

        }
    }
    public class Cell
    {
        public int Id;
        public Cell Top;
        public Cell Bottom;
        public Cell Left;
        public Cell Right;
        public bool Enabled;
    }
    public class NullCell:Cell
    {
        public static NullCell Instance = new NullCell();
        private NullCell()
        {
            this.Id = -1;
        }
        public new readonly bool Enabled = false;
    }
    public class Row
    {
        public List<Cell> Cells = new List<Cell>();
    }
}
