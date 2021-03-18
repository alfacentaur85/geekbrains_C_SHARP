using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {

            //testing

            //adjacency matrix
            Console.WriteLine("Adjacency matrix:");
            for (int i = 0; i < GraphClass.adjMatrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < GraphClass.adjMatrix.GetLength(1); j++)
                {
                    Console.Write($"{ GraphClass.adjMatrix[ i , j ] }|");
                }
            }
            //BFS
            Console.Write("\n\n[BFS]\n");
            Console.WriteLine("Expected: 0 -> 1 -> 5 -> 2 -> 3 -> 4 -> 7 -> 6 -> 10 -> 9 -> 8 -> 16 -> 11 -> 15 -> 12 -> 13 -> 14 -> 19 -> 17 -> 18");
            Console.Write("Result: ");
            GraphClass.BFS(0);

            //DFS
            Console.Write("\n\n[DFS]\n");
            Console.WriteLine("Expected: 0 -> 1 -> 2 -> 3 -> 5 -> 4 -> 10 -> 16 -> 14 -> 12 -> 8 -> 6 -> 7 -> 9 -> 11 -> 15 -> 17 -> 18 -> 19 -> 13");
            Console.Write("Result: ");
            GraphClass.DFS(0);

            Console.WriteLine();



        }
    }
}
