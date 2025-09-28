using System;
using Cysharp.Threading.Tasks;
using Shafir.FindLogics;
using Shafir.FSM;
using Shafir.GraphData;

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
            DoSearch().Forget();
        }

        private async UniTaskVoid DoSearch()
        {
            var searchModel = GetFindGraph(_appContext.GraphView.Model);
            var startNodeId = _searchContext.StartNodeId;
            var endNodeId = _searchContext.EndNodeId;
            var findLogic = _appContext.FindLogic;

            await UniTask.RunOnThreadPool(() => findLogic.Find(searchModel, startNodeId, endNodeId));
            await UniTask.SwitchToMainThread();
            Finished?.Invoke();
        }

        private SearchGraph GetFindGraph(GraphModel model)
        {
            var result = new SearchGraph();

            foreach (var node in model.Nodes.Values)
            {
                result.AddNode(node.Id);
            }

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