using System.Collections.Generic;
using Shafir.MonoPool;
using UnityEngine;

namespace Shafir.GraphViews
{
    /// <summary>
    /// Вью графа
    /// </summary>
    public class GraphView : MonoBehaviour
    {
        public GraphModel Model => _currentModel;

        public IReadOnlyDictionary<ulong, NodeView> Nodes => _nodeViews;
        public IReadOnlyDictionary<ulong, EdgeView> Edges => _edgeViews;

        [SerializeField] private NodeView nodeViewPrefab;
        [SerializeField] private EdgeView edgeViewPrefab;

        [SerializeField] private Transform nodesContainer;
        [SerializeField] private Transform edgesContainer;

        private GraphModel _currentModel;

        private Dictionary<ulong, NodeView> _nodeViews = new();
        private Dictionary<ulong, EdgeView> _edgeViews = new();

        public void SetModel(GraphModel model)
        {
            if (_currentModel != null)
            {
                _currentModel.NodeAdded -= OnNodeAdded;
                _currentModel.NodeRemoved -= OnNodeRemoved;
                _currentModel.EdgeAdded -= OnEdgeAdded;
                _currentModel.EdgeRemoved -= OnEdgeRemoved;

                foreach (var edgeView in _edgeViews.Values)
                {
                    ShafirMonoPool.Return(edgeView);
                }

                _edgeViews.Clear();

                foreach (var nodeView in _nodeViews.Values)
                {
                    ShafirMonoPool.Return(nodeView);
                }

                _nodeViews.Clear();
                _edgeViews.Clear();
            }

            _currentModel = model;

            var modelNodes = model.Nodes.Values;
            foreach (var modelNode in modelNodes)
            {
                CreateNode(modelNode);
            }

            var modelEdges = model.Edges.Values;
            foreach (var modelEdge in modelEdges)
            {
                CreateEdge(modelEdge);
            }

            _currentModel.NodeAdded += OnNodeAdded;
            _currentModel.NodeRemoved += OnNodeRemoved;
            _currentModel.EdgeAdded += OnEdgeAdded;
            _currentModel.EdgeRemoved += OnEdgeRemoved;
        }

        private void OnNodeAdded(ulong nodeId)
        {
            var nodeModel = _currentModel.Nodes[nodeId];
            CreateNode(nodeModel);
        }

        private void OnNodeRemoved(ulong nodeId)
        {
            var view = _nodeViews[nodeId];

            ShafirMonoPool.Return(view);
            _nodeViews.Remove(nodeId);
        }

        private void OnEdgeAdded(ulong edgeId)
        {
            var edgeModel = _currentModel.Edges[edgeId];
            CreateEdge(edgeModel);
        }

        private void OnEdgeRemoved(ulong edgeId)
        {
            var edge = _edgeViews[edgeId];
            ShafirMonoPool.Return(edge);
            _edgeViews.Remove(edgeId);
        }

        private void CreateNode(NodeModel nodeModel)
        {
            var nodeView = ShafirMonoPool.Get(nodeViewPrefab, nodesContainer);
            nodeView.SetModel(nodeModel);
            _nodeViews.Add(nodeModel.Id, nodeView);
        }

        private void CreateEdge(EdgeModel edgeModel)
        {
            var edgeView = ShafirMonoPool.Get(edgeViewPrefab, edgesContainer);
            edgeView.SetModel(edgeModel);
            _edgeViews.Add(edgeModel.Id, edgeView);
        }
    }
}