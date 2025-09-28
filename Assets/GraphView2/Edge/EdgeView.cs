using Shafir.MonoPool;
using UnityEngine;

namespace Shafir.GraphViews
{
    /// <summary>
    /// Вью для ребра графа
    /// </summary>
    public class EdgeView : EntityView, IPoolable
    {
        public bool IsActive => gameObject.activeSelf;

        public ulong Id => _model.Id;

        [SerializeField] private BoxCollider clickCollider;
        [SerializeField] private LineRenderer lineRenderer;

        private Vector3[] _linePoints;

        private bool _isInitialized;
        private EdgeModel _model;

        public void Activate()
        {
            gameObject.SetActive(true);
            TryInitialize();
        }

        public void DeActivate()
        {
            gameObject.SetActive(false);
            _model = null;
        }

        public void SetModel(EdgeModel edgeModel)
        {
            _model = edgeModel;
            Redraw();
        }

        private void Redraw()
        {
            var startNode = _model.StartNode;
            var endNode = _model.EndNode;
            var position = (startNode.Position + endNode.Position) / 2f;
            var rotation = Quaternion.LookRotation(endNode.Position - startNode.Position, Vector3.up);
            var length = Vector3.Distance(startNode.Position, endNode.Position);
            var size = clickCollider.size;
            size.x = lineRenderer.endWidth;
            size.y = lineRenderer.endWidth;
            size.z = length;
            clickCollider.transform.position = position;
            clickCollider.transform.rotation = rotation;
            clickCollider.size = size;

            _linePoints[0] = startNode.Position;
            _linePoints[1] = endNode.Position;
            lineRenderer.SetPositions(_linePoints);
        }

        private void TryInitialize()
        {
            if (_isInitialized == true)
                return;

            _linePoints = new Vector3[2];

            _isInitialized = true;
        }
    }
}