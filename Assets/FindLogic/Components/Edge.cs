namespace Shafir.FindLogics
{
    public class Edge
    {
        public readonly Node StartNode;
        public readonly Node EndNode;
        public readonly float Cost;

        public Edge(Node startNode, Node endNode, float cost)
        {
            StartNode = startNode;
            EndNode = endNode;
            Cost = cost;
        }
    }
}