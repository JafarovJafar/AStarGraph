using Shafir.FSM;
using Shafir.UI;
using UnityEngine;

namespace Shafir.App
{
    public class CreateNodesState : IState
    {
        private AppContext _appContext;

        private Window _openedWindow;

        private const string LegendText = "Добавление вершин";

        private Plane _raycastPlane;

        private ulong _maxNodeId;

        public CreateNodesState(AppContext appContext)
        {
            _appContext = appContext;

            _raycastPlane = new Plane(Vector3.zero, Vector3.up, Vector3.right);
        }

        public void Enter()
        {
            _appContext.UserInput.LeftMouseButtonClicked += OnLeftMouseButtonClicked;

            _appContext.LegendWindow.Show();
            _appContext.LegendWindow.SetLegend(LegendText);

            _maxNodeId = ulong.MinValue;

            var nodes = _appContext.GraphView.Model.Nodes;
            foreach (var node in nodes.Values)
            {
                if (node.Id > _maxNodeId)
                    _maxNodeId = node.Id;
            }

            _maxNodeId++;
        }

        public void Exit()
        {
            _appContext.UserInput.LeftMouseButtonClicked -= OnLeftMouseButtonClicked;

            _appContext.LegendWindow.Hide();
        }

        private void OnLeftMouseButtonClicked()
        {
            var camera = _appContext.MainCamera.Camera;
            var ray = camera.ScreenPointToRay(_appContext.UserInput.MousePosition);

            if (_raycastPlane.Raycast(ray, out var distance) == false)
                return;

            var clickPos = ray.GetPoint(distance);

            _appContext.GraphView.Model.AddNode(_maxNodeId, clickPos);
            _maxNodeId++;
        }
    }
}