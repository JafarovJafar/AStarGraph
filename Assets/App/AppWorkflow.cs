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


            _appContext.AppStateMachine.ChangeState(_appContext.BootState);
        }

        public void Stop()
        {

        }

        private void OnBootFinished()
        {
            _appContext.AppStateMachine.ChangeState(_appContext.WaitingUserActionState);
        }

        private void OnSearchModeRequested()
        {
            _appContext.AppStateMachine.ChangeState(_appContext.SearchingPathState);
        }

        private void OnConstructorModeRequested()
        {
            _appContext.AppStateMachine.ChangeState(_appContext.ConstructorState);
        }
    }
}