namespace Shafir.GraphData
{
    public class EdgeModel
    {
        public ulong Id => _id;
        public float Cost => _cost;
        public NodeModel StartNode => _startNode;
        public NodeModel EndNode => _endNode;

        private ulong _id;
        private float _cost;
        private NodeModel _startNode;
        private NodeModel _endNode;

        public EdgeModel(ulong id, float cost, NodeModel startNode, NodeModel endNode)
        {
            _id = id;
            _cost = cost;
            _startNode = startNode;
            _endNode = endNode;
        }
    }
}