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
        private const int ROWS = 5;
        private const int COL = 5;

        //part A pad
        //private static string[,] keypad = new string[ROWS, COL] { { "1", "2", "3" },          
        //{ "4", "5", "6" },          
        //{ "7", "8", "9" } };         

        // part B pad
        private static string[,] keypad = new string[ROWS, COL] { { null, null, "1", null, null},
                                                                  { null, "2", "3", "4", null},
                                                                  { "5", "6", "7", "8", "9"},
                                                                  { null, "A", "B", "C", null},
                                                                  { null, null, "D", null, null}};


        //code to enter
        private static string code = "";

        //starting position
       // private static int x = 1; //part a
       // private static int y = 1; //part a

        private static int x = 0;
        private static int y = 2;

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
            //NOTE - cleaned up function from part A. Include the boundry check within the switch statement before doing a move, part b uses this also.
            switch (direction)
            {
                case 'U':
                    if (y - 1 >= 0) //making sure you are in the keypad boundries
                    {
                        if (keypad[y - 1, x] != null) //checking you are not moving into a null position
                        {
                            y--;
                        }
                    }
                    break;
                case 'R':
                    if (x + 1 < 5)
                    {
                        if (keypad[y, x + 1] != null)
                        {
                            x++;
                        }
                    }
                    break;
                case 'D':
                    if (y + 1 < 5)
                    {
                        if (keypad[y + 1, x] != null)
                        {
                            y++;
                        }
                    }
                    break;
                case 'L':
                    if (x - 1 >= 0)
                    {
                        if (keypad[y, x - 1] != null)
                        {
                            x--;
                        }
                    }
                    break;
            }
        }
    }
}
