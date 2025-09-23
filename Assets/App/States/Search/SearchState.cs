using System;
using Shafir.FSM;

namespace Shafir.App
{
    public class SearchState : IState
    {
        public event Action ExitRequested;

        private readonly AppContext _appContext;

        public SearchState(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Enter()
        {
            _appContext.UserInput.CancelButtonPressed += OnCancelPressed;
        }

        public void Exit()
        {
            _appContext.UserInput.CancelButtonPressed -= OnCancelPressed;
        }

        private void OnCancelPressed()
        {
            ExitRequested?.Invoke();
        }
    }
}