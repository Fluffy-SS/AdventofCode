using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AoC_Day1
{
    class Program
    {
        //user starting position
        private static Point position = new Point(0, 0);

        // Keep track of previous positions
        private static List<Point> recentPositions = new List<Point>();

        // first position santa hits twice - part B
        private static Point visitTwicePos;

        // tell if first position has been hit - part B
        private static bool alreadyVisited = false;


        static void Main(string[] args)
        {
            // direction input puzzle
            // Read the file as one string.
            string allInputs = System.IO.File.ReadAllText(@"C:\Users\Sean Spalding\Documents\AdventofCode\Day 1\puzzle input.txt");

            // split the inputs so we can go step by step, seperate by the comma
            string[] splitInputs = Regex.Split(allInputs, ", ");

            // the direction santa is facing 0 = north, 1 = east, 2 = south, 3 = west
            int direction = 0; //begin facing north

            string[] dir = { "North", "East", "South", "West"};
            string facing = "";



            for (int i = 0; i < splitInputs.Length; i++)
            {
                // turn left or right 90 degrees depending on the first character in the split input array 
                // checking the first index, first character then second index first character and so on
                direction = splitInputs[i][0] == 'L' ? turnLeft(direction) : turnRight(direction);

                //once santa is facing the right way, we need to move him forward
                //move forward the blocks provided
                //check the second character of the input
                //parse the string to an int to be used correctly
                move(int.Parse(splitInputs[i].Substring(1)), direction);
            }

            //Check which way santa is facing
            if (direction == 0) facing = dir[0];

            else if (direction == 1) facing = dir[1];

            else if (direction == 2) facing = dir[2];

            else if (direction == 3) facing = dir[3];

            //check the result
            Console.WriteLine("Santa is " + Math.Abs(position.X + position.Y) + " blocks away due " + facing + " of the initial starting position");
            Console.WriteLine(Math.Abs(visitTwicePos.X - visitTwicePos.Y) + " Blocks away is the first location Santa visited twice"); // - part B
            Console.Read();
        }

        //turn 90 degree right, if the dir is more than 3 then it is back to north
        private static int turnRight(int direction)
        {
            direction++;
            if (direction > 3) direction = 0;

            return direction;
        }

        //turn 90 degree left, if the dir is more than 3 then it is back to west
        private static int turnLeft(int direction)
        {
            direction--;
            if (direction < 0) direction = 3;

            return direction;
        }

        //Move santa forward in the given blocks
        private static void move(int blocksToMove, int direction)
        {
            // Loop through steps
            for (int i = 0; i < blocksToMove; i++)
            {
                // check if we have completed our position duplicate check - part B
                if (!alreadyVisited)
                {
                    // Check if we have been in this position before - part B
                    foreach (Point item in recentPositions)
                    {
                        // If the location matches an item in the list - part B
                        if (position == item)
                        {
                            visitTwicePos = item;
                            alreadyVisited = true;
                            continue;
                        }
                    }
                }
                    // Store position at each step
                    recentPositions.Add(position);

                //Move forward one block at a time
                // +Y = North, -Y = South, +X = East, -X = West
                if (direction == 0)
                {
                    position.Y++;
                }
                else if (direction == 1)
                {
                    position.X++;
                }

                else if (direction == 2)
                {
                    position.Y--;
                }

                else if (direction == 3)
                {
                    position.X--;
                }

            }

        }
    }
}
