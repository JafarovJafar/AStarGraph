using Shafir.FSM;

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
            _appContext.AppStateMachine.ChangeState(_appContext.SearchingPathState);
        }
    }
}