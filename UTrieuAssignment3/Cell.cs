/*
 * ProgramID: Game Tic-Tac-Toe
 * 
 * Purpose: Cell class to display image
 * 
 * Revision history:
 *      Tony Trieu written Nov 19, 2018
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTrieuAssignment3
{
    /// <summary>
    /// the class to display cell which is inherit from PictureBox
    /// </summary>
    public class Cell : PictureBox
    {
        //List of images
        private List<Image> lst = new List<Image>()
        {
            null,
            Properties.Resources.x_red,
            Properties.Resources.o_blue
        };
        private int row;
        public int Row { get => row; set => row = value; }

        private int col;
        public int Col { get => col; set => col = value; }
        private int type;


        public int Type
        {
            get => type;
            set
            {
                if(value < lst.Count)
                {
                    type = value;
                    Image = lst[value];
                }
            }
        }

        /// <summary>
        /// Default constructor of the class
        /// </summary>
        public Cell()
        {
            this.type = 0;
            this.Image = lst[type];
            SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
