using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Store input in vec3 class
            //Part A
            //List<Vec3> triangles = new List<Vec3>();

            //keep track of valid triangles
            //Part B
            int count = 0;

            //read input from file
            string[] input = System.IO.File.ReadAllLines(@"C:\Users\Sean Spalding\Documents\AdventofCode\Day 3\puzzle input.txt");

            //store lines in a list
            //Part B
            List<Line> list = new List<Line>();

            // Loop through all lines
            for (int i = 0; i < input.Length; i++)
            {
                // Split the line on whitespaces
                string[] splitInput = input[i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();

                // Store splitted string in int
                int x = int.Parse(splitInput[0]);
                int y = int.Parse(splitInput[1]);
                int z = int.Parse(splitInput[2]);

                //Part A
                //triangles.Add(new Vec3(x, y, z));

                //add current line to list
                list.Add(new Line(x, y, z));
            }

            //Part B
            for (int i = 0; i < list.Count; i += 3)
            {
                //create list to store new points of vertical data
                List<Line> temp = new List<Line>();
                temp.Add(list[i]);
                temp.Add(list[i + 1]);
                temp.Add(list[i + 2]);

                //get vertical points 
                for (int j = 0; j < 3; j++)
                {
                    int x = temp[0].Get(j);
                    int y = temp[1].Get(j);
                    int z = temp[2].Get(j);

                    // Check if valid
                    //Parts A & B
                    if (((x + y) > z) &&
                        ((x + z) > y) &&
                        ((y + z) > x))
                    {
                        count++;
                        //if part A then replace above with triangles.add code
                    }
                }
            }

            //Part A
            //triangles.Add(new Vec3(int.Parse(splitInput[0]), int.Parse(splitInput[1]), int.Parse(splitInput[2])));

            // Part B
            Console.WriteLine("Amount of triangles: " + count);

            //Part A
            // Console.WriteLine("Amount of valid triangles is " + triangles.Count);
            Console.Read();
        }
    }
}
