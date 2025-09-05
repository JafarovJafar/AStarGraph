namespace Shafir.FindLogics
{
    public class Edge
    {
        public readonly ulong Id;
        public readonly Node StartNode;
        public readonly Node EndNode;
        public readonly float Cost;

        public Edge(ulong id, Node startNode, Node endNode, float cost)
        {
            Id = id;
            StartNode = startNode;
            EndNode = endNode;
            Cost = cost;
        }
    }
}