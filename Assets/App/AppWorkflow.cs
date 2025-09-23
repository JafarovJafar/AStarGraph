namespace Shafir.App
{
    /// <summary>
    /// Логика работы приложения (схема переходов между состояниями)
    /// </summary>
    public class AppWorkflow
    {
        private readonly AppContext _appContext;

        public AppWorkflow(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Start()
        {
            _appContext.BootState.Finished += OnBootFinished;
            _appContext.IdleState.SearchModeRequested += OnSearchModeRequested;
            _appContext.IdleState.ConstructorRequested += OnConstructorModeRequested;
            _appContext.SearchState.ExitRequested += OnSearchExitRequested;
            _appContext.ConstructorState.ExitRequested += OnConstructorExitRequested;

            _appContext.AppStateMachine.ChangeState(_appContext.BootState);
        }

        public void Stop()
        {
            _appContext.AppStateMachine.CurrentState.Exit();

            _appContext.BootState.Finished -= OnBootFinished;
            _appContext.IdleState.SearchModeRequested -= OnSearchModeRequested;
            _appContext.IdleState.ConstructorRequested -= OnConstructorModeRequested;
            _appContext.SearchState.ExitRequested -= OnSearchExitRequested;
            _appContext.ConstructorState.ExitRequested -= OnConstructorExitRequested;
        }

        private void OnBootFinished()
        {
            _appContext.AppStateMachine.ChangeState(_appContext.IdleState);
        }

        private void OnSearchModeRequested()
        {
            _appContext.AppStateMachine.ChangeState(_appContext.SearchState);
        }

        private void OnSearchExitRequested()
        {
            _appContext.AppStateMachine.ChangeState(_appContext.IdleState);
        }

        private void OnConstructorExitRequested()
        {
            _appContext.AppStateMachine.ChangeState(_appContext.IdleState);
        }

        private void OnConstructorModeRequested()
        {
            _appContext.AppStateMachine.ChangeState(_appContext.ConstructorState);
        }
    }
}