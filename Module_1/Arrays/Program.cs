using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            array[0] = 34;
            array[5] = 56;
            foreach(int x in array)
            {
                Console.WriteLine(x);
            }

            int[,] matrix = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            Console.WriteLine(matrix[1,1]);

            int[,,] kubus = new int[3, 3, 3];


            var multi = new int[5, 5, 6, 7, 9];

            int[][] jagged = new int[5][];
            jagged[0] = new int[5];
            jagged[1] = new int[10];


        }
    }
}
