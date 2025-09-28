using System;
using Shafir.FSM;

namespace Shafir.App
{
    public class SearchState : IState
    {
        public event Action ExitRequested;

        private readonly AppContext _appContext;
        private readonly SearchContext _searchContext;

        private WaitingUserActionState _waitingUserActionState;
        private SearchingPathState _searchingPathState;
        private PathSearchFinishedState _pathSearchFinishedState;
        private SimpleStateMachine _stateMachine;

        private const string LegendText = "Поиск пути";

        public SearchState(AppContext appContext)
        {
            _appContext = appContext;

            _searchContext = new SearchContext();

            _waitingUserActionState = new WaitingUserActionState(_appContext, _searchContext);
            _searchingPathState = new SearchingPathState(_appContext, _searchContext);
            _pathSearchFinishedState = new PathSearchFinishedState(_appContext); // todo переименовать класс
            _stateMachine = new SimpleStateMachine();
        }

        public void Enter()
        {
            _waitingUserActionState.SearchStartRequested += OnSearchStartRequested;
            _searchingPathState.Finished += OnSearchFinished;
            _pathSearchFinishedState.PathDrawn += OnPathDrawn;

            _appContext.UserInput.CancelButtonPressed += OnCancelPressed;

            _stateMachine.ChangeState(_waitingUserActionState);

            _appContext.LegendWindow.Show();
            _appContext.LegendWindow.SetLegend(LegendText);

            _appContext.OutputWindow.Show();
            _appContext.OutputWindow.Clear();
        }

        public void Exit()
        {
            _waitingUserActionState.SearchStartRequested -= OnSearchStartRequested;
            _searchingPathState.Finished -= OnSearchFinished;
            _pathSearchFinishedState.PathDrawn -= OnPathDrawn;

            _appContext.UserInput.CancelButtonPressed -= OnCancelPressed;

            _appContext.PathDrawer.Clear();

            _appContext.LegendWindow.Hide();
            _appContext.OutputWindow.Hide();

            _stateMachine.CurrentState.Exit();
        }

        private void OnSearchStartRequested()
        {
            _stateMachine.ChangeState(_searchingPathState);
        }

        private void OnSearchFinished()
        {
            _stateMachine.ChangeState(_pathSearchFinishedState);
        }

        private void OnPathDrawn()
        {
            _stateMachine.ChangeState(_waitingUserActionState);
        }

        private void OnCancelPressed()
        {
            ExitRequested?.Invoke();
        }
    }
}