using Shafir.MonoPool;
using UnityEngine;

namespace Shafir.GraphViews
{
    /// <summary>
    /// Вью для ребра графа
    /// </summary>
    public class EdgeView : EntityView, IPoolable
    {
        public NodeView StartNode => _startNode;
        public NodeView EndNode => _endNode;

        public bool IsActive => gameObject.activeSelf;

        public ulong Id => _id;

        [SerializeField] private BoxCollider clickCollider;
        [SerializeField] private LineRenderer lineRenderer;

        private ulong _id;

        private NodeView _startNode;
        private NodeView _endNode;

        private Vector3[] _linePoints;

        private bool _isInitialized;

        public void SetId(ulong id)
        {
            _id = id;
        }

        public void SetNodes(NodeView startNode, NodeView endNode)
        {
            _startNode = startNode;
            _endNode = endNode;

            Redraw();
        }

        private void Redraw()
        {
            var position = (_startNode.Position + _endNode.Position) / 2f;
            var rotation = Quaternion.LookRotation(_endNode.Position - _startNode.Position, Vector3.up);
            var length = Vector3.Distance(_startNode.Position, _endNode.Position);
            var size = clickCollider.size;
            size.x = lineRenderer.endWidth;
            size.y = lineRenderer.endWidth;
            size.z = length;
            clickCollider.transform.position = position;
            clickCollider.transform.rotation = rotation;
            clickCollider.size = size;

            _linePoints[0] = _startNode.Position;
            _linePoints[1] = _endNode.Position;
            lineRenderer.SetPositions(_linePoints);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            TryInitialize();
        }

        public void DeActivate()
        {
            gameObject.SetActive(false);
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