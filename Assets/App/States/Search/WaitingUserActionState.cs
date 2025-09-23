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

        private bool _startNodeSelected;
        private ulong _startNodeId;

        public WaitingUserActionState(AppContext appContext, SearchContext searchContext)
        {
            _appContext = appContext;
            _searchContext = searchContext;
        }

        public void Enter()
        {
            _appContext.UserInput.LeftMouseButtonClicked += OnLeftMouseButtonClicked;

            _startNodeSelected = false;
        }

        public void Exit()
        {
            _appContext.UserInput.LeftMouseButtonClicked -= OnLeftMouseButtonClicked;

            if (_startNodeSelected == true)
            {
                _appContext.GraphView.Nodes[_startNodeId].ResetOutlineColor();
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

            clickedNodeView.SetOutlineColor(Color.green);

            if (_startNodeSelected == false)
            {
                _startNodeSelected = true;
                _startNodeId = clickedNodeView.Id;
                return;
            }

            _searchContext.StartNodeId = _startNodeId;
            _searchContext.EndNodeId = clickedNodeView.Id;

            SearchStartRequested?.Invoke();
        }
    }
}