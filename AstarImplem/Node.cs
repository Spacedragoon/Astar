using System.Collections.Generic;

namespace AstarImplem
{
    public struct Node
    {
        public int X;
        public int Y;
        public int Cost;
        public int Heuristic;
        public bool IsWall;

        public List<Node> PreviousNodes;


        public Node(int x, int y, int c = 0, int h = 0, bool isWall = false)
        {
            X = x;
            Y = y;
            Cost = c;
            Heuristic = h;
            IsWall = isWall;
            PreviousNodes = new List<Node>();
        }

        public string GetString()
        {
            return $"{{ X: {X}, Y: {Y}  => C: {Cost}, H: {Heuristic}, W: {IsWall}}}";
        }
    }
}
