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
        private AppContext _appContext;

        public SearchingPathState(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Enter()
        {
            _appContext.LoadingWindow.Show();

            var searchModel = GetFindGraph(_appContext.GraphView.Model);
            _appContext.FindLogic.Find(searchModel, 0, 3, output =>
            {
                _appContext.AppStateMachine.ChangeState(_appContext.PathSearchFinishedState);
            });
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