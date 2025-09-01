namespace Shafir.FindLogics
{
    public class Edge
    {
        public readonly ulong StartNodeId;
        public readonly ulong EndNodeId;
        public readonly bool IsTwoDirectional;

        public Edge(ulong startNodeId, ulong endNodeId, bool isTwoDirectional)
        {
            StartNodeId = startNodeId;
            EndNodeId = endNodeId;
            IsTwoDirectional = isTwoDirectional;
        }
    }
}