using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        //starting position
        private static int x = 1;
        private static int y = 1;

        static void Main(string[] args)
        {

            string fileName = (@"C:\Users\Sean Spalding\Documents\AdventofCode\Day 2\puzzle input.txt"); 

            string input = System.IO.File.ReadAllText(fileName);

            // split the inputs so we can get each code, seperate by an empty space
            string[] splitInputs = Regex.Split(input, ",");

            List<string> instructions = new List<string>();
            for (int i = 0; i < splitInputs.Length; i++)
            {
                instructions.Add(splitInputs[i]);

            }

            //looping all the lines
            for (int i = 0; i < instructions.Count; i++)
            {
                // Loop through string
                for (int j = 0; j < instructions[i].Length; j++)
                {
                    //move on pad
                    move(instructions[i][j]);
                }

                //add number to the code
                code += keypad[y, x];
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
            if (x > 2) //furthest right
                x = 2;
            else if (x < 0) //furthest left
                x = 0;
            else if (y > 2) //furthest down
                y = 2;
            else if (y < 0) //furthest up
                y = 0;
        }
    }
}
