using System.Collections.Generic;
using Shafir.MonoPool;
using TMPro;
using UnityEngine;

namespace Shafir.GraphViews
{
    /// <summary>
    /// Вью для вершины графа
    /// </summary>
    public class NodeView : EntityView, IPoolable
    {
        public bool IsActive => gameObject.activeSelf;
        public Vector3 Position => transform.position;
        public IReadOnlyList<EdgeView> Edges => _edges;
        public ulong Id => _id;

        [SerializeField] private TextMeshPro text;
        [SerializeField] private MeshRenderer renderer;
        [SerializeField] private Color defaultOutlineColor;

        private ulong _id;
        private List<EdgeView> _edges = new();

        private static readonly int BorderColorProperty = Shader.PropertyToID("_BorderColor");

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void SetName(string name)
        {
            gameObject.name = name;
        }

        public void SetId(ulong id)
        {
            _id = id;
            text.text = id.ToString();
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetOutlineColor(Color color)
        {
            renderer.material.SetColor(BorderColorProperty, color);
        }

        public void ResetOutlineColor()
        {
            SetOutlineColor(defaultOutlineColor);
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