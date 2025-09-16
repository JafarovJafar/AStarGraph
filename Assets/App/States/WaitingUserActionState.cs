using Shafir.FSM;
using Shafir.GraphViews;
using UnityEngine;

namespace Shafir.App
{
    /// <summary>
    /// Ожидание действий пользователя
    /// </summary>
    public class WaitingUserActionState : IState
    {
        private AppContext _appContext;

        private bool _startNodeSelected;
        private ulong _startNodeId;
        private bool _endNodeSelected;
        private ulong _endNodeId;

        public WaitingUserActionState(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Enter()
        {
            _appContext.MainWindow.Show();
            _appContext.MainWindow.StartClicked += OnStartClicked;
            _appContext.UserInput.LeftMouseButtonClicked += OnLeftMouseButtonClicked;

            _startNodeSelected = false;
            _endNodeSelected = false;
        }

        public void Exit()
        {
            _appContext.MainWindow.StartClicked -= OnStartClicked;
            _appContext.MainWindow.Hide();
            _appContext.UserInput.LeftMouseButtonClicked -= OnLeftMouseButtonClicked;
        }

        private void OnStartClicked()
        {
            if (_startNodeSelected == false || _endNodeSelected == false)
            {
                Debug.LogError("Ноды не выбраны");
                return;
            }

            _appContext.StartNodeId = _startNodeId;
            _appContext.EndNodeId = _endNodeId;
            _appContext.AppStateMachine.ChangeState(_appContext.SearchingPathState);
        }

        private void OnLeftMouseButtonClicked()
        {
            var camera = _appContext.MainCamera.Camera;
            var ray = camera.ScreenPointToRay(_appContext.UserInput.MousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit) == false)
                return;

            if (hit.transform.TryGetComponent(out NodeView clickedNodeView) == false)
                return;

            if (_startNodeSelected == false)
            {
                _startNodeSelected = true;
                _startNodeId = clickedNodeView.Id;
                return;
            }

            if (_endNodeSelected == false)
            {
                _endNodeSelected = true;
                _endNodeId = clickedNodeView.Id;
                return;
            }

            _startNodeSelected = true;
            _endNodeSelected = false;
            _startNodeId = clickedNodeView.Id;
        }
    }
}