using Shafir.FSM;

namespace Shafir.App
{
    /// <summary>
    /// Инициализация приложения
    /// </summary>
    public class BootState : IState
    {
        private AppContext _appContext;

        public BootState(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Enter()
        {
            _appContext.AppStateMachine.ChangeState(_appContext.WaitingUserActionState);
        }

        public void Exit()
        {

        }
    }
}