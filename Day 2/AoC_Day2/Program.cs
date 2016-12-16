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

        //array of 3 rows and 2 columns
        private const int ROWS = 3;
        private const int COL = 3;
        private static string[,] keypad = new string[ROWS, COL] { { "1", "2", "3" },           //0,0 0,1 0,2
                                                                  { "4", "5", "6" },           //1,0 1,1 1,2
                                                                  { "7", "8", "9" } };         //2,0 2,1 2,2

        //code to enter
        private static string code = "";

        //current position
        private static int x = 1;
        private static int y = 1;

        static void Main(string[] args)
        {


            // direction input puzzle
            // Read the file as one string.
            string input = System.IO.File.ReadAllText(@"C:\Users\Sean Spalding\Documents\AdventofCode\Day 2\puzzle input.txt");

            //looping through keypad array
            for (int row = 0; row < keypad.GetLength(0); row++)
            {
                for (int col = 0; col < keypad.GetLength(1); col++)
                {
                    //Console.WriteLine(keypad[row, col]);
                }
            }
            Console.WriteLine("Code: " + code);
            Console.Read();
        }

        private static void move(char direction)
        {
            // where to move on keypad
            switch (direction)
            {
                case 'U':
                    y--;
                    break;
                case 'R':
                    x++;
                    break;
                case 'D':
                    y++;
                    break;
                case 'L':
                    x--;
                    break;
            }

            // out of bounds check
            if (x > keypad.GetLength(0)) //furthest right
                x = keypad.GetLength(0);
            else if (x < keypad.GetLength(0)-ROWS) //furthest left
                x = keypad.GetLength(0) - ROWS;
            else if (y > keypad.GetLength(1)) //furthest down
                y = keypad.GetLength(1);
            else if (y < keypad.GetLength(1) - COL) //furthest up
                y = keypad.GetLength(1) - COL;
        }
    }
}
