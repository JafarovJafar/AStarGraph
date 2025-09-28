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

        private readonly AppContext _appContext;
        private readonly SearchContext _searchContext;

        private bool _isStartNodeSelected;
        private ulong _startNodeId;
        private bool _isEndNodeSelected;
        private ulong _endNodeId;

        public WaitingUserActionState(AppContext appContext, SearchContext searchContext)
        {
            _appContext = appContext;
            _searchContext = searchContext;
        }

        public void Enter()
        {
            _appContext.UserInput.LeftMouseButtonClicked += OnLeftMouseButtonClicked;

            _isStartNodeSelected = false;
            _isEndNodeSelected = false;
        }

        public void Exit()
        {
            _appContext.UserInput.LeftMouseButtonClicked -= OnLeftMouseButtonClicked;

            if (_isStartNodeSelected == true)
            {
                _appContext.GraphView.Nodes[_startNodeId].ResetOutlineColor();
            }

            if (_isEndNodeSelected == true)
            {
                _appContext.GraphView.Nodes[_endNodeId].ResetOutlineColor();
            }
        }

        private void OnLeftMouseButtonClicked()
        {
            var camera = _appContext.MainCamera.Camera;
            var mousePosition = _appContext.UserInput.MousePosition;

            if (_appContext.Raycaster.TryRaycast(camera, mousePosition, out NodeView clickedNodeView) == false)
            {
                return;
            }

            clickedNodeView.SetOutlineColor(Color.green);

            if (_isStartNodeSelected == false)
            {
                _isStartNodeSelected = true;
                _startNodeId = clickedNodeView.Id;
                return;
            }

            _endNodeId = clickedNodeView.Id;

            _isEndNodeSelected = true;
            _searchContext.StartNodeId = _startNodeId;
            _searchContext.EndNodeId = _endNodeId;

            SearchStartRequested?.Invoke();
        }
    }
}