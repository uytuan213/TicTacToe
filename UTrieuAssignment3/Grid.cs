/*
 * ProgramID: Game Tic-Tac-Toe
 * 
 * Purpose: Grid to store cells
 * 
 * Revision history:
 *      Tony Trieu written Nov 19, 2018
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTrieuAssignment3
{
    /// <summary>
    /// A class to display list of cells
    /// </summary>
    public class Grid
    {
        public const int NUM_OF_ROWS = 3;
        public const int NUM_OF_COLS = 3;
        public const int CELL_WIDTH = 100;
        public const int CELL_HEIGHT = 100;

        private Cell[,] cells;

        public Cell[,] Cells { get => cells; set => cells = value; }

        /// <summary>
        /// Generate grid which contains list of cells
        /// </summary>
        public void generate()
        {
            cells = new Cell[NUM_OF_ROWS, NUM_OF_COLS];
            for (int i = 0; i < NUM_OF_ROWS; i++)
            {
                for (int j = 0; j < NUM_OF_COLS; j++)
                {
                    Cell c = new Cell();
                    c.Width = CELL_WIDTH;
                    c.Height = CELL_HEIGHT;
                    c.BorderStyle = BorderStyle.FixedSingle;
                    c.Top = i * CELL_WIDTH;
                    c.Left = j * CELL_HEIGHT;
                    cells[i, j] = c;
                }
            }
        }

        /// <summary>
        /// Check if all cells is clicked
        /// </summary>
        /// <returns></returns>
        public bool isFull()
        {
            for (int i = 0; i < NUM_OF_ROWS; i++)
            {
                for (int j = 0; j < NUM_OF_COLS; j++)
                {
                    if(Cells[i, j].Type == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
