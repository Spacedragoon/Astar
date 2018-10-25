using System;
using System.Collections.Generic;
using System.Linq;

namespace AstarImplem
{
    public class Graph
    {
        private Node[,] _board;
        public Graph(int x, int y)
        {
            _board = new Node[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    _board[i, j] = new Node(i, j);
                }
            }
        }

        public void MakeAWall(int x1, int y1, int x2 = 0, int y2 = 0)
        {
            if (x2 == 0 && y2 == 0)
            {
                _board[x1, y1].IsWall = true;
                return;
            }
            if (x1 == x2)
            {
                for (int i = y1; i <= y2; i++)
                {
                    _board[x1, i].IsWall = true;
                }
            }
            else if (y1 == y2)
            {
                for (int i = x1; i <= x2; i++)
                {
                    _board[i, y1].IsWall = true;
                }
            }
        }
        public int GetDistance(Node n1, Node n2)
        {
            return n1.GetDistance2(n2);
        }

        public List<Node> GetShortestPath(int x, int y, int x2, int y2)
        {
            return GetShortestPath(_board[x, y], _board[x2, y2]);
        }


        public List<Node> GetShortestPath(Node start, Node end)
        {
            var openList = new List<Node>();
            var closedList = new List<Node>();
            openList.Add(start);

            while (openList.Count > 0)
            {
                var u = openList[0];
                openList.RemoveAt(0);
                if (u.IsSame(end))
                {
                    Console.WriteLine("Finished");
                    closedList.Add(u);
                    return u.PreviousNodes;
                    //get path and Finish
                }
                var neighbours = GetNeighbours(_board, u);
                for (int i = 0; i < neighbours.Count ; i++)
                {
                    var n = neighbours[i];
                    n.Cost = u.Cost + 1;
                    if (!n.IsWall && closedList.Where(x => x.IsSame(n) && x.Cost <= n.Cost).Count() == 0 && openList.Where(x => x.IsSame(n) && x.Cost <= n.Cost).Count() == 0)
                    {
                        var list = new List<Node>();
                        n.Heuristic = n.Cost + n.GetDistance2(end);
                        list.AddRange(u.PreviousNodes);
                        list.Add(u);
                        n.PreviousNodes = list;
                        openList.Add(n);
                    }
                }
                closedList.Add(u);
                if (openList.Count > 1)
                {
                    openList = openList.OrderBy(n => n.Heuristic).ToList();
                }
            }

            Console.WriteLine("Failed");
            return closedList;
        }


        public List<Node> GetNeighbours(Node[,] graph, Node n)
        {
            var result = new List<Node>();
            int xmax = graph.GetLength(0);
            int ymax = graph.GetLength(1);

            for (int i = Math.Max(n.X - 1, 0); i <= n.X + 1 && i < xmax; i++)
            {
                for (int j = Math.Max(n.Y - 1, 0); j <= n.Y + 1 && j < ymax; j++)
                {
                    if(!n.IsWall)
                        result.Add(graph[i, j]);
                }
            }

            return result;
        }



    }




}
