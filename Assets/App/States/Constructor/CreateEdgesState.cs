using Shafir.FSM;
using Shafir.GraphData;
using Shafir.GraphViews;
using UnityEngine;

namespace Shafir.App
{
    public class CreateEdgesState : IState
    {
        private AppContext _appContext;

        private const string LegendText = "Добавление ребер";

        private LayerMask _layerMask;

        private bool _wasFirstNodeClicked = false;
        private NodeModel _firstNode;

        private ulong _maxEdgeId;

        public CreateEdgesState(AppContext appContext)
        {
            _appContext = appContext;
            _layerMask = LayerMask.GetMask("Node");
        }

        public void Enter()
        {
            _wasFirstNodeClicked = false;

            _appContext.UserInput.LeftMouseButtonClicked += OnLeftMouseButtonClicked;

            _appContext.LegendWindow.Show();
            _appContext.LegendWindow.SetLegend(LegendText);

            _maxEdgeId = ulong.MinValue;
            var edges = _appContext.GraphView.Model.Edges.Values;

            foreach (var edge in edges)
            {
                if (edge.Id > _maxEdgeId)
                    _maxEdgeId = edge.Id;
            }

            _maxEdgeId++;
        }

        public void Exit()
        {
            _firstNode = null;

            _appContext.UserInput.LeftMouseButtonClicked -= OnLeftMouseButtonClicked;

            _appContext.LegendWindow.Hide();
        }

        private void OnLeftMouseButtonClicked()
        {
            var camera = _appContext.MainCamera.Camera;
            var mousePos = _appContext.UserInput.MousePosition;

            if (_appContext.Raycaster.TryRaycast(camera, mousePos, _layerMask, out NodeView clickedNodeView) == false)
                return;

            if (_wasFirstNodeClicked == false)
            {
                _wasFirstNodeClicked = true;
                _firstNode = _appContext.GraphView.Model.Nodes[clickedNodeView.Id];
                return;
            }

            var secondNodeId = clickedNodeView.Id;
            var edgeCost = Vector3.Distance(_firstNode.Position, clickedNodeView.Position);

            _appContext.GraphView.Model.AddEdge
            (
                _maxEdgeId, edgeCost,
                _firstNode.Id, _firstNode.Position,
                secondNodeId, clickedNodeView.Position
            );

            _maxEdgeId++;
            _wasFirstNodeClicked = false;
        }
    }
}