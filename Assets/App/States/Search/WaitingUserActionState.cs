using System;
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
        public event Action SearchStartRequested;

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
            _appContext.UserInput.LeftMouseButtonClicked += OnLeftMouseButtonClicked;

            _startNodeSelected = false;
            _endNodeSelected = false;
        }

        public void Exit()
        {
            _appContext.UserInput.LeftMouseButtonClicked -= OnLeftMouseButtonClicked;

            if (_startNodeSelected == true)
            {
                _appContext.GraphView.Nodes[_startNodeId].ResetOutlineColor();
            }

            if (_endNodeSelected == true)
            {
                _appContext.GraphView.Nodes[_endNodeId].ResetOutlineColor();
            }
        }

        private void OnLeftMouseButtonClicked()
        {
            var camera = _appContext.MainCamera.Camera;
            var ray = camera.ScreenPointToRay(_appContext.UserInput.MousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit) == false)
                return;

            if (hit.transform.TryGetComponent(out NodeView clickedNodeView) == false)
                return;

            if (_startNodeSelected == false && _endNodeSelected == false)
            {
                _appContext.GraphView.Nodes[_startNodeId].ResetOutlineColor();
                _appContext.GraphView.Nodes[_endNodeId].ResetOutlineColor();
            }

            clickedNodeView.SetOutlineColor(Color.green);

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

                _appContext.StartNodeId = _startNodeId;
                _appContext.EndNodeId = _endNodeId;
                SearchStartRequested?.Invoke();
                return;
            }

            _appContext.GraphView.Nodes[_startNodeId].ResetOutlineColor();
            _appContext.GraphView.Nodes[_endNodeId].ResetOutlineColor();

            _startNodeSelected = true;
            _endNodeSelected = false;
            _startNodeId = clickedNodeView.Id;
        }
    }
}