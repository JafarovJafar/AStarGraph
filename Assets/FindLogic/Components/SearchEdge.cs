namespace Shafir.FindLogics
{
    public class SearchEdge
    {
        public readonly ulong Id;
        public readonly SearchNode StartNode;
        public readonly SearchNode EndNode;
        public readonly float Cost;

        public SearchEdge(ulong id, SearchNode startNode, SearchNode endNode, float cost)
        {
            Id = id;
            StartNode = startNode;
            EndNode = endNode;
            Cost = cost;
        }
    }
}