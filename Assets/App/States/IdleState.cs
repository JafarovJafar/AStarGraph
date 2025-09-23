using System;
using Shafir.FSM;

namespace Shafir.App
{
    public class IdleState : IState
    {
        public event Action SearchModeRequested;
        public event Action ConstructorRequested;

        private AppContext _appContext;

        public IdleState(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Enter()
        {
            _appContext.MainWindow.Show();
            _appContext.MainWindow.SearchModeClicked += OnSearchModeClicked;
            _appContext.MainWindow.ConstructorModeClicked += OnConstructorModeClicked;
        }

        public void Exit()
        {
            _appContext.MainWindow.SearchModeClicked -= OnSearchModeClicked;
            _appContext.MainWindow.Hide();
        }

        private void OnSearchModeClicked()
        {
            SearchModeRequested?.Invoke();
        }

        private void OnConstructorModeClicked()
        {
            ConstructorRequested?.Invoke();
        }
    }
}