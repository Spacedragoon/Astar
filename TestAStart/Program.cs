using AstarImplem;
using System;

namespace TestAStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph(10, 10);

            graph.MakeAWall(0, 2, 8, 2);
            var a = graph.GetShortestPath(1, 1, 5, 5);

            foreach(var n in a)
            {
                Console.WriteLine(n.GetString());
            }

            Console.ReadKey(true);
        }




    }
}
