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

        private readonly AppContext _appContext;
        private readonly SearchContext _searchContext;

        public SearchingPathState(AppContext appContext, SearchContext searchContext)
        {
            _appContext = appContext;
            _searchContext = searchContext;
        }

        public void Enter()
        {
            _appContext.LoadingWindow.Show();

            var searchModel = GetFindGraph(_appContext.GraphView.Model);
            var startNodeId = _searchContext.StartNodeId;
            var endNodeId = _searchContext.EndNodeId;
            _appContext.FindLogic.Find(searchModel, startNodeId, endNodeId, OnSearchFinished);
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