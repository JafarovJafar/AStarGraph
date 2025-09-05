using Shafir.MonoPool;
using UnityEngine;

namespace Shafir.GraphViews
{
    /// <summary>
    /// Вью для ребра графа
    /// </summary>
    public class EdgeView : MonoBehaviour, IPoolable
    {
        public NodeView StartNode => _startNode;
        public NodeView EndNode => _endNode;

        public bool IsActive => gameObject.activeSelf;

        [SerializeField] private LineRenderer lineRenderer;

        private NodeView _startNode;
        private NodeView _endNode;

        private Vector3[] _linePoints;

        private bool _isInitialized;

        public void SetNodes(NodeView startNode, NodeView endNode)
        {
            _startNode = startNode;
            _endNode = endNode;

            Redraw();
        }

        private void Redraw()
        {
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