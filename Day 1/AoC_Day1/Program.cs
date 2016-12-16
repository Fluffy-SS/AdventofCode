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
        private static Point firstLocVisitTwice;

        // tell if first position has been hit - part B
        private static bool gotFirstPosVisitTwice = false;


        static void Main(string[] args)
        {
            // direction input puzzle
            string allInputs = "L5, R1, L5, L1, R5, R1, R1, L4, L1, L3, R2, R4, L4, L1, L1, R2, R4, R3, L1, R4, L4, L5, L4, R4, L5, R1, R5, L2, R1, R3, L2, L4, L4, R1, L192, R5, R1, R4, L5, L4, R5, L1, L1, R48, R5, R5, L2, R4, R4, R1, R3, L1, L4, L5, R1, L4, L2, L5, R5, L2, R74, R4, L1, R188, R5, L4, L2, R5, R2, L4, R4, R3, R3, R2, R1, L3, L2, L5, L5, L2, L1, R1, R5, R4, L3, R5, L1, L3, R4, L1, L3, L2, R1, R3, R2, R5, L3, L1, L1, R5, L4, L5, R5, R2, L5, R2, L1, L5, L3, L5, L5, L1, R1, L4, L3, L1, R2, R5, L1, L3, R4, R5, L4, L1, R5, L1, R5, R5, R5, R2, R1, R2, L5, L5, L5, R4, L5, L4, L4, R5, L2, R1, R5, L1, L5, R4, L3, R4, L2, R3, R3, R3, L2, L2, L2, L1, L4, R3, L4, L2, R2, R5, L1, R2";

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
            Console.WriteLine(Math.Abs(firstLocVisitTwice.X - firstLocVisitTwice.Y) + " Blocks away is the first location Santa visited twice"); // - part B
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
                if (!gotFirstPosVisitTwice)
                {
                    // Check if we have been in this position before - part B
                    foreach (Point item in recentPositions)
                    {
                        // If the location matches an item in the list - part B
                        if (position == item)
                        {
                            firstLocVisitTwice = item;
                            gotFirstPosVisitTwice = true;
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
