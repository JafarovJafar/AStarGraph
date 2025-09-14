using Shafir.FindLogics;
using Shafir.FSM;
using Shafir.GraphViews;

namespace Shafir.App
{
    /// <summary>
    /// Ожидание действий пользователя
    /// </summary>
    public class WaitingUserActionState : IState
    {
        private AppContext _appContext;

        public WaitingUserActionState(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Enter()
        {
            _appContext.MainWindow.Show();
            _appContext.MainWindow.StartClicked += OnStartClicked;
        }

        public void Exit()
        {
            _appContext.MainWindow.StartClicked -= OnStartClicked;
            _appContext.MainWindow.Hide();
        }

        private void OnStartClicked()
        {
            _appContext.MainWindow.Hide();
            _appContext.LoadingWindow.Show();

            var searchModel = GetFindGraph(_appContext.GraphView.Model);
            _appContext.FindLogic.Find(searchModel, 0, 3, output =>
            {
                _appContext.MainWindow.Show();
                _appContext.MainWindow.SetTime(output.FindDuration);
                _appContext.LoadingWindow.Hide();
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
    }
}