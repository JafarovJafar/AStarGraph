using System.Collections.Generic;
using UnityEngine;

namespace Shafir.GraphViews
{
    /// <summary>
    /// Модель графа
    /// </summary>
    /// <remarks>
    /// Чтение данных - через свойства
    /// Изменение данных - через методы
    /// </remarks>
    public class GraphModel
    {
        public IReadOnlyDictionary<ulong, NodeModel> Nodes => _nodes;
        public IReadOnlyDictionary<ulong, EdgeModel> Edges => _edges;

        private Dictionary<ulong, NodeModel> _nodes = new();
        private Dictionary<ulong, EdgeModel> _edges = new();

        public void AddEdge
        (
            ulong edgeId, float edgeCost,
            ulong startNodeId, Vector3 startPos,
            ulong endNodeId, Vector3 endPos
        )
        {
            var startNode = CreateOrPickNode(startNodeId, startPos);
            var endNode = CreateOrPickNode(endNodeId, endPos);
            var newEdge = new EdgeModel(edgeId, edgeCost, startNode, endNode);
            startNode.AddEdge(newEdge);
            endNode.AddEdge(newEdge);
            _edges.Add(edgeId, newEdge);
        }

        public void RemoveEdge(ulong edgeId)
        {
            var edge = _edges[edgeId];
            RemoveEdgeFromNode(edge, edge.StartNode);
            RemoveEdgeFromNode(edge, edge.EndNode);
            _edges.Remove(edgeId);
        }

        private NodeModel CreateOrPickNode(ulong id, Vector3 pos)
        {
            if (_nodes.ContainsKey(id) == true)
                return _nodes[id];

            var newNode = new NodeModel(id, pos);
            _nodes.Add(id, newNode);
            return newNode;
        }

        private void RemoveEdgeFromNode(EdgeModel edge, NodeModel node)
        {
            node.RemoveEdge(edge);
            if (node.Edges.Count == 0)
                _nodes.Remove(node.Id);
        }
    }
}