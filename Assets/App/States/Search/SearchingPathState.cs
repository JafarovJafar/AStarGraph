using System;
using Shafir.FindLogics;
using Shafir.FSM;
using Shafir.GraphViews;

namespace Shafir.App
{
    /// <summary>
    /// Поиск пути
    /// </summary>
    public class SearchingPathState : IState
    {
        public event Action Finished;

        private AppContext _appContext;

        public SearchingPathState(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Enter()
        {
            _appContext.LoadingWindow.Show();

            var searchModel = GetFindGraph(_appContext.GraphView.Model);
            _appContext.FindLogic.Find(searchModel, _appContext.StartNodeId, _appContext.EndNodeId, OnSearchFinished);
        }

        private void OnSearchFinished(FindOutput findOutput)
        {
            Finished?.Invoke();
        }

        private Graph GetFindGraph(GraphModel model)
        {
            var result = new Graph();

            foreach (var edge in model.Edges.Values)
            {
                result.AddEdge(edge.Id, edge.StartNode.Id, edge.EndNode.Id, edge.Cost);
            }

            return result;
        }

        public void Exit()
        {
            _appContext.LoadingWindow.Hide();
        }
    }
}