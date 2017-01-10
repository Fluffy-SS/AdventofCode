using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sum of the sector IDs of the real rooms
            //Part A
            //int totalsum = 0;

            // Load file in memory
            string[] alllines = System.IO.File.ReadAllLines(@"C:\Users\Sean Spalding\Documents\AdventofCode\Day 4\puzzle input.txt");

            // Loop through all lines
            foreach (string line in alllines)
            {
                // Create room
                Room room = new Room(line);

                // If the room is valid add the sector id
                if (room.IsValidRoom())
                {
                    //Part A
                    //totalsum += room.SectorId;

                    string decr = room.Decrypted();
                    if (decr.Contains("object"))
                    {
                        Console.WriteLine("At sector {0} is the {1}.", room.SectorId, decr);
                    }
                }
                    
            }

            // Output
            //Part A
            //Console.WriteLine("The total sum is: {0}", totalsum);

            // Keep the console open
            Console.Read();
        }
    }
}
