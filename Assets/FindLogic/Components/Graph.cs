using System.Collections.Generic;

namespace Shafir.FindLogics
{
    /// <summary>
    /// Граф для алгоритма поиска путей
    /// </summary>
    public class Graph
    {
        public IReadOnlyDictionary<ulong, Node> Nodes => _nodes;
        public IReadOnlyList<Edge> Edges => _edges;

        private Dictionary<ulong, Node> _nodes = new();
        private List<Edge> _edges = new();

        public void AddNode(ulong id)
        {
            if (_nodes.ContainsKey(id))
                return;

            var node = new Node(id);
            _nodes[id] = node;
        }

        public void AddEdge(ulong id, ulong from, ulong to, float cost)
        {
            AddNode(from);
            AddNode(to);

            var startNode = _nodes[from];
            var endNode = _nodes[to];

            var edge = new Edge(id, startNode, endNode, cost);
            startNode.AddEdge(edge);
            endNode.AddEdge(edge);
        }
    }
}