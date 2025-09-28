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
        public ulong Id => _model.Id;

        [SerializeField] private TextMeshPro text;
        [SerializeField] private MeshRenderer bodyRenderer;
        [SerializeField] private Color defaultOutlineColor;

        private static readonly int BorderColorProperty = Shader.PropertyToID("_BorderColor");

        private NodeModel _model;

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void DeActivate()
        {
            gameObject.SetActive(false);
            ResetOutlineColor();
        }

        public void SetModel(NodeModel model)
        {
            if (_model != null)
            {
                _model.Updated -= OnModelUpdated;
            }

            _model = model;
            _model.Updated += OnModelUpdated;
            UpdateByModel();
        }

        public void SetOutlineColor(Color color)
        {
            bodyRenderer.material.SetColor(BorderColorProperty, color);
        }

        public void ResetOutlineColor()
        {
            SetOutlineColor(defaultOutlineColor);
        }

        private void OnModelUpdated()
        {
            UpdateByModel();
        }

        private void UpdateByModel()
        {
            gameObject.name = $"Node_{_model.Id}";
            text.text = _model.Id.ToString();
            transform.position = _model.Position;
        }
    }
}