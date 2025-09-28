using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shafir.GraphData
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
        public event Action<ulong> NodeAdded;
        public event Action<ulong> NodeRemoved;

        public event Action<ulong> EdgeAdded;
        public event Action<ulong> EdgeRemoved;

        public IReadOnlyDictionary<ulong, NodeModel> Nodes => _nodes;
        public IReadOnlyDictionary<ulong, EdgeModel> Edges => _edges;

        private Dictionary<ulong, NodeModel> _nodes = new();
        private Dictionary<ulong, EdgeModel> _edges = new();

        public void AddNode(ulong nodeId, Vector3 nodePosition)
        {
            var nodeModel = new NodeModel(nodeId, nodePosition);
            _nodes.Add(nodeId, nodeModel);

            NodeAdded?.Invoke(nodeId);
        }

        public void RemoveNode(ulong nodeId)
        {
            if (_nodes.TryGetValue(nodeId, out var node) == false)
                return;

            var edges = new List<ulong>(node.Edges.Keys);
            foreach (var edgeId in edges)
            {
                RemoveEdge(edgeId);
            }

            _nodes.Remove(nodeId);

            NodeRemoved?.Invoke(nodeId);
        }

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

            EdgeAdded?.Invoke(edgeId);
        }

        public void RemoveEdge(ulong edgeId)
        {
            var edge = _edges[edgeId];
            edge.StartNode.RemoveEdge(edgeId);
            edge.EndNode.RemoveEdge(edgeId);
            _edges.Remove(edgeId);

            EdgeRemoved?.Invoke(edgeId);
        }

        private NodeModel CreateOrPickNode(ulong id, Vector3 pos)
        {
            if (_nodes.ContainsKey(id) == true)
                return _nodes[id];

            var newNode = new NodeModel(id, pos);
            _nodes.Add(id, newNode);
            return newNode;
        }
    }
}