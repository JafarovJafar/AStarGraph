using System.Collections.Generic;

namespace Shafir.FindLogics
{
    /// <summary>
    /// Граф для алгоритма поиска путей
    /// </summary>
    public class SearchGraph
    {
        public IReadOnlyDictionary<ulong, SearchNode> Nodes => _nodes;
        public IReadOnlyList<SearchEdge> Edges => _edges;

        private Dictionary<ulong, SearchNode> _nodes = new();
        private List<SearchEdge> _edges = new();

        public void AddNode(ulong id)
        {
            if (_nodes.ContainsKey(id))
                return;

            var node = new SearchNode(id);
            _nodes[id] = node;
        }

        public void AddEdge(ulong id, ulong from, ulong to, float cost)
        {
            AddNode(from);
            AddNode(to);

            var startNode = _nodes[from];
            var endNode = _nodes[to];

            var edge = new SearchEdge(id, startNode, endNode, cost);
            startNode.AddEdge(edge);
            endNode.AddEdge(edge);
        }
    }
}