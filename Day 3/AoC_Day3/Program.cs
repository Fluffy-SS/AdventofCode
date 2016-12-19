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
            //======TODO
            //get input
            //store 3 values in a vec3
            //if x + y > z & x + z > y & y + z > x then this is a triangle, counter++
            //================================================

            // Store input in vec3 class
            List<Vec3> triangles = new List<Vec3>();

            //read input from file
            string[] input = System.IO.File.ReadAllLines(@"C:\Users\Sean Spalding\Documents\AdventofCode\Day 3\puzzle input.txt");

            // Loop through all lines
            for (int i = 0; i < input.Length; i++)
            {
                // Split the line on whitespaces
                string[] splitInput = input[i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();

                // Store splitted string in int
                int x = int.Parse(splitInput[0]);
                int y = int.Parse(splitInput[1]);
                int z = int.Parse(splitInput[2]);

                // Check if valid
                if (((x + y) > z) &&
                    ((x + z) > y) &&
                    ((y + z) > x))
                {
                    // Add splitted line to list
                    triangles.Add(new Vec3(int.Parse(splitInput[0]), int.Parse(splitInput[1]), int.Parse(splitInput[2])));
                }
            }

            Console.WriteLine("Amount of valid triangles is " + triangles.Count);
            Console.Read();
        }
    }
}
