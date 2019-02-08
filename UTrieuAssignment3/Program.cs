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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTrieuAssignment3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Tic_Tac_Toe());
        }
    }
}
