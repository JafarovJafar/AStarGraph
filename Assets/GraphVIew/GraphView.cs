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
                foreach (var edgeView in _edgeViews.Values)
                {
                    var startNode = edgeView.StartNode;
                    var endNode = edgeView.EndNode;

                    startNode.RemoveEdge(edgeView);
                    endNode.RemoveEdge(edgeView);

                    ShafirMonoPool.Return(edgeView);
                }

                _edgeViews.Clear();

                foreach (var nodeView in _nodeViews.Values)
                {
                    ShafirMonoPool.Return(nodeView);
                }

                _nodeViews.Clear();
            }

            _currentModel = model;
            
            var modelNodes = model.Nodes.Values;
            foreach (var modelNode in modelNodes)
            {
                var nodeView = ShafirMonoPool.Get(nodeViewPrefab, nodesContainer);
                // по хорошему надо передавать модель во вью и давать ему подписаться
                nodeView.SetId(modelNode.Id);
                nodeView.SetPosition(modelNode.Position);
                _nodeViews.Add(modelNode.Id, nodeView);
            }

            var modelEdges = model.Edges.Values;
            foreach (var modelEdge in modelEdges)
            {
                var isStartNodeFound = _nodeViews.TryGetValue(modelEdge.StartNode.Id, out var startNodeView);
                var isEndNodeFound = _nodeViews.TryGetValue(modelEdge.EndNode.Id, out var endNodeView);

                if (isStartNodeFound == false || isEndNodeFound == false)
                {
                    Debug.LogError($"Одна из вершин ребра {modelEdge.Id} не найдена. Пропускаю создание вью ребра");
                    continue;
                }

                var edgeView = ShafirMonoPool.Get(edgeViewPrefab, edgesContainer);
                edgeView.SetNodes(startNodeView, endNodeView);
            }
        }
    }
}