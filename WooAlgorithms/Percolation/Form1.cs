using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WooAlgorithms.DynamicConnectivity;

namespace Percolation
{
    public partial class Form1 : Form
    {
        WooAlgorithms.DynamicConnectivity.Percolation percolator = null;
        int colums = 10;
        int rows = 10;
        public Form1()
        {

            percolator = new WooAlgorithms.DynamicConnectivity.Percolation(colums,rows);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddButtons();
        }

        void AddButtons()
        {
            int ButtonWidth = 40;
            int ButtonHeight = 40;
            int Distance = 20;
            int start_x = 10;
            int start_y = 10;

            for (int x = 0; x < colums; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    CellButton tmpButton = new CellButton(percolator.GetCell(x,y),percolator);
                    tmpButton.Top = start_x + (x * ButtonHeight + Distance);
                    tmpButton.Left = start_y + (y * ButtonWidth + Distance);
                    tmpButton.Width = ButtonWidth;
                    tmpButton.Height = ButtonHeight;
                    tmpButton.Text = "X: " + x.ToString() + " Y: " + y.ToString();
                    tmpButton.BackColor = Color.Gray;
                    this.Controls.Add(tmpButton);
                }

            }
        }
    }

    public class CellButton : Button
    {
        Cell cell = null;
        WooAlgorithms.DynamicConnectivity.Percolation percolator = null;
        public CellButton(Cell cell, WooAlgorithms.DynamicConnectivity.Percolation p)
        {
            this.percolator = p;
            this.cell = cell;
            base.Click += CellButton_Click;
        }

        private void CellButton_Click(object sender, EventArgs e)
        {
            cell.Enabled = !cell.Enabled;
            if (cell.Enabled)
            {
                this.BackColor = Color.White;
                if (cell.Top.Enabled)
                    percolator.Union(cell.Id, cell.Top.Id);
                if (cell.Bottom.Enabled)
                    percolator.Union(cell.Id, cell.Bottom.Id);
                if (cell.Left.Enabled)
                    percolator.Union(cell.Id, cell.Left.Id);
                if (cell.Right.Enabled)
                    percolator.Union(cell.Id, cell.Right.Id);

                if (percolator.IsPercolated())
                {
                    this.FindForm().Close();
                }
            }
            else
                this.BackColor = Color.Gray;

        }

    }
}
