namespace AstarImplem
{
    public static class NodeExtension
    {
        public static int Compare(this Node n1, Node n2)
        {
            if (n1.Heuristic < n2.Heuristic)
                return 1;
            if (n1.Heuristic == n2.Heuristic)
                return 0;
            return -1;
        }

        public static int GetDistance2(this Node n1, Node n2)
        {
            return (n2.X - n1.X) * (n2.X - n1.X) + (n2.Y - n1.Y) * (n2.Y - n1.Y);
        }


        public static bool IsSame(this Node n1, Node n2)
        {
            return n1.X == n2.X && n1.Y == n2.Y;
        }
    }

}
