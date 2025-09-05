using System.Collections.Generic;

namespace Shafir.FindLogics
{
    /// <summary>
    /// Вершина графа
    /// </summary>
    public class Node
    {
        public readonly ulong Id;
        public IReadOnlyList<Edge> Edges => _edges;
        public float Cost => _cost;
        public Node PreviousNode => _previousNode;

        private List<Edge> _edges = new();
        private float _cost;
        private Node _previousNode;

        public Node(ulong id)
        {
            Id = id;
        }

        public void AddEdge(Edge edge)
        {
            _edges.Add(edge);
        }

        public void SetCost(float cost)
        {
            _cost = cost;
        }

        public void SetPreviousNode(Node node)
        {
            _previousNode = node;
        }

        public void ClearPreviousNode()
        {
            _previousNode = null;
        }
    }
}