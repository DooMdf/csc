// lesson 3 - dF - DrawSquares - 12.10.13
// this script will draw suqares from a given point and given side length
// uses functions

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 60); // set console window size
            int x = 20, y = 10, len = 0, cnt = 1;

            Console.Write("Set board size (for default: 20w x 10h press Enter, minimum: 10x10, to set value type: \"W x H\"): ");
            string[] nums = { "20", "10", "0" };

            string str = Console.ReadLine();
            if (str != "" && str != "0")
            {
                nums = str.Split('x');
            }

            if (int.Parse(nums[0]) < 10) { x = 20; }
            else { x = int.Parse(nums[0]); }

            if (int.Parse(nums[1]) < 10) { y = 10; }
            else { y = int.Parse(nums[1]); }

            if (x < 10) { x = 10; }
            if (y < 10) { y = 10; }

            char[,] arr = new char[x, y]; // set the main matrix

            matrixInit(ref arr, x, y);

            Console.Write("Insert coordinates (separate x, y and side length values with commas ','): ");
            str = Console.ReadLine();
            if (str == "" || str == "0") { cnt = 0; }
            else { nums = str.Split(','); }

            x = int.Parse(nums[0]);
            y = int.Parse(nums[1]);
            len = int.Parse(nums[2]);

            if (x == 0 || y == 0 || len == 0) { cnt = 0; } // exit

            while (cnt == 1) // draw squares as long as user want too...
            {
                if (x + len - 1 > arr.GetLength(0) || y + len - 1 > arr.GetLength(1))
                {
                    Console.WriteLine("Out of area size! try again");
                }
                else
                {
                    drawSqrt(ref arr, x, y, len); // function call
                }

                Console.Write("Insert coordinates (separate x, y and side length values with space): ");
                str = Console.ReadLine();
                if (str == "" || str == "0") { cnt = 0; }
                else { nums = str.Split(','); }

                x = int.Parse(nums[0]);
                y = int.Parse(nums[1]);
                len = int.Parse(nums[2]);

                if (x == 0 || y == 0) { cnt = 0; } // end loop
            }

            printMatrix(ref arr); // print the result on screen

            Console.ReadLine(); // show window
        }


        // reset the array + fill it with spaces -> user selected size
        static void matrixInit(ref char[,] arr, int w = 20, int h = 10)
        {
            int i, j; // counters

            for (i = 0; i < h; i++)
            {
                for (j = 0; j < w; j++)
                {
                    arr[j, i] = '+'; // initialize array
                }
            }
        }


        // draw square at selected pos + random color for each sqaure
        static void drawSqrt(ref char[,] arr, int x, int y, int len)
        {
            int i, j; // counters
            x--; y--; // offset coordinates

            // draw square
            for (i = x; i <= x + len - 1; i++)
            {
                for (j = y; j <= y + len - 1; j++)
                {
                    if (j == y || j == y + len - 1 || i == x || i == x + len - 1)
                    {
                        arr[j, i] = '*'; // square boreder style
                    }
                }
            }
        }


        // peint the finished matrix on screen 
        static void printMatrix(ref char[,] arr)
        {
            int i, j; // counters

            Console.Clear(); // clear screen

            // print array
            for (i = 0; i < arr.GetLength(1); i++)
            {
                for (j = 0; j < arr.GetLength(0); j++)
                {
                    Console.Write(arr[j, i]);
                }
                Console.WriteLine();
            }
        }

    }
}
