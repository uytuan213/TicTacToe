/*
 * ProgramID: Game Tic-Tac-Toe
 * 
 * Purpose: Main class to play game
 * 
 * Revision history:
 *      Tony Trieu written Nov 19, 2018
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTrieuAssignment3
{
    /// <summary>
    /// A class to demonstrate play form
    /// </summary>
    public partial class Tic_Tac_Toe : Form
    {
        private Grid grid;
        private int turn;
        private enum Type
        {
            none,
            x,
            o
        };
        /// <summary>
        /// The default constructor of the class
        /// </summary>
        public Tic_Tac_Toe()
        {
            InitializeComponent();
            grid = new Grid();
            generateGrid();
        }

        /// <summary>
        /// Generate a list of cells 
        /// </summary>
        public void generateGrid()
        {
            pnlDisplay.Controls.Clear();
            grid.generate();
            for (int i = 0; i < grid.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < grid.Cells.GetLength(1); j++)
                {
                    grid.Cells[i, j].Row = i;
                    grid.Cells[i, j].Col = j;
                    grid.Cells[i, j].Click += Cell_Click;
                    pnlDisplay.Controls.Add(grid.Cells[i, j]);
                }
            }
            turn = 0;
            lblTurn.Text = "X turn";
            lblTurn.ForeColor = Color.Red;
        }

        /// <summary>
        /// Take turn and display x-o to cells
        /// </summary>
        private void Cell_Click(object sender, EventArgs e)
        {
            Cell c = (Cell)sender;
            if(c.Type == (int)Type.none)
            {
                if (turn % 2 == 0)
                {
                    c.Type = (int)Type.x;
                    lblTurn.Text = "O turn";
                    lblTurn.ForeColor = Color.Blue;
                }
                else
                {
                    c.Type = (int)Type.o;
                    lblTurn.Text = "X turn";
                    lblTurn.ForeColor = Color.Red;
                    
                }
                turn++;
                //Check victory
                if (checkVictory(c))
                {
                    if (c.Type == (int)Type.x)
                    {
                        MessageBox.Show("X wins!");
                    }
                    else
                    {
                        MessageBox.Show("O wins!");
                    }
                    generateGrid();
                }
                else
                {
                    if (grid.isFull())
                    {
                        MessageBox.Show("Draw");
                        generateGrid();
                    }
                }
            }
            
        }

        /// <summary>
        /// Check if there is a win 
        /// </summary>
        /// <param name="c">The lastest cell clicked</param>
        /// <returns>True if there is a win</returns>
        private bool checkVictory(Cell c)
        {
            
            int row = c.Row;
            int col = c.Col;
            int count = 0;
            if (c.Row == c.Col)
            {
                for (int i = 0; i < Grid.NUM_OF_ROWS; i++)
                {
                    if (grid.Cells[i, i].Type == c.Type)
                    {
                        count++;
                    }
                }
                if (count == Grid.NUM_OF_ROWS)
                    return true;
            }
            count = 0;
            if (c.Row + c.Col == Grid.NUM_OF_ROWS - 1)
            {
                int i = 0;
                int j = Grid.NUM_OF_ROWS - 1;
                while (i < Grid.NUM_OF_ROWS && j >= 0)
                {
                    if (grid.Cells[i, j].Type == c.Type)
                    {
                        count++;
                    }
                    i++;
                    j--;
                }
                if (count == Grid.NUM_OF_ROWS)
                {
                    return true;
                }
            }
            count = 0;
            for (int i = 0; i < Grid.NUM_OF_ROWS; i++)
            {
                if(grid.Cells[i, c.Col].Type == c.Type)
                {
                    count++;
                }
            }
            if (count == Grid.NUM_OF_ROWS)
            {
                return true;
            }
            count = 0;
            for (int i = 0; i < Grid.NUM_OF_COLS; i++)
            {
                if (grid.Cells[c.Row, i].Type == c.Type)
                {
                    count++;
                }
            }
            if (count == Grid.NUM_OF_ROWS)
            {
                return true;
            }
            return false;
        }
    }
}
