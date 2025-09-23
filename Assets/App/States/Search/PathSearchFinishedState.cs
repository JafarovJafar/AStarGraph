using System;
using System.Collections.Generic;
using Shafir.FSM;
using UnityEngine;

namespace Shafir.App
{
    /// <summary>
    /// Поиск пути завершен
    /// </summary>
    public class PathSearchFinishedState : IState
    {
        public event Action PathDrawn;

        private AppContext _appContext;

        public PathSearchFinishedState(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Enter()
        {
            var output = _appContext.FindLogic.Output;

            var nodesPositions = new List<Vector3>();
            var nodesIds = output.FoundPath;
            foreach (var nodeId in nodesIds)
            {
                var nodePosition = _appContext.GraphView.Model.Nodes[nodeId].Position;
                nodesPositions.Add(nodePosition);
            }

            _appContext.PathDrawer.SetPoints(nodesPositions);

            var duration = output.FindDuration;
            _appContext.OutputWindow.SetTime(duration);

            PathDrawn?.Invoke();
        }

        public void Exit()
        {

        }
    }
}