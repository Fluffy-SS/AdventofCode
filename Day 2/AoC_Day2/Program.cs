using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//U moves up, D moves down, L moves left, and R moves right
/*  keypad
    1 2 3
    4 5 6
    7 8 9
*/

//Each button to be pressed can be found by starting on the previous button and moving to adjacent buttons on the keypad
//Each line of instructions corresponds to one button, starting at the previous button (or, for the first line, the "5" button)
//press whatever button you're on at the end of each line. If a move doesn't lead to a button, ignore it.

namespace AoC_Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            //array of 3 rows and 2 columns
            const int ROWS = 3;
            const int COL = 3;
            string[,] keypad = new string[ROWS, COL] { { "1", "2", "3" }, 
                                                       { "4", "5", "6" },
                                                       { "7", "8", "9" } };

            // direction input puzzle
            // Read the file as one string.
            string input = System.IO.File.ReadAllText(@"C:\Users\Sean Spalding\Documents\AdventofCode\Day 2\puzzle input.txt");

            for (int row = 0; row < keypad.GetLength(0); row++)
            {
                for (int col = 0; col < keypad.GetLength(1); col++)
                {
                    Console.WriteLine(keypad[row, col]);
                }
            }
            //Console.WriteLine(keypad);
            Console.Read();
        }
    }
}
