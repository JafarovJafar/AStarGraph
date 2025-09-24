using Shafir.FSM;
using Shafir.GraphViews;
using UnityEngine;

namespace Shafir.App
{
    public class DeleteEntitiesState : IState
    {
        private AppContext _appContext;

        private const string LegendText = "Удаление сущностей";

        private LayerMask _layerMask;

        public DeleteEntitiesState(AppContext appContext)
        {
            _appContext = appContext;
            _layerMask = LayerMask.GetMask("Node", "Edge");
        }

        public void Enter()
        {
            _appContext.UserInput.LeftMouseButtonClicked += OnLeftMouseButtonClicked;

            _appContext.LegendWindow.Show();
            _appContext.LegendWindow.SetLegend(LegendText);
        }

        public void Exit()
        {
            _appContext.UserInput.LeftMouseButtonClicked -= OnLeftMouseButtonClicked;

            _appContext.LegendWindow.Hide();
        }

        private void OnLeftMouseButtonClicked()
        {
            var camera = _appContext.MainCamera.Camera;
            var mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

            if (_appContext.Raycaster.TryRaycast(camera, mousePosition, out EntityView entityView) == false)
                return;

            switch (entityView)
            {
                case NodeView nodeView:
                    _appContext.GraphView.Model.RemoveNode(nodeView.Id);
                    return;
                case EdgeView edgeView:
                    _appContext.GraphView.Model.RemoveEdge(edgeView.Id);
                    return;
            }
        }
    }
}