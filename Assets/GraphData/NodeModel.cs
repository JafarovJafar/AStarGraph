using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shafir.GraphData
{
    public class NodeModel
    {
        public event Action Updated;

        public ulong Id => _id;
        public Vector3 Position => _position;
        public IReadOnlyDictionary<ulong, EdgeModel> Edges => _edges;

        private ulong _id;
        private Vector3 _position;
        private Dictionary<ulong, EdgeModel> _edges = new();

        public NodeModel(ulong id, Vector3 position)
        {
            _id = id;
            _position = position;
        }

        public void AddEdge(EdgeModel edge)
        {
            _edges.Add(edge.Id, edge);
            Updated?.Invoke();
        }

        public void RemoveEdge(ulong edgeId)
        {
            _edges.Remove(edgeId);
            Updated?.Invoke();
        }
    }
}