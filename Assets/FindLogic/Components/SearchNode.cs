using System.Collections.Generic;

namespace Shafir.FindLogics
{
    /// <summary>
    /// Вершина графа
    /// </summary>
    public class SearchNode
    {
        public readonly ulong Id;
        public IReadOnlyList<SearchEdge> Edges => _edges;
        public float Cost => _cost;
        public SearchNode PreviousNode => _previousSearchNode;

        private List<SearchEdge> _edges = new();
        private float _cost;
        private SearchNode _previousSearchNode;

        public SearchNode(ulong id)
        {
            Id = id;
        }

        public void AddEdge(SearchEdge searchEdge)
        {
            _edges.Add(searchEdge);
        }

        public void SetCost(float cost)
        {
            _cost = cost;
        }

        public void SetPreviousNode(SearchNode searchNode)
        {
            _previousSearchNode = searchNode;
        }

        public void ClearPreviousNode()
        {
            _previousSearchNode = null;
        }
    }
}