using System.Collections.Generic;
using Shafir.MonoPool;
using UnityEngine;

namespace Shafir.GraphViews
{
    /// <summary>
    /// Вью для вершины графа
    /// </summary>
    public class NodeView : MonoBehaviour, IPoolable
    {
        public bool IsActive => gameObject.activeSelf;
        public Vector3 Position => transform.position;
        public IReadOnlyList<EdgeView> Edges => _edges;

        private List<EdgeView> _edges = new();

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void AddEdge(EdgeView edge)
        {
            _edges.Add(edge);
        }

        public void RemoveEdge(EdgeView edge)
        {
            _edges.Remove(edge);
        }

        public void DeActivate()
        {
            gameObject.SetActive(false);
            _edges.Clear();
        }
    }
}